using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

public partial class ShoelaceDialogProvider : ComponentBase, IDisposable
{
    private readonly List<IDialogReference> _dialogs = [];

    public void DismissAll()
    {
        foreach (var dialog in _dialogs)
        {
            DismissInstance(dialog, DialogResult.Cancel());
        }
        
        InvokeAsync(StateHasChanged);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    internal void DismissInstance(Guid id, DialogResult result)
    {
        var reference = GetDialogReference(id);
        if (reference != null)
        {
            DismissInstance(reference, result);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            NavigationManager.LocationChanged -= LocationChanged;
            DialogService.DialogInstanceAddedAsync -= AddInstanceAsync;
            DialogService.OnDialogCloseRequested -= DismissInstance;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (!firstRender)
        {
            foreach (var dialogReference in _dialogs.Where(x => !x.Result.IsCompleted))
            {
                dialogReference.RenderCompleteTaskCompletionSource.TrySetResult(true);
            }
        }
        else
        {
            await JSRuntime.InvokeVoidAsync("import", "./_content/Shoelace.Style/components/dialog/dialog.js");
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        DialogService.DialogInstanceAddedAsync += AddInstanceAsync;
        DialogService.OnDialogCloseRequested += DismissInstance;
        NavigationManager.LocationChanged += LocationChanged;
    }

    private Task AddInstanceAsync(IDialogReference dialog)
    {
        _dialogs.Add(dialog);
        return InvokeAsync(StateHasChanged);
    }

    private void DismissInstance(IDialogReference dialog, DialogResult? result)
    {
        if (!dialog.Dismiss(result)) return;

        _dialogs.Remove(dialog);
        InvokeAsync(StateHasChanged);
    }

    private IDialogReference? GetDialogReference(Guid id)
    {
        return _dialogs.Find(x => x.Id == id);
    }

    private void LocationChanged(object? sender, LocationChangedEventArgs args)
    {
        DismissAll();
    }
}