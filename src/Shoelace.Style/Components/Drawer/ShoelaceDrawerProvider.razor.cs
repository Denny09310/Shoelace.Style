using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Shoelace.Style.Components;

/// <summary>
/// Provides dialog management for the application, allowing for the display and dismissal of dialogs.
/// </summary>
public partial class ShoelaceDrawerProvider : ComponentBase, IDisposable
{
    private bool disposed;
    private DrawerOptions _options = DrawerOptions.Default;

    /// <summary>
    /// Determine if the drawer shoud close on navigation
    /// </summary>
    [Parameter]
    public bool NavigationClose { get; set; } = true;

    private bool Open { get; set; }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                DrawerService.DrawerInstanceOpen -= OpenDrawer;
                DrawerService.OnDrawerCloseRequested -= CloseDrawer;
                NavigationManager.LocationChanged -= LocationChanged;
            }

            disposed = true;
        }
    }

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        DrawerService.DrawerInstanceOpen += OpenDrawer;
        DrawerService.OnDrawerCloseRequested += CloseDrawer;
        NavigationManager.LocationChanged += LocationChanged;
    }

    private void CloseDrawer()
    {
        Open = false;
        InvokeAsync(StateHasChanged);
    }

    private void LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        if (NavigationClose)
        {
            CloseDrawer();
        }
    }

    private void OpenDrawer(DrawerOptions options)
    {
        _options = options;

        Open = true;
        InvokeAsync(StateHasChanged);
    }
}