using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using System.Collections.Concurrent;

namespace Shoelace.Style.Components;

/// <summary>
/// Tab groups organize content into a container that shows one section at a time.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/tab-group"/>
/// </remarks>
public partial class ShoelaceTabGroup : ShoelaceComponentBase
{
    private const string ScriptModule = "./_content/Shoelace.Style/scripts/shoelace-tab-group-interop.js";

    private readonly Lazy<ValueTask<IJSObjectReference>> _module;
    private readonly ConcurrentDictionary<string, TabRegistration> _tabs = [];

    public ShoelaceTabGroup()
    {
        _module = new(() => JSRuntime.InvokeAsync<IJSObjectReference>("import", ScriptModule));
    }

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
    /// Registers a tab panel to be associated with its corresponding tab.
    /// </summary>
    /// <param name="panel">The <see cref="ShoelaceTabPanel"/> instance to register in the tab group.</param>
    /// <exception cref="ArgumentException">Thrown when no tab is found with the same name as the panel being registered.</exception>
    /// <remarks>
    /// This method should be called when a new <see cref="ShoelaceTabPanel"/> is initialized to associate it with an already registered tab.
    /// </remarks>
    public void RegisterPanel(ShoelaceTabPanel panel)
    {
        if (!_tabs.TryGetValue(panel.Name, out var registration))
        {
            throw new ArgumentException($"No tab registered with panel '${panel.Name}'");
        }

        _tabs[panel.Name] = registration with { Panel = panel };
    }

    /// <summary>
    /// Registers a tab to be associated with its corresponding panel.
    /// </summary>
    /// <param name="tab">The <see cref="ShoelaceTab"/> instance to register in the tab group.</param>
    /// <exception cref="ArgumentException">Thrown when a tab is already registered with the specified panel.</exception>
    /// <remarks>
    /// This method is called when a new <see cref="ShoelaceTab"/> is initialized to create an association between the tab and its corresponding panel.
    /// </remarks>
    public void RegisterTab(ShoelaceTab tab)
    {
        if (!_tabs.TryAdd(tab.Panel, new(tab, null)))
        {
            throw new ArgumentException($"Can't register tab with panel '{tab.Panel}'.");
        }
    }

    /// <summary>
    /// Unregisters a tab and its associated panel from the tab group asynchronously.
    /// </summary>
    /// <param name="name">The name of the panel to unregister.</param>
    /// <returns>A task that represents the asynchronous operation of removing both the tab and its panel.</returns>
    /// <exception cref="ArgumentException">Thrown when no tab is found with the specified panel name.</exception>
    public async Task UnregisterTabAsync(string name)
    {
        if (!_tabs.TryRemove(name, out var registration))
        {
            throw new ArgumentException($"No tab registered with panel '{name}'");
        }

        var (tab, panel) = registration;

        if (panel == null)
        {
            throw new ArgumentException($"No panel registered with tab '${tab.Panel}'");
        }

        var module = await _module.Value;
        await module.InvokeVoidAsync("unregister", Element, tab.Element, panel.Element);
    }

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
    public ValueTask ShowAsync(ElementReference panel) => Element.InvokeVoidAsync("show", panel);

    #endregion Instance Methods

    /// <summary>
    /// A record to hold both the tab and panel registration with an index.
    /// </summary>
    private sealed record TabRegistration(ShoelaceTab Tab, ShoelaceTabPanel? Panel);
}