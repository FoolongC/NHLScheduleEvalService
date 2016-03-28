function DetailViewModel() {
    var self = this;
    self.detail = ko.observable();
    var spinner = getSpinner();

    function ajaxHelper(uri, method, data) {
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

    self.getTeamDetail = function (item) {
        self.detail('');
        $('#spinnerDetail').append(spinner);
        ajaxHelper('/api/b2bcomparison/' + item.Id, 'GET').done(function (data) {
            $("#spinnerDetail").remove();
            $('#detailTeamName').text(item.TeamName);
            $('#detailTeamCount').text(' - ' + item.Count);
            data.forEach(function (entry) {
                var date = new Date(entry.GameOneDate);
                date =  date.setDate(date.getDate() + 1);
                entry.GameOneDate = ('0' + new Date(date).toLocaleDateString('en-US')).slice(-10);
                date = new Date(entry.GameTwoDate);
                date = date.setDate(date.getDate() + 1);
                entry.GameTwoDate = ('0' + new Date(date).toLocaleDateString('en-US')).slice(-10);
            })
            self.detail(data);
        });
    }
}