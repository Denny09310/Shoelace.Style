const events = [
    {
        name: 'slcopy',
        browserEventName: 'sl-copy',
    },
    {
        name: 'slshow',
        browserEventName: 'sl-show',
    },
    {
        name: 'slaftershow',
        browserEventName: 'sl-after-show',
    },
    {
        name: 'slhide',
        browserEventName: 'sl-hide',
    },
    {
        name: 'slafterhide',
        browserEventName: 'sl-after-hide',
    },
    {
        name: 'slload',
        browserEventName: 'sl-load',
    },
    {
        name: 'slerror',
        browserEventName: 'sl-error',
    },
    {
        name: 'slblur',
        browserEventName: 'sl-blur',
    },
    {
        name: 'slinvalid',
        browserEventName: 'sl-invalid',
    },
    {
        name: 'slclear',
        browserEventName: 'sl-clear',
    },
    {
        name: 'slinitialfocus',
        browserEventName: 'sl-initial-focus',
    },
    {
        name: 'slrequestclose',
        browserEventName: 'sl-request-close',
        createEventArgs: ({ detail }) => ({
            Source: detail.source
        })
    },
    {
        name: 'slhover',
        browserEventName: 'sl-hover',
        createEventArgs: ({ detail }) => ({
            Phase: detail.phase,
            Value: detail.value,
        })
    },
    {
        name: 'slfocus',
        browserEventName: 'sl-focus',
        createEventArgs: ({ type }) => ({
            Type: type
        })
    },
    {
        name: 'slselect',
        browserEventName: 'sl-select',
        createEventArgs: ({ detail }) => ({
            Value: detail.item.value,
            Checked: detail.item.checked
        })
    },
    {
        name: 'slchange',
        browserEventName: 'sl-change',
        createEventArgs: ({ target }) => ({
            Value: target.value
        })
    },
    {
        name: 'slcheckedchange',
        browserEventName: 'sl-change',
        createEventArgs: ({ target }) => ({
            Checked: target.checked
        })
    },
    {
        name: 'slinput',
        browserEventName: 'sl-input',
        createEventArgs: ({ target }) => ({
            Value: target.value
        })
    },
    {
        name: 'slresize',
        browserEventName: 'sl-resize',
        createEventArgs: ({ entries }) => {
            const mapSizes = (sizes) => sizes.map(size => ({
                BlockSize: size.blockSize,
                InnerSize: size.innerSize,
            }));

            return {
                Entries: entries.map(entry => ({
                    BorderBoxSize: mapSizes(entry.borderBoxSize),
                    ContentBoxSize: mapSizes(entry.contentBoxSize)
                }))
            }
        }
    },
];

export function beforeStart() {
    const stylesheet = document.createElement('link');

    stylesheet.rel = "stylesheet";
    stylesheet.href = "_content/Shoelace.Style/Shoelace.Style.styles.css"

    document.head.appendChild(stylesheet);
}

export function afterStarted(blazor) {
    events.forEach(event => {
        blazor.registerCustomEventType(event.name, event);
    });
}