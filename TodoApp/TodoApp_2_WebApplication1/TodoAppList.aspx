<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodoAppList.aspx.cs" Inherits="TodoApp_2_WebApplication1.TodoAppList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>할일목록</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>할일많다</h1>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
