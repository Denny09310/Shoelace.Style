export const init = (groupTab) => {
    return {
        // Removes the current tab and panel, and activates the previous tab if the removed one was active
        remove: (currentTab, currentPanel) => {
            if (currentTab.active) {
                const previousTab = currentTab.previousElementSibling || groupTab.querySelector('sl-tab:last-of-type');
                groupTab.show(previousTab.panel);
            }

            currentTab.remove();
            currentPanel.remove();
        },

        // Activates the next tab, wrapping around if it's the last tab
        next: () => {
            const nextTab = groupTab.activeTab.nextElementSibling || groupTab.querySelector('sl-tab:first-of-type');
            groupTab.show(nextTab.panel);
        },

        // Activates the previous tab, wrapping around if it's the first tab
        previous: () => {
            const previousTab = groupTab.activeTab.previousElementSibling || groupTab.querySelector('sl-tab:last-of-type');
            groupTab.show(previousTab.panel);
        }
    };
};