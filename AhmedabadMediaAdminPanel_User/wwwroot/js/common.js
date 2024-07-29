$(document).ready(() => {
    //To set selected menu as a active menu
    if (jsCurrentMenuId == 54 || jsCurrentMenuId == 0) {
        $('#dashboard').addClass('active');
    }
    else {
        var ele = $('.child-menu').first();
        if (jsCurrentMenuId != 0) {
            ele = $("[id='" + jsCurrentMenuId + "']");
        }

        ele.parent().parent().parent().find('a').click();
        ele.addClass('active');
        ele.parent().parent().parent().find('a').addClass("selected-menu");
        $('.sub-menu-arrow').removeClass("rotate-in");
        ele.parent().parent().parent().find('a').find('.sub-menu-arrow').addClass('rotate-in');
    }
})

//success popup
function fnSweetMessage(msgType, title, message, confirmButtonText = "Ok", showCancelButton = false, confirmButtonColor = '#5149e5') {
    return swal({
        title: title,
        text: message,
        icon: msgType,
        buttons: {
            cancel: {
                text: "Cancel",
                visible: showCancelButton,
                className: 'btn btn-secondary',
            },
            confirm: {
                text: confirmButtonText,
                className: 'btn btn-primary',
                closeModal: true
            }
        },
        dangerMode: false,
        closeOnClickOutside: false, // Disable clicking outside the popup
    });
}

//error popup
function fnShowError(error) {
    swal({
        title: "Oops!",
        text: error,
        icon: "error",
        dangerMode: true
    });
}

function IsNullOrEmptyString(str) {
    if (str == undefined || str == "" || str == null || str.trim() == "")
        return true;

    return false;
}

function IsUndefinedOrNull(obj) {
    if (obj == undefined || obj == null)
        return true;

    return false;
}

function IsValueUndefinedOrNull(val) {
    if (val == undefined || val == null)
        return true;

    return false;
}

function fnAddValidationErrorClass(element) {
    var id = element.attr('id');
    var errorSpanId = "#error_" + id;
    $(errorSpanId).show();
    element.addClass('border border-danger');
    element.focus();
}


//Remove error message from span tag
function fnRemoveValidationMessage(event) {
    var id = event.id;
    $(event).removeClass("border border-danger");
    $('#error_' + id).text('');
}

function fnToggleSidebar() {
    //$('#sidebar-main').toggleClass('d-none');
    $('.layout-wrapper').toggleClass('slider-custom');
    //$('#sidebar-main').toggleClass('slidebar-left');
    $('#sidebar-main').toggleClass('d-none');
}


//Notification Modal
function fnOpenNotificationModal() {
    var myOffcanvas = document.getElementById('notificationOffCanvas');
    var bsOffcanvas = new bootstrap.Offcanvas(myOffcanvas);
    bsOffcanvas.show();
}


//loader
function fnShowMainProgress() {
    //debugger;
    $(".main-loader").removeClass("loader-hide");
    $(".main-loader").addClass("loader-show");
}

function fnHideMainProgress() {
    $(".main-loader").removeClass("loader-show");
    $(".main-loader").addClass("loader-hide");
}


function getNiceScrollResize() {
    setTimeout(function () {
        $(".table-responsive").getNiceScroll().resize();
    },400)
}

function deleteAllCookies() {
    const cookies = document.cookie.split(";");

    for (let i = 0; i < cookies.length; i++) {
        const cookie = cookies[i];
        const eqPos = cookie.indexOf("=");
        const name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}

function fnCallPostMethod(route, menuId) {
    $.ajax({
        type: 'GET',
        url: route,
        data: { menuId: menuId },
        contenttype: "application/json; charset=utf-8",
        datatype: 'json',
        success: function (data) {
            
        },
        error: function (req, status, err) {
            
        }
    });
}

//Email Validation
function CheckEmailValidation(fieldObj) {
    let pattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,10})+$/
    if (pattern.test(fieldObj)) {
        return true;
    }
    else {
        return false;
    }
}
function fnFilterDropDown() {
    var filterCollapse = document.getElementById('filterModel')
    new bootstrap.Collapse(filterCollapse, {
        toggle: true
    });

    getNiceScrollResize();
}

/**
 *  Function to set the value of an input element or default to "N/A"
 */
function setValueOrDefault(element, value) {
    // Check if the provided value is null or an empty string
    if (value === null || value === '') {
        // Set the element's value to "N/A" if the value is null or empty
        $(element).val("N/A");
    } else {
        // Otherwise, set the element's value to the provided value
        $(element).val(value);
    }
}

/**
 * Function to set the text of an element or default to "N/A"
 */
function setTextOrDefault(element, value) {
    // Check if the provided value is null or an empty string
    if (value === null || value === '') {
        // Set the element's text to "N/A" if the value is null or empty
        $(element).text("N/A");
    } else {
        // Otherwise, set the element's text to the provided value
        $(element).text(value);
    }
}