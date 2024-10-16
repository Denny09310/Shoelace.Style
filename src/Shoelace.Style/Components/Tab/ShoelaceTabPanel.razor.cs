using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// Tab panels are used inside <see cref="ShoelaceTabGroup"/> to display tabbed content.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/tab-panel"/>
/// </remarks>
public partial class ShoelaceTabPanel : ShoelaceComponentBase
{
    /// <summary>
    /// The tab panel’s content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// The parent <see cref="ShoelaceTabGroup"/>.
    /// </summary>
    [CascadingParameter]
    public ShoelaceTabGroup Tabs { get; set; } = default!;

    #region Properties

    /// <summary>
    /// When true, the tab panel will be shown.
    /// </summary>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// The tab panel’s name.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public string Name { get; set; } = default!;

    #endregion Properties

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Tabs.RegisterPanel(this);
    }
}