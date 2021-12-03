$(document).ready(() => {
    let productos = [];
    let detalle = [];
    const editar = "data-editar";
    const remove = "data-eliminar";
    let formValidation = Module.get("form-validation");
    formValidation.InitValidation("#frm-compra");
    formValidation.InitValidation("#frm-detalle");

    let productSelected = null;

    const getProductos = async () => {
        let productos = await $.get("/api/Compra");
        return productos;
    }

    $(document).on("keyup", "#filtro", function () {
        let filtro = $(this).val();
        let pfiltrados = productos.filter(x => x.nombreProducto.includes(filtro) || x.talla.includes(filtro) || x.marca.includes(filtro));
        CargarTablaP(pfiltrados);
    });


    const CalcuteTotalesCompra = () => {
        let totales = 0;
        let descuento = $("input[data-name='Descuento']").val() ?? "0";
        let iva = $("input[data-name='Iva']").val() ?? "0";

        descuento = $formater.unformatDecimalString(descuento) / 100;
        iva = $formater.unformatDecimalString(iva) / 100;

        $.each(detalle, function (i, e) {

            let total = $formater.formatDecimalString(e.subTotal.toString());
            total = $formater.unformatDecimalString(total);

            totales += +total;

        });
        $("input[data-name='SubTotal']").val($formater.formatDecimalString(totales.toString()));

        let totalDes = +$formater.unformatDecimalString(totales.toString()) * descuento;
        let totalIva = +$formater.unformatDecimalString(totales.toString()) * iva;

        totales = (+$formater.unformatDecimalString(totales.toString()) - totalDes) + totalIva;

        $("input[data-name='Total']").val($formater.formatDecimalString(totales.toString()));

    };

    const CalculteTotal = () => {

        let tCantidad = 0;
        let tPrecioCompra = 0;
        let tPrecioVenta = 0;
        let tSubtotal = 0;
        $.each(detalle, function (i, e) {
            let compra = $formater.formatDecimalString(e.PrecioCompra);
            compra = $formater.unformatDecimalString(compra);

            tPrecioCompra += +compra;

            let venta = $formater.formatDecimalString(e.precioVenta.toString());
            venta = $formater.unformatDecimalString(venta);

            tPrecioVenta += +venta;

            let cantidad = $formater.formatDecimalString(e.Cantidad);
            cantidad = $formater.unformatDecimalString(cantidad);

            tCantidad += +cantidad;

            let subtotal = $formater.formatDecimalString(e.subTotal.toString());
            subtotal = $formater.unformatDecimalString(subtotal);

            tSubtotal += +subtotal;

        });

        $("#tCantidad").text("C$ " + $formater.formatDecimalString(tCantidad.toString()));
        $("#tPCompra").text("C$ " + $formater.formatDecimalString(tPrecioCompra.toString()));
        $("#tPVenta").text("C$ " + $formater.formatDecimalString(tPrecioVenta.toString()));
        $("#tSubTotal").text("C$ " + $formater.formatDecimalString(tSubtotal.toString()));

        CalcuteTotalesCompra();
    };

    const CargarTablaP = (response) => {
        $("#tabla_productos").empty();
        $.each(response, function (i, element) {
            let row = "<tr>";
            row += "<th>" + element.nombreProducto + "</td>";
            row += "<th>" + element.talla + "</td>";
            row += "<th>" + element.marca + "</td>";
            row += "<th> C$" + element.precioVenta + "</td>";
            row += "<th><button class='btn btn-success' data-element='" + JSON.stringify(element) + "' id='seleccionar' data-toggle='tooltip' title='Seleccionar'><i class='fa fa-check'></i></button></td>";
            row += "</tr>";
            $("#tabla_productos").append(row);
        });

        $("#productos-modal").modal("show");
    };

    $(document).on("click", ".input-group-append", function () {
        getProductos().then(response => {
            productos = response;
            CargarTablaP(productos);
        });
    });

    

    $(document).on("click", "#seleccionar", function () {
        
        productSelected = $(this).data("element");
        console.log(productSelected);
        $('input[data-detalle-name="IdProducto"]').val(0);
        $('input[data-detalle-name="NombreProducto"]').val(productSelected.nombreProducto);
        $('input[data-detalle-name="PrecioVenta"]').val(productSelected.precioVenta);
        let detalle = `Producto : ${productSelected.nombreProducto}
Marca : ${productSelected.marca}
Talla : ${productSelected.talla}
Precio : ${productSelected.precioVenta}
Color : ${productSelected.color}`;
        $('textarea[data-detalle-name="Detalle"]').val(detalle);

        $("#productos-modal").modal("hide");

        $('input[data-detalle-name="Cantidad"]').prop("readonly", false);

    });

    $(document).on("submit", "#frm-compra", function (event) {

        event.preventDefault();
        event.stopPropagation();


        event.preventDefault();
        event.stopPropagation();

        let formValidation = Module.get("form-validation");
        let TblVentas = formValidation.GetDataForm("data-name", "name");
        TblVentas.Total = $formater.unformatDecimalString(TblVentas.Total);
        TblVentas.detalle = detalle;

        if (!detalle.length) {
            swal({
                title: "Venta",
                text: "Debe ingresar productos al carrito",
                icon: "error",
                button: "Ok",
            });
            return false;
        }
        $.post("/api/venta", TblVentas).then((response) => {
            swal({
                title: "Venta!",
                text: "Venta realizada exitosamente!",
                icon: "success",
                button: "Ok",
            }).then(() => {

                window.location.href = "/Facturacion/Venta/Ventas";

            });
        });
    });

    $(document).on("submit", "#frm-detalle", function (event) {
        event.preventDefault();
        event.stopPropagation();

        if (!productSelected) {

            swal({
                title: "Producto no seleccionado",
                text: "Debe seleccionar un producto.",
                icon: "info",
                button: "Ok",
            });

            return false;
        }
        let cantidadIngresada = +$('input[data-detalle-name="Cantidad"]').val();
        
        if (!cantidadIngresada) {
            swal({
                title: "Datos incorrectos",
                text: "La cantidad debe ser mayor a 0.",
                icon: "info",
                button: "Ok",
            });
            return false;
        }

        if (+productSelected.cantidad < +cantidadIngresada) {

            swal({
                title: "Stock insuficiente",
                text: "Lamentamos informarle que no hay suficientes productos en stock, cantidad disponible " + productSelected.cantidad,
                icon: "info",
                button: "Ok",
            });
            return;
        }

        productSelected.cantidad = cantidadIngresada;

        let product = detalle.find((d) => d.nombreProducto === productSelected.nombreProducto && d.marca === productSelected.marca
            && d.talla === productSelected.talla && d.color === productSelected.color);

        if (product) {

            detalle = detalle.filter((d) => d.id !== product.id);
            product.Cantidad = productSelected.Cantidad;
            detalle.push(product);
            this.reset();
            loadDetalle(detalle);
        }
        else {

            productSelected.id = detalle.length + 1;

            let cnt = $formater.formatDecimalString(productSelected.cantidad.toString());

            let precioV = $formater.formatDecimalString(productSelected.precioVenta.toString());

            productSelected.subTotal = $formater.unformatDecimalString(cnt) * $formater.unformatDecimalString(precioV);
            detalle.push(productSelected);
            this.reset();
            loadDetalle(detalle);
        }

        productSelected = null;
        $('input[data-detalle-name="Cantidad"]').prop("readonly", true);
        loadDetalle(detalle);
    });

    const loadDetalle = (data) => {
        let row = "";
        let button = Module.get("Table");
        $.each(data, function (i, element) {
            row += `<tr>
                        <td>${element.nombreProducto}</td><td>${element.marca}</td><td>${element.talla}</td><td>${element.color}</td><td>${element.cantidad}</td><td>C$ ${element.precioVenta}</td><td>C$ ${$formater.formatDecimalString(element.subTotal.toString())}</td>
                        <td>${button.GenerateButton("btn btn-danger", "fas fa-trash", remove, element.id)}</td>
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

    $(document).on("change", "input[data-name='Descuento']", function () {
        CalcuteTotalesCompra();
    });

    $(document).on("change", "input[data-name='Iva']", function () {
        CalcuteTotalesCompra();
    });
});