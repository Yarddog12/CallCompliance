Declare("Uma.Reporting", {
    serverModel:        null,
    self:               null,
    model: ko.observable(),

    init: function () {

        var self = Uma.Reporting;

        if (self.serverModel) {
            self.model(ko.mapping.fromJS(self.serverModel));
        }

        self.model().SelectedReportName.subscribe(function (rptName) {
			if (rptName !== undefined) {
                window.open('http://MLK-SSR-P-SQ03/Reports/Pages/Report.aspx?ItemPath=/Call+Compliance/' + rptName, '_blank');
			}
        });

        ko.applyBindings(self.model);
    }
});






