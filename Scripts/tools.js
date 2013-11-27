$(document).ready(function () {

    //This is used to asynchronious delete an item from an index list.
    $(function () {
        $('.delete').click(function () {
            if (confirm('Are you sure you want to delete this item?')) {
                var $link = $(this);
                $.ajax({
                    url: this.href,
                    type: 'POST',
                    success: function (result) {
                        $link.parent().parent().parent().remove();
                    }
                });
            }
            return false;
        });
    });
});