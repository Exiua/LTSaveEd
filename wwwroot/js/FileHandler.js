/**
 * Save a file to the computer
 * @param data {Uint8Array} The Uint8Array data that makes up the file (automatically converted from a byte[] to a Uint8Array when sent from C#)
 * @param filename {string} The name of the file to save
 */
export function saveFile(data, filename) {
    // Create a Blob from the byte array (Uint8Array)
    const blob = new Blob([data], { type: 'application/xml' });

    // Create an anchor element and download the file
    const url = URL.createObjectURL(blob);
    const anchor = document.createElement('a');
    anchor.href = url;
    anchor.download = filename;
    document.body.appendChild(anchor); // Required for Firefox
    anchor.click();
    document.body.removeChild(anchor);
    URL.revokeObjectURL(url);
}