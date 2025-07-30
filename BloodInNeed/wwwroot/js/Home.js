
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
            Home.CheckLoginCallBack(result);
        }, Home.failureCallback());

    }

    , CheckLoginCallBack: function (result) {
        //showProcessing();        
        console.log(result);
        hideProcessing();

    }




    , failureCallback: function () {

        console.log("Api Call Failed.");

    }


}

Home.init();


