<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Callback.aspx.cs" Inherits="StepUpSample.authorize.Callback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var array_store;
        window.onload = function () {
            array_store = document.getElementById("array_store");
            document.getElementById("array_disp").innerHTML = array_store.value;
            var str = window.location.hash;
            var res = str.replace("#", "?");
            window.location.href = "https://localhost:44363/Authorized.aspx" + res;
        };
        function UpdateArray() {
            array_store.value = window.location.hash;
        };
    </script>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <span id="array_disp"></span>
        <br />
        <asp:Button ID="Button1" runat="server" OnClientClick="UpdateArray()" Text="Button" OnClick="Button1_Click" />
        <input type="hidden" id="array_store" name="ArrayStore" />
    </form>
</body>
</html>
