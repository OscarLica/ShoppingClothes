$(document).ready(() => {
    const Api = "/api/Proveedor";
    const editar = "data-editar";
    const remove = "data-eliminar";

    $(document).on('click', "button[data-nuevo]", function (event) {
        $("#modal").modal("toggle");
        $("#exampleModalLabel").text("Nuevo proveedor");
        let formValidation = Module.get("form-validation");
        $("#frm")[0].reset();
        formValidation.InitValidation();
    })

    const load = async () => {
        let response = await $.get(Api);
        let row = "";
        let button = Module.get("Table");
        $.each(response, function (i, element) {
            row += `<tr>
                        <td>${element.nombreCompañia}</td><td>${element.nombreContacto}</td><td>${element.cargoContacto}</td><td>${element.direccion}</td><td>${element.telefono}</td><td>${element.email}</td>
                        <td>${button.GenerateButton("btn btn-primary", "fas fa-pencil", editar, element.id)} &nbsp; ${button.GenerateButton("btn btn-danger", "fas fa-trash", remove, element.id)}</td>
                    </tr>`;

            $(document).on("click", "button[" + editar +"=" + element.id + "" + "]", function () {
                let id = $(this).data("editar");
                $.get(Api+"/Get/" + id).then((response) => {

                    $("#modal").modal("toggle");
                    $("#exampleModalLabel").text("Editar proveedor");
                    let formValidation = Module.get("form-validation");
                    formValidation.InitValidation();
                    formValidation.SetDataForm("data-name", response);
                });
            });

            $(document).on("click", "button[" + remove + "=" + element.id + "" + "]", function () {
                let id = $(this).data("eliminar");
                swal({
                    title: "Eliminar?",
                    text: "¿Está seguro que desea eliminar el registro?",
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
        let frm = this;
        event.preventDefault()
        event.stopPropagation()
        let formValidation = Module.get("form-validation");
        let catProveedor = formValidation.GetDataForm("data-name");

        $("#modal").modal("toggle");

        $.post(Api, catProveedor
        ).then(() => {
            swal({
                title: "Exito!",
                text: "Proceso realizado exitosamente!",
                icon: "success",
                button: "Ok",
            }).then(() => {

            });
            load();
            frm.reset();
        }).catch(() => {

        });
    });
    load();
});