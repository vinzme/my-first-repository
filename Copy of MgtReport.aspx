<%@ Page Language="VB" masterpagefile="~/MasterPage4.master" AutoEventWireup="false" CodeFile="Copy of MgtReport.aspx.vb" Inherits="MgtReport" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<atlas:ScriptManager ID="sl" EnablePartialRendering="true" runat="server" />

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td style="width: 115px; height: 46px; vertical-align: bottom; text-align: center; border-right: lightgrey 1px solid; border-top: lightgrey 1px solid; background-color: gainsboro;">
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="True" Font-Names="Lucida Sans Typewriter"
                    Font-Size="Small" ForeColor="MidnightBlue" Width="79px" BackColor="AliceBlue" AutoPostBack="True">
                    <asp:ListItem Selected="True">2006</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 558px; height: 46px; border-bottom: lightgrey 1px solid; border-top: lightgrey 1px solid; border-left-width: 1px; border-left-color: lightgrey; border-right-width: 1px; border-right-color: lightgrey; background-color: #ebebef;">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%; text-align: right;">
                    <tr>
                        <td style="width: 100px; background-color: #ebebef;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ses_logo.png" /></td>
                         <td>
                             <asp:Label ID="Label7" runat="server" Width="52px"></asp:Label>
                         </td>
                        <td style="text-align: right; background-image: url(images/name_spacer.gif);">
                            <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/images/memo.gif" ImageAlign="Right" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
<td style="width: 115px; height: 435px; vertical-align: top; text-align: center; border-right: lightgrey 1px solid; background-color: gainsboro;">
                <atlas:UpdatePanel ID="pl1" runat="server">
                <ContentTemplate>
                <asp:Menu ID="Menu1" runat="server" Height="163px" Width="100px" DynamicEnableDefaultPopOutImage="False" MaximumDynamicDisplayLevels="2" StaticEnableDefaultPopOutImage="False" ForeColor="Black" Font-Names="Lucida Sans Typewriter" Font-Size="Small" Font-Bold="True">
                        <StaticMenuItemStyle CssClass="menuItem" />
                        <StaticSelectedStyle CssClass="menuSelectedItem" />
                    </asp:Menu>
            </ContentTemplate>   
            </atlas:UpdatePanel>                                            

    <asp:Label ID="Label6" runat="server" ForeColor="LightGray" Height="180px" Text="Label"
        Width="92px"></asp:Label>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/notice_img.gif" /></td>
            <td style="width: 558px; height: 435px;">
                <br />
                <table style="width: 263px; height: 428px">
                    <tr>
                        <td style="width: 49px">
                        </td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/income.gif" /></td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/images/content1.gif" /></td>
                    </tr>
                    <tr>
                        <td style="width: 49px">
                            <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Label" Width="46px"></asp:Label></td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/backlog.gif" PostBackUrl="~/MgtBacklogByOrder.aspx" /></td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/images/content5.gif" PostBackUrl="~/MgtBacklogByOrder.aspx" /></td>
                    </tr>
                    <tr>
                        <td style="width: 49px">
                        </td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/cc.gif" /></td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/images/content2.gif" /></td>
                    </tr>
                    <tr>
                        <td style="width: 49px">
                        </td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/margin.gif" /></td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/images/content3.gif" /></td>
                    </tr>
                    <tr>
                        <td style="width: 49px">
                        </td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/labor.gif" /></td>
                        <td style="vertical-align: middle; width: 100px">
                            <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/images/content4.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 22px; color: #ffffff; background-color: cornflowerblue; text-align: right;">
                <asp:Label ID="Label3" runat="server" Text="Copyright © 2006" Width="109px"></asp:Label></td>
            <td style="width: 558px; height: 22px; color: #ffffff; background-color: cornflowerblue; vertical-align: middle; text-align: left;">
                <table style="width: 853px">
                    <tr>
                        <td style="width: 735px; height: 23px;">
                            <asp:Label ID="Label2" runat="server" Text="by SES-IT  All Rights Reserved"
                                Width="194px"></asp:Label>
                            <asp:Label ID="Label1" runat="server" ForeColor="CornflowerBlue" Text="Management "
                                Width="93px"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text="Management Information Report by Finance Department"
                                Width="382px"></asp:Label></td>
                        <td style="width: 21px; height: 23px;">
                            <img src="images/ses_logo.png" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>