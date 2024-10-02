using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Breadcrumb Items are used inside <see cref="ShoelaceBreadcrumb"/> to represent different links.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/breadcrumb-item"/>
/// </remarks>
public partial class ShoelaceBreadcrumbItem : ShoelaceComponentBase
{
    /// <summary>
    /// The content of the breadcrumb item.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Optional URL to direct the user to when the breadcrumb item is activated. 
    /// </summary>
    /// <remarks>
    /// When set, a link will be rendered internally. 
    /// When unset, a button will be rendered instead.
    /// </remarks>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// The rel attribute to use on the link.
    /// </summary>
    /// <remarks>
    /// Only used when href is set.
    /// </remarks>
    [Parameter]
    public string? Rel { get; set; }

    /// <summary>
    /// Tells the browser where to open the link.
    /// </summary>
    /// <remarks>
    /// Only used when href is set.
    /// </remarks>
    [Parameter]
    public string? Target { get; set; }

    #endregion Properties
}