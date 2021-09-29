function Validations() {
    /**
     * Aplica todas las máscaras y relevantes a validaciones.
     */
    this.Initialize = function () {
        this.ApplyMasks(); // Aplicación de máscaras en entradas.
    };

    /**
    * Aplica máscaras a entradas en formularios.
    */
    this.ApplyMasks = function () {
        // Aplicar máscara de enteros a campos.
        $(document).on("keyup", "input[data-val-masktype='integer']", function () {
            var text = $(this).val(),
                textFormat = $formater.formatIntegerString(text);
            $(this).val(textFormat).focusout().focusin(); // Agregando valor y desencadenando validaciones adicionales.
        });

        // Aplicar máscara de decimales a campos.
        $(document).on("keyup", "input[data-val-masktype='decimal']", function () {
            var text = $(this).val(),
                textFormat = $formater.formatDecimalString(text);
            $(this).val(textFormat).focusout().focusin(); // Agregando valor y desencadenando validaciones adicionales.
        });

        // Aplicar máscara de date a campos.
        $("input[data-val-masktype='date']").each(function (index, element) {
            var options = {};
            $datetimepicker.createDatepicker(element, options);
            $(this).focusout().focusin(); // Desencadenando validaciones adicionales.
        });

        //// Aplicar máscara de time a campos.
        //$("input[data-val-masktype='timespan']").each(function (index, element) {
        //    var options = {};
        //    $datetimepicker.createTimepicker(element, options);
        //    $(this).focusout().focusin(); // Desencadenando validaciones adicionales.
        //});

        //// Aplicar máscara de datetime a campos.
        //$("input[data-val-masktype='datetime']").each(function (index, element) {
        //    var options = {};
        //    $datetimepicker.createDatetimepicker(element, options);
        //    $(this).focusout().focusin(); // Desencadenando validaciones adicionales.
        //});

        // Limpiar campo al presionar Esc.
        $(document).on("keyup", "input:focus", function (e) {
            var input = $(e.target);
            if (e.key) {
                if (e.key.toLowerCase() === "escape") {
                    $(input).val("");
                }
            }
        });

        // Identifica los textarea y registra longitudes.
        $(document).on("keyup", "textarea[data-val-textarea='true']", function () {
            var minLength = $attr.dataLengthMin(this),
                maxLength = $attr.dataLengthMax(this);
            $validator.validateTextArea(this, minLength, maxLength, false);
        });

        // Registra las máscaras aplicables a todos los elementos input al inicio de la vista.
        $(":input:not([type=hidden]):not([type=submit]):not(button)").each(function (index, element) {
            $(element).keyup();
        });

        // Registra evento al hacer clic sobre un campo numérico para limpiar campo.
        $(document).on("click", "[data-val-masktype='integer'],[data-val-masktype='decimal']", function () {
            var text = $formater.unformatDecimalString($(this).val()),
                number = new BigNumber(text),
                zero = new BigNumber("0");
            if (number.comparedTo(zero) === 0 && !($(this).attr('readonly') === "readonly" || $(this).attr('readonly') === "true" || $(this).attr('readonly') === true)) {
                $(this).val("");
            }
        });

        // Registra evento al salir del campo para colocar cero por defecto.
        //$(document).on("focusout", "[data-val-masktype='integer'],[data-val-masktype='decimal']", function () {
        //    var text = $(this).val() || "";
        //    if (text.length === 0 && !$validator.isOptional(this)) {
        //        var masktype = $attr.dataMasktype(this);
        //        if (masktype === "integer") {
        //            $(this).val("0");
        //        } else if (masktype === "decimal") {
        //            $(this).val("0.00");
        //        }
        //    }
        //});

        // Limpia la cadena de entrada de inicio y fin
        $(document).on("focusout", 'textarea,input[type="text"]', function () {
            var inputText = ($(this).val() || "").replace(/[ ]+/gm, " ").trim();
            $(this).val(inputText);
        });
    };

    /**
     * Registra el indicador de campos requeridos para los campos obligatorios establecidos mediante DataAnnotations.
     */
    this.DataValRequiredIndicator = function () {
        $("input,select,textarea").each(function (index, element) {
            $validator.addRequiredIndicator(element);
        });
    };

    /**
     * Registra el indicador de campos requeridos para los campos obligatorios establecidos mediante DataAnnotations.
     * @param {string} formSelector Selector del form donde se aplicará el indicador.
     */
    this.DataValRequiredIndicatorForm = function (formSelector) {
        $(formSelector).find("input,select,textarea[data-val-required]").each(function (index, element) {
            $validator.addRequiredIndicator(element);
        });
    };

    /**
     * Registra el indicador de campos opcionales para los campos establecidos mediante DataAnnotations.
     * @param {string} formSelector Selector del form donde se aplicará el indicador.
     */
    this.DataValOptionalIndicatorForm = function (formSelector) {
        $(formSelector).find("input,select,textarea").each(function (index, element) {
            $validator.addOptionalIndicator(element);
        });
    };

    /**
     * Registra los globos de ayuda para los campos.
     */
    this.HelpAlert = function () {
        /**
         * Registra la alerta para ayuda del usuario con caracteres especiales dentro de campos de texto de tipo cadena de texto común (solo restricciones del idioma español).
         */
        $("body").on("click", "i.text-regex-help", function () {
            $alert.info("Los caracteres especiales soportados son: ¿?¡!$%&\\/()=\"'*{}[].,;:+-_#`´<>|°¬¨~@^.");
        });

        /**
         * Registra la alerta para ayuda del usuario con caracteres especiales dentro de campos de texto de tipo textarea (solo restricciones del idioma español).
         */
        $("body").on("click", "i.textarea-regex-help", function () {
            $alert.info("Los caracteres especiales soportados son: ¿?¡!$%&\\/()=\"'*{}[].,;:+-_#`´<>|°¬¨~@^. Además de tabulaciones y saltos de línea.");
        });

        /**
         * Registra la alerta para ayuda del usuario con caracteres especiales dentro de campos de texto de tipo número telefónico.
         */
        $("body").on("click", "i.string-phonenumber-regex-help", function () {
            $alert.info("Ejemplo de los formatos soportados son:\n+(506) 22665544,\n+(506) 2266 5544,\n+(506) 2266-5544,\n+506 2266-5544,\n+506 2266-5544 ext. 502,\n+(506)22665544EXT502, y más.\n" +
                "Tenga presente que los caracteres soportados son: 0-9 +() ext.-# (en cualquier posición)."
            );
        });

        /**
         * Registra la alerta para ayuda del usuario con caracteres especiales dentro de campos de texto de tipo dirección de correo electrónico.
         */
        $("body").on("click", "i.string-email-regex-help", function () {
            $alert.info("Ingrese su dirección de correo electrónico, p. ej. direccion_correo@dominio.com.");
        });

        /**
         * Registra la alerta para ayuda del usuario con caracteres especiales dentro de campos de texto de tipo dirección de correo electrónico.
         */
        $("body").on("click", "i.decimal-regex-help", function () {
            $alert.info("Ingrese números decimales con formato: 9.999.999,99. La coma es el caracter separador de decimales.");
        });
    };
}


const $validations = new Validations();
$validations.Initialize();