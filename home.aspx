<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="School_Management_System.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 640px, width:1366px">
    <form id="form1" runat="server">
        <div style="width: 1368px; height: 610px; margin-right: 0px;">
            <asp:Panel ID="Panel1" runat="server" BackColor="#000066" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Height="90px" Width="1366px">
                &nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; LOYOLA PRIMARY SCHOOL<asp:Panel ID="Panel2" runat="server" BackColor="White" Height="520px" style="margin-left: 0px; margin-right: 0px; margin-top: 12px">
                    &nbsp;
                    <asp:Menu ID="menu_strip" runat="server" BackColor="White" CssClass="static" Orientation="Horizontal">
                        <DynamicHoverStyle BackColor="Red" />
                        <DynamicMenuItemStyle BackColor="#000066" ForeColor="White" VerticalPadding="20px" />
                        <DynamicMenuStyle HorizontalPadding="200px" />
                        <Items>
                            <asp:MenuItem Text="Registration" Value="Registration">
                                <asp:MenuItem NavigateUrl="~/School_Admission_Form.aspx" Text="School Admission" Value="School Admission"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/HostelAdmisiion.aspx" Text="Hostel Registration" Value="Hostel Registration"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/BusRegistration.aspx" Text="Bus Registration" Value="Bus Registration"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/FeeConcessionregistration.aspx" Text="Fee Concession Registration" Value="Fee Concession Registration"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Fee Payment" Value="Fee Payment">
                                <asp:MenuItem NavigateUrl="~/schoolfee.aspx" Text="School Fee Payment" Value="School Fee Payment"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/LibraryFee.aspx" Text="Library Fee Payment" Value="Library Fee Payment"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/hostelfee.aspx" Text="Hostel Fee Payment" Value="Hostel Fee Payment"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Examfee.aspx" Text="Exam Fee Payment" Value="Exam Fee Payment"></asp:MenuItem>
                                <asp:MenuItem Text="Bus Fee payment" Value="Bus Fee payment" NavigateUrl="~/busfee.aspx"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Login" Value="Login">
                                <asp:MenuItem NavigateUrl="~/Student_login.aspx" Text="Student Login" Value="Student Login"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/stafflogin.aspx" Text="Staff Login" Value="Staff Login"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/admin_login.aspx" Text="Admin Login" Value="Admin Login"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Management_login.aspx" Text="Management Login" Value="Management Login"></asp:MenuItem>
                            </asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="White" />
                        <StaticMenuItemStyle BackColor="White" ForeColor="#000066" HorizontalPadding="250px" />
                        <StaticMenuStyle Width="1366px" />
                    </asp:Menu>
                    <br />
                    <asp:Panel ID="Panel3" runat="server" BackColor="#FFFF66" Font-Size="XX-Large" ForeColor="Black" Height="468px" Width="1366px">
                        &nbsp;&nbsp;
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WELCOME TO LOYOLA PRIMARY SCHOOL,CHENNAI.<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
