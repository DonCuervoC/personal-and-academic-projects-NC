var dataTable;

//load all document
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblCategories').DataTable({
        "ajax": {
            "url": "/Categories/GetAllCategories",
            "type": "GET",
            "datatype": "json"
            //"dataSrc": function (json) {
            //    console.log(json); // Imprimir la respuesta en la consola
            //    return json.data;
            //}
        },
        "columns": [
            { "data": "id", "width": "20%" },
            { "data": "name", "width": "40%" },
            { "data": "dateCreation", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                          <a href="/Categories/Edit/${data}" class="btn btn-success text-white" style="cursor: pointer;">Edit</a>
                          &nbsp;
                          <a onClick="Delete('/Categories/Delete/${data}')" class="btn btn-danger text-white" style="cursor: pointer;">Delete</a>
                    </div>`;
                },
                "width": "20%"
            }
        ]
    });

    dataTable.on('draw.dt', function () {
        console.log(dataTable.ajax.json()); // Imprimir la respuesta en la consola
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete the record?",
        text: "This action cannot be reversed!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

