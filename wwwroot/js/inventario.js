$(document).ready(function () {
    $('#table_id').DataTable();
});

$(document).on("click", ".deleteCmModal", function () {
    var idcm = $(this).data('id');
    $("#idcmDelete").val( idcm );
    $("#titleDeleteCm").text("Eliminar CM: "+ idcm +"");
});

$(document).on("click", ".editCmModal", function () {
    var idcmEdit = $(this).data('id');
    $("#titleEditCm").text("Editar CM: "+ idcmEdit +"");
    for (var i = 0; i < inventariosJSON.length; i++) {
        var idcmOriginal = inventariosJSON[i]['idcm'];
        if (idcmOriginal == (idcmEdit)) {
            $("#idcmOriUpdate").val(idcmOriginal);
            $("#idcmUpdate").val(inventariosJSON[i]['idcm']);
            $("#cod_CM_ClienteUpdate").val(inventariosJSON[i]['cod_CM_Cliente']);
            $("#calleCMUpdate").val(inventariosJSON[i]['calleCM']);
            $("#numCMUpdate").val(inventariosJSON[i]['numCM']);
            $("#situacionUpdate").val(inventariosJSON[i]['situacion']);
            $("#IDTipoGobiernoUpdate").val(inventariosJSON[i]['idTipoGobierno']);
            $("#IDTipoCajaUpdate").val(inventariosJSON[i]['idTipoCaja']);
            $("#potenciaCMUpdate").val(inventariosJSON[i]['potenciaCM']);
            var fecha = inventariosJSON[i]['fechaAltaCM'];
            var fechaAlta = new Date(Date.parse(fecha)).getFullYear() + "-" + ("0" + (new Date(Date.parse(fecha)).getMonth() + 1)).slice(-2) + "-" + new Date(Date.parse(fecha)).getDate();
            $("#fechaAltaCmUpdate").val(fechaAlta);
            fecha = inventariosJSON[i]['fechaBajaCM'];
            var fechaBaja = new Date(Date.parse(fecha)).getFullYear() + "-" + ("0" + (new Date(Date.parse(fecha)).getMonth() + 1)).slice(-2) + "-" + new Date(Date.parse(fecha)).getDate();
            $("#fechaBajaCmUpdate").val(fechaBaja);
            return;
        }
    }
});