function clearMessage(roleId) {
    var strongMessage = $(`#role-box-${roleId} > strong`);
    strongMessage.html("");
}

$(":checkbox").on("change", function () {

    //console.log(this);
    //console.log($(this));
    var userId = $("#userId").val();
    var roleId = $(this).attr("id");
    var isChecked = $(this).is(":checked")

    console.log(userId + " " + roleId + " " + isChecked);

    var strongMessage = $(`#role-box-${roleId} > strong`);

    $.ajax({
        url: "/Role/UserUpdateRole",
        method:"POST",
        data: { userId: userId, roleId: roleId, roleStatus: isChecked },
        beforeSend: function () {
            console.log("Önce ben çalýþtým");
            $(`#spinner-${roleId}`).show();
        },
        success: function (data, textStatus, xhr) {
            console.log(data);
            strongMessage.addClass("text-success").html(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr.status);
            console.log(xhr.responseText);
            var data = `${xhr.status} : ${xhr.responseText}`;
            strongMessage.html(data);
            switch (xhr.status) {
                case 400:
                    strongMessage.addClass("text-danger");
                    break;
                case 404:
                    strongMessage.addClass("text-warning");
                    break;
                case 405:
                    strongMessage.addClass("text-info");
                    break;
                default:
                    strongMessage.addClass("text-primary");
            }

        },
        complete: function () {
            $(`#spinner-${roleId}`).hide();
            setTimeout(`clearMessage('${roleId}')`, 2500);
        }
    });

});

function onChagenCheckbox(element) {
    //login
}