using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Represents the configuration options for actions placed in the drawer's header.
/// </summary>
public class DrawerHeaderActionOptions(string icon)
{
    /// <summary>
    /// Gets or sets the CSS class for the header action element.
    /// </summary>
    /// <remarks>
    /// This can be used to style the header action element.
    /// </remarks>
    public string? Class { get; set; }

    /// <summary>
    /// Gets or sets the name of the header action.
    /// </summary>
    /// <remarks>
    /// This value is required and typically used as a label or identifier for the action.
    /// </remarks>
    public string Icon { get; set; } = icon;

    /// <summary>
    /// Gets or sets the inline style for the header action element.
    /// </summary>
    /// <remarks>
    /// This can be used to apply custom inline CSS styling to the header action element.
    /// </remarks>
    public string? Style { get; set; }
}

/// <summary>
/// Represents options for configuring a drawer component.
/// </summary>
public class DrawerOptions
{
    /// <summary>
    /// Gets the default drawer options with standard configurations.
    /// </summary>
    public static readonly DrawerOptions Default = new();

    /// <summary>
    /// Gets or sets the collection of header action options that can be displayed in the drawer's header.
    /// </summary>
    public IEnumerable<DrawerHeaderActionOptions> HeaderActions { get; set; } = [];

    /// <summary>
    /// Gets or sets the label that identifies the drawer content.
    /// </summary>
    /// <remarks>
    /// This label can be used to provide a title for accessibility purposes.
    /// </remarks>
    public string Label { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether the drawer should hide its header.
    /// </summary>
    /// <value>
    /// <c>true</c> if the header should be hidden; otherwise, <c>false</c>.
    /// </value>
    public bool NoHeader { get; set; }

    /// <summary>
    /// Gets or sets the placement of the drawer (e.g., top, bottom, left, right).
    /// </summary>
    /// <remarks>
    /// The drawer's placement determines where it will appear on the screen. Default is typically left.
    /// </remarks>
    public string? Placement { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered inside the drawer.
    /// </summary>
    /// <remarks>
    /// Use this to define the content that will be displayed within the drawer component.
    /// </remarks>
    public RenderFragment? RenderFragment { get; set; }
}