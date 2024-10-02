﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

/// <summary>
/// Inputs collect data from the user.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/input"/>
/// </remarks>
/// <typeparam name="TValue">The type of the value attribute</typeparam>
public partial class ShoelaceInput<TValue> : ShoelaceInputBase<TValue>, ISelectable
{
    /// <summary>
    /// The content of the input.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Controls whether and how text input is automatically capitalized as it is entered by the user.
    /// </summary>
    [Parameter]
    public bool AutoCapitalize { get; set; }

    /// <summary>
    /// Specifies what permission the browser has to provide assistance in filling out form field values.
    /// </summary>
    /// <remarks>
    /// Refer to this page on MDN for available values.
    /// </remarks>
    [Parameter]
    public bool AutoComplete { get; set; }

    /// <summary>
    /// Indicates whether the browser’s autocorrect feature is on or off.
    /// </summary>
    [Parameter]
    public bool AutoCorrect { get; set; }

    /// <summary>
    /// Indicates that the input should receive focus on page load.
    /// </summary>
    [Parameter]
    public bool AutoFocus { get; set; }

    /// <summary>
    /// Adds a clear button when the input is not empty.
    /// </summary>
    [Parameter]
    public bool Clearable { get; set; }

    /// <summary>
    /// Used to customize the label or icon of the Enter key on virtual keyboards.
    /// </summary>
    [Parameter]
    public string? EnterKeyHint { get; set; }

    /// <summary>
    /// Draws a filled input.
    /// </summary>
    [Parameter]
    public bool Filled { get; set; }

    /// <summary>
    /// Tells the browser what type of data will be entered by the user,
    /// allowing it to display the appropriate virtual keyboard on supportive devices.
    /// </summary>
    [Parameter]
    public string? InputMode { get; set; }

    /// <summary>
    /// The input’s maximum value.
    /// </summary>
    /// <remarks>
    /// Only applies to date and number input types.
    /// </remarks>
    [Parameter]
    public double? Max { get; set; }

    /// <summary>
    /// The maximum length of input that will be considered valid.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }

    /// <summary>
    /// The input’s minimum value.
    /// </summary>
    /// <remarks>
    /// Only applies to date and number input types.
    /// </remarks>
    [Parameter]
    public double? Min { get; set; }

    /// <summary>
    /// The minimum length of input that will be considered valid.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }

    /// <summary>
    /// Hides the browser’s built-in increment/decrement spin buttons for number inputs.
    /// </summary>
    [Parameter]
    public bool NoSpinButtons { get; set; }

    /// <summary>
    /// Adds a button to toggle the password’s visibility.
    /// </summary>
    /// <remarks>
    /// Only applies to password types.
    /// </remarks>
    [Parameter]
    public bool PasswordToggle { get; set; }

    /// <summary>
    /// Determines whether or not the password is currently visible.
    /// </summary>
    /// <remarks>
    /// Only applies to password types.
    /// </remarks>
    [Parameter]
    public bool PasswordVisible { get; set; }

    /// <summary>
    /// A regular expression pattern to validate input against.
    /// </summary>
    [Parameter]
    [StringSyntax(StringSyntaxAttribute.Regex)]
    public string? Pattern { get; set; }

    /// <summary>
    /// Draws a pill-style input with rounded edges.
    /// </summary>
    [Parameter]
    public bool Pill { get; set; }

    /// <summary>
    /// Placeholder text to show as a hint when the input is empty.
    /// </summary>
    [Parameter]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Makes the input readonly.
    /// </summary>
    [Parameter]
    public bool Readonly { get; set; }

    /// <summary>
    /// Enables spell checking on the input.
    /// </summary>
    [Parameter]
    public bool Spellcheck { get; set; }

    /// <summary>
    /// Specifies the granularity that the value must adhere to, or the special value any which means no stepping is implied, allowing any numeric value.
    /// </summary>
    /// <remarks>
    /// Only applies to date and number input types.
    /// </remarks>
    [Parameter]
    public double? Step { get; set; }

    /// <summary>
    /// The type of input. Works the same as a native &lt;input&gt; element, but only a subset of types are supported. Defaults to text.
    /// </summary>
    /// <remarks>
    /// Valid values are 'date' | 'datetime-local' | 'email' | 'number' | 'password' | 'search' | 'tel' | 'text' | 'time' | 'url'
    /// </remarks>
    [Parameter]
    public string? Type { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the clear button is activated.
    /// </summary>
    [Parameter]
    public EventCallback OnClear { get; set; }

    #endregion Events

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-clear", OnClear);
        }
    }

    #region Instance Methods

    /// <inheritdoc />
    public ValueTask SelectAsync() => Element.InvokeVoidAsync("select");

    /// <inheritdoc />
    public ValueTask SetRangeTextAsync(string replacement, int start, int end, string selectMode) => Element.InvokeVoidAsync("setRangeText", replacement, start, end, selectMode);

    /// <inheritdoc />
    public ValueTask SetSelectionRangeAsync(int selectionStart, int selectionEnd, string selectionDirection) => Element.InvokeVoidAsync("setSelectionRange", selectionStart, selectionEnd, selectionDirection);

    /// <summary>
    /// Displays the browser picker for an input element.
    /// </summary>
    /// <remarks>
    /// Only works if the browser supports it for the input type.
    /// </remarks>
    public ValueTask ShowPickerAsync() => Element.InvokeVoidAsync("showPicker");

    /// <summary>
    /// Increments the value of a numeric input type by the value of the step attribute.
    /// </summary>
    public ValueTask StepDownAsync() => Element.InvokeVoidAsync("stepDown");

    /// <summary>
    /// Decrements the value of a numeric input type by the value of the step attribute.
    /// </summary>
    public ValueTask StepUpAsync() => Element.InvokeVoidAsync("stepUp");

    #endregion Instance Methods
}