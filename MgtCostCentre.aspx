<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtCostCentre.aspx.vb" Inherits="MgtCostCentre" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Cost Centre</title>
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
        <table style="width: 447px">
            <tr>
                <td style="width: 93px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" Height="20px" Width="100px" /></td>
                <td style="width: 105px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="Cost Centre Expenses for the Month of September 2006" Width="450px"></asp:Label></td>
                <td style="width: 3570px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="DodgerBlue" RepeatDirection="Horizontal" Width="205px" AutoPostBack="True">
                        <asp:ListItem Value="0" Selected="True">Summary</asp:ListItem>
                        <asp:ListItem Value="1">Detailed</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                 <td style="width: 3355px">
                     <asp:Button ID="Button1" runat="server" Text="Main" Font-Names="Verdana" Font-Size="X-Small" PostBackUrl="~/MgtReport.aspx" ToolTip="Click this button to go to Main Screen" />
                </td>
            </tr>
        </table>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer id="ReportViewer1" runat="server" height="630px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Cost Centre Report" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
            </rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer id="ReportViewer2" runat="server" height="630px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Detailed Cost Centre Report" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" /></rsweb:reportviewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
