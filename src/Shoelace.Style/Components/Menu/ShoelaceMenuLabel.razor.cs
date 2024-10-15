using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Menu labels are used to describe a group of menu items.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/menu-label"/>
/// </remarks>
public partial class ShoelaceMenuLabel : ShoelaceComponentBase
{
    /// <summary>
    /// The menu label’s content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
