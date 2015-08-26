$(function () {
    $('.add-item').click(function (event) {
        event.preventDefault();
        var $this = $(this);
        var $alternative = $this.parent();
        var $count = $alternative.data('count');
        $.get($this.prop('href'), { index: $count }, function (data) {
            $alternative.append(data);
            $alternative.data('count', ++$count);
        });
    });

    $(document).on('click', 'div.remove-collection-item', function (event) {
        event.preventDefault();
        var container = $(this).parents('.collection');
        $(this).parent().remove();
        container.data('count', container.data('count') - 1);
    });
});