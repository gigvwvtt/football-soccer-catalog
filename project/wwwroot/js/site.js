$(document).ready(function() {
    var url = window.location;
    $('ul.nav li a').each(function () {
        if (this.href == url) {
            $("ul.nav li").each(function () {
                if ($(this).hasClass("active")) {
                    $(this).removeClass("active");
                }
                //if ($(this).hasAttribute("aria-current")) {
                //    $(this).removeAttr("aria-current");
                //}
            });
            $(this).addClass('active');
            // $(this).parent().attr('aria-current', 'page');
        }
    });
});