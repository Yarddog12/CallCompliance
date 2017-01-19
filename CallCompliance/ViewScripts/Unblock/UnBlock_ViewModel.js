
Declare("UMA.UnBlock", {
    serverModel: null,
    self: null,
    model: ko.observable(),
    validationErrors: [],

    // A list of the Exception Reason Name objects for drop down.
    reasonCollection: ko.observableArray(),
    selectedReasonId: ko.observable(""),

    init: function () {

        var self = UMA.UnBlock;

        // fill in the dropdown
        self.fillCollectionDropDown();

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }

        // apply bindings after the computed functions
        //ko.applyBindings(self.model);
    },

    // this method will fill the collection dropdown 
    // from the server model's list of reason Collections
    fillCollectionDropDown: function () {

        var self = UMA.UnBlock;

        var dropDownModel = function(id, name) {
            this.selectedId = id;
            this.country = name;
        };

        self.ignoreEvents = true;

        // get the array of reasonCollectionDto objects
        var collectionDtoList = self.model.ExceptionReasonNames;

        // for each reasonCollectionDto, add it to the drop down list
        for (var index = 0; index != collectionDtoList.length; index++) {
            var collectionDto = collectionDtoList[index];
            var item1 = new dropDownModel(collectionDto.Id, collectionDto.ReasonName);
            self.reasonCollection.push(item1);
        };

        ko.applyBindings(self);
        self.ignoreEvents = false;
    },

    doSaveUnblock: function () {

        var self = UMA.UnBlock;
        var url = '/Unblock/SaveUnblockNumber/';
        self.model.ReasonId = self.selectedReasonId().selectedId;

        var data = ko.mapping.toJSON(self.model);
        var msg = "";

        if (self.isModelValid(self.model)) {

            $.ajax({
                    url: url,
                    data: data,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8"
                })


            // look this up...new in JQuery 3.0
            .done(function(x) {

                if (x) { 
                    //msg = 'Phone Number ' + self.model.PhoneNumber + ' has been unblocked';
                    modal({
                        type: x.Status ? 'error' : 'inverted',
                        title: x.Title,
                        text:  x.Message,
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

                    //var url = "/Internal/Admin/Profile/" + userId;
                    //location.href = url;
                }
            })
                // This would be some AJAX error....
            .fail(function(errorMessage) {
                msg = 'Phone Number (' + self.model.PhoneNumber + ') has *** NOT *** been unblocked.  Check that you entered a phone number. (ajax error)';
                modal({
                    type: 'error',
                    title: 'Unblock Phone Number failure',
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
                title: 'Unblock Phone Number failure',
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

        var self = UMA.UnBlock;
        self.validationErrors = [];

        // **********************// Validation for UNBLOCK page **********************//

        // Phone Number
        uma.validation.isRequiredField (model.PhoneNumber, "Phone number to block is required.", self.validationErrors);
        uma.validation.isPhoneNumberValid ("Invalid phone Number", model.PhoneNumber, self.validationErrors);
        uma.validation.isTextFieldOverMaxLength ('Phone number too long.  Max length = 20', model.PhoneNumber, 20, self.validationErrors);

        // Reason for overriding daily dial limit cap (ExceptionReasonId)  This is a dropdown.
        uma.validation.isRequiredField(model.ReasonId, "You must choose a reason for overriding the daily dial limit cap.", self.validationErrors);

        // Student or Employer name (Requestor department)
        uma.validation.isTextFieldOverMaxLength ('Student or Employer name too long.  Max length = 100', model.RequestorDepartment, 100, self.validationErrors);
       
        // StudentId should be an integer, no characthers
        uma.validation.isNumeric(1, self.validationErrors);

        // Included additional details (notes)
        uma.validation.isRequiredField(model.Notes, "You must enter a few additional details please.", self.validationErrors);
        uma.validation.isTextFieldOverMaxLength('Additional details field too long.  Max length = 500', model.Notes, 500, self.validationErrors);

        return self.validationErrors.length == 0;
    },

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doReset: function () {
        var url = "/Unblock/";
        location.href = url;
    },

    //toggleSaveLoader: function (isLoading) {
    //    if (isLoading) {
    //        $("#save").addClass("active");
    //        $("#save").prop("disabled", true);
    //    }
    //    else {
    //        $("#save").removeClass("active");
    //        $("#save").prop("disabled", false);
    //    }
    //}
});

ko.bindingHandlers.formatPhone = {
    update: function (element, valueAccessor) {
        var phone = ko.utils.unwrapObservable(valueAccessor());
        if (phone) {
            var formatPhone = function () {
                return phone.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
            }
            ko.bindingHandlers.text.update(element, formatPhone);
        }
    }
};



