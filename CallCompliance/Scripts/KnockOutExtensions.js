Declare("fpf.util.format", {
    phone: function (value) {
        if (value.length <= 10) {
            value = value.replace(/(\d\d\d)(\d\d\d)(\d\d\d\d)/, '($1) $2-$3');
        } else {
            value = value.replace(/(\d\d\d)(\d\d\d)(\d\d\d\d)(\d+)/, '($1) $2-$3 x$4');
        }
        return value;
    }
});

ko.bindingHandlers.phoneNumber = {
    formatNumber: function (box) {
        var box = $(box);
        var value = box.data("value");
        if (!value) { return; }
        value = fpf.util.format.phone(value);
        $(box).val(value);
    },
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        if (!valueAccessor()) {
            throw "Model does not contain the bound property. " + $(element).attr("data-bind");
        }
        var _this = ko.bindingHandlers.phoneNumber;
        var textbox = $(element);
        textbox.keydown(function (e) {
            // allow cut/copy/paste
            if (e.ctrlKey && (e.which === 67 || e.which === 86 || e.which === 88)) {
                return;
            }
            // allow delete, backspace and tab
            if (e.which === 8 || e.which === 46 || e.which === 9) {
                return;
            }
            // Ensure that a number was pushed
            if (e.shiftKey || !((e.which >= 48 && e.which <= 57) || (e.which >= 96 && e.which <= 105))) {
                e.preventDefault();
            }
        });
        textbox.focusin(function (e) {
            var value = textbox.data("value") || "";
            textbox.val(value);
        });
        textbox.focusout(function (e) {
            var value = textbox.val().replace(/[^0-9]+/g, '');
            textbox.data("value", value);
            _this.formatNumber(this);
            valueAccessor()(value);
        });
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        if (!valueAccessor()) {
            throw "Model does not contain the bound property. " + $(element).attr("data-bind");
        }
        var _this = ko.bindingHandlers.phoneNumber;
        var textbox = $(element);
        if (!valueAccessor()()) {
            textbox.val("");
            return;
        }
        var value = valueAccessor()().replace(/[^0-9]+/g, '');
        textbox.data("value", value);
        _this.formatNumber(textbox);
    }
};