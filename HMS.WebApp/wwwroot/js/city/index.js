function GetCities(_pageNo) {
    $.ajax({
        url: "/Country/CityList",
        method: "GET",
        data: { pageSize: 3, pageNo: _pageNo },
        success: function (result) {
            //console.log(result);
            $("#city-list").html(result);
        },
        error: function (error, xhr) {

        }
    })
}