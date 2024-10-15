using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Progress rings are used to show the progress of a determinate operation in a circular fashion.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/progress-ring"/>
/// </remarks>
public partial class ShoelaceProgressRing : ShoelaceComponentBase
{
    /// <summary>
    /// A label to show inside the progress indicator.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// A custom label for assistive devices.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// The current progress as a percentage, 0 to 100.
    /// </summary>
    [Parameter]
    public double Value { get; set; } = default!;

    #endregion Properties
}
