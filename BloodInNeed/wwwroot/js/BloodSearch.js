

var BaseapiUrl = '/api/base/';

var BloodSearch = {

    init: function () {
        
        $('#citySearch').on('input', function () {

            var query = $(this).val();
            var dataList = $('#citySearchData');

            dataList.empty();


            if (!query) return;

            if (query.length >= 3) {

                var data = {
                    SearchValue: query,
                    SearchType: 'CitySearch'
                }

                ApiCall.get(BaseapiUrl + 'AutoCompleteGet', data, function (result) {
                    BloodSearch.CitySearchCallBack(result);
                }, BloodSearch.failureCallback);

            }

        });



        $('#bloodGroupSearch').on('input', function () {

            var query = $(this).val();
            var dataList = $('#bloodGroupsData');

            dataList.empty();


            if (!query) return;            

                var data = {
                    SearchValue: query,
                    SearchType: 'BloodGroupSearch'
                }

                ApiCall.get(BaseapiUrl + 'AutoCompleteGet', data, function (result) {
                    BloodSearch.BloodSearchCallBack(result);
                }, BloodSearch.failureCallback);


        });





    }

    , BloodSearchCallBack: function (result) {
        console.log(result);
        var dataList = $('#bloodGroupsData');
        var html = '';
        dataList.empty();

        if (result != null) {
            $.each(result, function () {

                a = this;

                html += `<option value=${a.searchResult} data-id="${a.searchId}" >${a.searchResult}</option>`;

            });


            dataList.html(html);


        }

    }


    , CitySearchCallBack: function (result) {

        var dataList = $('#citySearchData');
        var html = '';
        dataList.empty();

        if (result != null) {
            $.each(result, function () {
               
                a = this;

                html += `<option value=${a.searchResult} data-id="${a.searchId}" >${a.searchResult}</option>`;

            });


            dataList.html(html);

        
        }

    }

    

    , failureCallback: function () {

        console.log("Api Call Failed.");

    }


}

BloodSearch.init();


