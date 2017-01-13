
someModel = {
    serverModel: null,
    self: null,
    model: ko.observable(),
    validationErrors: [],
    DropDownItems: ko.observableArray([new UnBlockReasonNameDropDown()]),

    init: function () {
        self = someModel;
        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }

        // apply bindings after the computed functions
        ko.applyBindings(self.model);

    },

    // this method is called when the Reset Password button is clicked
    onResetPswdBtnClick: function () {
        BootstrapDialog.show({
            type: BootstrapDialog.TYPE_DANGER,
            title: 'Reset Password',
            message: "<p>Resetting your password will log your account out of Lendscape and invalidate your current password. " + 
                "You will be prompted to type in your new password the next time you login.</p>" +
                "<p style='font-size:12pt'><b>Do you want to proceed?</h2></b>",
            buttons: [
                {
                    label: 'Cancel',
                    action: function (dialog) {
                        dialog.close();
                    }
                },
                {
                    label: 'Confirm',
                    cssClass: 'btn-success',
                    action: function (dialog) {
                        dialog.close();
                        self.doPasswordReset();
                }
            }]
        });
    },

    doSaveProfile: function () {

        var url = '/Internal/Admin/SaveUserProfile/';
        var model = self.model();
        var data = ko.mapping.toJSON(model);
        var userName = model.UserName();

        if (self.isModelValid(model)) {

            self.toggleSaveLoader(true);

            $.ajax({
                url: url,
                data: data,
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8"
            })

           .success(function (data) {
               var userId = data.UserId;
               if (data) {
                   var msg = 'Your profile data has been saved';
                   BootstrapDialog.alert({
                       title: 'My Profile',
                       message: msg,
                       type: BootstrapDialog.TYPE_SUCCESS,
                       closable: true,
                       draggable: true,
                       buttonLabel: 'Close'
                   });

                   var url = "/Internal/Admin/Profile/" + userId;
                   location.href = url;
               }
           })
                t
           .fail(function (errorMessage) {
               console.log(errorMessage);
           })

           .always(function () {
               self.toggleSaveLoader(false);
           })
        } else {
            var message = "<div>Please review the following errors:</div><br/><ul>";

            _.each(self.validationErrors, function (item) {
                message = message + "<li>" + item + "</li>";
            });
            message = message + "</ul>";

            if (userName == null) {
                userName = '<Empty>';
            }

            BootstrapDialog.alert({
                title: 'Problem saving your profile data',
                message: message,
                type: BootstrapDialog.TYPE_DANGER
            });
        }
    },

    //isModelValid: function (model) {
    //    self.validationErrors = [];

    //    fpf.validation.isRequiredField(model.LegalFirstName(), "Legal First Name required.", self.validationErrors);
    //    fpf.validation.isRequiredField(model.FirstName(), "Alias First Name required.", self.validationErrors);
    //    fpf.validation.isRequiredField(model.LastName(), "Last Name required.", self.validationErrors);

    //    var ssn = model.SSN();
    //    if (!fpf.validation.validSSN(ssn)) {
    //        self.validationErrors.push("Invalid SSN (" + ssn + ")");
    //        model.SSN("");
    //    }

    //    var birthDate = model.BirthDate();
    //    var years = moment().diff(birthDate, 'years');

    //    // Greater than 13 and less than 100 years old.
    //    if (years < 14 || years > 99) {
    //        self.validationErrors.push("Valid age is greater than 13 and less than 100.  Age (" + years + ") is invalid.");
    //    }

    //    fpf.validation.isTextFieldOverMaxLength('Social Security Number', model.SSN(), 9, self.validationErrors);

    //    fpf.validation.isTextFieldOverMaxLength('Legal First Name', model.LegalFirstName(), 50, self.validationErrors);
    //    fpf.validation.isTextFieldOverMaxLength('Alias First Name', model.FirstName(), 50, self.validationErrors);
    //    fpf.validation.isTextFieldOverMaxLength('Middle Initial', model.MiddleInitial(), 50, self.validationErrors);
    //    fpf.validation.isTextFieldOverMaxLength('Last Name', model.LastName(), 50, self.validationErrors);
    //    fpf.validation.isTextFieldOverMaxLength('Suffix', model.Suffix(), 15, self.validationErrors);
    //    fpf.validation.isTextFieldOverMaxLength('My Notes', model.MyNotes(), 10000, self.validationErrors);
        
    //    return self.validationErrors.length == 0;
    //},

    // this method is called when the user clicks the Save button in the 
    // Reset Password pop up dialog
    doPasswordReset: function () {
        var url = "/Internal/Admin/DoResetProfilePassword";
        var redirect = "/Account/Logout";
        $.ajax({
            url: url,
            data: null,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8"
        })
        .success(function (data, status, xhr) {
            console.log("Success");
            location.href = redirect;
        })
        .fail(function (errorMessage) {
            console.log(errorMessage);
        })
    },

    toggleSaveLoader: function (isLoading) {
        if (isLoading) {
            $("#save").addClass("active");
            $("#save").prop("disabled", true);
        }
        else {
            $("#save").removeClass("active");
            $("#save").prop("disabled", false);
        }
    },
};

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
