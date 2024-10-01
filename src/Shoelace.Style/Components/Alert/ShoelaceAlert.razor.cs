using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

public partial class ShoelaceAlert : ShoelacePresentableBase
{
    private const string InteropScriptPath = "./_content/Shoelace.Style/scripts/shoelace-alert-interop.js";

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

    #region Static Methods

    public static async Task ToastAsync(IJSRuntime js, string message, string? variant = null, string? icon = null, double? duration = null)
    {
        var module = await js.InvokeAsync<IJSObjectReference>("import", InteropScriptPath);
        await module.InvokeVoidAsync("toast", message, new ToastOptions { Variant = variant, Duration = duration, Icon = icon });
        await module.DisposeAsync();
    }

    public static async Task ToastAsync(IJSRuntime js, ToastOptions? options = null)
    {
        var module = await js.InvokeAsync<IJSObjectReference>("import", InteropScriptPath);
        await module.InvokeVoidAsync("toast", options);
        await module.DisposeAsync();
    }

    #endregion Static Methods
}