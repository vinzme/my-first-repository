<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtFieldSupport.aspx.vb" Inherits="MgtFieldSupport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Labour Efficiency</title>
    <script> 
if(!window.opener){ 
newWin=window.open (this.location,'newwindow','toolbar=no,menubar=no,scrollbars=no,resizable=yes,location=no,directories=no,status=no') 
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
        <table>
            <tr>
                <td style="width: 106px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" /></td>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="Field Support Labour Efficiency for the Month of September 2006"
                        Width="484px"></asp:Label></td>
                <td style="width: 108px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="Small" ForeColor="DodgerBlue" RepeatDirection="Horizontal" Width="194px" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem Value="1">Year to Date</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="Small" PostBackUrl="~/MgtLabour713.aspx"
                        Text="Labour Efficiency" ToolTip="Click to go back to Labour Efficiency Report"
                        Width="143px" /></td>
            </tr>
        </table>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer id="ReportViewer1" runat="server" height="618px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Field Support Labour Efficiency Report" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" /></rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer id="ReportViewer2" runat="server" height="618px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Field Support Labour Efficiency Report" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" /></rsweb:reportviewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
