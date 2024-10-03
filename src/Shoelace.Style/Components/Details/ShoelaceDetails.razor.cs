using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Details show a brief summary and expand to show additional content.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/details"/>
/// </remarks>
public partial class ShoelaceDetails : ShoelacePresentableBase
{
    /// <summary>
    /// The details’ main content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Disables the details so it can’t be toggled.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The summary to show in the header. If you need to display HTML, use the summary slot instead.
    /// </summary>
    [Parameter]
    public string? Summary { get; set; }

    #endregion Properties
}