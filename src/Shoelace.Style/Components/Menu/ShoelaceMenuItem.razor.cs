using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// Menus provide a list of options for the user to choose from.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/menu"/>
/// </remarks>
public partial class ShoelaceMenuItem : ShoelaceComponentBase
{
    /// <summary>
    /// The menu’s content, including menu items, menu labels, and dividers.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Draws the checkbox in a checked state.
    /// </summary>
    [Parameter]
    public bool Checked { get; set; }

    /// <summary>
    /// Draws the menu item in a disabled state, preventing selection.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Draws the menu item in a loading state.
    /// </summary>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    /// The type of menu item to render. To use checked, this value must be set to checkbox.
    /// </summary>
    /// <remarks>
    /// Possible values are 'normal' | 'checkbox'
    /// </remarks>
    [Parameter]
    public string? Type { get; set; }

    /// <summary>
    /// A unique value to store in the menu item.
    /// This can be used as a way to identify menu items when selected.
    /// </summary>
    [Parameter]
    public string? Value { get; set; }

    #endregion Properties

    #region Instance Methods

    /// <summary>
    /// Returns a plain text label based on the option’s content.
    /// </summary>
    /// <returns>The label string value</returns>
    public ValueTask<string> GetTextLabelAsync() => Element.InvokeAsync<string>("getTextLabel");

    #endregion Instance Methods
}