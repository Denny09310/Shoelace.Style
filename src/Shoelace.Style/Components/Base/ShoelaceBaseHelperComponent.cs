using Microsoft.AspNetCore.Components;
using System.Collections;

namespace Shoelace.Style.Components;

/// <summary>
/// A base component to assist with rendering content dynamically in Blazor.
/// </summary>
/// <typeparam name="TComponent">The type of component that extends this base class.</typeparam>
public abstract class BaseHelperComponent<TComponent> : IComponent where TComponent : IComponent
{
    private const string ChildContent = nameof(ChildContent);
    private RenderFragment? _renderFragment;
    private RenderHandle _renderHandle;

    /// <summary>
    /// Wraps the provided <see cref="RenderFragment"/> content into a component for rendering.
    /// </summary>
    /// <param name="renderFragment">The content to be rendered.</param>
    /// <returns>A <see cref="RenderFragment"/> that can be rendered within a Blazor component.</returns>
    /// <remarks>
    /// This method is typically used to encapsulate content in a helper component that controls rendering logic.
    /// </remarks>
    public static RenderFragment Wrap(RenderFragment renderFragment) => new(builder =>
    {
        builder.OpenComponent<TComponent>(1);
        builder.AddAttribute(2, ChildContent, renderFragment);
        builder.CloseComponent();
    });

    void IComponent.Attach(RenderHandle renderHandle) => _renderHandle = renderHandle;

    Task IComponent.SetParametersAsync(ParameterView parameters)
    {
        if (_renderFragment is null && parameters.TryGetValue<RenderFragment>(ChildContent, out var renderFragment))
        {
            _renderFragment = renderFragment;
            _renderHandle.Render(_renderFragment);
        }

        return Task.CompletedTask;
    }
}

/// <summary>
/// The parameters passed into a <see cref="ShoelaceDrawer"/> instance.
/// </summary>
public class BaseHelperParameters : IEnumerable<KeyValuePair<string, object?>>
{
    internal Dictionary<string, object?> _parameters = [];

    /// <summary>
    /// The number of parameters.
    /// </summary>
    public int Count => _parameters.Count;

    /// <summary>
    /// Gets or sets a parameter.
    /// </summary>
    /// <param name="parameterName">The name of the parameter to find.</param>
    /// <returns>The parameter value.</returns>
    public object? this[string parameterName]
    {
        get => Get<object?>(parameterName);
        set => _parameters[parameterName] = value;
    }

    /// <summary>
    /// Adds or updates a parameter.
    /// </summary>
    /// <param name="parameterName">The name of the parameter.</param>
    /// <param name="value">The value to add or update.</param>
    public void Add(string parameterName, object? value)
    {
        _parameters[parameterName] = value;
    }

    /// <summary>
    /// Gets an existing parameter.
    /// </summary>
    /// <typeparam name="T">The type of value to return.</typeparam>
    /// <param name="parameterName">The name of the parameter to find.</param>
    /// <returns>The parameter value, if it exists.</returns>
    public T? Get<T>(string parameterName)
    {
        if (_parameters.TryGetValue(parameterName, out var value))
        {
            return (T?)value;
        }

        throw new KeyNotFoundException($"{parameterName} does not exist in Drawer parameters");
    }

    /// <summary>
    /// Gets an enumerator for all parameters.
    /// </summary>
    /// <returns>An enumerator of <see cref="KeyValuePair{TKey, TValue}"/> values.</returns>
    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        return _parameters.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _parameters.GetEnumerator();
    }

    /// <summary>
    /// Gets an existing parameter or a default value if nothing was found.
    /// </summary>
    /// <typeparam name="T">The type of value to return.</typeparam>
    /// <param name="parameterName">The name of the parameter to find.</param>
    /// <returns>The parameter value, if it exists.</returns>
    public T? TryGet<T>(string parameterName)
    {
        if (_parameters.TryGetValue(parameterName, out var value))
        {
            return (T?)value;
        }

        return default;
    }
}