function TeamViewModel() {
    var self = this;
    self.teams = ko.observableArray();
    self.error = ko.observable();
    var spinner = getSpinner();

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
        $('#spinnerTeam').append(spinner);
        ajaxHelper('/api/teams/', 'GET').done(function (data) {
            $('#spinnerTeam').remove();
            data.forEach(function (entry) {
                entry.Count = 'Count: ' + entry.Count;
            })
            self.teams(data);
        });
    }

    self.getTeamDetail = function (item) {
        detailContainerVM.getTeamDetail(item);
    }

    getAllTeams();
}