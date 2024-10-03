using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

/// <summary>
/// Icons buttons are simple, icon-only buttons that can be used for actions and in toolbars.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/icon-button"/>
/// </remarks>
public partial class ShoelaceIconButton : ShoelaceComponentBase, IFocusable
{
    #region Properties

    /// <summary>
    /// Disables the button.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Tells the browser to download the linked file as this filename. Only used when href is set.
    /// </summary>
    [Parameter]
    public string? Download { get; set; }

    /// <summary>
    /// When set, the underlying button will be rendered as an &lt;a&gt;
    /// with this href instead of a &lt;button&gt;.
    /// </summary>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// A description that gets read by assistive devices.
    /// For optimal accessibility, you should always include a label that describes what the icon button does.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// The name of a registered custom icon library.
    /// </summary>
    [Parameter]
    public string? Library { get; set; }

    /// <summary>
    /// The name of the icon to draw. Available names depend on the icon library being used.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public string Name { get; set; } = default!;

    /// <summary>
    /// An external URL of an SVG file. Be sure you trust the content you are including,
    /// as it will be executed as code and can result in XSS attacks.
    /// </summary>
    [Parameter]
    public string? Src { get; set; }

    /// <summary>
    /// Tells the browser where to open the link. Only used when href is set.
    /// </summary>
    /// <remarks>
    /// Possible values are '_blank' | '_parent' | '_self' | '_top'
    /// </remarks>
    [Parameter]
    public string? Target { get; set; }

    #endregion Properties

    #region Events

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnBlur { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnFocus { get; set; }

    #endregion Events

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-blur", OnBlur);
            await AddEventListener("sl-focus", OnFocus);
        }
    }

    #region Instance Methods

    /// <inheritdoc />
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <summary>
    /// Simulates a click on the icon button.
    /// </summary>
    public ValueTask ClickAsync() => Element.InvokeVoidAsync("click");

    /// <inheritdoc />
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus");

    #endregion Instance Methods
}