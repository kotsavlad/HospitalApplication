<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultPage2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 114px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" rowspan="2">&nbsp;</td>
                <td>Пацієнти, які відвідували лікарів усіх спеціальностей</td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ResultListBox" runat="server" Width="372px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
