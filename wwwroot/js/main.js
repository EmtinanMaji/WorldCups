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

//hotel
function search_hotel(Ateam1) {
    $.ajax({
        url: "Search_Hotel",
        type: "POST",
        data: { Ateam1: Ateam1 },

        success: function (result) {

            $("#hotelcontainer").html(result);
        }
    });
}

function confirm_delete_hotel() {
    $.ajax({
        url: "DeleteHotel",
        type: "get",
        data: { id: get_id },

        success: function (result) {
            $("#hotelcontainer").html(result); // to refresh the partile

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

//Stadiums
function search_stadiums(Name) {
    $.ajax({
        url: "Search_Stadiums",
        type: "POST",
        data: { Name: Name },

        success: function (result) {

            $("#stadiumscontainer").html(result);
        }
    });
}

function confirm_delete_stadiums() {
    $.ajax({
        url: "DeleteStadiums",
        type: "get",
        data: { id: get_id },

        success: function (result) {
            $("#stadiumscontainer").html(result); // to refresh the partile

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

//TableFootball
function search_tableFootball(Name) {
    $.ajax({
        url: "Search_TableFootball",
        type: "POST",
        data: { Name: Name },

        success: function (result) {

            $("#tableFootballcontainer").html(result);
        }
    });
}

function confirm_delete_tableFootball() {
    $.ajax({
        url: "DeleteTableFootball",
        type: "get",
        data: { id: get_id },

        success: function (result) {
            $("#tableFootballcontainer").html(result); // to refresh the partile

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

function booking(hotelId) {
    alert(`Hotel with ID: ${hotelId} is booked!`);
}