var dataTable;

$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $('#tblData').DataTable({
        order: [[1, 'asc']],
        ajax: {
            url: "/HeadDepartment/CourseEnrollment/GetAll"
        },
        columns: [
            { data: 'deptCode', width: "25%" },
            { data: 'classNo',width: "15%" },
            { data: 'semNo',width: "15%" },
            { data: 'acYear', width: "15%" },
            { data: 'courseCode', width: "30%" },
            {
                data: 'cENo',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/HeadDepartment/CourseEnrollment/" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
                "width": "5%"
            },
            {
                data: 'cENo',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/HeadDepartment/CourseEnrollment/" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i></a>
                    </div>`
                },
                "width": "5%"
            }
        ]
    });
}
