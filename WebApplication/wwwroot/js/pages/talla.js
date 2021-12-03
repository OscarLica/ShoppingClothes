$(document).ready(() => {
    const Api = "/api/Talla";
    const editar = "data-editar";
    const remove = "data-eliminar";

    $(document).on('click', "button[data-nuevo]", function (event) {
        $("#modal").modal("toggle");
        $("#exampleModalLabel").text("Nueva talla");
        let formValidation = Module.get("form-validation");
        $("#frm")[0].reset();
       $("input[data-name='Id']").val(0);
        formValidation.InitValidation();
    })

    const load = async () => {
        let response = await $.get(Api);
        let row = "";
        let button = Module.get("Table");
        $.each(response, function (i, element) {
            let checked = element.estado === "true" ? "Si" : "No";
            row += `<tr>
                        <td>${element.nombre}</td><td>${checked}</td>
                        <td>${button.GenerateButton("btn btn-primary", "fas fa-pencil", editar, element.id)} &nbsp; ${button.GenerateButton("btn btn-danger", "fas fa-trash", remove, element.id)}</td>
                    </tr>`;

            $(document).on("click", "button[" + editar +"=" + element.id + "" + "]", function () {
                let id = $(this).data("editar");
                $.get(Api+"/Get/" + id).then((response) => {

                    $("#modal").modal("toggle");
                    $("#exampleModalLabel").text("Editar talla");
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
        let catTalla = formValidation.GetDataForm("data-name");

        $("#modal").modal("toggle");

        $.post(Api, catTalla).then(() => {
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