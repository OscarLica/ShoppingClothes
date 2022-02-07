$(document).ready(() => {
    $(document).on('click', "a[data-anular-factura]", function (event) {
        let IdVenta = $(this).data("anularFactura");
        swal({
            title: 'Anular factura',
            text: "¿Está seguro que desea anular está factura?",
            icon: 'warning',
            buttons: true,
            dangerMode: true,
        }).then((result) => {
            if (result) {
                $.get("/api/Venta/Anular/" + IdVenta).then(() => {
                    swal(
                        'Anulada!',
                        'Factura anulada correctamente.',
                        'success'
                    ).then(() => {
                        window.location.reload();
                    });
                });
            }
        })
    });

    $(document).on('click', "a[data-ver-factura]", function (event) {
        let IdVenta = $(this).data("verFactura");
        $.get("/Reporte/Venta/" + IdVenta).then((response) => {
            $("#ver-venta").modal("show");
            response = response.replace(/['"]+/g, '');
            var src = "data:application/pdf;base64," + response;
            document.getElementById("embedReporte").src = src;
            $("#reporte-avance-procesos").show();
        });
    });
});