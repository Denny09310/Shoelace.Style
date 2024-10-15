using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

/// <summary>
/// Color pickers allow the user to select a color.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/color-picker"/>
/// </remarks>
public partial class ShoelaceColorPicker : ShoelaceInputBase<string?>, IFocusable
{
    #region Properties

    /// <summary>
    /// The format to use. If opacity is enabled,
    /// these will translate to HEXA, RGBA, HSLA, and HSVA respectively.
    /// The color picker will accept user input in any format (including CSS color names)
    /// and convert it to the desired format.
    /// </summary>
    [Parameter]
    public string? Format { get; set; }

    /// <summary>
    /// Enable this option to prevent the tooltip from being clipped
    /// when the component is placed inside a container with overflow: auto|hidden|scroll.
    /// Hoisting uses a fixed positioning strategy that works in many, but not all, scenarios.
    /// </summary>
    [Parameter]
    public bool Hoist { get; set; }

    /// <summary>
    /// Renders the color picker inline rather than in a dropdown.
    /// </summary>
    [Parameter]
    public bool Inline { get; set; }

    /// <summary>
    /// Removes the button that lets users toggle between format.
    /// </summary>
    [Parameter]
    public bool NoFormatToggle { get; set; }

    /// <summary>
    /// Shows the opacity slider.
    /// Enabling this will cause the formatted value to be HEXA, RGBA, or HSLA.
    /// </summary>
    [Parameter]
    public bool Opacity { get; set; }

    /// <summary>
    /// One or more predefined color swatches to display as presets in the color picker.
    /// Can include any format the color picker can parse,
    /// including HEX(A), RGB(A), HSL(A), HSV(A), and CSS color names.
    /// </summary>
    [Parameter]
    public string[] Swatches { get; set; } = [];

    /// <summary>
    /// By default, values are lowercase. With this attribute,
    /// values will be uppercase instead.
    /// </summary>
    [Parameter]
    public bool Uppercase { get; set; }

    #endregion Properties

    #region Events

    /// <inheritdoc />
    public EventCallback OnBlur { get; set; }

    /// <inheritdoc />
    public EventCallback OnFocus { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnBluer event.
    /// </summary>
    protected virtual async Task BlurHandlerAsync() => await OnBlur.InvokeAsync();

    /// <summary>
    /// Handler for the OnFocus event.
    /// </summary>
    protected virtual async Task FocusHandlerAsync() => await OnFocus.InvokeAsync();

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Element.SetPropertyAsync("swatches", string.Join(';', Swatches));
        }
    }

    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = value;
        validationErrorMessage = null;
        return true;
    }

    #region Instance Methods

    /// <inheritdoc />
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <inheritdoc />
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus", options);

    #endregion Instance Methods
}