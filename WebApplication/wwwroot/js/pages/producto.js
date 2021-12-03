$(document).ready(() => {
    const Api = "/api/Producto";
    const editar = "data-editar";
    const remove = "data-eliminar";

    const loadSubCategoria = async () => {
        let response = await $.get("/api/SubCategoria");
        $("select[data-name='IdSubCategoria']").empty();
        $("select[data-name='IdSubCategoria']").append("<option value>[Seleccione un opción]</option>");

        $.each(response, function (i, e) {
            $("select[data-name='IdSubCategoria']").append("<option value=" + e.id + ">"+e.nombre+"</option>");
        });
    }

    $(document).on('click', "button[data-nuevo]", function (event) {
        $("#modal").modal("toggle");
        $("#exampleModalLabel").text("Nuevo producto");
        let formValidation = Module.get("form-validation");
        $("#frm")[0].reset();
        loadSubCategoria();
       $("input[data-name='Id']").val(0);
        formValidation.InitValidation();
    })

    const load = async () => {
        let response = await $.get(Api);
        let row = "";
        let button = Module.get("Table");
        $.each(response, function (i, element) {
            let checked = element.estado ==="true" ? "Si" : "No";
            row += `<tr>
                        <td>${element.nombreProducto}</td><td>${element.descripcion}</td><td>${element.idSubCategoria}</td><td>${checked}</td>
                        <td>${button.GenerateButton("btn btn-primary", "fas fa-pencil", editar, element.id)} &nbsp; ${button.GenerateButton("btn btn-danger", "fas fa-trash", remove, element.id)}</td>
                    </tr>`;

            $(document).on("click", "button[" + editar +"=" + element.id + "" + "]", function () {
                let id = $(this).data("editar");
                $.get(Api+"/Get/" + id).then((response) => {

                    $("#modal").modal("toggle");
                    $("#exampleModalLabel").text("Editar producto");
                    let formValidation = Module.get("form-validation");
                    loadSubCategoria().then(() => {
                        formValidation.InitValidation();
                        formValidation.SetDataForm("data-name", response);
                    });
                });
            });

            $(document).on("click", "button[" + remove + "=" + element.id + "" + "]", function () {
                let id = $(this).data("eliminar");
                 swal({
                    title: "Eliminar?",
                    text: "¿Está seguro que desea eliminar el registr?",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {

                            $.get(Api + "/Delete/" + id).then((response) => {
                                load();
                            }).then(() => {
                                swal("Exito! Registro eliminado exitosamente!", {
                                    icon: "success",
                                });
                            });

                        }
                    });
            });
        });
        $("#body").html(row);

    }

    $(document).on("submit", "#frm", function (event) {
        let form = this;
        event.preventDefault()
        event.stopPropagation()
        let formValidation = Module.get("form-validation");
        let producto = formValidation.GetDataForm("data-name");

        $("#modal").modal("toggle");

        $.post(Api, producto).then(() => {
            swal({
                title: "Exito!",
                text: "Proceso realizado exitosamente!",
                icon: "success",
                button: "Ok",
            }).then(() => {

            });
            load();
            form.reset();
        }).catch(() => {

        });
    });
    load();
});