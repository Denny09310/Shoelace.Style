export const unregister = (group, tab, panel) => {
    if (tab.active) {
        group.show(tab.previousElementSibling.panel);
    }

    tab.remove();
    panel.remove();
}