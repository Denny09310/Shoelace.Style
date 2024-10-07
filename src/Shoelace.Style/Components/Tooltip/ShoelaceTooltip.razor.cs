using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Tooltips display additional information based on a specific action.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/tooltip"/>
/// </remarks>
public partial class ShoelaceTooltip : ShoelacePresentableBase
{

    /// <summary>
    /// The tooltip’s target element. Avoid slotting in more than one element, as subsequent ones will be ignored.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// The tooltip’s content. If you need to display HTML, use the content slot instead.
    /// </summary>
    [Parameter]
    public string? Content { get; set; }

    /// <summary>
    /// Disables the tooltip so it won’t show when triggered.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The distance in pixels from which to offset the tooltip away from its target.
    /// </summary>
    [Parameter]
    public int Distance { get; set; }

    /// <summary>
    /// Enable this option to prevent the tooltip from being clipped
    /// when the component is placed inside a container with overflow: auto|hidden|scroll.
    /// Hoisting uses a fixed positioning strategy that works in many, but not all, scenarios.
    /// </summary>
    /// <remarks>
    /// Possible values are 'top' | 'top-start' | 'top-end' | 'right' | 'right-start' | 'right-end' | 'bottom' | 'bottom-start' | 'bottom-end' | 'left' | 'left-start' | 'left-end'
    /// </remarks>
    [Parameter]
    public bool Hoist { get; set; }

    /// <summary>
    /// The preferred placement of the tooltip. 
    /// Note that the actual placement may vary as needed to keep the tooltip inside of the viewport.
    /// </summary>
    [Parameter]
    public string? Placement { get; set; }

    /// <summary>
    /// The distance in pixels from which to offset the tooltip along its target.
    /// </summary>
    [Parameter]
    public int Skidding { get; set; }

    /// <summary>
    /// Controls how the tooltip is activated.
    /// Multiple options can be passed by separating them with a space.
    /// When manual is used, the tooltip must be activated programmatically.
    /// </summary>
    /// <remarks>
    /// Possible values are 'click' | 'hover' | 'focus' | 'manual'. 
    /// </remarks>
    [Parameter]
    public string? Trigger { get; set; }

    #endregion Properties
}
