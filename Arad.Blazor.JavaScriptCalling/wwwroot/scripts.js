export function InvokeVoidAsync(functionPath) {
    window[functionPath].apply(null, Array.prototype.slice.call(arguments, 1));
}
export function getInnerHtml(id) {
    const element = document.getElementById(id)
    return element.innerHTML;
}