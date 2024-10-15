using Microsoft.AspNetCore.Components;
using Shoelace.Style.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

/// <summary>
/// Radio groups are used to group multiple radios or radio buttons so they function as a single form control.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/radio-group"/>
/// </remarks>
/// <typeparam name="TValue">The type of the radio group value</typeparam>

[CascadingTypeParameter(nameof(TValue))]
public partial class ShoelaceRadioGroup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : ShoelaceInputBase<TValue>
{
    /// <summary>
    /// The default slot where <see cref="ShoelaceRadio{T}"/>
    /// or <see cref="ShoelaceRadioButton{T}"/> elements are placed.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);
}