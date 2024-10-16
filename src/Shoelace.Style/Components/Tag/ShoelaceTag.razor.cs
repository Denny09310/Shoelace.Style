using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Tags are used as labels to organize things or to indicate a selection.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/tag"/>
/// </remarks>
public partial class ShoelaceTag : ShoelaceComponentBase
{
    /// <summary>
    /// The tag’s content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Draws a pill-style tag with rounded edges.
    /// </summary>
    [Parameter]
    public bool Pill { get; set; }

    /// <summary>
    /// Makes the tag removable and shows a remove button.
    /// </summary>
    [Parameter]
    public bool Removable { get; set; }

    /// <summary>
    /// The tag's size
    /// </summary>
    /// <remarks>
    /// Possible values are 'small' | 'medium' | 'large'
    /// </remarks>
    [Parameter]
    public string? Size { get; set; }

    /// <summary>
    /// The tag’s theme variant.
    /// </summary>
    /// <remarks>
    /// Possible values are 'primary' | 'success' | 'neutral' | 'warning' | 'danger' | 'text'
    /// </remarks>
    [Parameter]
    public string? Variant { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the remove button is activated.
    /// </summary>
    [Parameter]
    public EventCallback OnRemove { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnRemove event.
    /// </summary>
    protected virtual Task RemoveHandlerAsync() => OnRemove.InvokeAsync();
}