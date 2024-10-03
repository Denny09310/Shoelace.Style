# Shoelace Style Blazor Components

![Shoelace](https://shoelace.style/assets/images/wordmark.svg)

This repository contains Blazor components built on top of the [Shoelace](https://shoelace.style) library, enabling developers to use Shoelace UI elements in their Blazor applications.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (8.0 or higher)
- A Blazor application (Blazor Server or Blazor WebAssembly)

### Installation

1. Install the nuget package:

   ```bash
   dotnet add package Shoelace.Style --version 1.0.0.4
   ```

2. Add the links to reference the css and js in index.html/App.razor/_Host.cshtml:

   ```html
    <link rel="stylesheet"
          media="(prefers-color-scheme:light)"
          href="_content/Shoelace.Style/themes/light.css" />
   
    <link rel="stylesheet"
          media="(prefers-color-scheme:dark)"
          href="_content/Shoelace.Style/themes/dark.css"
          onload="document.documentElement.classList.add('sl-theme-dark');" />
   ```

   ``` html
    <script src="_content/Shoelace.Style/shoelace-autoloader.js" type="module"></script>
   ```

   Or follow the instructions in the [Installation](https://shoelace.style/getting-started/installation) page of the main site.

### Usage

Import the main namespaces inside the _Import.razor file:

``` cshtml
@using Shoelace.Style.Components
@using Shoelace.Style.Services @* Optional *@
@using Shoelace.Style.Options @* Optional *@
```

Add the service collection extension in you Program.cs:

``` cs
builder.Services.AddShoelaceStyle();
```

### Shoelace Components Checklist

- [X] Alert (`<sl-alert>`)
- [X] Animated Image (`<sl-animated-image>`)
- [ ] Animation (`<sl-animation>`)
- [X] Avatar (`<sl-avatar>`)
- [X] Badge (`<sl-badge>`)
- [X] Breadcrumb (`<sl-breadcrumb>`)
- [X] Breadcrumb Item (`<sl-breadcrumb-item>`)
- [X] Button (`<sl-button>`)
- [X] Button Group (`<sl-button-group>`)
- [X] Card (`<sl-card>`)
- [ ] Carousel (`<sl-carousel>`)
- [ ] Carousel Item (`<sl-carousel-item>`)
- [X] Checkbox (`<sl-checkbox>`)
- [X] Color Picker (`<sl-color-picker>`)
- [X] Copy Button (`<sl-copy-button>`)
- [ ] Details (`<sl-details>`)
- [X] Dialog (`<sl-dialog>`)
- [ ] Divider (`<sl-divider>`)
- [ ] Drawer (`<sl-drawer>`)
- [ ] Dropdown (`<sl-dropdown>`)
- [ ] Format Bytes (`<sl-format-bytes>`)
- [ ] Format Date (`<sl-format-date>`)
- [ ] Format Number (`<sl-format-number>`)
- [ ] Icon (`<sl-icon>`)
- [ ] Icon Button (`<sl-icon-button>`)
- [ ] Image Comparer (`<sl-image-comparer>`)
- [ ] Include (`<sl-include>`)
- [X] Input (`<sl-input>`)
- [ ] Menu (`<sl-menu>`)
- [ ] Menu Item (`<sl-menu-item>`)
- [ ] Menu Label (`<sl-menu-label>`)
- [ ] Mutation Observer (`<sl-mutation-observer>`)
- [ ] Option (`<sl-option>`)
- [ ] Popup (`<sl-popup>`)
- [ ] Progress Bar (`<sl-progress-bar>`)
- [ ] Progress Ring (`<sl-progress-ring>`)
- [ ] QR Code (`<sl-qr-code>`)
- [ ] Radio (`<sl-radio>`)
- [ ] Radio Button (`<sl-radio-button>`)
- [ ] Radio Group (`<sl-radio-group>`)
- [ ] Range (`<sl-range>`)
- [ ] Rating (`<sl-rating>`)
- [ ] Relative Time (`<sl-relative-time>`)
- [ ] Resize Observer (`<sl-resize-observer>`)
- [ ] Select (`<sl-select>`)
- [ ] Skeleton (`<sl-skeleton>`)
- [X] Spinner (`<sl-spinner>`)
- [ ] Split Panel (`<sl-split-panel>`)
- [ ] Switch (`<sl-switch>`)
- [ ] Tab (`<sl-tab>`)
- [ ] Tab Group (`<sl-tab-group>`)
- [ ] Tab Panel (`<sl-tab-panel>`)
- [ ] Tag (`<sl-tag>`)
- [ ] Textarea (`<sl-textarea>`)
- [ ] Tooltip (`<sl-tooltip>`)
- [ ] Tree (`<sl-tree>`)
- [ ] Tree Item (`<sl-tree-item>`)
- [ ] Visually Hidden (`<sl-visually-hidden>`)


### Contributing

Contributions are welcome! Please follow these steps to contribute:

1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature/YourFeature`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a pull request.

### License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Denny09310/Shoelace.Style/blob/master/LICENSE.txt) file for more details.

### Acknowledgments

- [Shoelace](https://shoelace.style) for the UI components.
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) for enabling web applications with C#.

## Contact

For questions or support, please contact [Koja Dennis](mailto:k.denny2000@gmail.com).