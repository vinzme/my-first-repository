<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MgtLabVar.aspx.vb" Inherits="MgtLabVar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Absorbed Burden Variance Analysis</title>
    <script type ="text/javascript" > 
if(!window.opener){ 
newWin=window.open (this.location,'newwindow','toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,directories=no,status=no') 
newWin.moveTo(0,0); 
newWin.resizeTo(screen.availWidth,screen.availHeight) 
window.opener='a'; 
window.close(); 
} 
</script> 

    <link href="" rel="stylesheet" type="text/css" />
</head>
<body  >
    <form id="form1" runat="server" >
    <div >
    <table style="width: 951px">
            <tr>
                <td style="width: 105px; height: 22px">
                    <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/images/ses_logo.png"
                        Width="100px" /></td>
                <td style="width: 100px; height: 22px">
                    &nbsp;</td>
                <td style="width: 100px; height: 22px">
                    </td>
                 <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Labour Efficiency"
                        Width="157px" ToolTip="Click to go back to Labour Efficiency Report" /></td>
            </tr>
        </table>
    </div>
    <div  style="height:auto">
        <asp:Literal ID="Literal1" runat="server"  ></asp:Literal>
      
     </div>  
    </form>
</body>
</html>
