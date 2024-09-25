using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

public partial class ShoelaceButton : ShoelaceComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Draws the button with a caret. Used to indicate that the button
    /// triggers a dropdown menu or similar behavior.
    /// </summary>
    [Parameter]
    public bool Caret { get; set; }

    /// <summary>
    /// Draws a circular icon button. When this attribute is present,
    /// the button expects a single <c>&lt;sl-icon&gt;</c> in the default slot.
    /// </summary>
    [Parameter]
    public bool Circle { get; set; }

    /// <summary>
    /// Disables the button.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Specifies the filename for downloading the linked file.
    /// Only applicable when <c>Href</c> is set.
    /// </summary>
    [Parameter]
    public string? Download { get; set; }

    /// <summary>
    /// The “form owner” to associate the button with. If omitted,
    /// the closest containing form will be used instead. The value
    /// must be an ID of a form in the same document or shadow root as the button.
    /// </summary>
    [Parameter]
    public string? Form { get; set; }

    /// <summary>
    /// Overrides the form owner’s <c>form-action</c> attribute.
    /// </summary>
    [Parameter]
    public string? FormAction { get; set; }

    /// <summary>
    /// Overrides the form owner’s <c>form-enctype</c> attribute.
    /// </summary>
    [Parameter]
    public string? FormEncType { get; set; }

    /// <summary>
    /// Overrides the form owner’s <c>form-method</c> attribute.
    /// </summary>
    [Parameter]
    public string? FormMethod { get; set; }

    /// <summary>
    /// Overrides the form owner’s <c>form-no-validate</c> attribute.
    /// </summary>
    [Parameter]
    public bool FormNoValidate { get; set; }

    /// <summary>
    /// Overrides the form owner’s <c>form-target</c> attribute.
    /// </summary>
    [Parameter]
    public string? FormTarget { get; set; }

    /// <summary>
    /// When set, the button will be rendered as an <c>&lt;a&gt;</c>
    /// with the specified <c>Href</c> instead of a <c>&lt;button&gt;</c>.
    /// </summary>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// Draws the button in a loading state.
    /// </summary>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    /// The name of the button, submitted as a name/value pair with form data.
    /// This is only applicable when the button is the submitter and <c>Href</c> is not set.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Draws an outlined button.
    /// </summary>
    [Parameter]
    public bool Outline { get; set; }

    /// <summary>
    /// Draws a pill-style button with rounded edges.
    /// </summary>
    [Parameter]
    public bool Pill { get; set; }

    /// <summary>
    /// Sets the <c>rel</c> attribute for the underlying link when using <c>Href</c>.
    /// The default is <c>noreferrer noopener</c> to prevent security exploits.
    /// If using <c>Target</c> to point to a specific tab or window, you may need
    /// to adjust this value.
    /// </summary>
    [Parameter]
    public string? Rel { get; set; }

    /// <summary>
    /// The button’s size.
    /// </summary>
    [Parameter]
    public string? Size { get; set; }

    /// <summary>
    /// Specifies where to open the linked document when <c>Href</c> is set.
    /// </summary>
    [Parameter]
    public string? Target { get; set; }

    /// <summary>
    /// The button type. The default is <c>button</c>, unlike native <c>&lt;button&gt;</c>
    /// elements which default to <c>submit</c>. When set to <c>submit</c>,
    /// the button submits the surrounding form.
    /// </summary>
    [Parameter]
    public string? Type { get; set; }

    /// <summary>
    /// The button's value, submitted with the button's <c>Name</c> as part of
    /// the form data. This is ignored when <c>Href</c> is present.
    /// </summary>
    [Parameter]
    public string? Value { get; set; }

    /// <summary>
    /// The theme variant for the button.
    /// </summary>
    [Parameter]
    public string? Variant { get; set; }

    #endregion Properties

    #region Events

    [Parameter]
    public EventCallback OnBlur { get; set; }

    [Parameter]
    public EventCallback OnFocus { get; set; }

    [Parameter]
    public EventCallback OnInvalid { get; set; }

    #endregion Events

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-blur", OnBlur);
            await AddEventListener("sl-focus", OnFocus);
            await AddEventListener("sl-invalid", OnInvalid);
        }
    }
}