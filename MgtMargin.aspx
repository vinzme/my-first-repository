<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtMargin.aspx.vb" Inherits="MgtMargin" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Margin Report</title>
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
                <td style="width: 105px; height: 22px">
                    <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/images/ses_logo.png"
                        Width="100px" /></td>
                <td style="width: 100px; height: 22px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="Gross Margin After Discount by Product Group (SAR k)"
                        Width="396px"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="RoyalBlue" Text="For the Month of September 2006" Width="387px"></asp:Label></td>
                <td style="width: 100px; height: 22px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="Small" ForeColor="DodgerBlue" RepeatDirection="Horizontal" Width="421px" AutoPostBack="True">
                    </asp:RadioButtonList></td>
                <td style="width: 50px; height: 22px">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        Text="Main" PostBackUrl="~/MgtReport.aspx" Width="47px" ToolTip="Click this button to go to Main Screen" /></td>
            </tr>
        </table>
    
    </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:ReportViewer id="ReportViewer1" runat="server" height="622px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Margin By Product" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:ReportViewer ID="ReportViewer2" runat="server" height="622px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Margin By Product" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <rsweb:ReportViewer ID="ReportViewer3" runat="server" height="622px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <rsweb:ReportViewer ID="ReportViewer4" runat="server" height="622px" processingmode="Remote"
            width="988px" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
