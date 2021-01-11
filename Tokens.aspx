<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tokens.aspx.cs" Inherits="StepUpSample.Tokens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Id Token"></asp:Label>
        <br />
        <asp:GridView ID="GridViewID" runat="server" CssClass="mGrid" OnRowDataBound="GridViewID_OnRowDataBound">
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Access Token"></asp:Label>
        <br />
        <asp:GridView ID="GridViewAccess" runat="server" CssClass="mGrid" OnRowDataBound="GridViewAccess_RowDataBound">
        </asp:GridView>
        <div>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Step Up</asp:LinkButton>
        </div>
    </form>
</body>
</html>
