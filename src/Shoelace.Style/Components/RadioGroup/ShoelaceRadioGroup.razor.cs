using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Radio groups are used to group multiple radios or radio buttons so they function as a single form control.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/radio-group"/>
/// </remarks>
/// <typeparam name="T">The type of the radio group value</typeparam>
public partial class ShoelaceRadioGroup<T> : ShoelaceInputBase<T>
{
    /// <summary>
    /// The default slot where <see cref="ShoelaceRadio{T}"/> 
    /// or <see cref="ShoelaceRadioButton{T}"/> elements are placed.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
