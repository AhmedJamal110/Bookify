//const { data } = require("jquery");

function ShowSuccessMessage(message = 'Save Successfuiily') {
    Swal.fire({
        icon: "success",
        title: "success",
        text: "save succesfully",
    });
}

function ShowErrorssage(message = 'Something Wrong') {
    Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",

    })

}

function onModelBegin() {
    $('body :submit').attr('disabled', 'disabled');
}

function onModelCompelet() {
    $('body : submit').removeAttrattr('disabled')
}


function onModalSuccess(item) {
    ShowSuccessMessage()
    $('#Modal').modal('hide')

    $('tbody').append(item)

    KTMenu.init();
    KTMenu.initHandlers();
}

$(document).ready(function () { 
    var message = $('#Message').text();
    if (message != '') {
     ShowSuccessMessage(message);
    }
})


    $('.js-render-modal').on('click', function () {
        
        var btn = $(this)
        var modal = $('#Modal');

        modal.find('#ModalLabel').text(btn.data('title'))

        $.get({

               url: btn.data('url'),
            
            success: function (form) {
                modal.find('.modal-body').html(form);
                $.validator.unobtrusive.parse(modal);


            },
            error: function () {
                ShowErrorssage();
            } ,
        })


        modal.modal('show');

     })


//// toggel statue 

$('table').DataTable();

$(document).ready(function () {
    $('body').delegate('.js-toggle-status', 'click', function () {
        console.log("kldsacsldj")
        var btn = $(this);

        bootbox.confirm({
            message: 'Are you sure to toggle this item?',
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-primary'
                }
            },
            callback: function (result) {
                if (result) {

                    $.post({
                        url: btn.data('url'),
                        data: {
                            '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                        },
                        success: function (latUpdatedOn) {
                            var status = btn.parents('tr').find('.js-stauts')
                            var newStatus = status.text().trim() === 'Deleted' ? 'Available' : 'Deleted';
                            status.text(newStatus).toggleClass(' badge-light-success  badge-light-danger')
                            ///lastUpdateOn
                            btn.parents('tr').find('.js-last-update').html(latUpdatedOn)
                            btn.parents('tr').addClass('animate__animated animate__flash')

                            ShowSuccessMessage();
                            // Swal.fire({
                            //     icon: "success",
                            //     title: "success",
                            //     text: "save succesfully",
                            // });
                        },

                        error: function () {
                            Swal.fire({
                                icon: "error",
                                title: "Oops...",
                                text: "Something went wrong!",
                                footer: '<a href="#">Why do I have this issue?</a>'
                            });
                        }



                    })

                }





            }
        });





    })


});