const events = [
    {
        name: 'slblur',
        browserEventName: 'sl-blur',
    },
    {
        name: 'slinvalid',
        browserEventName: 'sl-invalid',
    },
    {
        name: 'slfocus',
        browserEventName: 'sl-focus',
        createEventArgs: event => ({
            Type: event.type
        })
    },
    {
        name: 'slchange',
        browserEventName: 'sl-change',
        createEventArgs: event => ({
            Value: event.target.value
        })
    },
    {
        name: 'slinput',
        browserEventName: 'sl-input',
        createEventArgs: event => ({
            Value: event.target.value
        })
    }
];

export function afterStarted(blazor) {
    events.forEach(event => {
        blazor.registerCustomEventType(event.name, event);
    });
}