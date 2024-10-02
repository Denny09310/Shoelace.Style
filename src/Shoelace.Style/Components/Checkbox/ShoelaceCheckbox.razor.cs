using Microsoft.AspNetCore.Components;
using Shoelace.Style.Events;

namespace Shoelace.Style.Components;

/// <summary>
/// Cards can be used to group related subjects in a container.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/card"/>
/// </remarks>
public partial class ShoelaceCheckbox : ShoelaceInputBase<bool>
{
    /// <summary>
    /// Emitted when the attribute checked change.
    /// </summary>
    [Parameter]
    public EventCallback<bool> CheckedChanged { get; set; }

    #region Properties

    /// <summary>
    /// Draws the checkbox in a checked state.
    /// </summary>
    [Parameter]
    public bool Checked { get; set; }

    /// <summary>
    /// The default value of the form control. Primarily used for resetting the form control.
    /// </summary>
    [Parameter]
    public bool DefaultChecked { get; set; }

    /// <summary>
    /// Draws the checkbox in an indeterminate state.
    /// This is usually applied to checkboxes that represents a “select all/none”
    /// behavior when associated checkboxes have a mix of checked and unchecked states.
    /// </summary>
    [Parameter]
    public bool Indeterminate { get; set; }

    #endregion Properties

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener<ShoelaceChangeEventArgs<string>, bool>(Immediate ? "sl-input" : "sl-change", CheckedChanged, (e) => e.Target.Checked);
        }
    }
}