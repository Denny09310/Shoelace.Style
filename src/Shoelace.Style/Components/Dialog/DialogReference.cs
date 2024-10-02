using Microsoft.AspNetCore.Components;
using Shoelace.Style.Services;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

/// <summary>
/// An instance of a sl-dialog.
/// </summary>
/// <seealso cref="IDialogReference" />
public interface IDialogReference
{
    /// <summary>
    /// The dialog linked to this reference.
    /// </summary>
    object? Dialog { get; }

    /// <summary>
    /// The unique ID of this dialog.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// A task completion source that tracks the rendering completion state of the dialog.
    /// </summary>
    TaskCompletionSource<bool> RenderCompleteTaskCompletionSource { get; }

    /// <summary>
    /// The content within this dialog.
    /// </summary>
    RenderFragment? RenderFragment { get; set; }

    /// <summary>
    /// The result of closing the dialog.
    /// </summary>
    Task<DialogResult?> Result { get; }

    /// <summary>
    /// Hides the dialog.
    /// </summary>
    void Close();

    /// <summary>
    /// Hides the dialog and returns a result.
    /// </summary>
    /// <param name="result">The result of closing the dialog.</param>
    void Close(DialogResult? result);

    /// <summary>
    /// Notifies that this dialog has been dismissed.
    /// </summary>
    /// <param name="result">The result of closing the dialog.</param>
    /// <returns>Returns <c>true</c> if the result was set successfully.</returns>
    bool Dismiss(DialogResult? result);

    /// <summary>
    /// Gets the result of closing the dialog.
    /// </summary>
    /// <typeparam name="T">The type of value to return.</typeparam>
    /// <returns>The results of closing the dialog.</returns>
    Task<T?> GetReturnValueAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>();

    /// <summary>
    /// Replaces the dialog with the specified reference.
    /// </summary>
    /// <param name="inst">The new dialog to use.</param>
    void InjectDialog(object inst);

    /// <summary>
    /// Replaces the dialog content.
    /// </summary>
    /// <param name="rf">The new content to use.</param>
    void InjectRenderFragment(RenderFragment rf);
}

/// <summary>
/// A reference to a dialog instance, used to interact with and control the dialog.
/// </summary>
/// <param name="instanceId">The unique identifier for the dialog instance.</param>
/// <param name="service">The dialog service managing this dialog instance.</param>
public class DialogReference(Guid instanceId, IDialogService service) : IDialogReference
{
    private readonly TaskCompletionSource<DialogResult?> _result = new();
    private readonly IDialogService _service = service;

    /// <inheritdoc />
    public object? Dialog { get; private set; }

    /// <inheritdoc />
    public Guid Id { get; } = instanceId;

    /// <inheritdoc />
    public TaskCompletionSource<bool> RenderCompleteTaskCompletionSource { get; } = new();

    /// <inheritdoc />
    public RenderFragment? RenderFragment { get; set; }

    /// <inheritdoc />
    public Task<DialogResult?> Result => _result.Task;

    /// <inheritdoc />
    public void Close()
    {
        _service.Close(this);
    }

    /// <inheritdoc />
    public void Close(DialogResult? result)
    {
        _service.Close(this, result);
    }

    /// <inheritdoc />
    public virtual bool Dismiss(DialogResult? result)
    {
        return _result.TrySetResult(result);
    }

    /// <inheritdoc />
    public async Task<T?> GetReturnValueAsync<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] T>()
    {
        var result = await Result;
        try
        {
            return (T?)result?.Data;
        }
        catch (InvalidCastException)
        {
            Debug.WriteLine($"Could not cast return value to {typeof(T)}, returning default.");
            return default;
        }
    }

    /// <inheritdoc />
    public void InjectDialog(object inst)
    {
        Dialog = inst;
    }

    /// <inheritdoc />
    public void InjectRenderFragment(RenderFragment rf)
    {
        RenderFragment = rf;
    }
}