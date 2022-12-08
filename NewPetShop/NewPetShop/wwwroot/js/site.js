$(function () {
    $('.page-contrtol form input').change(function () {
        $(this).closest('form').submit();
    })
    $('.page-contrtol form #firstPage').click(function () {
        $(this).closest('form').find('#pageNumber').val(1).change();
    })
    $('.page-contrtol form #previousPage').click(function () {
        var input = $(this).closest('form').find('#pageNumber');
        var num = parseInt(input.val());
        input.val(--num).change();
    })
    $('.page-contrtol form #nextPage').click(function () {
        var input = $(this).closest('form').find('#pageNumber');
        var num = parseInt(input.val());
        input.val(++num).change();
    })
    $('.page-contrtol form #lastPage').click(function () {
        var input = $(this).closest('form').find('#pageNumber');
        var total = parseInt($(this).closest('form').find('#totalCount').val());
        var size = parseInt($(this).closest('form').find('#pageSize').val());
        var num = Math.floor(total / size);
        if ((total % size) > 0) {
            num++;
        }
        input.val(num).change();
    })
    $('.page-contrtol form #selectCategory').change(function (e) {
        $(this).closest('form').find('#category').val($(e.target).val()).change();
    })
    $('.page-contrtol form #selectPersonType option').each(function () {
        var selected = $(this).closest('form').find('#category').val();
        if (selected && $(this).val() == selected) {
            $(this).attr('selected', 'selected');
        }
    })
})