namespace Shoelace.Style.Utilities;

/// <inheritdoc/>
public sealed class IdentifierContext : IDisposable
{
    private static readonly ThreadLocal<Stack<IdentifierContext>> _threadScopeStack = new(() => new Stack<IdentifierContext>());

    /// <inheritdoc/>
    public IdentifierContext(Func<uint, string> newId)
    {
        _threadScopeStack.Value?.Push(this);
        NewId = newId;
        CurrentIndex = 0;
    }

    /// <inheritdoc/>
    public static IdentifierContext? Current
    {
        get
        {
            if (_threadScopeStack.Value == null || _threadScopeStack.Value.Count == 0)
            {
                return null;
            }
            else
            {
                return _threadScopeStack.Value?.Peek();
            }
        }
    }

    private uint CurrentIndex { get; set; }

    private Func<uint, string> NewId { get; init; }

    /// <summary>
    /// Returns the next number between 0 and 99999999.
    /// </summary>
    /// <returns></returns>
    internal string GenerateId()
    {
        var id = NewId.Invoke(CurrentIndex);

        CurrentIndex++;

        if (CurrentIndex >= 99999999)
        {
            CurrentIndex = 0;
        }

        return id;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _ = _threadScopeStack.Value?.TryPop(out _);
    }
}