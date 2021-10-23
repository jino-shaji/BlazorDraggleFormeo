import { FormeoEditor, FormeoRenderer } from 'formeo'
var editor = null;
var renderer = null;
var options = {
    editorContainer: 'div.formeo-wrap',
    svgSprite: 'https://draggable.github.io/formeo/assets/img/formeo-sprite.svg',
    events: {
        onRender: (element) => {
            console.log('onRender', element);
        },
        formeoLoaded: (element) => {
            console.log('formeoLoaded');
        },
        onUpdate: (element) => {
            console.log('onUpdate');
        },
        onSave: (element) => {
            const formData = editor.formData
            console.log('onSave', JSON.stringify(formData));
            window.localStorage.setItem('formdata', JSON.stringify(formData));
            console.log('element', element);
        },
    },
};
var optionsRender = {
    renderContainer: '#formeo-wrap-render',
    svgSprite: 'https://draggable.github.io/formeo/assets/img/formeo-sprite.svg',
};

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

window.alert = {
    confirm: function (message) {
        var res = confirm(message);
        return res;
    },
    successAlert: function (message) {
        $('#success-message').html(message);
        $('#success-alert').removeClass('d-none');
        setTimeout(() => {
            $('#success-alert').addClass('d-none');
        }, 1500);
    },
    errorAlert: function (message) {
        $('#error-message').html(message);
        $('#error-alert').removeClass('d-none');
        setTimeout(() => {
            $('#error-alert').addClass('d-none');
        }, 1500);
    },
}
window.formDesigner = {
    init: function (formData, TemplateName) {
        if (formData) {
            options.formData = JSON.parse(formData);
        }
        if (TemplateName != '') {
            $('#TemplateName').val(TemplateName);
        }
        console.log('formDesigner.init');
        editor = new FormeoEditor(options);
        console.log(editor, 'editor');
        //const formData = editor.formData
    },
    getFormTemplateData: function () {
        if (JSON.stringify(editor.formData.columns) == "{}")
            return '';
        else
            return JSON.stringify(editor.formData);
    },
    clearForm: function () {
        var res = confirm('Are you sure to clear form?');
        if (res)
            editor = new FormeoEditor(options);
        return res;
    },
    renderForm: function (formData) {
        //var formData = window.localStorage.getItem('formdata');
        console.log('formData new', formData);
        if (formData) {
            renderer = new FormeoRenderer(optionsRender)
            renderer.render(JSON.parse(formData));
        }
    },
    fillFormData: function (userData) {
        console.log('userData', userData);
        $.each(JSON.parse(userData), function (id, value) {
            console.log('checkbox', value, id);
            if ($('#' + id).attr('type') == 'checkbox') {
                $('#' + id).prop('checked', true);
                $('#' + id).attr('readonly', true);
                $('#' + id).attr('disabled', true);
                $('#' + id).trigger('change');
            } else {
                $('#' + id).val(value);
                $('#' + id).trigger('change');
                $('#' + id).attr('readonly', true);
                $('#' + id).attr('disabled', true);
            }
        });
    },
    getData: function () {
        var data = $(optionsRender.renderContainer).serializeArray();
        var values = {};
        console.log('data', data);
        $.each(data, function (i, field) {
            if ($('[name=' + field.name + ']').length > 1) {
                values[$('[name=' + field.name + '][value =' + field.value + ']').attr('id')] = field.value;
            } else {
                values[$('[name=' + field.name + ']').attr('id')] = field.value;
            }
        });
        return JSON.stringify(values);
    },
    validForm: function (formName) {
        var isValid = true;
        $.each($(optionsRender.renderContainer).serializeArray(), function (i, field) {
            console.log('field', field);
          //  $('#' + field.id).attr('required')
            if (field.value == '') {
                isValid = false;
                return isValid;
            }
        });
        return isValid;
    }
}