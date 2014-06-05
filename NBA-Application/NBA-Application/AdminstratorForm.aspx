<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminstratorForm.aspx.cs" Inherits="NBA_Application.AdminstratorForm" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<%@ Register src="MatchesOnDate.ascx" tagname="MatchesOnDate" tagprefix="uc1" %>

<%@ Register src="TicketsAdd.ascx" tagname="TicketsAdd" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administator panel</title>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <script type="text/javascript">
</script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID = "lblWelcome" runat="server" Text = "Welcome Meny Metekia"></asp:Label>
    <div class = "btn-group">
        <asp:Button ID="btnAddPlayer" class = "btn btn-primary" runat="server" 
            Text="Add Player" onclientclick="return false;" />
        <asp:Button ID="btnAddTeam" class = "btn btn-primary" runat="server" style="margin-bottom: 0px" 
            Text="Add Team" onclientclick="return false;" />
        <asp:Button ID="btnAddMatch" class = "btn btn-primary" runat="server" Text="Add Match" 
             onclientclick="return false;" />
        <asp:Button ID="btnAddDetails" class = "btn btn-primary" runat="server" Text="Add Match details" 
            onclientclick="return false;" />
            </div>
            <asp:Button ID="btnLogOut" class ="btn btn-default" runat="server" PostBackUrl="~/Home.aspx" 
        Text="Log out" />
            <br />
            <br />
            <div class = "btn-group" id = "btn-group2">
        <asp:Button ID="btnAddEmployee" class = "btn btn-primary" runat="server" Text="Add Team-Employee" 
            Width="154px" 
            onclientclick="return false;" />
        <asp:Button ID="btnAddStadium" class = "btn btn-primary" runat="server" 
            Text="Add Stadium" Width="151px" 
            onclientclick="return false;" />
        <asp:Button ID="btnAddTickets" class = "btn btn-primary" runat="server" Text="Add Tickets" 
            Width="125px" onclick="btnAddTickets_Click" />
        <asp:Button ID="btnAddEvent" class = "btn btn-primary" runat="server" Text="Add Event" 
            onclientclick="return false;" />
    </div>
    <div class = "panels">
    <asp:Panel ID="pnlAddPlayer" CssClass = "well" runat="server" 
            Height="187px" Width="449px">
        <asp:Label ID="Label1" runat="server" Text="Add Player"></asp:Label>
        <br />
        <asp:Label ID="lblNamePlayer" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="tbPlayerName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Length"></asp:Label>
        <asp:DropDownList ID="ddlLength" CssClass = "dropdown" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Weight"></asp:Label>
        <asp:DropDownList ID="ddlWeight" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label5" runat="server" Text="School/Country"></asp:Label>
        <asp:TextBox ID="tbSchool_Country" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Birthdate"></asp:Label>
        <asp:Label ID="lblDay" runat="server" Text="Day"></asp:Label>
        <asp:DropDownList ID="ddlDay" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" Text="Month"></asp:Label>
        <asp:DropDownList ID="ddlMonth" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label9" runat="server" Text="Year"></asp:Label>
        <asp:DropDownList ID="ddlYear" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Pro-Year"></asp:Label>
        <asp:DropDownList ID="ddlPro_Year" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label11" runat="server" Text="Position"></asp:Label>
        <asp:DropDownList ID="ddlPosition" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label12" runat="server" Text="Team"></asp:Label>
        <asp:DropDownList ID="ddlTeam" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnAddPConfirm" runat="server" onclick="btnAddPConfirm_Click" 
            Text="Add" />
    </asp:Panel>
    <asp:Panel ID="pnlAddTeam" CssClass = "well" runat="server" Width="447px">
    <asp:Label ID="Labelteam" runat="server" Text="Add Team"></asp:Label>
    <br />
        <asp:Label ID="Label13" runat="server" Text="Name team"></asp:Label>
        <asp:TextBox ID="tbTeamName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label14" runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Founded"></asp:Label>
        <asp:TextBox ID="tbFounded" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label16" runat="server" Text="Conference"></asp:Label>
        <asp:DropDownList ID="ddlConference" runat="server" Height="26px" 
            Width="120px">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label17" runat="server" Text="Division"></asp:Label>
        <asp:DropDownList ID="ddlDivision" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label35" runat="server" Text="Stadium"></asp:Label>
        <asp:DropDownList ID="ddlStadium" runat="server" 
            style="margin-bottom: 0px; top: 0px; width: 209px; height: 25px;">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnAddTeamConfirm" runat="server" Text="Add" 
            onclick="btnAddTeamConfirm_Click" />
    </asp:Panel>
        <br />
    <asp:Panel ID="pnlAddMatch" runat="server" CssClass = "well" Width="447px">
    <asp:Label ID="labelMatch" runat="server" Text="Add Match"></asp:Label>
        <br />
        <asp:Label ID="Label19" runat="server" Text="Date and time"></asp:Label>
        <eo:DatePicker ID="dpDateMatch" runat="server" ControlSkinID="None" 
            DayCellHeight="16" DayCellWidth="21" DayHeaderFormat="FirstLetter" 
            DisabledDates="" GridLineColor="207, 217, 227" GridLineFrameVisible="False" 
            GridLineVisible="True" PickerFormat="dd/MM/yyyy HH:mm" SelectedDates="" 
            TitleFormat="MMM yyyy" TitleLeftArrowHtml="&amp;lt;" 
            TitleRightArrowHtml="&amp;gt;" VisibleDate="2014-05-01"><CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea" /><TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;" /><DayHeaderStyle CssText="font-size: 11px; font-family: verdana;height: 17px" /><DayStyle CssText="font-size: 11px; font-family: verdana;border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea" /><DayHoverStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" /><SelectedDayStyle CssText="font-size: 11px; font-family: verdana;border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" /></eo:DatePicker>
        <br />
        <asp:Label ID="Label20" runat="server" Text="Hometeam"></asp:Label>
        <asp:DropDownList ID="ddlHomeTeam" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label21" runat="server" Text="Awayteam"></asp:Label>
        <asp:DropDownList ID="ddlAwayTeam" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label22" runat="server" Text="Stadium"></asp:Label>
        <asp:DropDownList ID="ddlStadiumMatch" runat="server">
        </asp:DropDownList>
        <br />
        <uc2:TicketsAdd ID="ucTicketsAddDetails" runat="server" />
        <asp:Button ID="btnAddMConfirm" runat="server" onclick="btnAddMConfirm_Click" 
            Text="Add" />
            <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlMatchDetails" runat="server" CssClass = "well" Width="447px">
    <asp:Label ID="lblDetails" runat="server" Text="Add Match Details"></asp:Label>
        <br />
        <uc1:MatchesOnDate ID="ucMatchesOnDateDetails" runat="server" />
        <asp:Label ID="Label25" runat="server" Text="Homescore"></asp:Label>
        <asp:TextBox ID="tbHomeScore" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label26" runat="server" Text="Awayscore"></asp:Label>
        <asp:TextBox ID="tbAwayScore" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label27" runat="server" Text="Topscorer"></asp:Label>
        <asp:DropDownList ID="ddlTopscorer" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnAddDetailsConfirm" runat="server" Height="26px" 
            onclick="btnAddDetailsConfirm_Click" Text="Add" Width="50px" />
            
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlAddTeam_Employee" runat="server" CssClass = "well" Width="447px">
        <asp:Label ID="LabelEmp" runat="server" Text="Add Team Employee"></asp:Label>
        <br />
        <asp:Label ID="Label28" runat="server" Text="Name employee"></asp:Label>
        <asp:TextBox ID="tbEmployeeName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label29" runat="server" Text="College"></asp:Label>
        <asp:TextBox ID="tbCollege" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label30" runat="server" Text="Function"></asp:Label>
        <asp:TextBox ID="tbFunction" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label31" runat="server" Text="Assistent"></asp:Label>
        <asp:DropDownList ID="ddlAssistent" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label45" runat="server" Text="Team"></asp:Label>
        <asp:DropDownList ID="ddlEmpTeam" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnAddEConfirm" runat="server" onclick="btnAddEConfirm_Click" 
            Text="Add" />
            <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlAddStadium" runat="server" CssClass = "well" Width="445px">
        <asp:Label ID="LabelStadium" runat="server" Text="Add Stadium"></asp:Label>
        <br />
        <asp:Label ID="Label32" runat="server" Text="Name Stadium"></asp:Label>
        <asp:TextBox ID="tbStadiumName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label33" runat="server" Text="Location"></asp:Label>
        <asp:TextBox ID="tbLocation" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label34" runat="server" Text="Max people"></asp:Label>
        <asp:TextBox ID="tbMaxPeople" runat="server">1000</asp:TextBox>
        <br />
        <asp:Button ID="btnAddSConfirm" runat="server" onclick="btnAddSConfirm_Click" 
            Text="Add" />
            <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlAddTicketConfirm" CssClass = "well" runat="server" Width="445px">
        <asp:Label ID="lblSingle" runat="server" Text="Add single"></asp:Label>
        <uc1:MatchesOnDate ID="ucMatchesOnDateSingle" runat="server" />
        <uc2:TicketsAdd ID="ucTicketsAddSingle" runat="server" />
        <asp:Button ID="btnAddSingle" runat="server"
            Text="Add" onclick="btnAddSingle_Click" />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlAddSeasonTicket" CssClass = "well" runat="server" Width="446px">
        <asp:Label ID="Label40" runat="server" 
    Text="Add Seasonticket"></asp:Label>
        <br />
        <asp:Label ID="Label41" runat="server" Text="Team"></asp:Label>
        <asp:DropDownList ID="ddlSeasonTeam" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label42" runat="server" Text="Begin-date"></asp:Label>
        <eo:DatePicker ID="dpSeasonStart" runat="server" ControlSkinID="None" 
            DayCellHeight="15" DayCellWidth="31" DayHeaderFormat="Short" DisabledDates="" 
            OtherMonthDayVisible="True" PickerFormat="dd/MM/yyyy" SelectedDates="" 
            TitleFormat="MMMM, yyyy" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
            TitleRightArrowImageUrl="DefaultSubMenuIcon" VisibleDate="2014-05-01"><CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" /><TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" /><TitleArrowStyle CssText="cursor: hand" /><MonthStyle CssText="cursor:hand;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;" /><DayHeaderStyle CssText="font-family:Verdana;font-size:8pt;border-bottom: #f5f5f5 1px solid" /><DayStyle CssText="font-family:Verdana;font-size:8pt;" /><DayHoverStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040402');color:#1c7cdc;" /><TodayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040401');color:#1176db;" /><SelectedDayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040403');color:Brown;" /><DisabledDayStyle CssText="font-family:Verdana;font-size:8pt;color: gray" /><FooterTemplate><table border="0" cellPadding="0" cellspacing="5" 
                    style="font-size: 11px; font-family: Verdana"><tr><td width="30"></td><td valign="center"><img src="{img:00040401}"></img></td><td valign="center">Today: {var:today:MM/dd/yyyy}</td></tr></table></FooterTemplate></eo:DatePicker>
        <uc2:TicketsAdd ID="ucAddTicketsSeason" runat="server" />
        <asp:Button ID="btnAddSeasonTConfirm" runat="server" 
            onclick="btnAddSeasonTConfirm_Click" Text="Add" />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlAddEvent" CssClass = "well" runat="server" Width="445px">
    <asp:Label ID="LabelEvent" runat="server" Text="Add Event"></asp:Label>
    <br />
        <asp:Label ID="Label43" runat="server" Text="Name event"></asp:Label>
        <asp:TextBox ID="tbNameEvent" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label44" runat="server" Text="Begin-date"></asp:Label>
        <eo:DatePicker ID="dpBeginDateEvent" runat="server" ControlSkinID="None" 
            DayCellHeight="15" DayCellWidth="31" DayHeaderFormat="Short" DisabledDates="" 
            OtherMonthDayVisible="True" 
            PickerFormat="dd/MM/yyyy" SelectedDates="" TitleFormat="MMMM, yyyy" 
            TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
            TitleRightArrowImageUrl="DefaultSubMenuIcon" VisibleDate="2014-05-01"><CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" /><TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" /><TitleArrowStyle CssText="cursor: hand" /><MonthStyle CssText="cursor:hand;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;" /><DayHeaderStyle CssText="font-family:Verdana;font-size:8pt;border-bottom: #f5f5f5 1px solid" /><DayStyle CssText="font-family:Verdana;font-size:8pt;" /><DayHoverStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040402');color:#1c7cdc;" /><TodayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040401');color:#1176db;" /><SelectedDayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040403');color:Brown;" /><DisabledDayStyle CssText="font-family:Verdana;font-size:8pt;color: gray" /><FooterTemplate><table border="0" cellPadding="0" cellspacing="5" 
                    style="font-size: 11px; font-family: Verdana"><tr><td width="30"></td><td valign="center"><img src="{img:00040401}"></img></td><td valign="center">Today: {var:today:MM/dd/yyyy}</td></tr></table></FooterTemplate></eo:DatePicker>
        <asp:Button ID="btnAddEventConfirm" runat="server" 
            onclick="btnAddEventConfirm_Click" Text="Add" />
    </asp:Panel>
    </div>
             <script type="text/javascript" src = "/script/jquery.js"></script>
             <script type="text/javascript" src = "/script/toggle.js"></script>
    </form>
</body>
</html>
