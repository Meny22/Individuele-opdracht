<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyTicket.aspx.cs" Inherits="NBA_Application.BuyTicket" %>

<%@ Register src="MatchesOnDate.ascx" tagname="MatchesOnDate" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buy Tickets</title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="pnlBuyTickets" runat="server">
            <asp:Label ID="lblBuy" runat="server" Text="Buy Ticket"></asp:Label>
            <uc1:MatchesOnDate ID="TicketMatchOnDate" runat="server" />
            <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="tbName" runat="server" class=".form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Banknumber"></asp:Label>
            <asp:TextBox ID="tbBank" runat="server" class=".form-control"></asp:TextBox>
            <asp:Button ID="btnBuy" runat="server" class="btn-info" onclick="btnBuy_Click" 
                Text="Buy" />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
