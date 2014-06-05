<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchesOnDate.ascx.cs" Inherits="NBA_Application.MatchesOnDate" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<div style="width: 206px">
<asp:Label ID="Label24" runat="server" Text="Match date"></asp:Label>
        <eo:DatePicker ID="dpMatchPick" runat="server" ControlSkinID="None" 
            DayCellHeight="15" DayCellWidth="31" DayHeaderFormat="Short" DisabledDates="" 
            onselectionchanged="dpMatchPick_SelectionChanged" OtherMonthDayVisible="True" 
            PickerFormat="dd/MM/yyyy" SelectedDates="" TitleFormat="MMMM, yyyy" 
            TitleLeftArrowImageUrl="DefaultSubMenuIconRTL" 
            TitleRightArrowImageUrl="DefaultSubMenuIcon" VisibleDate="2014-05-01" 
        AutoPostbackOnSelect="True">
            <CalendarStyle CssText="background-color:white;border-bottom-color:Silver;border-bottom-style:solid;border-bottom-width:1px;border-left-color:Silver;border-left-style:solid;border-left-width:1px;border-right-color:Silver;border-right-style:solid;border-right-width:1px;border-top-color:Silver;border-top-style:solid;border-top-width:1px;color:#2C0B1E;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" />
            <TitleStyle CssText="font-family:Verdana;font-size:8.75pt;padding-bottom:5px;padding-left:5px;padding-right:5px;padding-top:5px;" />
            <TitleArrowStyle CssText="cursor: hand" />
            <MonthStyle CssText="cursor:hand;margin-bottom:0px;margin-left:4px;margin-right:4px;margin-top:0px;" />
            <DayHeaderStyle CssText="font-family:Verdana;font-size:8pt;border-bottom: #f5f5f5 1px solid" />
            <DayStyle CssText="font-family:Verdana;font-size:8pt;" />
            <DayHoverStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040402');color:#1c7cdc;" />
            <TodayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040401');color:#1176db;" />
            <SelectedDayStyle CssText="font-family:Verdana;font-size:8pt;background-image:url('00040403');color:Brown;" />
            <DisabledDayStyle CssText="font-family:Verdana;font-size:8pt;color: gray" />
            <FooterTemplate>
                <table border="0" cellPadding="0" cellspacing="5" 
                    style="font-size: 11px; font-family: Verdana">
                    <tr>
                        <td width="30">
                        </td>
                        <td valign="center">
                            <img src="{img:00040401}"></img></td>
                        <td valign="center">
                            Today: {var:today:MM/dd/yyyy}</td>
                    </tr>
                </table>
            </FooterTemplate>
        </eo:DatePicker>
        <asp:ListBox ID="lbMatches" runat="server" Height="142px" Width="411px">
        </asp:ListBox>
        <script type="text/javascript" src = "/script/jquery.js"></script>
        <script type="text/javascript" src = "/script/toggle.js"></script>
        </div>