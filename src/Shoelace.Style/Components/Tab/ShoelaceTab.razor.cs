using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Tabs are used inside tab groups to represent and activate tab panels.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/tab"/>
/// </remarks>
public partial class ShoelaceTab : ShoelaceComponentBase
{
    /// <summary>
    /// The tab’s label.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Draws the tab in an active state.
    /// </summary>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Makes the tab closable and shows a close button.
    /// </summary>
    [Parameter]
    public bool Closeable { get; set; }

    /// <summary>
    /// Disables the tab and prevents selection.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The name of the tab panel this tab is associated with.
    /// The panel must be located in the same tab group.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public string Panel { get; set; } = default!;

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the tab is closable and the close button is activated.
    /// </summary>
    [Parameter]
    public EventCallback OnClose { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnClose event.
    /// </summary>
    protected virtual Task CloseHandlerAsync() => OnClose.InvokeAsync();
}