using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Radios buttons allow the user to select a single option from a group using a button-like control.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/radio-button"/>
/// </remarks>
/// <typeparam name="T">The type of the radio buttton value</typeparam>
public partial class ShoelaceRadioButton<T> : ShoelaceRadio<T>
{
    #region Properties

    /// <summary>
    /// Draws a pill-style radio button with rounded edges.
    /// </summary>
    [Parameter]
    public bool Pill { get; set; }

    #endregion Properties
}