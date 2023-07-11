var dataTable;

//load all document
$(document).ready(function () {
    loadDataTable();
});

// from controller
function loadDataTable() {
    dataTable = $('#tblFilms').DataTable({
        "ajax": {
            "url": "/Films/GetAllFilms",
            "type": "GET",
            "datatype": "json"
            //"dataSrc": function (json) {
            //    console.log(json); // Imprimir la respuesta en la consola
            //    return json.data;
            //}
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "20%" },
            { "data": "description", "width": "30%" },
            { "data": "classification", "width": "10%" }, 
            { "data": "duration", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                          <a href="/Films/Edit/${data}" class="btn btn-success text-white" style="cursor: pointer;">Edit</a>
                          &nbsp;
                          <a onClick="Delete('/Films/Delete/${data}')" class="btn btn-danger text-white" style="cursor: pointer;">Delete</a>
                    </div>`;
                },
                "width": "25%"
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

