using Microsoft.AspNetCore.Components;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

public partial class ShoelaceDialogProvider : ComponentBase, IDisposable
{
    private bool disposed;
    private Stack<DialogOptions> Options { get; set; } = new();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                DialogService.DialogInstanceAdded -= HandleDialogShowRequested;
            }

            disposed = true;
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        DialogService.DialogInstanceAdded += HandleDialogShowRequested;
    }

    private async Task AnimateIn(DialogOptions options)
    {
        await Task.Delay(125);
        options.Open = true;
        await InvokeAsync(StateHasChanged);
    }

    private async Task AnimateOut(DialogOptions options)
    {
        await Task.Delay(125);
        options.Open = false;
        await InvokeAsync(StateHasChanged);
    }

    private async Task HandleDialogClosed(DialogOptions options)
    {
        options.TaskCompletionSource.SetResult(DialogResult.Cancel());
        await AnimateOut(options);

        Options.Pop();
        await InvokeAsync(StateHasChanged);
    }

    private async void HandleDialogShowRequested(DialogOptions options)
    {
        Options.Push(options);
        await InvokeAsync(StateHasChanged);

        await AnimateIn(options);
    }
}