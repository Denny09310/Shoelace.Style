using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

/// <summary>
/// Ratings give users a way to quickly view and provide feedback.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/rating"/>
/// </remarks>
public partial class ShoelaceRange : ShoelaceInputBase<double>, IFocusable
{
    #region Properties

    /// <summary>
    /// The highest rating to show.
    /// </summary>
    [Parameter]
    public double? Max { get; set; }

    /// <summary>
    /// The precision at which the rating will increase and decrease.
    /// For example, to allow half-star ratings, set this attribute to 0.5.
    /// </summary>
    [Parameter]
    public double? Precision { get; set; }

    /// <summary>
    /// Makes the rating readonly.
    /// </summary>
    [Parameter]
    public bool Readonly { get; set; }

    #endregion Properties

    #region Events

    /// <inheritdoc/>
    public EventCallback OnBlur { get; set; }

    /// <inheritdoc/>
    public EventCallback OnFocus { get; set; }

    /// <summary>
    /// Emitted when the user hovers over a value. 
    /// The phase property indicates when hovering starts, moves to a new value, or ends. 
    /// The value property tells what the rating’s value would be if the user were to commit to the hovered value.
    /// </summary>
    [Parameter]
    public EventCallback<ShoelaceHoverEvent> OnHover { get; set; }

    #endregion Events

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-hover", OnHover);
        }
    }

    #region Instance Properties

    /// <inheritdoc/>
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <inheritdoc/>
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus", options);

    #endregion Instance Properties
}