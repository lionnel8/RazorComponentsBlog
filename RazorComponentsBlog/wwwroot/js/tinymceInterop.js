﻿window.tinymceInterop = {
    init: function () {
        tinymce.init({
            selector: 'textarea',
            height: 500,
            plugins: 'codesample code',
            codesample_languages: [
                { text: 'C#', value: 'csharp' },
                { text: 'HTML', value: 'markup' },
                { text: 'CSS', value: 'css' },
                { text: 'JavaScript', value: 'javascript' },
                { text: 'WebAssembly', value: 'wasm' },
            ],
            toolbar: "codesample"
        });
    },
    remove: function () {
        tinymce.remove();
    },
    getContent: function () {
        return tinymce.activeEditor.getContent();
    },
    setContent: function (content) {
        tinymce.activeEditor.setContent(content);
    },
    highlightCode: function () {
        Prism.highlightAll();
    }

};