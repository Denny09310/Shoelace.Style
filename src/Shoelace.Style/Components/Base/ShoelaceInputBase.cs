using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Shoelace.Style.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Shoelace.Style.Components;

/// <summary>
/// Base class for Shoelace input components, extending <see cref="ShoelaceComponentBase"/>.
/// It provides support for handling additional HTML attributes, CSS classes, styles,
/// and event listeners on the component.
/// </summary>
public abstract partial class ShoelaceInputBase<TValue> : ShoelaceComponentBase, IValidatable, IDisposable
{
    internal readonly string UnknownBoundField = "(unknown)";

    private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;

    private bool _hasInitializedParameters;
    private string? _incomingValueBeforeParsing;
    private Type? _nullableUnderlyingType;
    private bool _parsingFailed;
    private ValidationMessageStore? _parsingValidationMessages;
    private bool _previousParsingAttemptFailed;

    /// <inheritdoc/>
    protected ShoelaceInputBase()
    {
        Id = Identifier.NewId();
        _validationStateChangedHandler = OnValidateStateChanged;
    }

    /// <summary>
    /// Gets or sets the delay, in milliseconds, before to raise the <see cref="ValueChanged"/> event.
    /// </summary>
    [Parameter]
    public int Delay { get; set; }

    /// <summary>
    /// Gets or sets the display name for this field.
    /// <para>This value is used when generating error messages when the input value fails to parse correctly.</para>
    /// </summary>
    [Parameter]
    public string? DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="FieldIdentifier"/> that identifies the bound value.
    /// If set, this parameter takes precedence over <see cref="ValueExpression"/>.
    /// </summary>
    [Parameter]
    public FieldIdentifier? Field { get; set; }

    /// <summary>
    /// Determines if the input should listen for the sl-change or sl-input event
    /// </summary>
    [Parameter]
    public bool Immediate { get; set; }

    /// <summary>
    /// Emitted when the value of the element changes.
    /// </summary>
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    internal virtual bool FieldBound => Field is not null || ValueExpression is not null || ValueChanged.HasDelegate;

    /// <summary>
    /// Gets the <see cref="FieldIdentifier"/> for the bound value.
    /// </summary>
    protected internal FieldIdentifier FieldIdentifier { get; set; }

    /// <summary>
    /// Gets or sets the current value of the input.
    /// </summary>
    protected TValue? CurrentValue
    {
        get => Value;
        set => _ = SetCurrentValueAsync(value);
    }

    /// <summary>
    /// Gets or sets the current value of the input, represented as a string.
    /// </summary>
    protected string? CurrentValueAsString
    {
        // InputBase-derived components can hold invalid states (e.g., an InputNumber being blank even when bound
        // to an int value). So, if parsing fails, we keep the rejected string in the UI even though it doesn't
        // match what's on the .NET model. This avoids interfering with typing, but still notifies the EditContext
        // about the validation error message.
        get => _parsingFailed ? _incomingValueBeforeParsing : FormatValueAsString(CurrentValue);
        set => _ = SetCurrentValueAsStringAsync(value);
    }

    /// <summary>
    /// Gets the associated <see cref="Microsoft.AspNetCore.Components.Forms.EditContext"/>.
    /// This property is uninitialized if the input does not have a parent <see cref="EditForm"/>.
    /// </summary>
    protected EditContext EditContext { get; set; } = default!;

    [CascadingParameter]
    private EditContext? CascadedEditContext { get; set; }

    #region Properties

    /// <summary>
    /// The default value of the form control.
    /// </summary>
    /// <remarks>
    /// Primarily used for resetting the form control.
    /// </remarks>
    [Parameter]
    public TValue? DefaultValue { get; set; }

    /// <summary>
    /// Disables the input.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// By default, form controls are associated with the nearest containing &lt;form&gt; element.
    /// This attribute allows you to place the form control outside of a form
    /// and associate it with the form that has this id.
    /// </summary>
    /// <remarks>
    /// The form must be in the same document or shadow root for this to work.
    /// </remarks>
    [Parameter]
    public string? Form { get; set; }

    /// <summary>
    /// The input’s help text. If you need to display HTML, use the help-text slot instead.
    /// </summary>
    [Parameter]
    public string? HelpText { get; set; }

    /// <summary>
    /// The input’s label. If you need to display HTML, use the label slot instead.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// The name of the input, submitted as a name/value pair with form data.
    /// ⚠️ This value needs to be set manually for SSR scenarios to work correctly.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Makes the input a required field.
    /// </summary>
    [Parameter]
    public bool Required { get; set; }

    /// <summary>
    /// The input’s size.
    /// </summary>
    /// <remarks>
    /// Possible values are 'small' | 'medium' | 'large'
    /// </remarks>
    [Parameter]
    public string? Size { get; set; }

    /// <summary>
    /// The current value of the input, submitted as a name/value pair with form data.
    /// </summary>
    [Parameter]
    public TValue? Value { get; set; }

    /// <inheritdoc />
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    #endregion Properties

    #region Events

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnInvalid { get; set; }

    #endregion Events

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (!_hasInitializedParameters)
        {
            // This is the first run
            // Could put this logic in OnInit, but its nice to avoid forcing people who override OnInit to call base.OnInit()

            if (Field is not null)
            {
                FieldIdentifier = (FieldIdentifier)Field;
            }
            else if (ValueExpression is not null)
            {
                FieldIdentifier = FieldIdentifier.Create(ValueExpression);
            }
            else if (ValueChanged.HasDelegate)
            {
                FieldIdentifier = FieldIdentifier.Create(() => Value);
            }

            if (CascadedEditContext != null)
            {
                EditContext = CascadedEditContext;
                EditContext.OnValidationStateChanged += _validationStateChangedHandler;
            }

            _nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));
            _hasInitializedParameters = true;
        }
        else if (CascadedEditContext != EditContext)
        {
            // Not the first run

            // We don't support changing EditContext because it's messy to be clearing up state and event
            // handlers for the previous one, and there's no strong use case. If a strong use case
            // emerges, we can consider changing this.
            throw new InvalidOperationException($"{GetType()} does not support changing the {nameof(Microsoft.AspNetCore.Components.Forms.EditContext)} dynamically.");
        }

        UpdateAdditionalValidationAttributes();

        // For derived components, retain the usual lifecycle with OnInit/OnParametersSet/etc.
        return base.SetParametersAsync(ParameterView.Empty);
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // When initialization in the SetParametersAsync method fails, the EditContext property can remain equal to null
            if (EditContext is not null)
            {
                EditContext.OnValidationStateChanged -= _validationStateChangedHandler;
            }

            _debounce.Dispose();
        }
    }

    /// <summary>
    /// Formats the value as a string. Derived classes can override this to determine the formating used for <see cref="CurrentValueAsString"/>.
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representation of the value.</returns>
    protected virtual string? FormatValueAsString(TValue? value) => value?.ToString();

    /// <summary>
    /// Attempts to set the current value of the input, represented as a string.
    /// </summary>
    /// <param name="value"></param>
    protected async Task SetCurrentValueAsStringAsync(string? value)
    {
        _incomingValueBeforeParsing = value;
        _parsingValidationMessages?.Clear();

        if (_nullableUnderlyingType != null && string.IsNullOrEmpty(value))
        {
            // Assume if it's a nullable type, null/empty inputs should correspond to default(T)
            // Then all subclasses get nullable support almost automatically (they just have to
            // not reject Nullable<T> based on the type itself).
            _parsingFailed = false;
            CurrentValue = default!;
        }
        else if (TryParseValueFromString(value, out var parsedValue, out var validationErrorMessage))
        {
            _parsingFailed = false;
            await SetCurrentValueAsync(parsedValue);
        }
        else
        {
            _parsingFailed = true;

            // EditContext may be null if the input is not a child component of EditForm.
            if (EditContext is not null && FieldBound)
            {
                _parsingValidationMessages ??= new ValidationMessageStore(EditContext);
                _parsingValidationMessages.Add(FieldIdentifier, validationErrorMessage);

                // Since we're not writing to CurrentValue, we'll need to notify about modification from here
                EditContext.NotifyFieldChanged(FieldIdentifier);
            }
        }

        // We can skip the validation notification if we were previously valid and still are
        if (_parsingFailed || _previousParsingAttemptFailed)
        {
            EditContext?.NotifyValidationStateChanged();
            _previousParsingAttemptFailed = _parsingFailed;
        }
    }

    /// <inheritdoc/>
    protected async Task SetCurrentValueAsync(TValue? value)
    {
        var hasChanged = !EqualityComparer<TValue>.Default.Equals(value, Value);
        if (!hasChanged)
        {
            return;
        }

        _parsingFailed = false;

        // If we don't do this, then when the user edits from A to B, we'd:
        // - Do a render that changes back to A
        // - Then send the updated value to the parent, which sends the B back to this component
        // - Do another render that changes it to B again
        // The unnecessary reversion from B to A can cause selection to be lost while typing
        // A better solution would be somehow forcing the parent component's render to occur first,
        // but that would involve a complex change in the renderer to keep the render queue sorted
        // by component depth or similar.
        Value = value;
        if (ValueChanged.HasDelegate)
        {
            // Thread Safety: Force `ValueChanged` to be re-associated with the Dispatcher, prior to invocation.
            await InvokeAsync(async () => await ValueChanged.InvokeAsync(value));
        }
        if (FieldBound)
        {
            // Thread Safety: Force `EditContext` to be re-associated with the Dispatcher
            await InvokeAsync(() => EditContext?.NotifyFieldChanged(FieldIdentifier));
        }
    }

    /// <summary>
    /// Parses a string to create an instance of <typeparamref name="TValue"/>. Derived classes can override this to change how
    /// <see cref="CurrentValueAsString"/> interprets incoming values.
    /// </summary>
    /// <param name="value">The string value to be parsed.</param>
    /// <param name="result">An instance of <typeparamref name="TValue"/>.</param>
    /// <param name="validationErrorMessage">If the value could not be parsed, provides a validation error message.</param>
    /// <returns>True if the value could be parsed; otherwise false.</returns>
    protected abstract bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage);

    /// <summary>
    /// Returns a dictionary with the same values as the specified <paramref name="source"/>.
    /// </summary>
    /// <returns>true, if a new dictionary with copied values was created. false - otherwise.</returns>
    private static bool ConvertToDictionary(IReadOnlyDictionary<string, object>? source, out Dictionary<string, object> result)
    {
        var newDictionaryCreated = true;
        if (source == null)
        {
            result = [];
        }
        else if (source is Dictionary<string, object> currentDictionary)
        {
            result = currentDictionary;
            newDictionaryCreated = false;
        }
        else
        {
            result = [];
            foreach (var item in source)
            {
                result.Add(item.Key, item.Value);
            }
        }

        return newDictionaryCreated;
    }

    private void OnValidateStateChanged(object? sender, ValidationStateChangedEventArgs e)
    {
        UpdateAdditionalValidationAttributes();
        InvokeAsync(StateHasChanged);
    }

    private void UpdateAdditionalValidationAttributes()
    {
        if (EditContext is null)
        {
            return;
        }

        var hasAriaInvalidAttribute = AdditionalAttributes != null && AdditionalAttributes.ContainsKey("data-invalid");
        if (FieldBound && EditContext.GetValidationMessages(FieldIdentifier).Any())
        {
            if (hasAriaInvalidAttribute)
            {
                // Do not overwrite the attribute value
                return;
            }

            if (ConvertToDictionary(AdditionalAttributes, out var additionalAttributes))
            {
                AdditionalAttributes = additionalAttributes;
            }

            // To make the `Input` components accessible by default
            // we will automatically render the `data-invalid` attribute when the validation fails
            // value must be "true" see https://www.w3.org/TR/wai-aria-1.1/#data-invalid
            additionalAttributes["data-invalid"] = "true";
            additionalAttributes.Remove("data-valid");
        }
        else if (hasAriaInvalidAttribute)
        {
            // No validation errors. Need to remove `data-invalid` if it was rendered already

            if (AdditionalAttributes!.Count == 1)
            {
                // Only data-invalid argument is present which we don't need any more
                AdditionalAttributes = null;
            }
            else
            {
                if (ConvertToDictionary(AdditionalAttributes, out var additionalAttributes))
                {
                    AdditionalAttributes = additionalAttributes;
                }

                additionalAttributes["data-valid"] = "true";
                additionalAttributes.Remove("data-invalid");
            }
        }
    }

    #region Instance Methods

    /// <inheritdoc />
    public ValueTask CheckValidityAsync() => Element.InvokeVoidAsync("checkValidity");

    /// <summary>
    /// Gets the associated form, if one exists.
    /// </summary>
    public ValueTask GetFormAsync() => Element.InvokeVoidAsync("getForm");

    /// <inheritdoc />
    public ValueTask ReportValidityAsync() => Element.InvokeVoidAsync("reportValidity");

    /// <inheritdoc />
    public ValueTask SetCustomValidityAsync(string message) => Element.InvokeVoidAsync("setCustomValidity", message);

    #endregion Instance Methods
}

public abstract partial class ShoelaceInputBase<TValue>
{
    private readonly Debounce _debounce = new();

#pragma warning disable S2583

    /// <summary>
    /// Handler for the OnChange event.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task ChangeHandlerAsync(ChangeEventArgs e)
    {
        var _notifyCalled = false;
        var isValid = TryParseValueFromString(e.Value?.ToString(), out TValue? result, out var validationErrorMessage);

        if (isValid)
        {
            await SetCurrentValueAsync(result ?? default);
            _notifyCalled = true;
        }
        else
        {
            if (FieldBound && CascadedEditContext != null)
            {
                _parsingValidationMessages ??= new ValidationMessageStore(CascadedEditContext);

                _parsingValidationMessages.Clear();
                _parsingValidationMessages.Add(FieldIdentifier, validationErrorMessage ?? "Unknown parsing error");
            }
        }
        if (FieldBound && !_notifyCalled)
        {
            CascadedEditContext?.NotifyFieldChanged(FieldIdentifier);
        }
    }

#pragma warning restore S2583

    /// <summary>
    /// Handler for the OnInput event, with an optional delay to avoid to raise the <see cref="ValueChanged"/> event too often.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task InputHandlerAsync(ChangeEventArgs e)
    {
        if (!Immediate)
        {
            return;
        }

        if (Delay > 0)
        {
            await _debounce.RunAsync(Delay, async () => await ChangeHandlerAsync(e));
        }
        else
        {
            await ChangeHandlerAsync(e);
        }
    }

    /// <summary>
    /// Handler for the OnInvalid event
    /// </summary>
    /// <returns></returns>
    protected virtual async Task InvalidHandlerAsync()
    {
        await OnInvalid.InvokeAsync();
    }
}