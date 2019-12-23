
function llamadoPOST(url, data) {
    $.post(
        url,
        data,
        function (data, status) {
            responseForm(data);
        }
    );
};


