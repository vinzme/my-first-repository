#Region "Imports"

Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web.UI.Page
Imports System.IO

#End Region

Public Class MgtReport
    Inherits System.Web.UI.Page
    Dim pubCheckMonth As Integer
    Dim pubUser As String
    Dim pubUserPosition As String
    Dim pubSelectedYear As String
    Dim pubUserManager As String
    Dim pubUserDesignation As String
    Dim pubSelectedMonth As String
    Dim pubStrMonth As String
    Dim pubServerDate As String
    Dim pubSelectedDate As String
    Dim pubMaxMonth As String
    Dim pubDomain As String

#Region "Events"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ImageButton1.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton2.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton3.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton4.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton5.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton6.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton7.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton8.Attributes.Add("onclick", "document.body.style.cursor='wait';")

        ImageButton9.Attributes.Add("onmouseover", "this.src='images/memo_on.gif'")
        ImageButton9.Attributes.Add("onmouseout", "this.src='images/memo.gif'")

        ImageButton10.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton11.Attributes.Add("onclick", "document.body.style.cursor='wait';")

        Dim sUser() As String = Split(User.Identity.Name, "\")
        Dim sDomain As String = sUser(0)
        Dim sUserId As String = sUser(1)

        pubUser = UCase(sUserId)

        pubDomain = UCase(sDomain)

        pubUserPosition = "User"

        CheckPubUser()

        CheckUserAuthority()

        'CheckUserDesignation()

        'GetMgtModules()
        GetServerDateTime()

        If Page.IsPostBack = False Then

            GetMenuMonths()
            GetSelectedMonth()
            GetCheckMonth()

        End If

    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick

        Dim i As Integer
        Dim y As Integer
        For i = 0 To Menu1.Items.Count - 1
            If i = e.Item.Value Then

                For y = 1 To Menu1.Items.Count
                    If Trim(Menu1.Items(i).Text) = Format(CDate(Trim(Str(y)) & "/25/2006"), "MMMM") Then
                        pubSelectedMonth = Trim(Str(y))
                        pubStrMonth = Format(CDate(Trim(Str(y)) & "/25/2006"), "MMMM")
                        Menu1.Items(i).Selected = True
                        UpdateUserParameter()
                    End If
                Next

                Exit For

            End If
        Next

        UpdateSelectedMonth()

    End Sub

#End Region

#Region "Procedures and Functions"

    Private Sub GetMgtModules()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String

        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "Select report_module, category, username from and_user_table where userid = '" & _
                    pubUser.Trim & "' group by report_module, category, username"

            'hide image buttons
            ImageButton1.Visible = False
            ImageButton2.Visible = False
            ImageButton3.Visible = False
            ImageButton4.Visible = False
            ImageButton5.Visible = False
            ImageButton6.Visible = False
            ImageButton7.Visible = False
            ImageButton8.Visible = False

            ImageButton10.Visible = False
            ImageButton11.Visible = False


            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    Select Case Trim(mReader("report_module").ToString)
                        Case "1"
                            ImageButton1.Visible = True
                            ImageButton6.Visible = True

                            ImageButton1.ImageUrl = "~/images/income.gif"
                            ImageButton6.ImageUrl = "~/images/content1.gif"

                            If Trim(mReader("category").ToString) = "jed" Then
                                ImageButton1.PostBackUrl = "~/MgtIncomeJeddah.aspx"
                                ImageButton6.PostBackUrl = "~/MgtIncomeJeddah.aspx"
                            Else
                                ImageButton1.PostBackUrl = "~/MgtIncome.aspx"
                                ImageButton6.PostBackUrl = "~/MgtIncome.aspx"
                            End If

                            ImageButton1.Attributes.Add("onmouseover", "this.src='images/income_on.gif'")
                            ImageButton1.Attributes.Add("onmouseout", "this.src='images/income.gif'")

                            ImageButton6.Attributes.Add("onmouseover", "this.src='images/content1_on.gif'")
                            ImageButton6.Attributes.Add("onmouseout", "this.src='images/content1.gif'")

                        Case "2"
                            ImageButton2.Visible = True
                            ImageButton7.Visible = True
                            ImageButton2.ImageUrl = "~/images/backlog.gif"
                            ImageButton7.ImageUrl = "~/images/content5.gif"

                            If Trim(mReader("category").ToString) = "GD" Then
                                ImageButton2.PostBackUrl = "~/MgtBacklog.aspx"
                                ImageButton7.PostBackUrl = "~/MgtBacklog.aspx"
                            Else
                                ImageButton2.PostBackUrl = "~/MgtBacklogByOrder.aspx"
                                ImageButton7.PostBackUrl = "~/MgtBacklogByOrder.aspx"
                            End If

                            ImageButton2.Attributes.Add("onmouseover", "this.src='images/backlog_on.gif'")
                            ImageButton2.Attributes.Add("onmouseout", "this.src='images/backlog.gif'")

                            ImageButton7.Attributes.Add("onmouseover", "this.src='images/content5_on.gif'")
                            ImageButton7.Attributes.Add("onmouseout", "this.src='images/content5.gif'")

                        Case "3"
                            ImageButton3.Visible = True
                            ImageButton8.Visible = True
                            ImageButton3.ImageUrl = "~/images/cc.gif"
                            ImageButton8.ImageUrl = "~/images/content2.gif"

                            ImageButton3.PostBackUrl = "~/MgtCostCentre.aspx"
                            ImageButton8.PostBackUrl = "~/MgtCostCentre.aspx"

                            ImageButton3.Attributes.Add("onmouseover", "this.src='images/cc_on.gif'")
                            ImageButton3.Attributes.Add("onmouseout", "this.src='images/cc.gif'")

                            ImageButton8.Attributes.Add("onmouseover", "this.src='images/content2_on.gif'")
                            ImageButton8.Attributes.Add("onmouseout", "this.src='images/content2.gif'")

                        Case "4"
                            ImageButton4.Visible = True
                            ImageButton10.Visible = True
                            ImageButton4.ImageUrl = "~/images/margin.gif"
                            ImageButton10.ImageUrl = "~/images/content3.gif"

                            If Trim(mReader("category").ToString) = "GD" Then
                                ImageButton4.PostBackUrl = "~/MgtMaginGD.aspx"
                                ImageButton10.PostBackUrl = "~/MgtMaginGD.aspx"
                            Else
                                ImageButton4.PostBackUrl = "~/MgtMargin.aspx"
                                ImageButton10.PostBackUrl = "~/MgtMargin.aspx"
                            End If


                            ImageButton4.Attributes.Add("onmouseover", "this.src='images/margin_on.gif'")
                            ImageButton4.Attributes.Add("onmouseout", "this.src='images/margin.gif'")

                            ImageButton8.Attributes.Add("onmouseover", "this.src='images/content3_on.gif'")
                            ImageButton8.Attributes.Add("onmouseout", "this.src='images/content3.gif'")

                        Case "5"

                            ImageButton5.Visible = True
                            ImageButton11.Visible = True
                            ImageButton5.ImageUrl = "~/images/labor.gif"
                            ImageButton11.ImageUrl = "~/images/content4.gif"

                            If Trim(mReader("category").ToString) = "713" Then
                                ImageButton5.PostBackUrl = "~/MgtLabour713.aspx"
                                ImageButton11.PostBackUrl = "~/MgtLabour713.aspx"
                            Else
                                ImageButton5.PostBackUrl = "~/MgtLabour.aspx"
                                ImageButton11.PostBackUrl = "~/MgtLabour.aspx"
                            End If

                            ImageButton5.Attributes.Add("onmouseover", "this.src='images/labor_on.gif'")
                            ImageButton5.Attributes.Add("onmouseout", "this.src='images/labor.gif'")

                            ImageButton11.Attributes.Add("onmouseover", "this.src='images/content4_on.gif'")
                            ImageButton11.Attributes.Add("onmouseout", "this.src='images/content4.gif'")

                    End Select

                End While
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetCheckMonth()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        Dim i As Integer
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        'ConnStr = "packet size=4096;user id=scheme;password=password;data source=SESH9SVR;persist security info=False;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try
            i = 0
            sSql = "Select max(mgt_month) as maxmonths from and_user_month where mgt_year = '" & _
                    DropDownList1.Text.Trim & "'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()

                    pubSelectedDate = Trim(mReader("maxmonths".ToString))
                    Select Case mReader("maxmonths")
                        Case 1
                            Menu1.Style.Add("Height", "31px")
                            Label6.Style.Add("Height", "340px")
                        Case 2
                            Menu1.Style.Add("Height", "62px")
                            Label6.Style.Add("Height", "309px")
                        Case "3"
                            Menu1.Style.Add("Height", "93px")
                            Label6.Style.Add("Height", "278px")
                        Case 4
                            Menu1.Style.Add("Height", "124px")
                            Label6.Style.Add("Height", "247px")
                        Case 5
                            Menu1.Style.Add("Height", "155px")
                            Label6.Style.Add("Height", "216px")
                        Case 6
                            Menu1.Style.Add("Height", "186px")
                            Label6.Style.Add("Height", "185px")
                        Case 7
                            Menu1.Style.Add("Height", "217px")
                            Label6.Style.Add("Height", "154px")
                        Case 8
                            Menu1.Style.Add("Height", "248px")
                            Label6.Style.Add("Height", "123px")
                        Case 9
                            Menu1.Style.Add("Height", "279px")
                            Label6.Style.Add("Height", "92px")
                        Case 10
                            Menu1.Style.Add("Height", "310px")
                            Label6.Style.Add("Height", "61px")
                        Case 11
                            Menu1.Style.Add("Height", "341px")
                            Label6.Style.Add("Height", "30px")
                        Case 12
                            Menu1.Style.Add("Height", "365px")
                            Label6.Style.Add("Height", "2px")
                    End Select

                End While
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetMenuMonths()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        Dim i As Integer
        Dim y As Integer
        Dim msel As Integer
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        'ConnStr = "packet size=4096;user id=scheme;password=password;data source=SESH9SVR;persist security info=False;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try
            i = 0
            y = 0
            If pubUserPosition = "Manager" Then
                sSql = "Select max(mgt_month) as maxmonths from and_user_month where mgt_year = '" & _
                        DropDownList1.Text.Trim & "'"
            Else
                sSql = "Select max(mgt_month) as maxmonths from and_user_month where mgt_year = '" & _
                        DropDownList1.Text.Trim & "' and mgt_status = '1'"
            End If

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()

                    msel = mReader("maxmonths")

                    For i = mReader("maxmonths") To 1 Step -1

                        ' Create the menu item for Year.
                        Dim newMenuItem = New MenuItem()

                        ' Add the menu item
                        Menu1.Items.Add(newMenuItem)

                        Menu1.Items(y).Text = Format(CDate(Trim(Str(i)) & "/25/2006"), "MMMM")
                        Menu1.Items(y).Value = Trim(Str(y))

                        y = y + 1

                    Next

                End While

                pubMaxMonth = Trim(Str(msel))
                pubSelectedMonth = Trim(Str(msel))
                pubStrMonth = Format(CDate(Trim(Str(msel)) & "/25/2006"), "MMMM")
                UpdateUserParameter()

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetSelectedMonth()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        Dim i As Integer
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        'ConnStr = "packet size=4096;user id=scheme;password=password;data source=SESH9SVR;persist security info=False;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            If pubUserPosition = "Manager" Then
                sSql = "Select selected_month, selected_date from and_user_selected_month where userid = '" & _
                        pubUserManager.Trim & "'"
            Else
                sSql = "Select selected_month, selected_date from and_user_selected_month where userid = '" & _
                        pubUser.Trim & "'"
            End If

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()

                    If Trim(mReader("selected_date".ToString)) = pubServerDate.Trim Then
                        pubSelectedDate = Trim(mReader("selected_month".ToString))

                        Select Case pubSelectedDate
                            Case "1"
                                pubSelectedMonth = "1"
                                pubStrMonth = "January"
                            Case "2"
                                pubSelectedMonth = "2"
                                pubStrMonth = "February"
                            Case "3"
                                pubSelectedMonth = "3"
                                pubStrMonth = "March"
                            Case "4"
                                pubSelectedMonth = "4"
                                pubStrMonth = "April"
                            Case "5"
                                pubSelectedMonth = "5"
                                pubStrMonth = "May"
                            Case "6"
                                pubSelectedMonth = "6"
                                pubStrMonth = "June"
                            Case "7"
                                pubSelectedMonth = "7"
                                pubStrMonth = "July"
                            Case "8"
                                pubSelectedMonth = "8"
                                pubStrMonth = "August"
                            Case "9"
                                pubSelectedMonth = "9"
                                pubStrMonth = "September"
                            Case "10"
                                pubSelectedMonth = "10"
                                pubStrMonth = "October"
                            Case "11"
                                pubSelectedMonth = "11"
                                pubStrMonth = "November"
                            Case "12"
                                pubSelectedMonth = "12"
                                pubStrMonth = "December"
                        End Select

                        UpdateUserParameter()

                        For i = 0 To Val(pubMaxMonth) - 1
                            If Trim(Menu1.Items(i).Text) = pubStrMonth Then
                                Menu1.Items(i).Selected = True
                            End If
                        Next


                    End If

                End While
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub UpdateUserParameter()

        Dim strConnStr As String
        strConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        'strConnStr = "packet size=4096;user id=scheme;password=password;data source=SESH9SVR;persist security info=False;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(strConnStr)
        'MySqlConn.Open()

        Dim cmdUpdate As New SqlCommand

        If pubUserPosition = "Manager" Then
            cmdUpdate.CommandText = "Update and_user_parameter set repyear = '" & _
                    DropDownList1.Text.Trim & "', repmonth = '" & pubSelectedMonth & _
                    "', repmonthdes = '" & pubStrMonth & "', userid_selected = '" & _
                    pubUser.Trim & "' where rtrim(userid) = '" & pubUserManager.Trim & "'"
        Else
            cmdUpdate.CommandText = "Update and_user_parameter set repyear = '" & _
                    DropDownList1.Text.Trim & "', repmonth = '" & pubSelectedMonth & _
                    "', repmonthdes = '" & pubStrMonth & "' where rtrim(userid) = '" & pubUser.Trim & "'"
        End If

        cmdUpdate.Connection = MySqlConn
        cmdUpdate.Connection.Open()
        cmdUpdate.ExecuteNonQuery()
        MySqlConn.Close()

    End Sub

    Private Sub UpdateSelectedMonth()

        Dim strConnStr As String
        strConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"

        Dim MySqlConn As New SqlConnection(strConnStr)

        Dim cmdUpdate As New SqlCommand

        If pubUserPosition = "Manager" Then
            cmdUpdate.CommandText = "Update and_user_selected_month set selected_month = '" & _
                    pubSelectedMonth & "', selected_date = '" & pubServerDate & _
                    "', selected_year = '" & DropDownList1.Text.Trim & "' where rtrim(userid) = '" & pubUserManager.Trim & "'"
        Else
            cmdUpdate.CommandText = "Update and_user_selected_month set selected_month = '" & _
                    pubSelectedMonth & "', selected_date = '" & pubServerDate & _
                    "', selected_year = '" & DropDownList1.Text.Trim & "' where rtrim(userid) = '" & pubUser.Trim & "'"

        End If

        cmdUpdate.Connection = MySqlConn
        cmdUpdate.Connection.Open()
        cmdUpdate.ExecuteNonQuery()
        MySqlConn.Close()

    End Sub

    Private Sub CheckUserAuthority()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            If pubUserPosition = "Manager" Then
                sSql = "Select user_domain from and_user_login where userid_check = '" & pubUserManager.Trim & "'"
            Else
                sSql = "Select distinct(user_domain) as user_domain from and_user_table " & _
                        "where userid = '" & pubUser.Trim & "'"
            End If

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()

                    If Trim(mReader("user_domain")) <> pubDomain.Trim Then
                        Response.Redirect("MgtUnauthorized.aspx")
                    End If

                End While
            Else
                Response.Redirect("MgtUnauthorized.aspx")
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub CheckPubUser()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "Select userid_check, userid, position from and_user_login where userid_check = '" & pubUser.Trim & "'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()

                    pubUser = Trim(mReader("userid"))
                    pubUserPosition = Trim(mReader("position"))
                    pubUserManager = Trim(mReader("userid_check"))

                End While
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub CheckUserDesignation()

        Dim ConnStr As String
        Dim sSql As String
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "SELECT designation FROM and_user_table where userid = '" & pubUser.Trim & "' GROUP BY designation"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()
                    pubUserDesignation = Trim(mReader("designation"))
                    Select Case Trim(mReader("designation"))
                        Case "GD"
                            Image1.ImageUrl = "~/images/name_image1.gif"
                        Case "KD"
                            Image1.ImageUrl = "~/images/name_image2.gif"
                        Case "CGN"
                            Image1.ImageUrl = "~/images/name_image3.gif"
                        Case "CD"
                            Image1.ImageUrl = "~/images/name_image4.gif"
                        Case "PSM"
                            Image1.ImageUrl = "~/images/name_image5.gif"
                        Case "BSS"
                            Image1.ImageUrl = "~/images/name_image6.gif"
                        Case "JBM"
                            Image1.ImageUrl = "~/images/name_image7.gif"
                        Case "DNM"
                            Image1.ImageUrl = "~/images/name_image8.gif"
                        Case "CSS"
                            Image1.ImageUrl = "~/images/name_image9.gif"
                        Case "SD"
                            Image1.ImageUrl = "~/images/name_image20.gif"
                        Case "JF"
                            Image1.ImageUrl = "~/images/name_image10.gif"
                        Case "FA"
                            Image1.ImageUrl = "~/images/name_image13.gif"
                        Case "FG"
                            Image1.ImageUrl = "~/images/name_image14.gif"
                        Case "FAG"
                            Image1.ImageUrl = "~/images/name_image15.gif"
                        Case "FFL"
                            Image1.ImageUrl = "~/images/name_image16.gif"
                    End Select

                End While

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetServerDateTime()

        Dim ConnStr As String
        Dim sSql As String
        Dim mServerdate As Date
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "select getdate() as logdate from and_user_selected_month where userid = '" & pubUser.Trim & "'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    mServerdate = mReader("logdate".ToString)

                    pubServerDate = Format(mServerdate, "dd MMM yyyy")

                End While

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

#End Region

End Class
