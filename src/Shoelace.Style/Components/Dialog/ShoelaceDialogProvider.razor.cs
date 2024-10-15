using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Shoelace.Style.Components;

/// <summary>
/// Provides dialog management for the application, allowing for the display and dismissal of dialogs.
/// </summary>
public partial class ShoelaceDialogProvider : ComponentBase, IDisposable
{
    private readonly List<IDialogReference> _dialogs = [];

    /// <summary>
    /// Dismisses all currently open dialogs.
    /// </summary>
    public void DismissAll()
    {
        foreach (var dialog in _dialogs)
        {
            DismissInstance(dialog, DialogResult.Cancel());
        }

        InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Disposes the resources used by the component.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dismisses a dialog instance by its unique identifier and returns the specified result.
    /// </summary>
    /// <param name="id">The unique identifier of the dialog to dismiss.</param>
    /// <param name="result">The result to return from the dismissed dialog.</param>
    internal void DismissInstance(string id, DialogResult result)
    {
        var reference = GetDialogReference(id);
        if (reference != null)
        {
            DismissInstance(reference, result);
        }
    }

    /// <summary>
    /// Disposes the resources used by the component, with an option to release managed resources.
    /// </summary>
    /// <param name="disposing">Whether to dispose managed resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            NavigationManager.LocationChanged -= LocationChanged;
            DialogService.DialogInstanceAddedAsync -= AddInstanceAsync;
            DialogService.OnDialogCloseRequested -= DismissInstance;
        }
    }

    /// <summary>
    /// Called after each render of the component. Marks dialogs as fully rendered.
    /// </summary>
    /// <param name="firstRender">Whether this is the first render of the component.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (!firstRender)
        {
            foreach (var dialogReference in _dialogs.Where(x => !x.Result.IsCompleted))
            {
                dialogReference.RenderCompleteTaskCompletionSource.TrySetResult(true);
            }
        }
    }

    /// <summary>
    /// Initializes the dialog provider, setting up event listeners for adding and dismissing dialogs.
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        DialogService.DialogInstanceAddedAsync += AddInstanceAsync;
        DialogService.OnDialogCloseRequested += DismissInstance;
        NavigationManager.LocationChanged += LocationChanged;
    }

    /// <summary>
    /// Adds a new dialog instance to be displayed.
    /// </summary>
    /// <param name="dialog">The dialog reference to add.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private Task AddInstanceAsync(IDialogReference dialog)
    {
        _dialogs.Add(dialog);
        return InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Dismisses a specific dialog instance and returns the specified result.
    /// </summary>
    /// <param name="dialog">The dialog to dismiss.</param>
    /// <param name="result">The result to return from the dismissed dialog.</param>
    private void DismissInstance(IDialogReference dialog, DialogResult? result)
    {
        if (!dialog.Dismiss(result)) return;

        _dialogs.Remove(dialog);
        InvokeAsync(StateHasChanged);
    }

    /// <summary>
    /// Retrieves a dialog reference by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the dialog.</param>
    /// <returns>The dialog reference, or <c>null</c> if not found.</returns>
    private IDialogReference? GetDialogReference(string id)
    {
        return _dialogs.Find(x => x.Id == id);
    }

    /// <summary>
    /// Handles navigation changes and dismisses all dialogs when the location changes.
    /// </summary>
    /// <param name="sender">The source of the location change event.</param>
    /// <param name="args">Event arguments for the location change.</param>
    private void LocationChanged(object? sender, LocationChangedEventArgs args)
    {
        DismissAll();
    }
}
