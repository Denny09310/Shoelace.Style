using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// Options define the selectable items within various form controls such as select.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/option"/>
/// </remarks>
/// <typeparam name="T">The type of the <see cref="ShoelaceOption{T}"/> value</typeparam>
public partial class ShoelaceOption<T> : ShoelaceComponentBase
{
    /// <summary>
    /// The option content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Draws the option in a disabled state, preventing selection.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The option’s value. When selected, the containing form control will receive this value.
    /// The value must be unique from other options in the same group.
    /// Values may not contain spaces, as spaces are used as delimiters when listing multiple values.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public T Value { get; set; } = default!;

    #endregion Properties

    #region Instance Methods

    /// <summary>
    /// Returns a plain text label based on the option’s content.
    /// </summary>
    /// <returns>The label string value</returns>
    public ValueTask<string> GetTextLabelAsync() => Element.InvokeAsync<string>("getTextLabel");

    #endregion Instance Methods
}