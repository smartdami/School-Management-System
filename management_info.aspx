<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="management_info.aspx.cs" Inherits="School_Management_System.management_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 768px; background-color: #FFFF66;">
            <div style="font-size: x-large; background-color: #000066; color: #FFFFFF; font-weight: bold; height: 90px;">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LOYOLA PRIMARY SCHOOL</div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="reg_btn" runat="server" CssClass="auto-style1" Height="70px" OnClick="reg_btn_Click" Text="Registered Students Selection" Width="300px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="con_btn" runat="server" CssClass="auto-style1" Height="70px" Text="School Fee Concession Selection" Width="300px" OnClick="con_btn_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="lib_btn" runat="server" CssClass="auto-style1" Height="70px" Text="Add Library Books" Width="300px" OnClick="lib_btn_Click" />
&nbsp;
            <br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="r_btn" runat="server" CssClass="auto-style1" Height="70px" OnClick="r_btn_Click" Text="Add New Room" Width="300px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="room_btn" runat="server" CssClass="auto-style1" Height="70px" Text="Room Details" Width="300px" OnClick="room_btn_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="log_btn" runat="server" CssClass="auto-style1" Height="70px" Text="Log-Out" Width="300px" OnClick="log_btn_Click" />
&nbsp;<br />
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
