function runReport() {
    if (boundAsync) {
        boundAsync.runReport().then(function (response) {
            alert(response);
        });
    }
}