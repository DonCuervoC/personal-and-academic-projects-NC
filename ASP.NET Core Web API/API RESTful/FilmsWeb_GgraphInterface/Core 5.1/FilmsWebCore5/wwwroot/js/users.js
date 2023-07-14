var dataTable;

//load all document
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblUsers').DataTable({
        "ajax": {
            "url": "/Users/GetAllUsers",
            "type": "GET",
            "datatype": "json"
            //"dataSrc": function (json) {
            //    console.log(json); // Imprimir la respuesta en la consola
            //    return json.data;
            //}
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "userName", "width": "25%" },
            { "data": "name", "width": "25%" },
            { "data": "password", "width": "20%" },
            { "data": "role", "width": "20%" }
        ]
    });

    dataTable.on('draw.dt', function () {
        console.log(dataTable.ajax.json()); // Imprimir la respuesta en la consola
    });
}




