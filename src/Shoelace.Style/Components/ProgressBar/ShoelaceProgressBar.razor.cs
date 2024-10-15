using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// A label to show inside the progress indicator.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/progress-bar"/>
/// </remarks>
public partial class ShoelaceProgressBar : ShoelaceComponentBase
{
    /// <summary>
    /// A label to show inside the progress indicator.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// When true, percentage is ignored, the label is hidden,
    /// and the progress bar is drawn in an indeterminate state.
    /// </summary>
    [Parameter]
    public bool Indeterminate { get; set; }

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