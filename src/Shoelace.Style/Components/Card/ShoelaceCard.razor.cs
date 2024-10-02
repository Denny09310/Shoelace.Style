using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Cards can be used to group related subjects in a container.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/card"/>
/// </remarks>
public partial class ShoelaceCard : ShoelaceComponentBase
{
    /// <summary>
    /// The content of the card.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}