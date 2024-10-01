using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Options;

public class DialogOptions(string label, RenderFragment content, TaskCompletionSource<DialogResult> tcs)
{
    public RenderFragment Content { get; set; } = content;
    public string Label { get; set; } = label;
    public bool Open { get; set; }
    public TaskCompletionSource<DialogResult> TaskCompletionSource { get; set; } = tcs;
}

public class DialogResult
{
    public object? Data { get; set; }
    public bool IsCancelled { get; set; }

    public static DialogResult Cancel() => new() { IsCancelled = true };
}