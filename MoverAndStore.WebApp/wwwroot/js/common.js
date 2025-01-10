$(document).ajaxError(function myErrorHandler(event, xhr, ajaxOptions, thrownError) {
    showErrorDialog('Error', 'An error occurred while processing your request, please contact technical support for assistance.');
});

$(".btn-export-to-excel").on("click", function () {
    var targetElement = $(this).attr('data-target-itemid');
    var fileName = $(this).attr('data-target-filename');

    var data = {};
    var table = $('#' + targetElement).DataTable().data().toArray();

    for (var i = 0; i < table.length; i++) { //i=13
        for (var j = 0; j < table[i].length; j++) { // j=11 = 0
            table[i][j] = table[i][j].replace(/(<([^>]+)>)/ig, '');
        }
    }
    data.body = table;
    var headers = [];
    var header = $('#' + targetElement).DataTable().context[0].aoColumns;
    for (var i = 0; i < header.length; i++) {
        var header_obj = header[i].sTitle;
        if (header_obj.length > 250) {
            header_obj = header_obj.replace(header_obj, 'Action');
        }
        headers.push(header_obj);
    }
    data.header = headers;

    if (data.body.length > 0) {
        var tableData = [];
        for (const row of data.body) {
            var rowObject = {};
            var index = 0;
            for (const cellKey in row) {
                if (typeof row[cellKey] === 'string') { // Check if cell is a string
                    var cell = row[cellKey].replace(/(<([^>]+)>)/ig, ''); // Remove HTML tags
                    rowObject[data.header[index]] = cell;
                    index++;
                }
                else {
                    if (row[index]?.display != undefined && row[index]?.display != null && row[index]?.display != "") {
                        rowObject[data.header[index]] = row[index]?.display;
                        index++;
                    }
                }
            }
            tableData.push(rowObject);
        }
        $("#frmDownloadExcelData").val(JSON.stringify(tableData));
        $("#frmDownloadExcelFileName").val(fileName);
        $("#frmDownloadExcel").submit();
    }
    else {
        toastr.error(fileTitle + " does not have sufficient data to generate excel.");
    }
});

function showErrorDialog(title, text) {
    Swal.fire({
        icon: 'error',
        title: title,
        showClass: {
            popup: 'animate__animated animate__fadeInDown animate__slow'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp animate__fast'
        },
        text: text,
        confirmButtonColor: '#04a9f5',
    })
}

function showSuccessDialog(title, text) {
    Swal.fire({
        icon: 'success',
        title: title,
        showClass: {
            popup: 'animate__animated animate__fadeInDown animate__slow'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp animate__fast'
        },
        text: text,
        confirmButtonColor: '#04a9f5',
    })
}

function showConfirmDialog(title, successCallback, errorCallback) {
    Swal.fire({
        title: title,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#04a9f5',
        cancelButtonColor: '#62747D',
        confirmButtonText: 'Confirm'
    }).then(successCallback).catch(errorCallback);
}

function makeButtonProgress(btnSelector, text) {
    $(btnSelector).text(text);
    $(btnSelector).prop('disabled', true);
}

function makeButtonOriginal(btnSelector, text, featherIcon) {
    $(btnSelector).html("<span class='" + featherIcon + "'></span> " + text);
    $(btnSelector).prop('disabled', false);
}

function notifySuccess(alertSelector, addAlertClass, message) {
    $(alertSelector).show();
    $(alertSelector).addClass(addAlertClass);
    $(alertSelector).css('padding', '10px 10px');
    $(alertSelector).html(message);
}

function notifyError(alertSelector, removeAlertClass, message) {
    $(alertSelector).show();
    $(alertSelector).addClass(removeAlertClass);
    $(alertSelector).css('padding', '10px 10px');
    $(alertSelector).html(message);
}

function displayRenderView(addSelectorView, removeSelectorView, Addclass) {
    $(addSelectorView).addClass(Addclass);
    $(removeSelectorView).removeClass(Addclass);
}


function updateDropdown(selector, url, defaultHTML) {
    const dropdown = $(selector);
    dropdown.html('<option value="">Loading...</option>');

    $.ajax({
        url: url,
        success: function (response) {
            dropdown.empty().append(defaultHTML);
            if (response && response.length) {
                response.forEach(option => {
                    dropdown.append($('<option>', { value: option.value, text: option.text }));
                });
            }
        },
        error: function (er) {
            dropdown.empty().append(defaultHTML);
            showErrorDialog('Error', er.message);
        }
    });
}

function resetDropdown(selector, defaultHTML) {
    $(selector).html('<option value="">Select ' + defaultHTML + '</option>');
}


function allowOnlyCharacter(selector) {
    var selectorArray = selector.split(", ");
    for (let i = 0; i <= selector.split(", ").length; i++) {
        $(selectorArray[i]).on('keypress', function (e) {
            const charCode = e.which || e.keyCode;
            if (!(charCode >= 65 && charCode <= 90 || charCode >= 97 && charCode <= 122))
                e.preventDefault();
        });
    }
}

function allowOnlyDigit(selector) {
    var selectorArray = selector.split(", ");
    for (let i = 0; i <= selector.split(", ").length; i++) {
        $(selectorArray[i]).on('keypress', function (e) {
            const charCode = e.which || e.keyCode;
            if (!(charCode >= 48 && charCode <= 57))
                e.preventDefault();
        });
    }
}