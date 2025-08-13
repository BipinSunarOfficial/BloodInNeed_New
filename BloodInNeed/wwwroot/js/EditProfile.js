var apiUrl = '/api/editProfile/';

var EditProfile = {

    init: function () {

        $('#userCountryId').on('change', function () {
            
            var countryId = $('#userCountryId option:selected').val();

            var data =
            {
                CountryId : countryId
                }

            ApiCall.get(apiUrl + 'CitybyCountryId', data, function (result) {
                EditProfile.CityCallBack(result);
            }, EditProfile.failureCallback())


        });


        $('#saveBtn').on('click', function () {
            var data =
            {
                UserId: $('#currentLoggedInUserId').val(),
                Salutation: $('#salutation option:selected').val(),
                FirstName: $('#editFirstName').val(),
                MiddleName: $('#editMiddleName').val(),
                LastName: $('#editLastName').val(),
                Gender: $('#gender option:selected').val(),
                Email: $('#editLastName').val(),
                UserName: '',
                Password: '',
                DonorSeeker: $('#donorseeker option:selected').val(),
                DOB: $('#dob').val(),
                Occupation: $('#editOccupation').val(),
                FatherName: $('#editFatherName').val(),
                MotherName: $('#editMotherName').val(),
                Country: $('#userCountryId option:selected').val(),
                City: $('#userCityId option:selected').val(),
                Contact: $('#contactNumber').val(),
                Address1: $('#editAddress1').val(),
                Address2: $('#editAddress2').val(),
                Address3: $('#editAddress3').val(),
                BloodGroup: $('#bloodGroup option:selected').val(),
                DonatedBefore: $('input[name="donateBefore"]:checked').val(),
                DonationCount: $('#donationCount').val(),
                DonationDateRecent: $('#recentDonationDate').val(),
                Inspiration: $('#inspirationField').val()
            }

            ApiCall.post(apiUrl + 'saveProfile', data, function (result) {
                EditProfile.SaveProfileCallBack(result);
            }, EditProfile.failureCallback())


        });

        $('#saveBtn').on('click', function () {
            var data =
            {
                UserId: $('#currentLoggedInUserId').val(),
                Salutation: $('#salutation option:selected').val(),
                FirstName: $('#editFirstName').val(),
                MiddleName: $('#editMiddleName').val(),
                LastName: $('#editLastName').val(),
                Gender: $('#gender option:selected').val(),
                Email: $('#editLastName').val(),
                UserName: '',
                Password: '',
                DonorSeeker: $('#donorseeker option:selected').val(),
                DOB: $('#dob').val(),
                Occupation: $('#editOccupation').val(),
                FatherName: $('#editFatherName').val(),
                MotherName: $('#editMotherName').val(),
                Country: $('#userCountryId option:selected').val(),
                City: $('#userCityId option:selected').val(),
                Contact: $('#contactNumber').val(),
                Address1: $('#editAddress1').val(),
                Address2: $('#editAddress2').val(),
                Address3: $('#editAddress3').val(),
                BloodGroup: $('#bloodGroup option:selected').val(),
                DonatedBefore: $('input[name="donateBefore"]:checked').val(),
                DonationCount: $('#donationCount').val(),
                DonationDateRecent: $('#recentDonationDate').val(),
                Inspiration: $('#inspirationField').val()
            }

            ApiCall.post(apiUrl + 'saveProfile', data, function (result) {
                EditProfile.SaveProfileCallBack(result);
            }, EditProfile.failureCallback())


        });

        $('#saveBtn').on('click', function () {
            var data =
            {
                UserId: $('#currentLoggedInUserId').val(),
                Salutation: $('#salutation option:selected').val(),
                FirstName: $('#editFirstName').val(),
                MiddleName: $('#editMiddleName').val(),
                LastName: $('#editLastName').val(),
                Gender: $('#gender option:selected').val(),
                Email: $('#editLastName').val(),
                UserName: '',
                Password: '',
                DonorSeeker: $('#donorseeker option:selected').val(),
                DOB: $('#dob').val(),
                Occupation: $('#editOccupation').val(),
                FatherName: $('#editFatherName').val(),
                MotherName: $('#editMotherName').val(),
                Country: $('#userCountryId option:selected').val(),
                City: $('#userCityId option:selected').val(),
                Contact: $('#contactNumber').val(),
                Address1: $('#editAddress1').val(),
                Address2: $('#editAddress2').val(),
                Address3: $('#editAddress3').val(),
                BloodGroup: $('#bloodGroup option:selected').val(),
                DonatedBefore: $('input[name="donateBefore"]:checked').val(),
                DonationCount: $('#donationCount').val(),
                DonationDateRecent: $('#recentDonationDate').val(),
                Inspiration: $('#inspirationField').val()
            }

            ApiCall.post(apiUrl + 'saveProfile', data, function (result) {
                EditProfile.SaveProfileCallBack(result);
            }, EditProfile.failureCallback())


        });

        $('#btnCancel').on('click', function () {
            
            showProcessing();
            window.location.href = "/Home/Index";

            hideProcessing();

        });





    }
    , SaveProfileCallBack: function (result) {

        if (result.msgType === "success") {
            showProcessing();

            // Redirect to the Home page after a short delay
            setTimeout(() => {
                showToast(result.msg, "success"); // Display success toast
                window.location.href = "/Profile/Edit";

                hideProcessing();
            }, 3000); // Wait 3 seconds before redirecting
        } else {
            showToast(result.msg, "error"); // Display error toast
        }

        hideProcessing();
    }

    , CityCallBack: function (d) {

        var a;
        
        var html = '';

        if (d != undefined || d != null) {
            html += `<option value="0">Select City/Town</option>`;

            $.each(d, function () {
                a = this;

                html += `<option value="${a.cityId}">${a.city}</option>`;

            })

        }
        
        var countryCode = $('#userCountryId option:selected').data('code');

        $('#telCountryCode').text('+' + countryCode);
        $('#userCityId').html(html);


    }

    , failureCallback: function () {

        console.log("Api Call Failed.");

    }


}

EditProfile.init();

