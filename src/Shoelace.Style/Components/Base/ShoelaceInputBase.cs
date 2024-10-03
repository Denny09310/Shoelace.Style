using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using System.Linq.Expressions;

namespace Shoelace.Style.Components;

/// <summary>
/// Base class for Shoelace input components, extending <see cref="ShoelaceComponentBase"/>.
/// It provides support for handling additional HTML attributes, CSS classes, styles,
/// and event listeners on the component.
/// </summary>
public abstract class ShoelaceInputBase<T> : ShoelaceComponentBase, IValidatable
{
    /// <summary>
    /// Emitted when the value of the element changes.
    /// </summary>
    [Parameter]
    public EventCallback<T> ValueChanged { get; set; }

    #region Properties

    /// <summary>
    /// The default value of the form control.
    /// </summary>
    /// <remarks>
    /// Primarily used for resetting the form control.
    /// </remarks>
    [Parameter]
    public T? DefaultValue { get; set; }

    /// <summary>
    /// Disables the input.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// By default, form controls are associated with the nearest containing &lt;form&gt; element. 
    /// This attribute allows you to place the form control outside of a form 
    /// and associate it with the form that has this id.
    /// </summary>
    /// <remarks>
    /// The form must be in the same document or shadow root for this to work.
    /// </remarks>
    [Parameter]
    public string? Form { get; set; }

    /// <summary>
    /// The input’s help text. If you need to display HTML, use the help-text slot instead.
    /// </summary>
    [Parameter]
    public string? HelpText { get; set; }

    /// <summary>
    /// Determines if the input should listen for the sl-change or sl-input event
    /// </summary>
    [Parameter]
    public bool Immediate { get; set; }

    /// <summary>
    /// The input’s label. If you need to display HTML, use the label slot instead.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// The name of the input, submitted as a name/value pair with form data.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Makes the input a required field.
    /// </summary>
    [Parameter]
    public bool Required { get; set; }

    /// <summary>
    /// The input’s size.
    /// </summary>
    /// <remarks>
    /// Possible values are 'small' | 'medium' | 'large'
    /// </remarks>
    [Parameter]
    public string? Size { get; set; }

    /// <summary>
    /// The current value of the input, submitted as a name/value pair with form data.
    /// </summary>
    [Parameter]
    public T? Value { get; set; }

    /// <inheritdoc />
    [Parameter]
    public Expression<Func<T>>? ValueExpression { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when an alteration to the control’s value is committed by the user.
    /// </summary>
    [Parameter]
    public EventCallback<ShoelaceChangeEventArgs<T>> OnChange { get; set; }

    /// <summary>
    /// Emitted when the control receives input.
    /// </summary>
    [Parameter]
    public EventCallback<ShoelaceChangeEventArgs<T>> OnInput { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnInvalid { get; set; }

    #endregion Events

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-change", OnChange);
            await AddEventListener("sl-input", OnInput);
            await AddEventListener("sl-invalid", OnInvalid);

            await AddEventListener<ShoelaceChangeEventArgs<T>, T>(Immediate ? "sl-input" : "sl-change", ValueChanged, (e) => e.Target.Value);
        }
    }

    #region Instance Methods


    /// <inheritdoc />
    public ValueTask CheckValidityAsync() => Element.InvokeVoidAsync("checkValidity");

    /// <summary>
    /// Gets the associated form, if one exists.
    /// </summary>
    public ValueTask GetFormAsync() => Element.InvokeVoidAsync("getForm");

    /// <inheritdoc />
    public ValueTask ReportValidityAsync() => Element.InvokeVoidAsync("reportValidity");

    /// <inheritdoc />
    public ValueTask SetCustomValidityAsync(string message) => Element.InvokeVoidAsync("setCustomValidity", message);

    #endregion Instance Methods
}