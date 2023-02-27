// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function someFunction(index) {
    if (confirm("هل تريد حذف الماده؟")) {
        $.ajax({
            type: 'POST',
            data: { index: index },
            url: '/student/DeleteRecordFromTable',
            success: function (Data) {
                $('#tableIdcourses').html(Data);
            },
            error: function () { console.log('there are an error!!!') },

        });
    }
}