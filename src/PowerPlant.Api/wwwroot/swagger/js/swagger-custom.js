(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            // Section 01 - Set url link 
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://www.engie.com/";
            logo[0].target = "_blank";

            // Section 02 - Set favicon
            document.querySelectorAll(`[rel="icon"]`).forEach(element => {
                element.remove();
            });

            var linkIcon = document.createElement('link');
            linkIcon.type = 'image/vnd.microsoft.icon';
            linkIcon.rel = 'icon';
            linkIcon.href = '/swagger/images/favicon.ico';
            document.getElementsByTagName('head')[0].append(linkIcon);
        });
    });

})();