<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NBA_Application.Webform1" %>

<%@ Register src="~/MatchNotPlayed.ascx" tagname="MatchNotPlayed" tagprefix="uc3" %>
<%@ Reference Control="MatchNotPlayed.ascx" %>

<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NBA.com</title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" method = "post" runat="server">
    <div>
       
        <input type="hidden" id="_ispostback" value="<%=Page.IsPostBack.ToString()%>" />
        <p id="Logo" style="width: 1101px; top: 0px;">
                <asp:Image ID="Image1" runat="server" Height="81px" ImageUrl="~/Images/NBA-logo.png" 
                    Width="113px" />
                <asp:Label ID="lblName" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <input name = "tbPassword" type = 'password' />
                <asp:Button ID="btnAdmin" class = "btn btn-info" runat="server" Text="Log in" 
                    onclick="btnAdmin_Click" />
        </p>
            <asp:Panel ID="pnlSearch" runat="server" Height="78px">
                &nbsp; Search&nbsp;
                <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" class="btn btn-info" runat="server" Text="Search" 
                     onclick="btnSearch_Click" />
                <br />
                <asp:Panel ID="pnlRadioButtons" runat="server">
                    <asp:RadioButton ID="rbAll" runat="server" 
                         Text="All" GroupName="Search" Checked="True" />
                    <asp:RadioButton ID="rbPlayer" runat="server" 
                         Text="Player" GroupName="Search" />
                    <asp:RadioButton ID="rbTeam" runat="server" 
                         Text="Team" GroupName="Search" />
                    <asp:RadioButton ID="rbStadium" runat="server" 
                         Text="Stadium" GroupName="Search" />
                    <asp:RadioButton ID="rbEmployee" runat="server" 
                         Text="Employee" GroupName="Search" />
                    <asp:RadioButton ID="rbEvent" runat="server" 
                         Text="Event" GroupName="Search" />
                </asp:Panel>
            </asp:Panel>
        
    </div>
    <div>
    <asp:Panel ID="Panel2" runat="server" Height="186px" style="margin-left: 285px" 
        Width="559px">
        <asp:Label ID="lblDate" runat="server"></asp:Label>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:Panel ID="pnlCalander" runat="server">
            <eo:DatePicker ID="dpDateMatches" runat="server" AutoPostbackOnSelect="True" 
                ControlSkinID="None" DayCellHeight="15" DayCellWidth="31" 
                DayHeaderFormat="Short" DisabledDates="" 
                onselectionchanged="dpDateMatches_SelectionChanged" OtherMonthDayVisible="True" 
                PickerFormat="dd/MM/yyyy" SelectedDates="2014-06-03" TitleFormat="MMMM, yyyy" 
                TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
                TitleRightArrowImageUrl="DefaultSubMenuIcon" VisibleDate="2014-06-01"><CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" /><TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" /><TitleArrowStyle CssText="cursor: hand" /><MonthStyle CssText="cursor:hand;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;" /><DayHeaderStyle CssText="font-family:Verdana;font-size:8pt;border-bottom: #f5f5f5 1px solid" /><DayStyle CssText="font-family:Verdana;font-size:8pt;" /><DayHoverStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040402');color:#1c7cdc;" /><TodayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040401');color:#1176db;" /><SelectedDayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040403');color:Brown;" /><DisabledDayStyle CssText="font-family:Verdana;font-size:8pt;color: gray" /><FooterTemplate><table border="0" cellPadding="0" cellspacing="5" 
                        style="font-size: 11px; font-family: Verdana"><tr><td width="30"></td><td valign="center"><img src="{img:00040401}"></img></td><td valign="center">Today: {var:today:MM/dd/yyyy}</td></tr></table></FooterTemplate></eo:DatePicker>
             <asp:Label ID="lblNoMatches" runat="server" Text="No matches on this date" 
                Visible="False" ForeColor="#CC0000"></asp:Label>
             <script type="text/javascript" src = "/script/jquery.js"></script>
             <script type="text/javascript" src = "/script/toggle.js"></script>
        </asp:Panel>
        </asp:Panel>
        &nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
