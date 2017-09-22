<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MDMarginReport.aspx.vb" Inherits="MDMarginReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Margin Reports including Summary</title>
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
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: cornflowerblue 1px solid; height: 11px;">
            <tr>
                <td style="width: 100px; background-color: aliceblue; text-align: right;">
                    <img src="images/ses_logo.png" /></td>
                <td style="width: 100px; background-color: aliceblue; text-align: center;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="September 2006" Width="130px"></asp:Label></td>
                <td style="width: 100px; background-color: aliceblue; text-align: right;">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="Small" ForeColor="DodgerBlue" RepeatDirection="Horizontal" Width="533px" AutoPostBack="True">
                        <asp:ListItem Value="0" Selected="True">Gross Margin Graph</asp:ListItem>
                        <asp:ListItem Value="1">Gross Sales by Product Group</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px; text-align: right; background-color: aliceblue;">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Text="Main" Width="77px" PostBackUrl="~/MgtReport.aspx" ToolTip="Go Back to Main Screen" /></td>
            </tr>
            <tr>
                <td style="height: 22px; background-color: white; text-align: center;" colspan="4">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="Blue" RepeatDirection="Horizontal" Width="271px" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem Value="1">Year to Date</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
        </table>
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="618px" ProcessingMode="Remote"
                    ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False"
                    ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                    Width="100%" Font-Names="Verdana" Font-Size="8pt">
                    <ServerReport ReportPath="/MIS Reports/Gross Margin Graph Company" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer id="ReportViewer2" runat="server" Height="618px" ProcessingMode="Remote"
                    ShowDocumentMapButton="False" ShowExportControls="False" ShowFindControls="False"
                    ShowPageNavigationControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False"
                    Width="100%" Font-Names="Verdana" Font-Size="8pt">
                    <ServerReport ReportPath="/MIS Reports/Gross Sales by Product Group" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:reportviewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
