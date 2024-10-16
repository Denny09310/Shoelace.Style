using Microsoft.AspNetCore.Components;
using Shoelace.Style.Events;

namespace Shoelace.Style.Components;

/// <summary>
/// Menus provide a list of options for the user to choose from.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/menu"/>
/// </remarks>
public partial class ShoelaceMenu : ShoelaceComponentBase
{
    /// <summary>
    /// The menu’s content, including menu items, menu labels, and dividers.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Events

    /// <summary>
    /// Emitted when a menu item is selected.
    /// </summary>
    [Parameter]
    public EventCallback<SelectEventArgs> OnSelect { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnSelect event.
    /// </summary>
    protected virtual Task SelectHandlerAsync(SelectEventArgs item) => OnSelect.InvokeAsync(item);
}