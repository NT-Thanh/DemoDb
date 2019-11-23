$(document).ready(function () {
    ajax = {
        get: function (url, id, row) {
            if (id == undefined) {
                id = '';
            }
            return $.ajax({
                url: url + "/" + id,
                type: 'GET',
                dataType: 'json'
            })
                .always(function () {

                })
                .fail(function () {

                })
        },
        put: function (url, id, row) {
            if (id == undefined) {
                id = '';
            }
            return $.ajax({
                url: url + "/" + id,
                type: 'PUT',
                dataType: 'json'
            })
                .always(function () {

                })
                .fail(function () {

                })
        },
        delete: function (url, id, row, number) {
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
                .always(function () {

                })
                .fail(function () {

                })
        }
    }
})

$(document).on('click', '#compareGet', function (e) {
    var row = $(this).parent().parent();
    ajax.get('studentmongo').done(function (res) {
        row.find('td').eq(2).text(res);
    })
    ajax.get('student').done(function (res) {
        row.find('td').eq(3).text(res);
    })
})

$(document).on('click', '#compareGetOne', function (e) {
    var row = $(this).parent().parent();
    var id = parseInt($('#searchID').val());
    ajax.get('studentmongo', id).done(function (res) {
        row.find('td').eq(2).text(res);
    })
    ajax.get('student', id).done(function (res) {
        row.find('td').eq(3).text(res);
    })
})

$(document).on('click', '#compareUpdateOne', function (e) {
    var row = $(this).parent().parent();
    var id = parseInt($('#updateID').val());
    ajax.put('studentmongo', id).done(function (res) {
        row.find('td').eq(2).text(res);
    })
    ajax.put('student', id).done(function (res) {
        row.find('td').eq(3).text(res);
    })
})

$(document).on('click', '#compareUpdate', function (e) {
    var row = $(this).parent().parent();
    ajax.put('studentmongo').done(function (res) {
        row.find('td').eq(2).text(res);
    })
    ajax.put('student').done(function (res) {
        row.find('td').eq(3).text(res);
    })
})

$(document).on('click', '#compareDeleteOne', function (e) {
    var row = $(this).parent().parent();
    var id = parseInt($('#deleteID').val());
    ajax.delete('studentmongodelete', id).done(function (res) {
        row.find('td').eq(2).text(res);
    })
    ajax.delete('studentdelete', id).done(function (res) {
        row.find('td').eq(3).text(res);
    })
})

$(document).on('click', '#compareDelete', function (e) {
    var row = $(this).parent().parent();
    var number = parseInt($('#deleteNumber').val());
    ajax.delete('studentmongo', '', undefined, number).done(function (res) {
        row.find('td').eq(2).text(res);
    })
    ajax.delete('student', '', undefined, number).done(function (res) {
        row.find('td').eq(3).text(res);
    })
})
