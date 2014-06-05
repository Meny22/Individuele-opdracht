function hidepanels() {
    $('#cldMatches').css('display', 'none');
    $('#pnlAddPlayer').css('display', 'none');
    $('#pnlAddTeam_Employee').css('display', 'none');
    $('#pnlAddEvent').css('display', 'none');
    $('#pnlAddMatch').css('display', 'none');
    $('#pnlMatchDetails').css('display', 'none');
    $('#pnlAddStadium').css('display', 'none');
    $('#pnlAddTeam').css('display', 'none');

}

$(document).ready(function () {
    var isPostBackObject = document.getElementById('isPostBack');
    var DontHideMatch = document.getElementById('MatchDate');
    var TicketOrMatch = document.getElementById('Ticket');
    if (DontHideMatch != null) {
        DontHideMatch = document.getElementById('MatchDate').value;
    }
    if (TicketOrMatch != null) {
        TicketOrMatch = document.getElementById('Ticket').value;
    }
    if (isPostBackObject == null) {
        hidepanels();
    }
    else if (isPostBackObject != null && DontHideMatch == 'MatchDate' && TicketOrMatch == "") {
        hidepanels();
        $('#pnlMatchDetails').show();
    }
    else {
        hidepanels();
        TicketOrMatch = null;
        $('#cldMatches').show();
    }

});

$("#btnCalander").click(function () {
    if ($("#cldMatches").css('display') == 'none')
        $("#cldMatches").show();
    else
        $('#cldMatches').css('display', 'none');
})


$("#btnAddPlayer").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
    $("#pnlAddPlayer").show();


});

$("#btnAddTeam").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
    $("#pnlAddTeam").show();

})

$("#btnAddEmployee").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
    $("#pnlAddTeam_Employee").show();
})

$("#btnAddMatch").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
        $("#pnlAddMatch").show();
})

$("#btnAddDetails").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
        $("#pnlMatchDetails").show();
})

$("#btnAddEvent").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
        $("#pnlAddEvent").show();
})

$("#btnAddStadium").click(function () {
    hidepanels();
    $('#pnlAddTicketConfirm').css('display', 'none');
    $('#pnlAddSeasonTicket').css('display', 'none');
        $("#pnlAddStadium").show();
})




