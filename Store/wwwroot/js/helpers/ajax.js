function callAjax(url, postdata, callbackfunc, param, method) {
    var errorCallback = arguments.length <= 5 || arguments[5] === undefined ? "" : arguments[5];
    method = typeof method !== 'undefined' ? method : 'POST';
    param.url = url;
    //     var loaderMessage =  '<img class="img-responsive" src="/assets/images/ajax-loader.gif">' ;
    //     $(param.elementId).css("pointer-events", "none");
    //     $(param.elementId).block({
    //         message: loaderMessage,
    //    overlayCSS: {
    //             backgroundColor: '#ebebeb',
    //             opacity: 0.6,
    //             zIndex: 1200,
    //             cursor: 'wait'
    //         },
    //         css: {
    //             border: 0,
    //             color: '#3f51b5',
    //             padding: 0,
    //             zIndex: 1201,
    //             backgroundColor: 'transparent'
    //         }
    //     });
    url = 'http://localhost:5208/api/' + url;
    $.ajax({
        type: method,
        data: JSON.stringify(postdata),
        url: url,
        callbackfunc: callbackfunc,
        param: param,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.responseJSON != null && jqXHR.responseJSON.Type != null) {
                // new PNotify({
                //     title: jqXHR.responseJSON.Title,
                //     text: jqXHR.responseJSON.Message,
                //     type: jqXHR.responseJSON.Type,
                //     hide: false,
                //     confirm: {
                //         confirm: true,
                //         buttons: [
                //             {
                //                 text: 'تایید'
                //             }
                //         ]
                //     },
                //     buttons: {
                //         closer: false,
                //         sticker: false
                //     },
                //     history: {
                //         history: false
                //     }
                // });
            }
            else {
                // new PNotify({
                //     title: "خطا",
                //     text: errorThrown,
                //     type: "error",
                //     hide: false,
                //     confirm: {
                //         confirm: true,
                //         buttons: [
                //             {
                //                 text: 'تایید'
                //             }
                //         ]
                //     },
                //     buttons: {
                //         closer: false,
                //         sticker: false
                //     },
                //     history: {
                //         history: false
                //     }
                // });
            }
            // $(param.elementId).unblock();
            // $(param.elementId).css("pointer-events", "unset");
        },
        success: function (serverResponse) {
            if (serverResponse !== null) {
                this.param.data = serverResponse.Data;
                this.param.serverResponse = serverResponse;
                if (callbackfunc != null && window.jQuery.type(callbackfunc) == "function") {
                    eval(callbackfunc)(this.param);
                }
            }
            else {
                if (errorCallback != "") {
                    eval(errorCallback)(serverResponse);
                }
                else {
                    // new PNotify({
                    //     title: "خطا",
                    //     text: serverResponse.message,
                    //     type: "error",
                    //     hide: false,
                    //     confirm: {
                    //         confirm: true,
                    //         buttons: [
                    //             {
                    //                 text: 'تایید'
                    //             }
                    //         ]
                    //     },
                    //     buttons: {
                    //         closer: false,
                    //         sticker: false
                    //     },
                    //     history: {
                    //         history: false
                    //     }
                    // });
                }
            }
            // $(param.elementId).unblock();
            // $(param.elementId).css("pointer-events", "unset");
        }
    });
}

function callAjaxWithPostData(url, postdata, callbackfunc, param, method) {
    var errorCallback = arguments.length <= 5 || arguments[5] === undefined ? "" : arguments[5];
    method = typeof method !== 'undefined' ? method : 'POST';
    param.url = url;
    var loaderMessage = (param.noText)
        ? '<img class="img-responsive" src="/assets/images/ajax-loader.gif">'
        : '  <div class="container loader"><div class="shape shape-1"></div><div class="shape shape-2"></div><div class="shape shape-3"></div><div class="shape shape-4"></div></div>';
    $(param.elementId).css("pointer-events", "none");
    $(param.elementId).block({
        message: loaderMessage,
        overlayCSS: {
            backgroundColor: '#ebebeb',
            opacity: 0.6,
            zIndex: 1200,
            cursor: 'wait'
        },
        css: {
            border: 0,
            color: '#3f51b5',
            padding: 0,
            zIndex: 1201,
            backgroundColor: 'transparent'
        }
    });

    $.ajax({
        type: method,
        data: postdata,
        url: config.ajax.root + url,
        callbackfunc: callbackfunc,
        param: param,
        contentType: false,
        dataType: "json",
        encType: "multipart/form-data",
        async: true,
        processData: false,
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.responseJSON != null && jqXHR.responseJSON.Type != null) {
                swal({
                    title: jqXHR.responseJSON.Title,
                    type: jqXHR.responseJSON.Type,
                    html: jqXHR.responseJSON.Message,
                    confirmButtonColor: "rgb(180, 180, 180)",
                    showCancelButton: false,
                    confirmButtonText:
                        '<i class="fa fa-thumbs-up"></i> بستن'
                });
            }
            else {
                swal({
                    title: "خطا",
                    type: "error",
                    html: errorThrown,
                    confirmButtonColor: "rgb(180, 180, 180)",
                    showCancelButton: false,
                    confirmButtonText:
                        '<i class="fa fa-thumbs-up"></i> بستن'
                });
            }
            $(param.elementId).unblock();
            $(param.elementId).css("pointer-events", "unset");
        },
        success: function (serverResponse) {
            if (serverResponse.error == null) {
                this.param.data = serverResponse.response;
                this.param.serverResponse = serverResponse;
                if (callbackfunc != null && window.jQuery.type(callbackfunc) == "function") {
                    eval(callbackfunc)(this.param);
                }
            }
            else {
                if (errorCallback != "") {
                    eval(errorCallback)(serverResponse);
                }
                else {
                    swal({
                        title: 'خطا',
                        type: 'error',
                        text: serverResponse.message,
                        confirmButtonColor: "rgb(180, 180, 180)",
                        showCancelButton: false,
                        confirmButtonText: 'بستن'
                    });
                }
            }
            $(param.elementId).unblock();
            $(param.elementId).css("pointer-events", "unset");
        }
    });
}


function alertS() {

    // Swal.fire({
    //   title: "از ثبت نظرات خود مطمئنید؟",
    //   icon: "question",
    //   iconHtml: "؟",
    //   confirmButtonText: "بله",
    //   cancelButtonText: "یخ",
    //   showCancelButton: true,
    //   showCloseButton: true
    // }).then((result) => {
    //     if (result.isConfirmed) {
    //       Swal.fire({
    //         title: "نتیجه!",
    //         text: "نظر شما محترم!",
    //         icon: "success"
    //       });
    //     }
    //   });
}
