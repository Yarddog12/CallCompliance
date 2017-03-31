Declare("Uma.WhiteList", {
    serverModel: null,
    self: null,
    model: ko.observable(),
    validationErrors: [],

    init: function () {

        var self = Uma.WhiteList;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);
    },

    doSaveWhiteList: function (string var1, int var2, double var3, lak) {

        var self = Uma.WhiteList;
        var url = '/WhiteList/SaveWhiteListNumber/';
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

                    // Clear the page by calling Reset button.
                    Uma.WhiteList.doReset();
                }
            })
                // This would be some AJAX error....
            .fail(function (errorMessage) {
                msg = 'Phone Number (' + self.model.PhoneNumber + ') *** WAS NOT *** added to white list.  Check that you entered a phone number. (ajax error)';
                modal({
                    type: 'error',
                    title: 'WhiteList Phone Number failure',
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
                title: 'WhiteList Phone Number failure',
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

        var self = Uma.WhiteList;
        self.validationErrors = [];

        // **********************// Validation for WhiteList page **********************//
        // Use the () to un-wrap
        // Phone Number
        Uma.validation.isRequiredField(model.PhoneNumber(), "Phone number to white list is required.", self.validationErrors);
        Uma.validation.isPhoneNumberValid("Invalid phone Number", model.PhoneNumber(), self.validationErrors);
        Uma.validation.isTextFieldOverMaxLength('Phone number too long.  Max length = 20', model.PhoneNumber(), 20, self.validationErrors);

        // Included additional details (notes)
        Uma.validation.isRequiredField(model.Notes(), "You must enter a few additional details please.", self.validationErrors);
        Uma.validation.isTextFieldOverMaxLength('Additional details field too long.  Max length = 500', model.Notes(), 500, self.validationErrors);
        Uma.validation.isTextFieldUnderMinLength ('Additional details field not long enough.  Minimum length = 10', model.Notes(), 10, self.validationErrors);

        return self.validationErrors.length === 0;
    },

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doReset: function () {
        var url = "/WhiteList/";
        document.location.href = url;
    }
});






