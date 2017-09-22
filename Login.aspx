<%@ Page Language="VB" masterpagefile="~/MasterPage4.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="body" style="width: 718px">
        <asp:Label ID="Label1" runat="server" Text="Select User :" Width="124px" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label>
    <br />
    
    <asp:DropDownList ID="DropDownList1" runat="server" Width="175px" BackColor="Honeydew" Font-Names="Verdana" Font-Size="Small">
    </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Update" Width="136px" />
        <asp:Button ID="Button2" runat="server" PostBackUrl="~/MgtReport.aspx" Text="Go to Main Page"
            Width="135px" /></div>
</asp:Content>