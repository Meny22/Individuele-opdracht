<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>


<%@ Register src="WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <p id="Logo" style="width: 1101px; top: 0px;">
                <asp:Image ID="Image1" runat="server" Height="81px" ImageUrl="~/Images/NBA-logo.png" 
                    Width="113px" />
                &nbsp;</p>
            <asp:Panel ID="pnlSearch" runat="server">
                &nbsp; Search&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:CheckBox ID="cbPlayer0" runat="server" 
                     Text="Player" />
                &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="Team" />
                <asp:CheckBox ID="CheckBox4" runat="server" Text="Employee" />
                <asp:CheckBox ID="CheckBox5" runat="server" Text="Event" />
                <asp:CheckBox ID="CheckBox6" runat="server" Text="Stadium" />
            </asp:Panel>
        
    </div>
    <div>
        <uc1:WebUserControl1 ID="WebUserControl11" runat="server" />
    </div>
    </form>
</body>
</html>
