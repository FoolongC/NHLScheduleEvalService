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
});