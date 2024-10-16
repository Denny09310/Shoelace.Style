using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Icons are symbols that can be used to represent various options within an application.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/icon"/>
/// </remarks>
public partial class ShoelaceIcon : ShoelaceComponentBase
{
    #region Properties

    /// <summary>
    /// An alternate description to use for assistive devices.
    /// If omitted, the icon will be considered presentational and ignored by assistive devices.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// The name of a registered custom icon library.
    /// </summary>
    [Parameter]
    public string? Library { get; set; }

    /// <summary>
    /// The name of the icon to draw. Available names depend on the icon library being used.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public string Name { get; set; } = default!;

    /// <summary>
    /// An external URL of an SVG file. Be sure you trust the content you are including,
    /// as it will be executed as code and can result in XSS attacks.
    /// </summary>
    [Parameter]
    public string? Src { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the icon has loaded. When using spriteSheet: true this will not emit.
    /// </summary>
    [Parameter]
    public EventCallback OnError { get; set; }

    /// <summary>
    /// Emitted when the icon fails to load due to an error. When using spriteSheet: true this will not emit.
    /// </summary>
    [Parameter]
    public EventCallback OnLoad { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnError event
    /// </summary>
    /// <returns></returns>
    protected virtual Task ErrorHandlerAsync() => OnError.InvokeAsync();

    /// <summary>
    /// Handler for the OnLoad event
    /// </summary>
    /// <returns></returns>
    protected virtual Task LoadHandlerAsync() => OnLoad.InvokeAsync();
}