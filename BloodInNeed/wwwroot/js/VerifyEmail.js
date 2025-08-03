
var apiUrl = '/api/login/';

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


    }

    , failureCallback: function () {

        console.log("Api Call Failed.");
        
    }


 }

VerifyLogin.init();


