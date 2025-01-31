export const init = (dialog, instance) => {

    const onRequestClose = (event) => {
        event.preventDefault();
        const source = event.detail.source;

        instance.invokeMethodAsync('request-close-callback', { Source: source }).then(prevented => {
            if (!prevented) {
                dialog.hide();
            }
        });
    };

    dialog.addEventListener('sl-request-close', onRequestClose);

    return {
        dispose: () => {
            dialog.removeEventListener('sl-request-close', onRequestClose);
        }
    };
};