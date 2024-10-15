namespace Shoelace.Style.Utilities;

/// <summary />
public static class Identifier
{
    private static readonly Random _rnd = new();

    /// <summary>
    /// Returns a new <see cref="IdentifierContext"/> where ID are sequential: "f0000", "f0001", "f0002", ...
    /// </summary>
    /// <returns></returns>
    public static IdentifierContext SequentialContext() => new((n) => $"f{n:0000}");

    /// <summary>
    /// Returns a new small Id.
    /// HTML id must start with a letter.
    /// Example: f127d9edf14385adb
    /// </summary>
    /// <remarks>
    /// You can use a <see cref="IdentifierContext"/> instance to customize the Generation process,
    /// for example in Unit Tests.
    /// </remarks>
    /// <returns></returns>
    public static string NewId(int length = 8)
    {
        if (IdentifierContext.Current == null)
        {
            if (length > 16)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "length must be less than 16");
            }

            if (length <= 8)
            {
                return $"f{_rnd.Next():x}";
            }

            return $"f{_rnd.Next():x}{_rnd.Next():x}"[..length];
        }

        return IdentifierContext.Current.GenerateId();
    }
}
