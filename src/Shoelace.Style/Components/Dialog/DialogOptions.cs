namespace Shoelace.Style.Components;

/// <summary>
/// Represents options for configuring a dialog component.
/// </summary>
public class DialogOptions
{
    /// <summary>
    /// Provides the default instance of <see cref="DialogOptions"/> with default settings.
    /// </summary>
    public static readonly DialogOptions Default = new();

    /// <summary>
    /// Gets or sets the CSS class to be applied to the dialog.
    /// </summary>
    public string? Class { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the dialog.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the dialog should render without a header.
    /// </summary>
    /// <remarks>If set to <c>true</c>, the dialog will not display a header.</remarks>
    public bool NoHeader { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the dialog is open.
    /// </summary>
    /// <remarks>When set to <c>true</c>, the dialog will be open and visible.</remarks>
    public bool Open { get; set; }

    /// <summary>
    /// Gets or sets the inline style for the dialog.
    /// </summary>
    /// <remarks>This can be used to directly set CSS styles on the dialog element.</remarks>
    public string? Style { get; set; }
}
