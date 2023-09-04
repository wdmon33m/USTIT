var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        order: [[1, 'asc']],
        ajax: {
            url: "/BasicData/Teacher/GetAll"
        },
        columns: [
            { data: 'teacherName', width: "25%" },
            {
                data: 'academicDegree.academicDegreeEng',width: "30%" },
            { data: 'notes', width: "30%" },
            {
                data: 'teacherNo',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/BasicData/Course/" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
                "width": "5%"
            },
            {
                data: 'teacherNo',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/BasicData/Course/" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i></a>
                    </div>`
                },
                "width": "5%"
            }
        ]
    });
}
