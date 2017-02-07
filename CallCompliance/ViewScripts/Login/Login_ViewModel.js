Declare("Uma.Login", {
    serverModel:        null,
    self:               null,
    model:              ko.observable(),
    validationErrors:   [],

    init: function () {

        var self = Uma.Login;
        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);
    },

    logIn: function () {

        var self = Uma.Login;

        var url = '/Login/ValidateLogin/';
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
            .done(function(x) {

                if (x.Status) {
                    document.location.href = "/Home/Welcome";

                } else {
                    modal({
                        type: 'error',
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
            .fail(function(errorMessage) {
                msg = 'User Name (' + self.model.UserName + ') could not be authenticated. (ajax error)';
                modal({
                    type: 'error',
                    title: 'Login failure.',
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
            .always(function() {
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
                title: 'Login Failure',
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

        var self = Uma.Login;
        self.validationErrors = [];

        // **********************// Validation for UNBLOCK page **********************//
        // Use the () to un-wrap
        // Phone Number
        //Uma.validation.isRequiredField(model.PhoneNumber(), "Phone number to block is required.", self.validationErrors);
        return self.validationErrors.length === 0;
    },

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doReset: function () {
        var url = "/Login/";
        document.location.href = url;
    }
});






