Declare("Uma.Reporting", {
    serverModel:        null,
    self:               null,
    model: ko.observable(),

    init: function () {

        var self = Uma.Reporting;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }
        ko.applyBindings(self.model);
    },

    doLaunchSSRS: function () {
        window.open('http://mlk-ssr-d-sq01/Reports/Pages/Report.aspx?ItemPath=/Call+Compliance/' + 'ODS Status', '_blank');
    }
});






