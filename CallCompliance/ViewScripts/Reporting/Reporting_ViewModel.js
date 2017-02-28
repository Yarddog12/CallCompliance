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

    doLaunchSSRS: function (value) {
                     Uma.Reporting.serverModel.ReportListNames[2].ReportNames
        var report = Uma.Reporting.serverModel.ReportListNames[value].ReportNames;
        alert(report);

        //window.open('http://mlk-ssr-d-sq01/Reports/Pages/Report.aspx?ItemPath=%2fCall+Compliance%2fODS+Status', '_blank');
        window.open('http://mlk-ssr-d-sq01/Reports/Pages/Report.aspx?ItemPath=/Call+Compliance/' + 'ODS Status', '_blank');
    }
});






