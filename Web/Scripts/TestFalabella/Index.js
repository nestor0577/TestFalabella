
$(document).ready(function () {

    $("#slArea").change(function () {

        var tipoOption = $("#slArea").val();

        if (tipoOption === "1") {

            $("#divGerenciaComercial").attr("style", "display:inline");
            $("#divFormulario").attr("style", "display:none");
            actionFormObtenerCompania();

        } else if (tipoOption === "2") {
            $("#divFormulario").attr("style", "display:inline");
            $("#divGerenciaComercial").attr("style", "display:none");
            actionFormObtenerCompania();
        }

    });

    $("#slCompaniaUsr").change(function () {
        actionFormObtenerProductosCompania();
    });

    $("#btnGuardarProducto").click(function () {
        guardarDatosProductos();
    });

    $("#btnGuardarCliente").click(function () {
        guardarDatosClientes();
    });

});

function guardarDatosProductos() {
    llamadoPOST("Home/guardarDatosProductos", obtenerDatosProductos());
};

function guardarDatosClientes() {
    llamadoPOST("Home/guardarDatosClientes", obtenerDatosClientes());
};
function actionFormObtenerCompania() {
    llamadoPOST("Home/loadCompania", null);
};

function actionFormObtenerProductosCompania() {
    llamadoPOST("Home/loadProductosCompania", obtenerDatosCompaniaProducto());
};

function obtenerDatosProductos() {
    var objSer = $("#divGerenciaComercial :input").serialize();
    return objSer;
};

function obtenerDatosClientes() {
    var objSer = $("#divFormulario :input").serialize();
    return objSer;
};

function obtenerDatosCompaniaProducto() {
    var objSer = $("#divProdComp :input").serialize();
    return objSer;
};

function responseForm(res) {
    if (res.actionResponse === true) {

        var optionsStr = "";

        if (res.typeAcc === 1) {

            alert(res.mensaje);
            setTimeout(location.reload(), 3000);

        } else if (res.typeAcc === 2) {

            $.each(res.data, function (id, valores) {
                optionsStr += "<option value=" + valores.IdCompania + ">" + valores.NombreCompania + "</option>";
            });

            if ($("#slArea").val() === "1") {
                $("#slCompania").append(optionsStr);
            } else {
                $("#slCompaniaUsr").append(optionsStr);
            }

        } else if (res.typeAcc === 3) {

            $.each(res.data, function (id, valores) {
                optionsStr += "<option value=" + valores.IdProducto + ">" + valores.NombreProducto + "</option>";
            });

            $("#slProducto").append(optionsStr);

        }

    }
};



