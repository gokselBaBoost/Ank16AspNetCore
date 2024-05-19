function clearMessage(roleId) {
    //console.log(roleId);
    $(`#role-box-${roleId} > strong`).html("");
    $(`#userRolesError`).html("");
}

$(":checkbox").on("change", function () {

    var userId = $("#userId").val();
    var roleId = $(this).attr("id");
    var isChecked = $(this).is(":checked");

    $.ajax({
        url: $("#userRoles").data("url"),
        method: "POST",
        data: { roleId: roleId, status: isChecked },
        beforeSend: () => { $(`#spinner-${roleId}`).show(); },
        success: (data, textStatus, xhr) => {
            //console.log(textStatus);
            //console.log(data);
            var strongStatus = $(`#role-box-${roleId} > strong`);
            strongStatus.html(data);
            switch (xhr.status) {
                case 200:
                    strongStatus.addClass("text-success");
                    break;
            }
        },
        error: (xhr, textStatus, errorThrown) => {
            var strongStatus = $(`#role-box-${roleId} > strong`);
            var data = `${xhr.status} : ${xhr.responseText}`;
            strongStatus.html(data);
            switch (xhr.status) {
                case 400:
                    strongStatus = $(`#userRolesError`);
                    strongStatus.html(data);
                    strongStatus.addClass("text-danger");
                    break;
                case 404:
                    strongStatus.addClass("text-warning");
                    break;
                case 405:
                    strongStatus.addClass("text-danger");
                    break;
                default:
                    strongStatus.addClass("text-info");
                    break;

            }
        },
        complete: () => {
            $(`#spinner-${roleId}`).hide();
            setTimeout(`clearMessage('${roleId}')`, 2500);
        }
    })
})

//$(":checkbox").each((index, element) => {
//    //console.log(index);
//    console.log($(element).attr("id"));
//    console.log($(element).is(":checked"));
//});