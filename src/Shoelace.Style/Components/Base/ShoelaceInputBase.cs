using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using System.Linq.Expressions;

namespace Shoelace.Style.Components;

public abstract class ShoelaceInputBase<TValue> : ShoelaceComponentBase
{
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    #region Properties

    [Parameter]
    public TValue? DefaultValue { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string? Form { get; set; }

    [Parameter]
    public string? HelpText { get; set; }

    [Parameter]
    public bool Immediate { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public bool Required { get; set; }

    [Parameter]
    public string? Size { get; set; }

    [Parameter]
    public TValue? Value { get; set; }

    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    #endregion Properties

    #region Events

    [Parameter]
    public EventCallback<ShoelaceChangeEventArgs<TValue>> OnChange { get; set; }

    [Parameter]
    public EventCallback<ShoelaceChangeEventArgs<TValue>> OnInput { get; set; }

    [Parameter]
    public EventCallback OnInvalid { get; set; }

    #endregion Events

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-change", OnChange);
            await AddEventListener("sl-input", OnInput);
            await AddEventListener("sl-invalid", OnInvalid);

            await AddEventListener<ShoelaceChangeEventArgs<TValue>, TValue>(Immediate ? "sl-input" : "sl-change", ValueChanged, (e) => e.Target.Value);
        }
    }

    #region Instance Methods

    public ValueTask CheckValidityAsync() => Element.InvokeVoidAsync("checkValidity");

    public ValueTask GetFormAsync() => Element.InvokeVoidAsync("getForm");

    public ValueTask ReportValidityAsync() => Element.InvokeVoidAsync("reportValidity");

    public ValueTask SetCustomValidityAsync(string message) => Element.InvokeVoidAsync("setCustomValidity", message);

    #endregion Instance Methods
}