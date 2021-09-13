

window.initForm = function (container) {
    console.log('click', container);
    const fbTemplate = document.getElementById(container);
    $(fbTemplate).formBuilder();
}
var fbEditorContainer = null;
var formBuilder = null;
var options = {
    onSave: function (evt, formData) {
        $('#fb-rendered-form').formRender({ formData });
        console.log(JSON.stringify(formData));
        window.sessionStorage.setItem('formData', JSON.stringify(formData));
    },
};

window.formDesigner = {
    init: function (container) {
        //console.log('formDesigner.init', container);
        fbEditorContainer = document.getElementById(container);
        formBuilder = $(fbEditorContainer).formBuilder(options);
    },
    getData: function () {
        console.log(formBuilder.actions.getData('json'));
    }
}
window.formRender = {
    renderForm: function (container) {
        var formData = '[{"type":"text", "label":"Text Input"}]';

        var options = {
            formData: '[{"type":"text", "label":"Text Input"}]',
            dataType: 'json'
        };
        $('#fb-rendered-form').formRender({ formData });
        //console.log('formDesigner.init', container);
        fbEditorContainer = document.getElementById(container);
        formBuilder = $(fbEditorContainer).formBuilder(options);
    },
    getData: function () {
        console.log(formBuilder.actions.getData('json'));
    }
}
//docs https://formbuilder.online/