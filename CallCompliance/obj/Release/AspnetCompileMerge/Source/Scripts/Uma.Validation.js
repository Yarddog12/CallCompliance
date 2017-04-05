Declare("Uma.validation", {
    validateEmail: function (email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    },


    // Check to see if the required field exists.  If not, load up the validationErrors to display via modal.
    //
    // Here is how it is called.
    //  var admin = Admin.Shared;
    //  self.validationErrors = [];
    //  self.isRequiredField (model.LegalFirstName(), "Legal First Name required.", self.validationErrors);
    //
    isRequiredField: function (val, errText, validationErrors) {

        if (val == null || val.length === 0) {
            validationErrors.push(errText);
        }
    },

    isRequiredDropDown: function (val, errText, validationErrors) {

        if (val == null || val.length === 0 || val === 0) {
            validationErrors.push(errText);
        }
    },
    // Check the lengths of the fields so we don't over run the text box.
    //
    // fpf.validation.isTextFieldOverMaxLength('Display Name', model.DisplayName(), 75, self.validationErrors);
    //
    isTextFieldOverMaxLength: function (txtFieldName, txtFieldValue, len, validationErrors) {
        if (txtFieldValue == null || txtFieldValue.length === 0) {
            return;
        }

        var lenTxt = txtFieldValue.length;
        if (lenTxt > len) {
            validationErrors.push(txtFieldName + " with length of " + lenTxt + " exceeds maximum length of " + len);
        }
    },

    isTextFieldUnderMinLength: function (txtFieldName, txtFieldValue, len, validationErrors) {
        if (txtFieldValue == null || txtFieldValue.length === 0) {
            return;
        }

        var lenTxt = txtFieldValue.length;
        if (lenTxt < len) {
            validationErrors.push(txtFieldName + " with length of " + lenTxt + " needs to be at least " + len + " characters long.");
        }
    },

    // Make sure this number is a valid numeric.
    //
    isNumeric: function (num, validationErrors) {
        if (isNaN(num)) {
            validationErrors.push("The number entered " + num + " is not a valid number.");
        }
    },

    // Checks to see if a valid phone number.
    //
    // fpf.validation.isPhoneNumberValid("Home Phone Number", homePhoneNumber, self.validationErrors);
    //
    isPhoneNumberValid: function (txt, phoneNum, validationErrors) {
        var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
        if (phoneNum == null || phoneNum.length === 0) {
            return true;
        }
        if (phoneNum.match(phoneno)) {
            return true;
        } else {
            validationErrors.push(txt + " (" + phoneNum + ") is invalid.");
            return false;
        }
    },

    phoneNumberFormatter: function(phoneNumber) {
        return '(' + phoneNumber.substr(0, 3) + ')' + phoneNumber.substr(3, 3) + '-' + phoneNumber.substr(6, 4);
    },

    // Validate that all of the necessary parts for the address exist.
    //
    //
    //
    isEntireAddressPresent: function (address, validationErrors) {
        var street1 = true;
        var city = true;
        var stateId = true;
        var zipCode = true;

        // Validate the Addresses (3 of them, Primary, Mailing and Business
        // Primary Residence Address
        if (address.Street1() == null || !address.Street1().length) {
            street1 = false;
        }

        if (address.City() == null || !address.City().length) {
            city = false;
        }

        if (address.StateId() == null || !address.StateId()) {
            stateId = false;
        }

        if (address.PostalCode() == null || !address.PostalCode().length) {
            zipCode = false
        }

        // ************* add the validation ******************
        if (!(!street1 && !city && !stateId && !zipCode)) {
            if (!street1) {
                validationErrors.push("Primary Residence Address: You must provide a Street address.");
            }
            if (!city) {
                validationErrors.push("Primary Residence Address: You must provide a City.");
            }
            if (!stateId) {
                validationErrors.push("Primary Residence Address: You must provide a State.");
            }
            if (!zipCode) {
                validationErrors.push("Primary Residence Address: You must provide a Zipcode.");
            }
        }
    },

    // Standard Social Security validation
    //
    // var ssn = model.SSN();
    // if (!fpf.validation.validSSN(ssn)) {
    //    self.validationErrors.push("Invalid SSN (" + ssn + ")");
    //    model.SSN("");
    // }
    //
    validSSN: function (value) {
        var regex = /^([0-6]\d{2}|7[0-6]\d|77[0-2])([ \-]?)(\d{2})\2(\d{4})$/;

        // return true if no SSN number, since not required.
        if (!regex.test(value)) {
            return false;
        }
        var temp = value;
        if (value.indexOf("-") !== -1) {
            temp = (value.split("-")).join("");
        }
        if (value.indexOf(" ") !== -1) {
            temp = (value.split(" ")).join("");
        }
        if (temp.substring(0, 3) === "000") {
            return false;
        }
        if (temp.substring(3, 5) === "00") {
            return false;
        }
        if (temp.substring(5, 9) === "0000") {
            return false;
        }
        return true;
    }
});
