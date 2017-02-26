Declare("Uma.Reporting", {
    serverModel:        null,
    self:               null,
    model:              ko.observable(),
    validationErrors:   [],

    init: function () {

        var self = Uma.Reporting;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);
    },

    doLaunchSSRS: function () {

        var self = Uma.Reporting;

        var url = '/Reporting/LaunchReport';
        var msg = "";

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
            //document.location.href = "/Reporting/LaunchReport";

            if (x.Status) {
                //document.location.href = "/Reporting/LaunchReport";
                alert("good boy");

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
        .fail(function (errorMessage) {
            msg = 'Reporting problem (ajax error)';
            modal({
                type: 'error',
                title: 'Reporting failure.',
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

    }
});






