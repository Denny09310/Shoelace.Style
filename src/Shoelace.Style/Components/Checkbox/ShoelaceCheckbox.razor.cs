using Microsoft.AspNetCore.Components;
using Shoelace.Style.Events;
using Shoelace.Style.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

/// <summary>
/// Cards can be used to group related subjects in a container.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/card"/>
/// </remarks>
public partial class ShoelaceCheckbox : ShoelaceInputBase<bool>
{
    /// <inheritdoc/>
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(CheckboxChangeEventArgs))]
    public ShoelaceCheckbox()
    {
        Id = Identifier.NewId();
    }

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

    /// <summary>
    /// Handler for the <see cref="CheckedChanged"/> event.
    /// </summary>
    protected virtual async Task CheckedChangeHandlerAsync(CheckboxChangeEventArgs e)
    {
        Checked = e.Checked ?? false;
        await CheckedChanged.InvokeAsync(Checked);
    }

    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage) => throw new NotSupportedException($"This component does not parse string inputs. Bind to the '{nameof(CurrentValue)}' property, not '{nameof(CurrentValueAsString)}'.");
}