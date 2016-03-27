var teamsContainerVM;
var detailContainerVM;

$(document).ready(function () {

    $('.alert').hide();    

    if ($.isEmptyObject(teamsContainerVM)) {
        teamsContainerVM = new TeamViewModel();
        ko.applyBindings(teamsContainerVM, document.getElementById("teamsContainer"));
    }

    if ($.isEmptyObject(detailContainerVM)) {
        detailContainerVM = new DetailViewModel();
        ko.applyBindings(detailContainerVM, document.getElementById("detailContainer"));
    }

    //var ViewModel = function () {
    //    var self = this;
    //    self.teams = ko.observableArray();
    //    self.detail = ko.observable();
    //    self.error = ko.observable();

    //    var teamsUri = '/api/teams/';
    //    var b2bComparisonUri = '/api/b2bcomparison/';

    //    function ajaxHelper(uri, method, data) {
    //        self.error('');
    //        return $.ajax({
    //            type: method,
    //            url: uri,
    //            dataType: 'json',
    //            contentType: 'application/json',
    //            data: data ? JSON.stringify(data) : null
    //        }).fail(function (jqXHR, textStatus, errorThrown) {
    //            self.error(errorThrown);
    //        });
    //    }

    //    function getAllTeams() {
    //        $('#spinnerTeam').append(spinner);
    //        ajaxHelper(teamsUri, 'GET').done(function (data) {
    //            $('#spinnerTeam').remove();
    //            data.forEach(function (entry) {
    //                entry.Count = 'Count: ' + entry.Count;
    //            })
    //            self.teams(data);
    //        });
    //    }

    //    getAllTeams();

    //    self.getTeamDetail = function (item) {
    //        self.detail('');
    //        $('#spinnerDetail').append(spinner);
    //        ajaxHelper(b2bComparisonUri + item.Id, 'GET').done(function (data) {
    //            $("#spinnerDetail").remove();
    //            $('#detailTeamName').text(item.TeamName);
    //            $('#detailTeamCount').text(' - ' + item.Count);
    //            data.forEach(function (entry) {
    //                entry.GameOneDate = ('0' + new Date(entry.GameOneDate).toLocaleDateString('en-US')).slice(-10);
    //                entry.GameTwoDate = ('0' + new Date(entry.GameTwoDate).toLocaleDateString('en-US')).slice(-10);
    //            })
    //            self.detail(data);
    //        });
    //    }
    //};

    //ko.applyBindings(new ViewModel());
});