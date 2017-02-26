
Declare("Uma.Admin", {
    serverModel: null,
    self: null,
    model: ko.observable(),
    validationErrors: [],

    init: function () {

        var self = Uma.Admin;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);
    },

    doSaveCallCaps: function () {

        var self = Uma.Admin;
        var url = '/Admin/SaveCallCaps/';
        var msg = "";

        if (self.isModelValid(self.model())) {

            var data = ko.mapping.toJSON(self.model);

            $.ajax({
                url: url,
                data: data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8"
            })


            // look this up...new in JQuery 3.0
            .done(function (x) {

                if (x) {
                    modal({
                        type: x.Status ? 'error' : 'inverted',
                        title: x.Title,
                        text: x.Message,
                        size: 'normal',
                        buttons: [
                            {
                                text: 'OK',
                                val: 'ok',
                                eKey: true,
                                addClass: 'btn-light-blue'
                            }
                        ]
                    });
                }
            })
                // This would be some AJAX error....
            .fail(function (errorMessage) {
                msg = 'Call cap save issue (ajax error)';
                modal({
                    type: 'error',
                    title: 'Call Cap save failure',
                    text: msg,
                    size: 'normal',
                    buttons: [
                        {
                            text: 'OK',
                            val: 'ok',
                            eKey: true,
                            addClass: 'btn-light-blue'
                        }
                    ]
                });
                console.log(errorMessage);
            })
            .always(function () {
                //self.toggleSaveLoader(false);
            });

        } else {
            var message = "<div>Please review the following errors:</div><br/><ul>";

            _.each(self.validationErrors, function (item) {
                message = message + "<li>" + item + "</li>";
            });
            message = message + "</ul>";

            modal({
                type: 'error',
                title: 'Call cap save issue',
                text: message,
                size: 'normal',
                buttons: [
                    {
                        text: 'OK',
                        val: 'ok',
                        eKey: true,
                        addClass: 'btn-light-blue'
                    }
                ]
            });
        }
    },

    // Check to see if the model is valid per requirements before we save it.
    isModelValid: function (model) {

        var self = Uma.Admin;
        self.validationErrors = [];

        // **********************// Validation for Call Cap page **********************//
        // Use the () to un-wrap
        // Call caps should be integer?
        Uma.validation.isNumeric(model.StudentId(), self.validationErrors);

        return self.validationErrors.length === 0;
    },

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doReset: function () {
        var url = "/Admin/";
        document.location.href = url;
    }
});
