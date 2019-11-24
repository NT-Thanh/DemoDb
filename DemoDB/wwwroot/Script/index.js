$(document).ready(function () {
    ajax = {
        get: function (url, id, row, pos) {
            if (id == undefined) {
                id = '';
            }
            return $.ajax({
                url: url + "/" + id,
                type: 'GET',
                dataType: 'json'
            })
                .done(function (res) {
                    row.find('td').eq(pos).html(res);
                })
                .always(function () {
                    $(row).find('button').removeAttr('disabled');
                })
                .fail(function () {
                    row.find('td').eq(pos).html("Error");
                })
        },
        put: function (url, id, row, pos) {
            if (id == undefined) {
                id = '';
            }
            return $.ajax({
                url: url + "/" + id,
                type: 'PUT',
                dataType: 'json'
            })
                .done(function (res) {
                    row.find('td').eq(pos).html(res);
                })
                .always(function () {
                    $(row).find('button').removeAttr('disabled');
                })
                .fail(function () {
                    row.find('td').eq(pos).html("Error");
                })
        },
        delete: function (url, id, row, number, pos) {
            if (id == undefined) {
                id = '';
            }
            if (number == undefined) {
                number = '';
            }
            return $.ajax({
                url: url + "/" + id + number,
                type: 'DELETE',
                dataType: 'json'
            })
                .done(function (res) {
                    row.find('td').eq(pos).html(res);
                })
                .always(function () {
                    $(row).find('button').removeAttr('disabled');
                })
                .fail(function () {
                    row.find('td').eq(pos).html("Error");
                })
        }
    }
})

var loadingMask = $('<div class="loading-mask"></div>');

function maskTrigger(row) {
    $(row).find('td').eq(2).html($(loadingMask).clone());
    $(row).find('td').eq(3).html($(loadingMask).clone());
    $(row).find('button').attr('disabled', 'disabled');
}

$(document).on('click', '#compareGet', function (e) {
    var row = $(this).parent().parent();
    maskTrigger(row);
    ajax.get('studentmongo', '', row, 2);
    ajax.get('student', '', row, 3);
})

$(document).on('click', '#compareGetOne', function (e) {
    var row = $(this).parent().parent();
    maskTrigger(row);
    var id = parseInt($('#searchID').val());
    ajax.get('studentmongo', id, row, 2);
    ajax.get('student', id, row, 3);
})

$(document).on('click', '#compareUpdateOne', function (e) {
    var row = $(this).parent().parent();
    var id = parseInt($('#updateID').val());
    maskTrigger(row);
    ajax.put('studentmongo', id, row, 2);
    ajax.put('student', id, row, 3);
})

$(document).on('click', '#compareUpdate', function (e) {
    var row = $(this).parent().parent();
    maskTrigger(row);
    ajax.put('studentmongo', '', row, 2);
    ajax.put('student', '', row, 3);
})

$(document).on('click', '#compareDeleteOne', function (e) {
    var row = $(this).parent().parent();
    var id = parseInt($('#deleteID').val());
    maskTrigger(row);
    ajax.delete('studentmongodelete', id, row, undefined, 2);
    ajax.delete('studentdelete', id, row, undefined, 3);
})

$(document).on('click', '#compareDelete', function (e) {
    var row = $(this).parent().parent();
    var number = parseInt($('#deleteNumber').val());
    maskTrigger(row);
    ajax.delete('studentmongo', '', row, number, 2);
    ajax.delete('student', '', row, number, 3);
})
