<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="NBA_Application.SearchResults" %>
<%@ PreviousPageType VirtualPath = "/Home.aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Searchresults</title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class = "label label-info"><asp:Label ID="lblSearchResult" runat="server" Text="Search Results"></asp:Label></span>
    
    </div>
    <div id = "SearchResults" class = "well">
    <asp:ListBox ID="lbResults" runat="server" Height="183px" Width="247px">
    </asp:ListBox>
    <asp:Button ID="btnInfo" runat="server" onclick="btnInfo_Click" 
        Text="More Info" />
    <asp:TextBox ID="tbMoreInfo" runat="server" Height="172px" Width="219px" 
        TextMode="MultiLine" style="margin-top: 0px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
