
Declare("Uma.CoolDown", {
    serverModel: null,
    self: null,
    model: ko.observable(),
    validationErrors: [],

    init: function () {

        var self = Uma.CoolDown;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);
    },

    doSaveUnblock: function () {

        var self = Uma.CoolDown;
        var url = '/CoolDown/SaveCoolDownNumber/';
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
                msg = 'Phone Number (' + self.model.PhoneNumberCoolDown + ') has *** NOT *** been cooled down.  Check that you entered a phone number. (ajax error)';
                modal({
                    type: 'error',
                    title: 'CoolDown Phone Number failure',
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
                title: 'CoolDown Phone Number failure',
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

        var self = Uma.CoolDown;
        self.validationErrors = [];

        // **********************// Validation for CoolDown page **********************//
        // Use the () to un-wrap
        // Phone Number to Cool Down
        Uma.validation.isRequiredField(model.PhoneNumberCoolDown(), "Phone number to cool down is required.", self.validationErrors);
        Uma.validation.isPhoneNumberValid("Invalid phone Number", model.PhoneNumberCoolDown(), self.validationErrors);
        Uma.validation.isTextFieldOverMaxLength('Phone number too long.  Max length = 20', model.PhoneNumberCoolDown(), 20, self.validationErrors);

        // Student Name
        Uma.validation.isTextFieldOverMaxLength('Student name too long.  Max length = 50', model.StudentName(), 50, self.validationErrors);

        // StudentId should be an integer, no characthers
        Uma.validation.isNumeric(model.StudentId(), self.validationErrors);

        // Included additional details (notes)
        Uma.validation.isRequiredField(model.Notes(), "You must enter a few additional details please.", self.validationErrors);
        Uma.validation.isTextFieldOverMaxLength('Additional details field too long.  Max length = 500', model.Notes(), 500, self.validationErrors);

        return self.validationErrors.length === 0;
    },

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doReset: function () {
        var url = "/CoolDown/";
        document.location.href = url;
    }
});
