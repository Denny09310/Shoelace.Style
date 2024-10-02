namespace Shoelace.Style.Components;

public class DialogOptions
{
    public static readonly DialogOptions Default = new();

    public string? Class { get; set; }
    public string? Id { get; set; }
    public bool NoHeader { get; set; }
    public bool Open { get; set; }
    public string? Style { get; set; }
}