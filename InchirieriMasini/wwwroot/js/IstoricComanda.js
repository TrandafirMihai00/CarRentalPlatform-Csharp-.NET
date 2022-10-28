var dataTable;

$(document).ready(function () {
    loadDataTable();
   
});

function loadDataTable() {
    dataTable = $('#tableComenzi').DataTable({
        "ajax": {
            "url":"/Client/Home/GetAll"
        },
        "columns": [
            { "data": "idComanda", "width": "10%" },
            { "data": "applicationUser.email", "width": "10%" },
            { "data": "idMasina", "width": "10%" },
            { "data": "dataInceput", "width": "10%" },
            { "data": "durata", "width": "10%" },
            { "data": "statusPlata", "width": "10%" },
            { "data": "dataComanda", "width": "10%" },
            { "data": "totalComanda", "width": "10%" },
        ] 
    });
} 

