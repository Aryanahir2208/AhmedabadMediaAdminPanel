function GridPagination(gridName, pageNo, urlCallBackMethodName, columnName) {
    $("#" + gridName + "PageNo").val(pageNo);
    var sortDirection = $("#" + gridName + "SortDirection").val();
    var previousSort = $("#" + gridName + "CurrentSort").val();
    if (!IsNullOrEmptyString(columnName)) {
        if (columnName == previousSort) {
            if (sortDirection == "asc") {
                $("#" + gridName + "SortDirection").val('desc');

            }
            else {
                $("#" + gridName + "SortDirection").val('asc');
            }
        }
        else {
            $("#" + gridName + "SortDirection").val('asc');
            sortDirection = 'asc';
        }
    } else {
        columnName = previousSort;
        sortDirection = 'desc';
    }
    var obj = $(".gridFilterElements");
    var result = [];
    console.log(obj);
    if (obj.length > 0) {
        for (var i = 0; i < obj.length; i++) {
            var objKeyValue = {};
            var ele = obj[i];
            objKeyValue.Text = ele.id;
            objKeyValue.Value = ele.value;
            result.push(objKeyValue);
        }
    }
    console.log(result);
    var pageIndex = IsValueUndefinedOrNull($("#" + gridName + "PageNo").val()) ? jsConfigDefaultPageNo : $("#" + gridName + "PageNo").val();
    var pageSize = IsValueUndefinedOrNull($("#" + gridName + "PageSize").val()) ? jsConfigDefaultPageSize : $("#" + gridName + "PageSize").val();
    //fnShowMainProgress();
    $.ajax({
        type: 'GET',
        url: urlCallBackMethodName,
        data: { pageIndex: pageIndex, pageSize: pageSize, filterObj: JSON.stringify(result), columnName: columnName, sortDirection: sortDirection },
        async: true,
        contenttype: "application/json; charset=utf-8",
        datatype: 'json',
        success: function (data) {
            //fnHideMainProgress();
            $("#" + gridName).html(data);
            $("#" + gridName + "PageSize").val(pageSize);
            $("#" + gridName + "SortDirection").val(sortDirection);
            $("#" + gridName + "CurrentSort").val(columnName);
            var ele = $('#' + columnName);
            if (ele != null) {
                var upperArrow = '<i class="bi bi-arrow-up"></i>';
                var downArrow = '<i class="bi bi-arrow-down"></i>';
                if (sortDirection == "asc") {
                    $(ele).append(upperArrow);
                }
                else {
                    $(ele).append(downArrow);
                }
            }
        },
        error: function (req, status, error) {
            fnHideMainProgress();
            fnShowError(error);
        }
    });
}

function ToggleSortDirectionOfGridColumn(gridName) {
    //debugger;
    console.log("Col - ",this)
    if (!IsUndefinedOrNull($("#" + gridName + "SortDirection"))) {
        if ($("#" + gridName + "SortDirection").val().toLowerCase() == 'asc') {
            $("#" + gridName + "SortDirection").val('desc');
        }
        else {
            $("#" + gridName + "SortDirection").val('asc');
        }
    }
}
function GetPaginationParameters(gridName, pageNo, columnName) {

    $("#" + gridName + "PageNo").val(pageNo);
    var sortDirection = $("#" + gridName + "SortDirection").val();
    var previousSort = $("#" + gridName + "CurrentSort").val();
    if (!IsNullOrEmptyString(columnName)) {
        if (columnName == previousSort) {
            if (sortDirection == "asc") {
                $("#" + gridName + "SortDirection").val('desc');

            }
            else {
                $("#" + gridName + "SortDirection").val('asc');
            }
        }
        else {
            $("#" + gridName + "SortDirection").val('asc');
            sortDirection = 'asc';
        }
    } else {
        columnName = previousSort;
        sortDirection = 'desc';
    }

    var pageIndex = IsValueUndefinedOrNull($("#" + gridName + "PageNo").val()) ? jsConfigDefaultPageNo : $("#" + gridName + "PageNo").val();
    var pageSize = IsValueUndefinedOrNull($("#" + gridName + "PageSize").val()) ? jsConfigDefaultPageSize : $("#" + gridName + "PageSize").val();

    return {
        pageIndex: pageIndex,
        pageSize: pageSize,
        columnSort: columnName + ' ' + sortDirection
    }
}
function Clearfilter() {
    var obj = $(".gridFilterElements");
    if (obj.length > 0) {
        for (var i = 0; i < obj.length; i++) {
            var objKeyValue = {};
            var ele = obj[i];
            objKeyValue.Text = ele.id;
            ele.value ='';
        }
    }
}