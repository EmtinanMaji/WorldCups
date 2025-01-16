var get_id;
function showmessage(id)
{
    get_id = id;
    $('#del').modal('show')

}
function confirm_delete() {
    window.location.href = "DeleteCategories?id=" + get_id //connect with backend
}

function search(Name) {
    $.ajax({
        url: "Search",
        type: "POST",
        data: { Name: Name },

        success: function (result) {

            $("#categriescontainer").html(result);
        }
        });
}

function confirm_delete1()
{
    $.ajax({
        url: "DeleteCategories",
        type: "get",
        data: { id: get_id },

        success: function (result) {

            //window.location.href = "Categories" // to refresh the page
            $("#categriescontainer").html(result); // to refresh the partile
            
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                title: "  تم الحذف بنجاح "
            });
            


        }


    });

}