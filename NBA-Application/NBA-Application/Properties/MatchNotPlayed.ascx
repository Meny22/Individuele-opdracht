<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MatchNotPlayed.ascx.cs" Inherits="MatchNotPlayed" %>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<div class="Match_not_played">
    <asp:Button ID="btBuy" runat="server" Height="23px" Text="Buy Tickets" 
        Width="89px" />
    <asp:Label ID="lblTime" runat="server" Text="Label">9:00 PM</asp:Label>
        <asp:Image ID="imgTv" runat="server" Height="24px" 
            ImageUrl="~/Images/NBA-on-TNT.png" Width="52px" />
        <asp:Label ID="lblTeam1" runat="server" Text="Heat"></asp:Label>
        <asp:Label ID="lblTeam2" runat="server" Text="Spurs"></asp:Label>
        <asp:Label ID="lblStadium" runat="server" Text="Madison Square Garden"></asp:Label>
    <asp:Image ID="imgBorder" runat="server" Height="146px" 
        ImageUrl="~/Images/border.png" Width="494px" />
        <asp:Image ID="imgHome" runat="server" Height="22px" 
            ImageUrl="~/Images/home-icon-614x460.png" Width="26px" />
</div>
