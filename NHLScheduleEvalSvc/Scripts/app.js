var ViewModel = function () {
    var self = this;
    self.teams = ko.observableArray();
    self.detail = ko.observable();
    self.error = ko.observable();

    var teamsUri = '/api/teams/';
    var b2bComparisonUri = '/api/b2bcomparison/';

    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllTeams() {
        ajaxHelper(teamsUri, 'GET').done(function (data){
            self.teams(data);
        });
    }

    getAllTeams();

    self.getTeamDetail = function (item) {
        self.detail('');
        $('#detailTeamName').text(item.TeamName);
        $('#detailTeamCount').text(' - Count: ' + item.Count);
        ajaxHelper(b2bComparisonUri + item.Id, 'GET').done(function (data) {
            data.forEach(function (entry) {
                entry.GameOneDate = entry.GameOneDate.replace('T00:00:00', '')
                entry.GameTwoDate = entry.GameTwoDate.replace('T00:00:00', '')
            })
            self.detail(data);
        });
    }
};

ko.applyBindings(new ViewModel());