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

