<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtBacklogByOrder.aspx.vb" Inherits="MgtBacklogByOrder" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Backlog Report by Order</title>
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
        <table style="width: 859px">
            <tr>
                <td style="width: 114px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" /></td>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="Backlog Report by Order No. for the Month of September 2006"
                        Width="517px"></asp:Label></td>
                <td style="width: 100px; text-align: right">
                    <asp:Button ID="Button1" runat="server" Text="Main" ToolTip="Go Back to Main Screen"
                        Width="69px" PostBackUrl="~/MgtReport.aspx" /></td>
            </tr>
        </table>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" height="630px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Backlog by Project" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
        </asp:MultiView>&nbsp;
        <br />
        <br />
        
    </form>
</body>
</html>
