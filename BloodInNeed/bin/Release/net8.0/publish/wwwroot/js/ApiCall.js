var ApiCall = {
    get: function (url, data, successCallback, failureCallback, isSync = true) {
        $.ajax({
            url: url
            , type: 'GET'
            , data: data
            , dataType: 'json'
            , contentType: "application/json"
            , success: function (result) {
                if (isSync) {
                    ////hideProcessing();
                    successCallback(result);
                }
                else {
                    successCallback(result);
                    ////hideProcessing();
                }
            }
            , error: function (xhr, s, e) {
                ApiCall.checkAjaxFailure(xhr);
                failureCallback(xhr, s, e);
                ////hideProcessing();
            }
        });
    }
    , post: function (url, data, successCallback, failureCallback, isSync = true) {
        $.ajax({
            url: url
            , type: 'POST'
            , data: JSON.stringify(data)
            , dataType: 'json'
            , contentType: "application/json"
            , success: function (result) {
                if (isSync) {
                    ////hideProcessing();
                    successCallback(result);
                }
                else {
                    successCallback(result);
                    ////hideProcessing();
                }
            }
            , error: function (xhr, s, e) {
                ApiCall.checkAjaxFailure(xhr);
                failureCallback(xhr, s, e);
                ////hideProcessing();
            }
        });
    }
    , upload: function (url, data, successCallback, failureCallback) {
        $.ajax({
            url: url
            , type: 'POST'
            , data: data
            , contentType: false
            , processData: false
            , success: successCallback
            , success: function (result) {
                successCallback(result);
                ////hideProcessing();
            }
            , error: function (xhr, s, e) {
                ApiCall.checkAjaxFailure(xhr);
                failureCallback(xhr, s, e);
                //hideProcessing();
            }
        });
    }
    , checkAjaxFailure: function (xhr) {
        console.log(xhr);
        if (xhr.status == 401)
            askLogin();
        else if (xhr.status == 403) {
            alert('warning', $.parseJSON(xhr.responseText).message);
        }
        else alert('error', 'Something went wrong while processing your request. Please try again');
    }
}

var ServiceCall = {
    post: function (url, data, successCallback, failureCallback) {
        showProcessing();
        $.ajax({
            url: url
            , type: 'POST'
            , contentType: "application/json; charset=utf-8"
            , data: JSON.stringify(data)
            , dataType: "json"
            , success: function (result) {
                successCallback(result);
                //hideProcessing();
            }
            , error: function (xhr, s, e) {
                ServiceCall.checkAjaxFailure(xhr);
                failureCallback(xhr, s, e);
                //hideProcessing();
            }
        });
    }
    , get: function (url, data, successCallback, failureCallback) {
        showProcessing();
        $.ajax({
            url: url
            , type: 'GET'
            , contentType: "application/json; charset=utf-8"
            , data: data
            , dataType: "json"
            , success: function (result) {
                successCallback(result);
                //hideProcessing();
            }
            , error: function (xhr, s, e) {
                ServiceCall.checkAjaxFailure(xhr);
                failureCallback(xhr, s, e);
                //hideProcessing();
            }
        });
    }
    , upload: function (url, data, successCallback, failureCallback) {
        showProcessing();
        $.ajax({
            url: url
            , type: 'POST'
            , contentType: false
            , processData: false
            , data: data
            , success: function (result) {
                successCallback(result);
                //hideProcessing();
            }
            , error: function (xhr, s, e) {
                ServiceCall.checkAjaxFailure(xhr);
                failureCallback(xhr, s, e);
                //hideProcessing();
            }
        });
    }
    , checkAjaxFailure: function (xhr) {
        if (xhr.status == 401) askLogin();
        else if (xhr.status == 403) alert('warning', xhr.statusText);
        else alert('error', 'Something went wrong while processing your request. Please try again');
    }
}

var HandlerCall = {
    post: function (url, data, successCallback, failureCallback) {
        showProcessing();
        $.ajax({
            url: url
            , type: 'POST'
            , data: data
            , dataType: "json"
            , success: function (result) {
                successCallback(result);
                //hideProcessing();
            }
            , error: function (xhr, s, e) {
                ServiceCall.checkAjaxFailure(xhr);
                //failureCallback(xhr, s, e);
                //hideProcessing();
            }
        });
    }
    , checkAjaxFailure: function (xhr) {
        if (xhr.status == 401) askLogin();
        else if (xhr.status == 403) alert('warning', xhr.statusText);
        else alert('error', 'Something went wrong while processing your request. Please try again');
    }
};
var HandlerCallPromise = {
    post: function (url, data) {
        showProcessing();
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: 'POST',
                data: data,
                dataType: "json",
                success: function (result) {
                    //hideProcessing();
                    resolve(result);
                },
                error: function (xhr, s, e) {
                    ServiceCall.checkAjaxFailure(xhr);
                    //hideProcessing();
                    reject(xhr, s, e);
                }
            });
        });
    },
    checkAjaxFailure: function (xhr) {
        if (xhr.status == 401) askLogin();
        else if (xhr.status == 403) alert('warning', xhr.statusText);
        else alert('error', 'Something went wrong while processing your request. Please try again');
    }
};