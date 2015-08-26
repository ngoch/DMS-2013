$(function () {
    buttonize();
    tabify();
    $(document).ajaxStop(function () {
        buttonize();
    });
});

function buttonize() {
    $('input[type=submit], button, .button, .actions-toolbar a').button();
}

function tabify() {
    $('.tabs').tabs({
        activate: function (event, ui) {
            event.preventDefault();
            event.stopPropagation();
            var a = ui.newTab.find('a');
            window.location.href = a.attr('href');
            $('html, body').animate({ scrollTop: '0px' }, 0);
        }
    });
}