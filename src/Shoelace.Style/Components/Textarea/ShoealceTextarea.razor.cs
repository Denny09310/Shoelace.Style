using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Textareas collect data from the user and allow multiple lines of text.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/textarea"/>
/// </remarks>
public partial class ShoealceTextarea : ShoelaceInput
{
    #region Properties

    /// <summary>
    /// The number of rows to display by default.
    /// </summary>
    [Parameter]
    public int Rows { get; set; }

    /// <summary>
    /// Controls how the textarea can be resized.
    /// </summary>
    /// <remarks>
    /// Posiible values are	'none' | 'vertical' | 'auto'
    /// </remarks>
    [Parameter]
    public string? Resize { get; set; }

    #endregion
}
