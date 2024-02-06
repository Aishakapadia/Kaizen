function SwalMessage(heading, message, type) {
    swal(heading, message, type);
}


function SwalComment() {
    //$("#txtProjectId").val('here is the comment');
    swal({
        title: "Please enter reason",
        content: "input",
        buttons: {
            cancel: true,
            confirm: true,
        },
    });
    return false;

}
function ShowMessage(Messagetext, Title, Image) {
    try {
        $.noConflict();
        $("<div class='dialog_content '> <br /> " + Messagetext + "</div>").dialog({

            title: Title.toUpperCase(),
            modal: true,
            overflow: "hidden",
            resizable: false,
            closeOnEscape: false,
            show: 'slide',
            buttons: {
                "Close": function () {

                    $(this).dialog("close");
                }

            }

        });
    }
    catch (e) {
    }
}


function DatePicker(DateControl) {
    try {
        var date_settings = {
            format: "mm/dd/yyyy",
            changeYear: true,
            changeMonth: true,
            yearRange: '1964:2091',
           // defaultDate: new Date()
        }
        var control = $(DateControl);
        if (control != null && control != undefined)
        { $(DateControl).datepicker(date_settings); }
    }
    catch (e) {
        $.noConflict();
        var date_settings = {
            format: "mm/dd/yyyy",
            changeYear: true,
            changeMonth: true,
            yearRange: '1964:2091',
           // defaultDate: new Date()
        }
        var control = $(DateControl);
        if (control != null && control != undefined)
        { $(DateControl).datepicker(date_settings); }
    }

}

function OpenPageInDialogue(PageUrl, item) {
    try {
        $("<div id='tempdiv'> <br/> </div> ").load(PageUrl + "?ReqId=" + item.title).dialog({
            modal: true,
            overflow: "hidden",
            resizable: false,
            show: 'slide',
            width: '900px',
            show: { effect: 'drop', direction: "up" },
            dialogClass: 'no-close success-dialog',
            buttons:
                {
                    "Close": function () {
                        $(".ui-dialog-titlebar-close").trigger('click');
                    }
                }
        });

    } catch (e) {

    }
    return false;
}