function escapeHtml(html) {
    const div = document.createElement('div');
    div.textContent = html;
    return div.innerHTML;
}

export const toast = async (message, options) => {
    const { variant = "primary", icon = "info-circle", duration = 3000 } = options;

    const alert = Object.assign(document.createElement('sl-alert'), {
        variant,
        closable: true,
        duration: duration,
        innerHTML: `
        <sl-icon name="${icon}" slot="icon"></sl-icon>
        ${escapeHtml(message)}
      `
    });

    document.body.append(alert);

    await customElements.whenDefined('sl-alert');
    alert.toast();
}