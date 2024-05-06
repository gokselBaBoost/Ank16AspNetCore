function GetHotelsForCity(cityId, e) {

    var ajaxUrl = $(e).data("ajax-url");
    //var bodyId = "#collapse-city-Id-" + cityId + " > .accordion-body";
    var bodyId = "#accordion-body-" + cityId;

    //console.log(ajaxUrl);

    $.ajax({
        url: ajaxUrl,
        method: "GET",
        success: function (data) {
            $(bodyId).html(data);
        }
    });
}