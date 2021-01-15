<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authorized.aspx.cs" Inherits="StepUpSample.Authorzied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Label2" runat="server" Text="Access Token"></asp:Label>
        <br />
        <asp:GridView ID="GridViewAccess" runat="server" CssClass="mGrid" OnRowDataBound="GridViewAccess_RowDataBound">
        </asp:GridView>
        <div>
        </div>
        </div>
    </form>
</body>
</html>
