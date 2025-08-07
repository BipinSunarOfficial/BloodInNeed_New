
var apiUrl = '/api/login/';

var Login = {

    init: function () {

        $('#logInBtn').on('click', function () {
            
            showProcessing();

            var user = $('#loginEmail').val();
            var pass = $('#loginPassword').val();

            Login.CheckLogin(user, pass);
        });


    }

    , CheckLogin: function (userEmail, password) {
        showProcessing();
        var data = {
            UserName : userEmail,
            Password: password
        }

        ApiCall.get(apiUrl + 'CheckLogin', data, function (result) {
            Login.CheckLoginCallBack(result);
        }, Login.failureCallback());

    }

    , CheckLoginCallBack: function (result) {
        showProcessing();
        console.log(result);
        
        // Show toast notification based on the result
        if (result.msgType === "success") {
            
            showProcessing();

            if (result.msg === "User found but need to verify email address.") {

                setTimeout(() => {
                    window.location.href = "/Login/VerifyEmail?Email=" + result.username;

                    showToast(result.msg, "success"); // Display success toast
                    hideProcessing();
                }, 3000);

            }

            else if (result.msg === "Login Successful.") {
                // Redirect to the Home page after a short delay
                setTimeout(() => {
                    window.location.href = "/Home/Index";
                    showToast(result.msg, "success"); // Display success toast

                    hideProcessing();
                }, 3000); // Wait 3 seconds before redirecting
            }
        } else {
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();

    }




    , failureCallback: function () {

        console.log("Api Call Failed.");
        
    }


 }

Login.init();


