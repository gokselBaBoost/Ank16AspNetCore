$("#success-message").hide();
function GetCountries(_pageNo) {
    $.ajax({
        url: "/Country/CountryList",
        method: "GET",
        data: { pageSize: 3, pageNo: _pageNo },
        success: function (result) {
            //console.log(result);
            $("#country-list").html(result);
        },
        error: function (error, xhr) {

        }
    })
}

function AddCountry() {
    $.ajax({
        url: "/Country/AddCountry",
        method: "GET",
        success: function (result) {
            //console.log(result);
            $("#add-country").html(result);
        },
        error: function (error, xhr) {

        }
    })
}

function SaveCountry() {

    var name = $("#Name").val();
    var isActive = $("#IsActive").val();

    var dataObj = { Name: name, IsActive: isActive };

    console.log(name);
    console.log(isActive);

    $.ajax({
        url: "/Country/SaveCountry",
        method: "POST",
        data: dataObj,
        success: function (result) {
            console.log(result);

            if (result.isSuccess) {
                $("#success-message").append("<p>Kayıt başarıyla oluşturuldu. Kayıt No : " + result.record.id + "</p>");
                $("#success-message").show();

                $("#add-country").html("");

                GetCountries();
            }
        },
        error: function (error, xhr) {

        }
    })
}