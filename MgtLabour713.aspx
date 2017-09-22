<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtLabour713.aspx.vb" Inherits="MgtSalam" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Labour Efficiency</title>
<script type = "text/javascript" > 
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
                <td style="width: 105px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" /></td>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="MidnightBlue"
                        Text="Labour Efficiency Report (by hours)" Width="267px"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="MidnightBlue"
                        Text="For the Month of Sepbtember 2006" Width="259px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="X-Small" ForeColor="DodgerBlue" Width="104px" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem Value="1">Year to Date</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Text="Over/Under Absorbed"
                        ToolTip="Click to go to Over/Under Absorbed Report" Width="166px" PostBackUrl="~/MgtOverUnder.aspx" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button2" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Field Support"
                        ToolTip="Click to go to Field Support Report" PostBackUrl="~/MgtFieldSupport.aspx" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button4" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Variance Report"
                        Width="120px" ToolTip="Click to go to Variance Report" PostBackUrl="~/Mgtlabvar.aspx" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button5" runat="server" Font-Size="X-Small" PostBackUrl="~/MgtTSummary.aspx"
                        Text="Timesheet Summary" ToolTip="Click to go to Timesheet Summary" Width="104px" /></td>
                <td style="width: 100px">
                    <asp:Button ID="Button3" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Main" PostBackUrl="~/MgtReport.aspx" ToolTip="Click this button to go to Main Screen" /></td>
            </tr>
        </table>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer id="ReportViewer1" runat="server" height="630px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Labour Efficiency Report" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" /></rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer id="ReportViewer2" runat="server" height="630px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Labour Efficiency Report" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" /></rsweb:reportviewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
