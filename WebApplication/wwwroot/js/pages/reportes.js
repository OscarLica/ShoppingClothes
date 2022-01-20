$(document).ready(() => {
    $(document).on("click", "a[data-download]", function () {
        var endpoint = $(this).data("download");
        var inicio = $("#inicio").val();
        var fin = $("#fin").val();
        var fechas = inicio && fin ? "/" + inicio + "/" + fin : "/null/null";

        if (inicio && fin) {

            if (!ValidaDateTimes(inicio, fin)) {
                swal({
                    title: "Fechas incorrectas",
                    text: "La fecha de inicio debe ser menor que la fecha de fin.",
                    type: "info",
                    showCloseButton: true,
                    confirmButtonText: "Aceptar"
                });
                return false;
            }

        }

        $.get("/Reporte/" + endpoint + fechas).then(response => {
            var blobresult = base64ToBlob(response,"application/pdf");
            const url = window.URL.createObjectURL(blobresult);
            const a = document.createElement('a');
            a.style.display = 'none';
            a.href = url;
            let name = "";
            // the filename you want
            switch (endpoint) {
                case "ReportProductosMasBendidos":
                    name = "productos más vendidos";
                    break;
                case "ReportProductosMenosBendidos":
                    name = "productos menos vendidos";
                    break;
                case "ReportProductosDaniados":
                    name = "productos dañados";
                    break;
            }
            a.download = "Reporte de " + name + ".pdf" ;
            document.body.appendChild(a);
            a.click();
            window.URL.revokeObjectURL(url);

        });
    });

    function ValidaDateTimes(inicio, fin) {
        var fechaFinal = new Date(moment(moment(fin).format('YYYY-MM-DD')));
        var fechaInicial = new Date(moment(moment(inicio).format('YYYY-MM-DD')));
        return new Date(fechaFinal) >= new Date(fechaInicial);
    }
    function base64ToBlob(base64, mimetype, slicesize) {
        if (!window.atob || !window.Uint8Array) {
            // The current browser doesn't have the atob function. Cannot continue
            return null;
        }
        mimetype = mimetype || '';
        slicesize = slicesize || 512;
        var bytechars = atob(base64);
        var bytearrays = [];
        for (var offset = 0; offset < bytechars.length; offset += slicesize) {
            var slice = bytechars.slice(offset, offset + slicesize);
            var bytenums = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                bytenums[i] = slice.charCodeAt(i);
            }
            var bytearray = new Uint8Array(bytenums);
            bytearrays[bytearrays.length] = bytearray;
        }
        return new Blob(bytearrays, { type: mimetype });
    };
});