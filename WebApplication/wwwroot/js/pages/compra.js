$(document).ready(() => {
    let detalle = [];
    const editar = "data-editar";
    const remove = "data-eliminar";
    let formValidation = Module.get("form-validation");
    formValidation.InitValidation("#frm-compra");
    formValidation.InitValidation("#frm-detalle");

    const CalculteTotal = () => {

        let tCantidad = 0;
        let tPrecioCompra = 0;
        let tPrecioVenta = 0;
        let tSubtotal = 0;
        $.each(detalle, function (i, e) {
            let compra = $formater.formatDecimalString(e.PrecioCompra);
            compra = $formater.unformatDecimalString(compra);

            tPrecioCompra += +compra;

            let venta = $formater.formatDecimalString(e.PrecioVenta);
            venta = $formater.unformatDecimalString(venta);

            tPrecioVenta += +venta;

            let cantidad = $formater.formatDecimalString(e.Cantidad);
            cantidad = $formater.unformatDecimalString(cantidad);

            tCantidad += +cantidad;

            let subtotal = $formater.formatDecimalString(e.SubTotal.toString());
            subtotal = $formater.unformatDecimalString(subtotal);

            tSubtotal += +subtotal;

        });

        $("#tCantidad").text($formater.formatDecimalString(tCantidad.toString()));
        $("#tPCompra").text($formater.formatDecimalString(tPrecioCompra.toString()));
        $("#tPVenta").text($formater.formatDecimalString(tPrecioVenta.toString()));
        $("#tSubTotal").text($formater.formatDecimalString(tSubtotal.toString()));

        CalcuteTotalesCompra();
    };

    const CalcuteTotalesCompra = () => {
        let totales = 0;
        let descuento = $("input[data-name='Descuento']").val() ?? "0";
        let iva = $("input[data-name='Iva']").val() ?? "0";

        descuento = $formater.unformatDecimalString(descuento) / 100;
        iva = $formater.unformatDecimalString(iva) / 100;

        $.each(detalle, function (i, e) {
            
            let total = $formater.formatDecimalString(e.SubTotal.toString());
            total = $formater.unformatDecimalString(total);

            totales += +total;

        });
        $("input[data-name='SubTotal']").val($formater.formatDecimalString(totales.toString()));

        let totalDes = +$formater.unformatDecimalString(totales.toString()) * descuento;
        let totalIva = +$formater.unformatDecimalString(totales.toString()) * iva;

        totales = (+$formater.unformatDecimalString(totales.toString()) - totalDes) + totalIva;

        $("input[data-name='Total']").val($formater.formatDecimalString(totales.toString()));

    };

    $(document).on("change", "input[data-name='Descuento']", function () {
        CalcuteTotalesCompra();
    });

    $(document).on("change", "input[data-name='Iva']", function () {
        CalcuteTotalesCompra();
    });

    const loadDetalle = (data) => {
        let row = "";
        let button = Module.get("Table");
        $.each(data, function (i, element) {
            row += `<tr>
                        <td>${element.Producto}</td><td>${element.Marca}</td><td>${element.Talla}</td><td>${element.Color}</td><td>${element.Cantidad}</td><td>${element.PrecioCompra}</td><td>${element.PrecioVenta}</td><td>${$formater.formatDecimalString(element.SubTotal.toString())}</td>
                        <td>${button.GenerateButton("btn btn-primary", "fas fa-pencil", editar, element.id)} &nbsp; ${button.GenerateButton("btn btn-danger", "fas fa-trash", remove, element.id)}</td>
                    </tr>`;

            $(document).on("click", "button[" + editar + "=" + element.id + "" + "]", function () {
                let id = $(this).data("editar");
                let formValidation = Module.get("form-validation");
                formValidation.InitValidation("#frm-detalle");

                let response = detalle.find((d) => d.id === id);
                formValidation.SetDataForm("data-detalle-name", response);
            });

            $(document).on("click", "button[" + remove + "=" + element.id + "" + "]", function () {
                let id = $(this).data("eliminar");
                detalle = detalle.filter((d) => d.id !== id);
                loadDetalle(detalle);
            });

        });
        $("#body").html(row);

        CalculteTotal();
    }

    const loadSelects = async () => {
        let almacen = await $.get("/api/Almacen");
        let color = await $.get("/api/Color");
        let talla = await $.get("/api/Talla");
        let marca = await $.get("/api/Marca");
        let proveedor = await $.get("/api/Proveedor");
        let productos = await $.get("/api/Producto");

        // cargamos combo de almacen
        let cbp = $("select[data-name='IdAlmacen']");
        $(cbp).empty();
        $(cbp).append("<option value>[Seleccione una opción]</option>");

        $.each(almacen, function (i, e) {
            $(cbp).append("<option value="+e.id+">"+e.nombre+"</option>");
        });

        // cargamos combo de color
        cbp = $("select[data-detalle-name='IdColor']");
        $(cbp).empty();
        $(cbp).append("<option value>[Seleccione una opción]</option>");

        $.each(color, function (i, e) {
            $(cbp).append("<option value=" + e.id + ">" + e.nombre + "</option>");
        });

        // cargamos combo de talla
        cbp = $("select[data-detalle-name='IdTalla']");
        $(cbp).empty();
        $(cbp).append("<option value>[Seleccione una opción]</option>");

        $.each(talla, function (i, e) {
            $(cbp).append("<option value=" + e.id + ">" + e.nombre + "</option>");
        });

        // cargamos combo de marca
        cbp = $("select[data-detalle-name='IdMarca']");
        $(cbp).empty();
        $(cbp).append("<option value>[Seleccione una opción]</option>");

        $.each(marca, function (i, e) {
            $(cbp).append("<option value=" + e.id + ">" + e.nombre + "</option>");
        });

        // cargamos combo de proveedor
        cbp = $("select[data-name='IdProveedor']");
        $(cbp).empty();
        $(cbp).append("<option value>[Seleccione una opción]</option>");

        $.each(proveedor, function (i, e) {
            $(cbp).append("<option value=" + e.id + ">" + e.nombreCompañia + "</option>");
        });

        // cargamos combo de productos
        cbp = $("select[data-detalle-name='IdProducto']");
        $(cbp).empty();
        $(cbp).append("<option value>[Seleccione una opción]</option>");

        $.each(productos, function (i, e) {
            $(cbp).append("<option value=" + e.id + ">" + e.nombreProducto + "</option>");
        });
    }

    loadSelects();

    $(document).on("submit", "#frm-compra", function (event) {

        event.preventDefault();
        event.stopPropagation();


        event.preventDefault();
        event.stopPropagation();

        let formValidation = Module.get("form-validation");
        let TblCompras = formValidation.GetDataForm("data-name", "name");
        TblCompras.Total = $formater.unformatDecimalString(TblCompras.Total);
        TblCompras.detalle = detalle;

        if (!detalle.length) {
            swal({
                title: "Compra",
                text: "Debe ingresar productos al carrito",
                icon: "error",
                button: "Ok",
            });
            return false;
        }
        $.post("/api/compra", TblCompras).then((response) => {
            swal({
                title: "Compra!",
                text: "Compra realizada exitosamente!",
                icon: "success",
                button: "Ok",
            }).then(() => {

                window.location.href = "/Facturacion/Compra/Compras";

            });
        });
    });

    $(document).on("submit", "#frm-detalle", function (event) {

        event.preventDefault();
        event.stopPropagation();

        let formValidation = Module.get("form-validation");
        let detalletmp = formValidation.GetDataForm("data-detalle-name", "detalleName");
        if (!detalletmp.Cantidad || detalletmp.Cantidad === "0") {
            swal({
                title: "Datos incorrectos",
                text: "La cantidad debe ser mayor a 0.",
                icon: "error",
                button: "Ok",
            });
            return false;
        }

        let product = detalle.find((d) => d.IdProducto === detalletmp.IdProducto && d.IdMarca === detalletmp.IdMarca && d.IdTalla === detalletmp.IdTalla && d.IdColor === detalletmp.IdColor);

        if (product) {

            product.Cantidad = detalletmp.Cantidad;
            product.PrecioUnitario = detalletmp.PrecioUnitario;
            product.PrecioCompra = detalletmp.PrecioCompra;
            product.PrecioVenta = detalletmp.PrecioVenta;

            detalle = detalle.filter((d) => d.id !== product.id);
            detalle.push(product);
            this.reset();
            loadDetalle(detalle);
        }
        else {
            detalletmp.id = detalle.length + 1;
            detalletmp.Producto = $("select[data-detalle-name='IdProducto'] option:selected").text();
            detalletmp.Marca = $("select[data-detalle-name='IdMarca'] option:selected").text();
            detalletmp.Talla = $("select[data-detalle-name='IdTalla'] option:selected").text();
            detalletmp.Color= $("select[data-detalle-name='IdColor'] option:selected").text();

            let cnt = $formater.formatDecimalString(detalletmp.Cantidad);

            let precioC = $formater.formatDecimalString(detalletmp.PrecioCompra);

            detalletmp.subTotal = $formater.unformatDecimalString(cnt) * $formater.unformatDecimalString(precioC);
            detalle.push(detalletmp);
            this.reset();
            loadDetalle(detalle);
        }
        

    });
});