
var apiUrl = '/api/base/';

var Home = {

    init: function () {

        Home.GetStatByCountry();

    }

    , GetStatByCountry: function () {
        showProcessing();

        var data = {
            CountryId : 0
        }
        ApiCall.get(apiUrl + 'GetStatByCountry',data, function (result) {
            Home.GetStatByCountryCallBack(result);
        }, Home.failureCallback());

    }

    , GetStatByCountryCallBack: function (result) {
        
        var html = '';
       
        if (result != null) {
            $.each(result, function () {
                a = this;
                
                html += `<tr>
                    <td class="d-flex align-items-center justify-content-center">
                        <img src="https://flagcdn.com/w40/${a.flag}.png" alt="${a.name} Flag" class="me-2" style="width: 30px; border-radius: 4px;" />
                        ${a.name}
                    </td>
                    <td>${a.users}</td>
                    <td>${a.donors}</td>
                    <td>${a.requests}</td>
                </tr>`;
            })
        }

        else {
            html += '<tr><td colspan="4">No Data Found to show.</td></tr>';
        }

        $('#country-stats-body').html(html);


        hideProcessing();

    }




    , failureCallback: function () {

        console.log("Api Call Failed.");

    }


}

Home.init();


