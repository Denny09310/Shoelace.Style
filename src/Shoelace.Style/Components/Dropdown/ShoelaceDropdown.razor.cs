using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// Drawers slide in from a container to expose additional options and information.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/drawer"/>
/// </remarks>
public partial class ShoelaceDropdown : ShoelacePresentableBase
{
    /// <summary>
    /// The dropdown’s main content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Parameters

    /// <summary>
    /// Disables the dropdown so the panel will not open.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The distance in pixels from which to offset the panel away from its trigger.
    /// </summary>
    [Parameter]
    public string? Distance { get; set; }

    /// <summary>
    /// Enable this option to prevent the tooltip from being clipped
    /// when the component is placed inside a container with overflow: auto|hidden|scroll.
    /// Hoisting uses a fixed positioning strategy that works in many, but not all, scenarios.
    /// </summary>
    [Parameter]
    public bool Hoist { get; set; }

    /// <summary>
    /// The preferred placement of the dropdown panel. 
    /// Note that the actual placement may vary as needed to keep the panel inside of the viewport.
    /// </summary>
    [Parameter]
    public string? Placement { get; set; }

    /// <summary>
    /// The distance in pixels from which to offset the panel along its trigger.
    /// </summary>
    [Parameter]
    public string? Skidding { get; set; }

    /// <summary>
    /// By default, the dropdown is closed when an item is selected. 
    /// This attribute will keep it open instead. 
    /// Useful for dropdowns that allow for multiple interactions.
    /// </summary>
    [Parameter]
    public bool StayOpenOnSelect { get; set; }

    /// <summary>
    /// The dropdown will close when the user interacts outside of this element (e.g. clicking).
    /// Useful for composing other components that use a dropdown internally.
    /// </summary>
    [Parameter]
    public ElementReference? ContainingElement { get; set; }

    /// <summary>
    /// Syncs the popup width or height to that of the trigger element.
    /// </summary>
    [Parameter]
    public bool Sync { get; set; }

    #endregion Parameters

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender && ContainingElement != null)
        {
            await Element.SetPropertyAsync("containingElement", ContainingElement);
        }
    }

    #region Instance Methods

    /// <summary>
    /// Instructs the dropdown menu to reposition. 
    /// Useful when the position or size of the trigger changes when the menu is activated.
    /// </summary>
    public ValueTask RepositionAsync() => Element.InvokeVoidAsync("reposition");

    #endregion Instance Methods
}
