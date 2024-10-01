using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

public partial class ShoelaceAlert : ShoelacePresentableBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    [Parameter]
    public bool Closable { get; set; }

    [Parameter]
    public string? Countdown { get; set; }

    [Parameter]
    public double? Duration { get; set; }

    [Parameter]
    public string? Variant { get; set; }

    #endregion Properties

    #region Instance Methods

    public ValueTask ToastAsync() => Element.InvokeVoidAsync("toast");

    #endregion Instance Methods
}