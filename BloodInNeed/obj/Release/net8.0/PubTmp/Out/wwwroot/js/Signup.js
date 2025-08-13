var apiUrl = '/api/signup/';

var Signup = {
    init: function () {
        // Email validation
        $('#signupEmail').on('input', function () {
            const email = $(this).val();
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // Simple email regex

            if (emailPattern.test(email)) {
                $('#emailError').hide();
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $('#emailError').show();
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            Signup.CheckInValidClass(); // Check button state
        });

        // Password validation
        $('#signupPassword').on('input', function () {
            const password = $(this).val();
            const strongPasswordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

            if (strongPasswordPattern.test(password)) {
                $('#signupPasswordError').hide();
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $('#signupPasswordError').show();
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            Signup.CheckInValidClass(); // Check button state
        });

        // Retype Password validation
        $('#signupRePassword').on('input', function () {
            const password = $('#signupPassword').val();
            const rePassword = $(this).val();

            if (password === rePassword && rePassword !== '') {
                $('#rePasswordError').hide();
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $('#rePasswordError').show();
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            Signup.CheckInValidClass(); // Check button state
        });

        // First Name and Last Name validation
        $('#signupFirstName, #signupLastName').on('input', function () {
            const value = $(this).val().trim();

            if (value !== '') {
                $(this).removeClass('is-invalid').addClass('is-valid');
            } else {
                $(this).removeClass('is-valid').addClass('is-invalid');
            }
            Signup.CheckInValidClass(); // Check button state
        });

        // Radio button validation
        $('input[name="DonorSeeker"]').on('change', function () {
            Signup.CheckInValidClass(); // Check button state
        });

        // Initial check on page load
        Signup.CheckInValidClass();


        $('#registerBtn').on('click', function () {
           
            showProcessing();

            var data = {
                FirstName: $('#signupFirstName').val(),
                MiddleName: $('#signupMiddleName').val(),
                LastName: $('#signupLastName').val(),
                Email: $('#signupEmail').val(),
                Password: $('#signupPassword').val(),
                IsDonorSeeker: $('input[name="DonorSeeker"]:checked').val()
            }

            ApiCall.post(apiUrl + 'SignUpUser', data, function (result) {
                Signup.SignupCallBack(result);
            }, Signup.failureCallback);
            
        });
    },

    SignupCallBack: function (result) {
       
        if (result.msgType === "success") {
            showProcessing();

            // Redirect to the Home page after a short delay
            setTimeout(() => {
                window.location.href ="/Login/VerifyEmail?Email=" + result.value;
                showToast(result.msg , "success"); // Display success toast

                hideProcessing();
            }, 3000); // Wait 3 seconds before redirecting
        } else {
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();
    }



    ,CheckInValidClass: function () {
        // Check for invalid classes or empty required fields
        const hasInvalid = $('.is-invalid').length > 0;

        // Ensure all required fields are filled
        const isFirstNameFilled = $('#signupFirstName').val().trim() !== '';
        const isLastNameFilled = $('#signupLastName').val().trim() !== '';
        const isEmailFilled = $('#signupEmail').val().trim() !== '';
        const isPasswordFilled = $('#signupPassword').val().trim() !== '';
        const isRePasswordFilled = $('#signupRePassword').val().trim() !== '';
        const isRadioChecked = $('input[name="DonorSeeker"]:checked').length > 0;

        const isFormValid =
            !hasInvalid &&
            isFirstNameFilled &&
            isLastNameFilled &&
            isEmailFilled &&
            isPasswordFilled &&
            isRePasswordFilled &&
            isRadioChecked;

        // Enable/Disable the register button
        $('#registerBtn').prop('disabled', !isFormValid);
    },


    failureCallback: function () {
        console.log("API Call Failed. Error: " + error);
    }
};

Signup.init();
