export function beforeStart() {
    // Get all script tags
    const scriptTags = document.querySelectorAll('script');

    // Find the script tag with a source that ends with 'shoelace-autoloader.js'
    const autoloaderTag = Array.from(scriptTags).find(script =>
        script.src && script.src.endsWith('shoelace-autoloader.js')
    );

    if (autoloaderTag) {
        // If the script is found attach the base address of the assets
        autoloaderTag.setAttribute('data-shoelace', '/_content/Shoelace.Style');
    }
}