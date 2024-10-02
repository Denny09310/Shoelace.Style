using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Button groups can be used to group related buttons into sections.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/button-group"/>
/// </remarks>
public partial class ShoelaceButtonGroup : ShoelaceComponentBase
{
    /// <summary>
    /// The content of the button group.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// The label to use for the breadcrumb control.
    /// This will not be shown on the screen but it will be announced by screen readers
    /// and other assistive devices to provide more context for users.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    #endregion Properties
}