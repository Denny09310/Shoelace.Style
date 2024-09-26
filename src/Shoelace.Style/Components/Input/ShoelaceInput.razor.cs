using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

public partial class ShoelaceInput<TValue> : ShoelaceInputBase<TValue>
{
    #region Properties

    [Parameter]
    public bool AutoCapitalize { get; set; }

    [Parameter]
    public bool AutoCorrect { get; set; }

    [Parameter]
    public bool AutoFocus { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool Clearable { get; set; }

    [Parameter]
    public string? EnterKeyHint { get; set; }

    [Parameter]
    public bool Filled { get; set; }

    [Parameter]
    public string? InputMode { get; set; }

    [Parameter]
    public double? Max { get; set; }

    [Parameter]
    public int? MaxLength { get; set; }

    [Parameter]
    public double? Min { get; set; }

    [Parameter]
    public int? MinLength { get; set; }

    [Parameter]
    public bool NoSpinButtons { get; set; }

    [Parameter]
    public bool PasswordToggle { get; set; }

    [Parameter]
    public bool PasswordVisible { get; set; }

    [Parameter]
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public string? Pattern { get; set; }

    [Parameter]
    public bool Pill { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }

    [Parameter]
    public bool Readonly { get; set; }

    [Parameter]
    public bool Spellcheck { get; set; }

    [Parameter]
    public double? Step { get; set; }

    [Parameter]
    public string? Type { get; set; }

    #endregion Properties

    #region Events

    [Parameter]
    public EventCallback OnClear { get; set; }

    #endregion Events

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-clear", OnClear);
        }
    }

    #region Instance Methods

    public ValueTask SelectAsync() => Element.InvokeVoidAsync("select");

    public ValueTask SetRangeTextAsync(string replacement, int start, int end, string selectMode) => Element.InvokeVoidAsync("setRangeText", replacement, start, end, selectMode);

    public ValueTask SetSelectionRangeAsync(int selectionStart, int selectionEnd, string selectionDirection) => Element.InvokeVoidAsync("setSelectionRange", selectionStart, selectionEnd, selectionDirection);

    public ValueTask ShowPickerAsync() => Element.InvokeVoidAsync("showPicker");

    public ValueTask StepDownAsync() => Element.InvokeVoidAsync("stepDown");

    public ValueTask StepUpAsync() => Element.InvokeVoidAsync("stepUp");

    #endregion Instance Methods
}