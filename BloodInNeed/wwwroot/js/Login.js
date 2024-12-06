
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
        }, Login.failureCallback);

    }

    , CheckLoginCallBack: function (result) {
        showProcessing();
       
        // Show toast notification based on the result
        if (result.msgType === "success") {
            showProcessing();
            // Redirect to the Home page after a short delay
            setTimeout(() => {
                window.location.href = result.redirectUrl || "/Home/Index";

                showToast(result.msg, "success"); // Display success toast
                hideProcessing();
            }, 2000); // Wait 2 seconds before redirecting
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


