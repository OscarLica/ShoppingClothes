$(document).ready(() => {
    const Api = "/api/SubCategoria";
    const editar = "data-editar";
    const remove = "data-eliminar";

    const LoadCategoria = async () => {
        let response = await $.get("/api/Categoria");
        response = response.filter((f) => f.estado === "true");
        $("select[data-name='IdCategoria']").empty();
        $("select[data-name='IdCategoria']").append("<option value=>[Seleccione una opción]</option>");
        $.each(response, function (i, e) {
            $("select[data-name='IdCategoria']").append("<option value=" + e.id + ">" + e.nombre + "</option>");
        });
    }

    $(document).on('click', "button[data-nuevo]", function (event) {
        $("#modal").modal("toggle");
        $("#exampleModalLabel").text("Nueva sub categoria");
        let formValidation = Module.get("form-validation");
        $("#frm")[0].reset();
        LoadCategoria();
        formValidation.InitValidation();
    })

    const load = async () => {
        let response = await $.get(Api);
        let row = "";
        let button = Module.get("Table");
        $.each(response, function (i, element) {
            let checked = element.estado === "true" ? "Si" : "No";
            row += `<tr>
                        <td>${element.nombre}</td><td>${element.idCategoria}</td><td>${checked}</td>
                        <td>${button.GenerateButton("btn btn-primary", "fas fa-pencil", editar, element.id)} &nbsp; ${button.GenerateButton("btn btn-danger", "fas fa-trash", remove, element.id)}</td>
                    </tr>`;

            $(document).on("click", "button[" + editar +"=" + element.id + "" + "]", function () {
                let id = $(this).data("editar");
                $.get(Api+"/Get/" + id).then((response) => {

                    $("#modal").modal("toggle");
                    $("#exampleModalLabel").text("Editar sub categoria");
                    let formValidation = Module.get("form-validation");
                    LoadCategoria().then(() => {
                        formValidation.InitValidation();
                        formValidation.SetDataForm("data-name", response);
                    });
                    
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
        let form = this;
        event.preventDefault()
        event.stopPropagation()
        let formValidation = Module.get("form-validation");
        let catSubCategoria = formValidation.GetDataForm("data-name");

        $("#modal").modal("toggle");

        $.post(Api, catSubCategoria).then(() => {
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