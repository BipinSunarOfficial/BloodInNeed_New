
var apiUrl = '/api/signup/';
var apiUrlSendCode = '/api/sendcode/';

var VerifyLogin = {

    init: function () {


        //const codeInput = $('#codeInput');
        //const verifyBtn = $('#verifyBtn');
        //const messageDiv = $('#message');

        $('#codeInput').on('input', function () {
            const valid = /^\d{6}$/.test($('#codeInput').val());
            $('#verifyBtn').prop('disabled', !valid);
            $('#message').text('');
        });


        $('#verifyBtn').on('click', function () {
            
            showProcessing();

            var data = {
                Email: $('#VerificationEmail').val(),
                Code: $('#codeInput').val()
            }

            ApiCall.post(apiUrl + 'VerifyEmail', data, function (result) {
                VerifyLogin.VerifyCodeCallBack(result);
            }, VerifyLogin.failureCallback);

        });


        $('#resendCode').on('click', function () {
            
            showProcessing();

            var data = {
                Email: $('#VerificationEmail').val(),
                Type: 'Resend'
            }

            ApiCall.post(apiUrlSendCode + 'SendCode', data, function (result) {
                VerifyLogin.ReSendCodeCallBack(result);
            }, VerifyLogin.failureCallback);

        });


    }

    , VerifyCodeCallBack: function (result) {

        if (result.msgType === "success") {
            showProcessing();
            
            setTimeout(() => {
                window.location.href = "/Login/Index";
                showToast(result.msg, "success"); // Display success toast

                hideProcessing();
            }, 5000); // Wait 3 seconds before redirecting
        } else {
            $('#message').text(result.msg);
            $('#message').show();
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();

    }
    
    , ReSendCodeCallBack: function (result) {

        if (result.msgType === "success") {
            showProcessing();
            
            setTimeout(() => {
                window.location.href = "/Login/VerifyEmail?Email=" + result.value;
                showToast(result.msg, "success"); // Display success toast

                hideProcessing();
            }, 5000); // Wait 5 seconds before redirecting
        } else {
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();

    }


    , failureCallback: function () {

        console.log("Api Call Failed.");
        
    }


 }

VerifyLogin.init();


