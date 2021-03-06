<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtMaginGD.aspx.vb" Inherits="MgtMaginGD" %>

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
        <table>
            <tr>
                <td style="width: 120px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" /></td>
                <td style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="X-Small" ForeColor="MediumBlue"
                        Text="Gross Margin After Discount by Product Group (SAR k)" Width="320px"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="X-Small" ForeColor="MediumBlue"
                        Text="For the Month of September 2006" Width="318px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                        ForeColor="DodgerBlue" RepeatDirection="Horizontal" Width="481px" AutoPostBack="True" Font-Bold="True">
                        <asp:ListItem Value="0" Selected="True">Division</asp:ListItem>
                        <asp:ListItem Value="1">Cost Centre</asp:ListItem>
                        <asp:ListItem Value="2">Total Company</asp:ListItem>
                        <asp:ListItem Value="3">Marketing</asp:ListItem>
                        <asp:ListItem Value="4">Graph</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 50px">
                    <asp:Button ID="Button1" runat="server" Font-Size="X-Small" Text="Main" PostBackUrl="~/MgtReport.aspx" ToolTip="Click this button to go to Main Screen" /></td>
            </tr>
        </table>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer id="ReportViewer1" runat="server" height="624px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Margin By Product" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
            </rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <rsweb:reportviewer ID="ReportViewer2" runat="server" height="624px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Margin By Product" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
            </rsweb:reportviewer>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <rsweb:ReportViewer ID="ReportViewer3" runat="server" height="624px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Margin By Product" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <rsweb:ReportViewer ID="ReportViewer4" runat="server" height="624px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowZoomControl="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Margin By Product" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <rsweb:ReportViewer ID="ReportViewer5" runat="server" height="596px" processingmode="Remote"
            width="100%" ShowDocumentMapButton="False" ShowFindControls="False" ShowPromptAreaButton="False" ShowRefreshButton="False" ShowExportControls="False">
            <ServerReport ReportPath="/MIS Reports/Gross Margin Graph" ReportServerUrl="http://inside.saudi-ericsson.com/reportserver" />
                </rsweb:ReportViewer>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
