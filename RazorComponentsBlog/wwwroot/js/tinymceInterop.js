window.tinymceInterop = {
    init: function () {
        tinymce.init({
            selector: 'textarea',
        });
    },
    getContent: function () {
        return tinymce.activeEditor.getContent();
    },
    setContent: function (content) {
        tinymce.activeEditor.setContent(content);
    }

};