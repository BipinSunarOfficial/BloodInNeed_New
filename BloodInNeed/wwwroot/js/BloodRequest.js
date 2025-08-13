
var apiUrl = '/api/BloodRequest/';

var BloodRequest = {

     msg : '',
     msgType : '',
    init: function () {
               

        $('#saveBtn').on('click', function () {
            
            showProcessing();

            BloodRequest.validateForm();

            if (msgType == "error") {
                showToast(msg, msgType);
                $('#errorMsg').text(msg);
                hideProcessing();
                return;
            }
            if (msgType == "success") {

                var data =
                {
                    
                    receipentId : $('#currentLoggedInUserId').val(),
                    patientName : $('#patientName').val(),
                    bloodGroup : $('#bloodGroup option:selected').val(),
                    requiredUnits : $('#requiredUnits').val(),
                    urgencyLevel : $('#urgencyLevel option:selected').val(),
                    hospitalName : $('#hospitalName').val(),
                    bloodCity : $('#bloodCity option:selected').val(),
                    dueDate : $('#dueDate').val(),
                    contactNumber : $('#contactNumber').val(),
                    diagnosis : $('#diagnosis').val(),
                    notes: $('#notes').val(),
                    bloodGroupSymbol : ''
                    
                }


                ApiCall.post(apiUrl + 'CreateRequest', data, function (result) {
                    BloodRequest.CreateRequestnCallBack(result);
                }, BloodRequest.failureCallback());

            }

            
        });


        $('.view-request').on('click', function () {
            
            var requestId = $(this).data("id");

            // Show modal immediately with loader
            $("#requestDetailsContent").html(`
            <div class="text-center py-4">
                <div class="spinner-border text-primary" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
            </div>
        `);
            $("#requestDetailsModal").modal("show");


        });




    }

    , validateForm: function () {

        var receipentId = $('#currentLoggedInUserId').val();
        var patientName = $('#patientName').val();
        var bloodGroup = $('#bloodGroup option:selected').val();
        var requiredUnits = $('#requiredUnits').val();
        var urgencyLevel = $('#urgencyLevel option:selected').val();
        var hospitalName = $('#hospitalName').val();
        var bloodCity = $('#bloodCity option:selected').val();
        var dueDate = $('#dueDate').val();
        var contactNumber = $('#contactNumber').val();
        var diagnosis = $('#diagnosis').val();
        var notes = $('#notes').val();

        if (
            patientName == '' ||
            bloodGroup == '' ||
            requiredUnits == '' || requiredUnits == 0 ||
            urgencyLevel == '' ||
            hospitalName == '' ||
            bloodCity == '' || bloodCity == '' ||
            dueDate == 0 || dueDate == '' || dueDate == null ||
            dueDate == 0 || dueDate == '' || dueDate == null ||
            diagnosis == ''
        ) {
            msg = "Fill all essential details.";
            msgType = "error";
        }
        else {
            msg = "All essential field filled.";
            msgType = "success";
        }

    }

    , CreateRequestnCallBack: function (result) {
        showProcessing();
        //console.log(result);
        
        // Show toast notification based on the result
        if (result.msgType === "success") {

            showProcessing();


            setTimeout(() => {
                window.location.href = "/BloodSearch/MyRequests";

                showToast(result.msg, "success"); // Display success toast
                hideProcessing();
            }, 3000);
        }

            else {
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();

    }




    , failureCallback: function () {

        console.log("Api Call Failed.");
        
    }


 }

BloodRequest.init();


