<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtIncomeJeddah.aspx.vb" Inherits="MgtIncomeJeddah" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Income Statement</title>
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
                <td style="width: 100px; height: 20px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" /></td>
                <td style="width: 100px; height: 20px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="Income Statement for the Month of September 2006"
                        Width="429px"></asp:Label></td>
                <td style="width: 118px; height: 20px;">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="Small" ForeColor="RoyalBlue" RepeatDirection="Horizontal" Width="308px" AutoPostBack="True">
                        <asp:ListItem Value="0" Selected="True">Jeddah Branch</asp:ListItem>
                        <asp:ListItem Value="1">Jeddah Region</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px; height: 20px;">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Main" PostBackUrl="~/MgtReport.aspx" ToolTip="Click this button to go to Main Screen" /></td>
            </tr>
        </table>
    
    </div>
        <table style="width: 955px">
            <tr>
                <td style="width: 100px; height: 20px; text-align: center;">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="Small" ForeColor="DodgerBlue" RepeatDirection="Horizontal" Width="952px" AutoPostBack="True">
                        <asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
                        <asp:ListItem Value="1">Year to Date</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer id="ReportViewer1" runat="server" height="580px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowExportControls="False" ShowRefreshButton="False">
            <ServerReport ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" ReportPath="/MIS Reports/Income Statement by Division" /></rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer id="ReportViewer2" runat="server" height="580px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowExportControls="False" ShowRefreshButton="False">
            <ServerReport ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" ReportPath="/MIS Reports/Income Statement by Division" /></rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <rsweb:reportviewer id="ReportViewer3" runat="server" height="580px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowExportControls="False" ShowRefreshButton="False">
            <ServerReport ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" ReportPath="/MIS Reports/Income Statement by Division" /></rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <rsweb:reportviewer id="ReportViewer4" runat="server" height="580px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowExportControls="False" ShowRefreshButton="False">
            <ServerReport ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" ReportPath="/MIS Reports/Income Statement by Division" /></rsweb:reportviewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
