Module.create('Table', {
    name: 'Table',
    description: 'Módulo que contiene funciones para agregar información al table',
    version: '1.0'
});


Module.append('Table', {

    GenerateButton: function (clas, icono, data, item) {
        return `<button type="button" class="${clas}" ${data}="${item}"><i class="${icono}"></i></button>`;
    }
});
