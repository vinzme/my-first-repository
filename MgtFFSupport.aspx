<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtFFSupport.aspx.vb" Inherits="MgtFFSupport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Supporting Schedule</title>
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
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: cornflowerblue 1px solid; height: 11px; background-color: honeydew;">
            <tr>
                <td style="width: 68px" rowspan="2">
                    <img src="images/ses_logo.png" /></td>
                <td style="width: 100px; text-align: right;" rowspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="September 2006" Width="134px"></asp:Label></td>
                <td style="width: 100px; background-color: honeydew;" colspan="3">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Bold="True"
                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="DodgerBlue" RepeatDirection="Horizontal"
                        Width="693px">
                        <asp:ListItem Value="0" Selected="True">Cost of Sales-Div</asp:ListItem>
                        <asp:ListItem Value="1">Cost of Sales-Cc</asp:ListItem>
                        <asp:ListItem Value="2">Cos Adjustment Details</asp:ListItem>
                        <asp:ListItem Value="3">Financial Charges</asp:ListItem>
                        <asp:ListItem Value="4">Juffalli Report Ratios</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px; background-color: honeydew;" rowspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Main" Width="71px" PostBackUrl="~/MgtReportFF.aspx" /></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center; background-color: honeydew;">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" Font-Bold="True"
                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="HotPink" RepeatDirection="Horizontal"
                        Width="297px">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem Value="1">Year to Date</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
        </table>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer ID="ReportViewer1" runat="server" Height="618px" ProcessingMode="Remote"
                    ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False"
                    ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                    Width="100%" Font-Names="Verdana" Font-Size="8pt">
                    <ServerReport ReportPath="/MIS Reports/Cost of Sales" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer id="ReportViewer2" runat="server" Height="618px" ProcessingMode="Remote"
                    ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False"
                    ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                    Width="100%" Font-Names="Verdana" Font-Size="8pt">
                    <ServerReport ReportPath="/MIS Reports/Cost of Sales Adjustment Details" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                 </rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <rsweb:reportviewer id="ReportViewer3" runat="server" Height="618px" ProcessingMode="Remote"
                    ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False"
                    ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                    Width="100%" Font-Names="Verdana" Font-Size="8pt">
                    <ServerReport ReportPath="/MIS Reports/Financial Charges" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <rsweb:reportviewer id="ReportViewer4" runat="server" Height="618px" ProcessingMode="Remote"
                    ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False"
                    ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                    Width="100%" Font-Names="Verdana" Font-Size="8pt">
                    <ServerReport ReportPath="/MIS Reports/Juffali Report Ratios" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:reportviewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
