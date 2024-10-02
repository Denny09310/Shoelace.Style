using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Copies text data to the clipboard when the user clicks the trigger.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/copy-button"/>
/// </remarks>
public partial class ShoelaceCopyButton : ShoelaceComponentBase
{
    /// <summary>
    /// The content of the copy button.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// A custom label to show in the tooltip.
    /// </summary>
    [Parameter]
    public string? CopyLabel { get; set; }

    /// <summary>
    /// Disables the copy button.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// A custom label to show in the tooltip when a copy error occurs.
    /// </summary>
    [Parameter]
    public string? ErrorLabel { get; set; }

    /// <summary>
    /// The length of time to show feedback before restoring the default trigger.
    /// </summary>
    [Parameter]
    public double? FeedbackDuration { get; set; }

    /// <summary>
    /// An id that references an element in the same document from which data will be copied.
    /// If both this and value are present, this value will take precedence.
    /// By default, the target element’s textContent will be copied.
    /// To copy an attribute, append the attribute name wrapped in square brackets,
    /// e.g. from="el[value]". To copy a property, append a dot and
    /// the property name, e.g. from="el.value".
    /// </summary>
    [Parameter]
    public string? Form { get; set; }

    /// <summary>
    /// Enable this option to prevent the tooltip from being clipped
    /// when the component is placed inside a container with overflow: auto|hidden|scroll.
    /// Hoisting uses a fixed positioning strategy that works in many, but not all, scenarios.
    /// </summary>
    [Parameter]
    public bool Hoist { get; set; }

    /// <summary>
    /// A custom label to show in the tooltip after copying.
    /// </summary>
    [Parameter]
    public string? SuccessLabel { get; set; }

    /// <summary>
    /// The preferred placement of the tooltip.
    /// </summary>
    /// <remarks>
    /// Valid values are 'top' | 'right' | 'bottom' | 'left'
    /// </remarks>
    [Parameter]
    public string? TooltipPlacement { get; set; }

    /// <summary>
    /// The text value to copy.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public string Value { get; set; } = default!;

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the data has been copied.
    /// </summary>
    [Parameter]
    public EventCallback OnCopy { get; set; }

    /// <summary>
    /// Emitted when the data could not be copied.
    /// </summary>
    [Parameter]
    public EventCallback OnError { get; set; }

    #endregion Events

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-copy", OnCopy);
            await AddEventListener("sl-error", OnError);
        }
    }
}