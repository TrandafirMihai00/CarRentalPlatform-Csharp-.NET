var dataTable;

$(document).ready(function () {
    loadDataTable();
   
});

function loadDataTable() {
    dataTable = $('#tableMasini').DataTable({
        "ajax": {
            "url":"/Manager/Masina/GetAll"
        },
        "columns": [
            { "data": "modelMasina", "width": "10%" },
            { "data": "marcaMasina.denumireMarca", "width": "10%" },
            { "data": "anFabricatie", "width": "10%" },
            { "data": "disponibilitateMasina", "width": "10%" },
            { "data": "numarInmatriculare", "width": "10%" },
            { "data": "tipCombustibil", "width": "10%" },
            { "data": "tipCutieViteza", "width": "10%" },
            { "data": "masaTotala", "width": "10%" },
            { "data": "numarUsi", "width": "10%" },
            {
                "data": "idMasina",
                "render": function (data) {
                    return `
                        <div class="btn-group" role="group">
                            <a class="btn btn-primary" href="/Manager/Masina/Upsert?idMasina=${data}"> <i class="bi bi-pencil-square"></i>
                                Editare
                            </a>
                            <a onClick=Stergere('/Manager/Masina/Stergere/${data}') class="btn btn-danger"> <i class="bi bi-trash-fill"></i>
                                Stergere
                            </a>
                        </div>
                        `
                },
                "width": "10%"
            },
        ] 
    });
} 

function Stergere(url) {
    Swal.fire({
        title: 'Esti sigur?',
        text: "Datele nu vor putea fi recuperate!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Da, sterge!',
        cancelButtonText: 'Nu!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}