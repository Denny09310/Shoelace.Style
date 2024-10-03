using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Dividers are used to visually separate or group elements.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/divider"/>
/// </remarks>
public partial class ShoelaceDivider : ShoelaceComponentBase
{
    #region Properties

    /// <summary>
    /// Draws the divider in a vertical orientation.
    /// </summary>
    [Parameter]
    public bool Vertical { get; set; }

    #endregion Properties
}