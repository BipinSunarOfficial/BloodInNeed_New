

var apiUrl = '/api/BloodRequest/';

var MyRequest = {

    msg: '',
    msgType: '',
    cancelData: 0,
    init: function () {

        $('.view-request').on('click', function () {

            var currentrequestId = $(this).data("id");

            // Show modal immediately with loader
            $("#requestDetailsContent").html(`
            <div class="text-center py-4">
                <div class="spinner-border text-primary" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
            </div>
        `);
            $("#requestDetailsModal").modal("show");

            //var data = { requestId: currentrequestId };


            ApiCall.post(apiUrl + 'RequestViewDetails/' + currentrequestId, null, function (result) {
                MyRequest.ViewDetailCallBack(result);
            }, MyRequest.failureCallback());


        });

        $('.cancel-request').on('click', function () {
            showProcessing();
            var currentrequestId = $(this).data("id");
            var currentUserId = $('#currentLoggedInUserId').val();

            cancelData = currentrequestId;

            if (confirm("Are you sure you want to cancel this request ?")) {

                ApiCall.post(apiUrl + 'CancelRequest/' + currentrequestId + '/' + currentUserId, null, function (result) {
                    MyRequest.CancelRequestCallBack(result);
                }, MyRequest.failureCallback());

            }
            hideProcessing();



        });


    }
    , ViewDetailCallBack: function (result) {


        if (result != null) {

            var html = `<table class="table table-bordered" <tr><th>Recipient Name</th><td>${result.receipentName}
            </td></tr>
                    <tr><th>Patient Name</th><td>${result.patientName}</td></tr>
                    <tr><th>Blood Group</th><td>${result.bloodGroup}</td></tr>
                    <tr><th>Units Required</th><td>${result.requiredUnits}</td></tr>
                    <tr><th>Urgency Level</th><td>${result.urgencyLevel}</td></tr>
                    <tr><th>Hospital</th><td>${result.hospitalName}</td></tr>
                    <tr><th>City</th><td>${result.cityName}</td></tr>
                    <tr><th>Due Date</th><td>${MyRequest.formatDate(result.dueDate)}</td></tr>
                    <tr><th>Contact Number</th><td>${result.contactNumber}</td></tr>
                    <tr><th>Diagnosis</th><td>${result.diagnosis}</td></tr>
                    <tr><th>Notes</th><td>${result.notes}</td></tr>
                    <tr><th>Status</th>
                        <td><span class="badge ${MyRequest.getStatusClass(result.status)}">${result.status}</span></td>
                    </tr>
                    <tr><th>Requested On</th><td>${MyRequest.formatDate(result.requestedOn)}</td></tr>
                    <tr><th>Accepted By</th><td>${result.donor}`;

            if (result.status == "accepted") {

                html += `<a href = "tel:` + result.donorContact + `" > <i class="fa fa-phone"></i></a > `;
            }
            html += `</td></tr >
                    <tr><th>Accepted On</th><td>${MyRequest.formatDate(result.acceptedOn)}</td></tr>
                </table>`;
            $("#requestDetailsContent").html(html);
        }

        else {
            $("#requestDetailsContent").html("<p class='text-danger text-center'>Failed to load request details.</p>");

        }
    }

    , CancelRequestCallBack: function (result) {
        

        if (result.msgType == "success") {
            showToast(result.msg, result.msgType);

            $('button.cancel-request[data-id="' + cancelData + '"]')
                .addClass('disabled')
                .css('pointer-events', 'none')
                .text('Cancelled');



            setTimeout(function () {
                location.reload();
            }, 1000);



        }
        else {
            showToast(result.msg, result.msgType);
        }
        hideProcessing();

    }
    , getStatusClass: function (status) {
        switch ((status || "").toLowerCase()) {
            case "pending": return "bg-warning";
            case "accepted": return "bg-success";
            case "cancelled": return "bg-danger";
            default: return "bg-secondary";
        }
    }

    , formatDate: function (dateStr) {
        if (!dateStr) return "";
        var date = new Date(dateStr);
        return date.toLocaleDateString("en-GB", { year: "numeric", month: "2-digit", day: "2-digit" });
    }


    , failureCallback: function () {

        console.log("Api Call Failed.");

    }


}

MyRequest.init();


