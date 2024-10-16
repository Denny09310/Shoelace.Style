using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;

namespace Shoelace.Style.Components;

/// <summary>
/// Tab groups organize content into a container that shows one section at a time.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/tab-group"/>
/// </remarks>
public partial class ShoelaceTabGroup : ShoelaceComponentBase
{
    /// <summary>
    /// Used for grouping tab panels in the tab group.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// When set to auto, navigating tabs with the arrow keys will instantly show the corresponding tab panel.
    /// When set to manual, the tab will receive focus but will not show until the user presses spacebar or enter.
    /// </summary>
    /// <remarks>
    /// Possible values are 'auto' | 'manual'
    /// </remarks>
    [Parameter]
    public string? Activation { get; set; }

    /// <summary>
    /// Prevent scroll buttons from being hidden when inactive.
    /// </summary>
    [Parameter]
    public bool FixedScrollControls { get; set; }

    /// <summary>
    /// Disables the scroll arrows that appear when tabs overflow.
    /// </summary>
    [Parameter]
    public bool NoScrollControls { get; set; }

    /// <summary>
    /// The placement of the tabs.
    /// </summary>
    /// <remarks>
    /// Possible values are 'top' | 'bottom' | 'start' | 'end'
    /// </remarks>
    [Parameter]
    public string? Placement { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when a tab is shown.
    /// </summary>
    [Parameter]
    public EventCallback<TabHideEventArgs> OnTabHide { get; set; }

    /// <summary>
    /// Emitted when a tab is hidden.
    /// </summary>
    [Parameter]
    public EventCallback<TabShowEventArgs> OnTabShow { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the <see cref="OnTabHide"/> event.
    /// </summary>
    protected virtual Task TabHideHandlerAsync(TabHideEventArgs e) => OnTabHide.InvokeAsync(e);

    /// <summary>
    /// Handler for the <see cref="OnTabShow"/> event.
    /// </summary>
    protected virtual Task TabShowHandlerAsync(TabShowEventArgs e) => OnTabShow.InvokeAsync(e);

    #region Instance Methods

    /// <summary>
    /// Shows the specified tab panel.
    /// </summary>
    /// <param name="panel">The name of the panel to show</param>
    public ValueTask ShowAsync(string panel) => Element.InvokeVoidAsync("show", panel);

    #endregion
}