using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Shoelace.Style.Events;

/// <summary>
/// The event handlers needed to razor
/// </summary>

[EventHandler("onslcheckedchange", typeof(CheckboxChangeEventArgs), true, true)]
[EventHandler("onslchange", typeof(ChangeEventArgs), true, true)]
[EventHandler("onslinput", typeof(ChangeEventArgs), true, true)]
[EventHandler("onslfocus", typeof(FocusEventArgs), true, true)]
[EventHandler("onslblur", typeof(EventArgs), true, true)]
[EventHandler("onslload", typeof(EventArgs), true, true)]
[EventHandler("onslhover", typeof(HoverEventArgs), true, true)]
[EventHandler("onslshow", typeof(FocusEventArgs), true, true)]
[EventHandler("onslaftershow", typeof(FocusEventArgs), true, true)]
[EventHandler("onslhide", typeof(FocusEventArgs), true, true)]
[EventHandler("onslafterhide", typeof(FocusEventArgs), true, true)]
[EventHandler("onslinvalid", typeof(EventArgs), true, true)]
[EventHandler("onslclear", typeof(EventArgs), true, true)]
[EventHandler("onslerror", typeof(EventArgs), true, true)]
[EventHandler("onslload", typeof(EventArgs), true, true)]
[EventHandler("onslcopy", typeof(EventArgs), true, true)]
[EventHandler("onslinitialfocus", typeof(EventArgs), true, true)]
[EventHandler("onslrequestclose", typeof(RequestCloseEventArgs), true, true)]
[EventHandler("onslresize", typeof(ResizeEventArgs), true, true)]
[EventHandler("onslselect", typeof(SelectEventArgs), true, true)]
[EventHandler("onslclose", typeof(EventArgs), true, true)]
[EventHandler("onsltabhide", typeof(TabHideEventArgs), true, true)]
[EventHandler("onsltabshow", typeof(TabShowEventArgs), true, true)]
[EventHandler("onslremove", typeof(EventArgs), true, true)]

public static class EventHandlers;
