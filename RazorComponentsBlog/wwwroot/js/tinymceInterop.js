window.tinymceInterop = {
    init: function () {
        tinymce.init({
            selector: 'textarea',
            height: 500,
            plugins: 'codesample code lists autolink emoticons insertdatetime link',
            codesample_languages: [
                { text: 'C#', value: 'csharp' },
                { text: 'HTML', value: 'markup' },
                { text: 'CSS', value: 'css' },
                { text: 'JavaScript', value: 'javascript' },
                { text: 'WebAssembly', value: 'wasm' },
            ],
            toolbar: "codesample numlist bullist emoticons nonbreaking link"
        });
    },
    remove: function () {
        tinymce.remove();
    },
    getContent: function (editorId = null) {
        if (editorId) {
            return tinymce.get(editorId).getContent();
        }
        return tinymce.activeEditor.getContent();
    },
    setContent: function (content) {
        tinymce.activeEditor.setContent(content);
    },
    highlightCode: function () {
        Prism.highlightAll();
    }

};