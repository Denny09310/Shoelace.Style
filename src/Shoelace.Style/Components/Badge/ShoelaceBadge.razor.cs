using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Badges are used to draw attention and display statuses or counts.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/badge"/>
/// </remarks>
public partial class ShoelaceBadge : ShoelaceComponentBase
{
    /// <summary>
    /// The content of the badge.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Draws a pill-style badge with rounded edges.
    /// </summary>
    [Parameter]
    public bool Pill { get; set; }

    /// <summary>
    /// Makes the badge pulsate to draw attention.
    /// </summary>
    [Parameter]
    public bool Pulse { get; set; }

    /// <summary>
    /// The badge’s theme variant.
    /// </summary>
    /// <remarks>
    /// Valid values are 'primary' | 'success' | 'neutral' | 'warning' | 'danger'
    /// </remarks>
    [Parameter]
    public string? Variant { get; set; }

    #endregion Properties
}