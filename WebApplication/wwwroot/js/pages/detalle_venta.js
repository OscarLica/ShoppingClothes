$(document).ready(() => {
    $(document).on("click", "button[data-send-taller]", function () {

        let productoAlmacen = $("#productoAlmacen").val();
        let descripcion = $("#desc").val();
        let idVenta = $("#idventa").val();

        let productoTaller = {
            IdProductoAlmacen: productoAlmacen,
            DescripcionIngreso: descripcion,
            IdVenta: idVenta
        };
        $.post("/api/Venta/ProductoTaller", productoTaller).then(response => {
            swal({
                title: "Taller",
                text: "Producto enviado a taller",
                icon: "success",
                button: "Ok",
            }).then(() => {

                window.location.reload();

            });
        });
    });

    $(document).on("click", "button[data-reported]", function () {
        let IdProductoAlmacen = $(this).data("reported");
        $("#productoAlmacen").val(IdProductoAlmacen);
        $("#modal").modal("show");
    });
});