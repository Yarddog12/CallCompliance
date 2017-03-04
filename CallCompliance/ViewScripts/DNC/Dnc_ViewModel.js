 Declare("Uma.Dnc", {
    serverModel: null,
    self: null,
    model: ko.observable(),
    validationErrors: [],

    init: function () {

        var self = Uma.Dnc;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);

    },

    doSaveDnc: function () {

        var self = Uma.Dnc;
        var url = '/DNC/SaveDncNumber/';
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
                msg = 'Phone Number (' + self.model.PhoneNumber + ') *** WAS NOT *** added to DNC.  Check that you entered a phone number. (ajax error)';
                modal({
                    type: 'error',
                    title: 'DNC Phone Number failure',
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
                title: 'Dnc Phone Number failure',
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

        var self = Uma.Dnc;
        self.validationErrors = [];

        // **********************// Validation for DNC page **********************//
        // Use the () to un-wrap
        // Phone Number
        Uma.validation.isRequiredField(model.PhoneNumber(), "Phone number to add to DNC is required.", self.validationErrors);
        Uma.validation.isPhoneNumberValid("Invalid phone Number", model.PhoneNumber(), self.validationErrors);
        Uma.validation.isTextFieldOverMaxLength('Phone number too long.  Max length = 20', model.PhoneNumber(), 20, self.validationErrors);

        // Reason for overriding daily dial limit cap (ExceptionReasonId)  This is a dropdown.
        //Uma.validation.isRequiredField(model.DncNameId(), "You must choose a list the phone number will be added too.", self.validationErrors);

        return self.validationErrors.length === 0;
    },

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doReset: function () {
        var url = "/DNC/";
        document.location.href = url;
    }
});






