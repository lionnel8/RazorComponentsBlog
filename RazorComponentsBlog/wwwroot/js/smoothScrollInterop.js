window.smoothScrollInterop = {
    scrollTo: function (anchor) {
        let scroll = new SmoothScroll();
        scroll.animateScroll(document.querySelector(anchor), '',
            {
                updateURL: false
            });
    }
};