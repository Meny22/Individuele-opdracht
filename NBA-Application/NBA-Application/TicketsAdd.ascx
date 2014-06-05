<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TicketsAdd.ascx.cs" Inherits="NBA_Application.TicketsAdd" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

<asp:Label ID="Label23" runat="server" Text="Amount of tickets(max 10)"></asp:Label>
        <asp:TextBox ID="tbTickets" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label38" runat="server" Text="Price of ticket"></asp:Label>
        <asp:TextBox ID="tbPriceTicket" runat="server"></asp:TextBox>
