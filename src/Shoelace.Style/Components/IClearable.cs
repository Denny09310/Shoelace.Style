using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

internal interface IClearable
{
    /// <summary>
    /// Adds a clear button when the input is not empty.
    /// </summary>
    public bool Clearable { get; set; }

    /// <summary>
    /// Emitted when the clear button is activated.
    /// </summary>
    public EventCallback OnClear { get; set; }
}
