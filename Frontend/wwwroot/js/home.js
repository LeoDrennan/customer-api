$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44378/customers',
        type: 'GET',
        success: function (data) {
            var tableBody = $('#customers tbody');
            tableBody.empty();

            $.each(data.customers, function (index, item) {

                var row = '<tr>';
                row += '<td>' + item.id + '</td>';
                row += '<td>' + item.firstName + '</td>';
                row += '<td>' + item.lastName + '</td>';
                row += '<td>' + item.email + '</td>';
                row += '<td>' + item.phoneNumber + '</td>';
                row += '<td><button class="btn btn-primary btn-edit" data-id="' + item.id + '">Edit</button></td>';
                row += '<td><button class="btn btn-danger btn-delete" data-id="' + item.id + '">Delete</button></td>';
                row += '</tr>';
                tableBody.append(row);
            });
        },
        error: function () {
            alert('Failed to load data.');
        }
    });

    $(document).on('click', '.btn-edit', function () {
        var id = $(this).data('id');
        redirectToEdit(id);
    });

    $(document).on('click', '.btn-delete', function () {
        var id = $(this).data('id');
        deleteRecord(id);
    });

    function deleteRecord(id) {
        $.ajax({
            url: 'https://localhost:44378/customers/' + id,
            type: 'DELETE',
            success: function () {
                $('button[data-id="' + id + '"]').closest('tr').remove();
            },
            error: function () {
                alert('Failed to delete record.');
            }
        });
    }

    function redirectToEdit(id) {
        var redirectUrl = '/Home/Edit/' + id;
        window.location.href = redirectUrl;
    }
});
