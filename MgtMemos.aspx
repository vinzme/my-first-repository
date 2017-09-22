<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtMemos.aspx.vb" Inherits="MgtMemos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>M E M O R A N D U M</title>
<script> 
if(!window.opener){ 
newWin=window.open (this.location,'newwindow','toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,directories=no,status=no') 
newWin.moveTo(0,0); 
newWin.resizeTo(screen.availWidth,screen.availHeight) 
window.opener='a'; 
window.close(); 
} 
</script>        
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table style="width: 951px">
            <tr>
                <td style="width: 105px; height: 22px">
                    <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/images/ses_logo.png"
                        Width="100px" /></td>
                <td style="width: 100px; height: 22px">
                    &nbsp;</td>
                <td style="width: 100px; height: 22px">
                    </td>
                <td style="width: 50px; height: 22px; text-align: right;">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Main" PostBackUrl="~/MgtReport.aspx" Width="83px" ToolTip="Click this button to go to Main Screen" /></td>
            </tr>
        </table>
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Image ID="Image2" runat="server" Height="652px" Width="725px" EnableTheming="True" /></asp:View>
            <asp:View ID="View2" runat="server">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="X-Small" ForeColor="RoyalBlue" RepeatDirection="Horizontal" AutoPostBack="True">
                </asp:RadioButtonList>
                <asp:Image ID="Image3" runat="server" Height="652px"
                    Width="725px" /></asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
