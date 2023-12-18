function saveAsFile(filename, byteBase64) {
    const link = document.createElement('a');
    link.download = filename;
    const blob = new Blob([byteBase64], { type: 'application/octet-stream' });
    link.href = window.URL.createObjectURL(blob);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}