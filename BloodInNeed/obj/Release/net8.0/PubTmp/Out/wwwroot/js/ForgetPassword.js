
var apiUrl = '/api/login/';
//var apiUrlSendCode = '/api/sendcode/';

var ForgetPassword = {

    init: function () {


        // Email validation
        $('#userEmail').on('input', function () {
            const email = $(this).val();
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Simple email regex

            if (emailPattern.test(email)) {
                $('#emailError').hide();
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $('#emailError').show();
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            ForgetPassword.CheckInValidClass(); // Check button state
        });


        // Password validation
        $('#userPassword').on('input', function () {
            const password = $(this).val();
            const strongPasswordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

            if (strongPasswordPattern.test(password)) {
                $('#userPasswordError').hide();
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $('#userPasswordError').show();
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            ForgetPassword.CheckInValidClass(); // Check button state
        });


        // Retype Password validation
        $('#userRePassword').on('input', function () {
            const password = $('#userPassword').val();
            const rePassword = $(this).val();

            if (password === rePassword && rePassword !== '') {
                $('#rePasswordError').hide();
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $('#rePasswordError').show();
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            ForgetPassword.CheckInValidClass(); // Check button state
        });


        $('#codeInput').on('input', function () {
            const valid = /^\d{6}$/.test($('#codeInput').val());
            $('#verifyBtn').prop('disabled', !valid);
            $('#message').text('');
        });


        $('#sendCodeBtn').on('click', function () {
            
            showProcessing();

            var data = {
                Email: $('#userEmail').val(),
                Code: 0
            }

            ApiCall.post(apiUrl + 'CheckUser', data, function (result) {
                ForgetPassword.CheckUserCallBack(result);
            }, ForgetPassword.failureCallback);

        });



        $('#verifyBtn').on('click', function () {

            showProcessing();

            var data = {
                Email: $('#userEmail').val(),
                Code: $('#resetCode').val()
            }

            ApiCall.post(apiUrl + 'VerifyResetCode', data, function (result) {
                ForgetPassword.VerifyResetCodeCallBack(result);
            }, ForgetPassword.failureCallback);

        });




        $('#resetBtn').on('click', function () {

            showProcessing();

            var data = {
                Email: $('#currentuserEmail').val(),
                Password: $('#userPassword').val()
            }

            ApiCall.post(apiUrl + 'ResetPassword', data, function (result) {
                ForgetPassword.ResetPasswordCallBack(result);
            }, ForgetPassword.failureCallback);

        });


    }

    , CheckInValidClass: function () {
        // Check for invalid classes or empty required fields
        const hasInvalid = $('.is-invalid').length > 0;

        // Ensure all required fields are filled
        
        const isEmailFilled = $('#userEmail').val().trim() !== '';
        const isPasswordFilled = $('#userPassword').val().trim() !== '';
        const isRePasswordFilled = $('#userRePassword').val().trim() !== '';
        

        const isFormValid =
            !hasInvalid &&

            isEmailFilled;
            //&&
            //isPasswordFilled &&
            //isRePasswordFilled;

        // Enable/Disable the register button
        $('#sendCodeBtn').prop('disabled', !isFormValid);


        const isPasswordValid =
            !hasInvalid &&
        isPasswordFilled &&
        isRePasswordFilled;

        
        $('#resetBtn').prop('disabled', !isPasswordValid);


    }


    , CheckUserCallBack: function (result) {

        if (result.msgType === "success") {
            showProcessing();
            
            //setTimeout(() => {
            //    window.location.href = "/Login/Index";
            //    showToast(result.msg, "success"); // Display success toast

            //    hideProcessing();
            //}, 5000); // Wait 3 seconds before redirecting

            showToast(result.msg, "success");

            $('#currentuserEmail').val(result.value);

            $('#labelUserEmail').text("We have sent you password reset code to your email.");

            $('#userEmail').val(result.value);
            $('#userEmail').prop('disabled', true);

            $('#divResetCode').show();
            $('#sendCodeBtn').hide();
            $('#verifyBtn').show(); 


        }

        else {
            $('#emailError').text(result.msg);
            $('#emailError').show();
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();

    }


    , VerifyResetCodeCallBack: function (result) {

        if (result.msgType === "success") {
            showProcessing();

            showToast(result.msg, "success");

            $('#labelUserEmail').text("We have sent you password reset code to your email.");

            $('#userEmail').val($('#currentuserEmail').val());

            $('#userEmail').prop('disabled', true);


            $('#divPassword').show();

            $('#divResetCode').hide();
            $('#verifyBtn').hide();
            $('#resetBtn').show();



        }

        else {
            $('#resetCodeError').text(result.msg);
            $('#resetCodeError').show();
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


    , ResetPasswordCallBack: function (result) {
        showProcessing();
        if (result.msgType === "success") {
            showProcessing();

            setTimeout(() => {
                window.location.href = "/Login/Index";
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

ForgetPassword.init();


