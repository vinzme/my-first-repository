#Region "Imports"

Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web.UI.Page
Imports System.IO

#End Region

Partial Class MgtReportFF

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


        'ImageButton9.Attributes.Add("onmouseover", "this.src='images/memo_on.gif'")
        'ImageButton9.Attributes.Add("onmouseout", "this.src='images/memo.gif'")

        ImageButton10.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton11.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton12.Attributes.Add("onclick", "document.body.style.cursor='wait';")
        ImageButton13.Attributes.Add("onclick", "document.body.style.cursor='wait';")

        ImageButton14.Attributes.Add("onclick", "document.body.style.cursor='wait';")

        Dim sUser() As String = Split(User.Identity.Name, "\")
        Dim sDomain As String = sUser(0)
        Dim sUserId As String = sUser(1)

        pubUser = UCase(sUserId)
        'pubUser = "ROBIN.POOLE"

        pubDomain = UCase(sDomain)

        pubUserPosition = "User"

        CheckPubUser()

        CheckUserAuthority()

        GetMgtModules()
        GetServerDateTime()

        If Page.IsPostBack = False Then
            CheckSelectedYear()

            GetMenuMonths()
            GetSelectedMonth()
            GetCheckMonth()

            'SelectJanuary()
            UpdateFFTag()

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

        '1
        ImageButton1.ImageUrl = "~/images/md_img1.gif"
        ImageButton6.ImageUrl = "~/images/content1_md.gif"

        ImageButton1.PostBackUrl = "~/MDCompanyIncome.aspx"
        ImageButton6.PostBackUrl = "~/MDCompanyIncome.aspx"

        ImageButton1.Attributes.Add("onmouseover", "this.src='images/md_img1_on.gif'")
        ImageButton1.Attributes.Add("onmouseout", "this.src='images/md_img1.gif'")

        ImageButton6.Attributes.Add("onmouseover", "this.src='images/content1_md_on.gif'")
        ImageButton6.Attributes.Add("onmouseout", "this.src='images/content1_md.gif'")

        '2
        ImageButton2.ImageUrl = "~/images/md_img6.gif"
        ImageButton7.ImageUrl = "~/images/content6_md.gif"

        ImageButton2.PostBackUrl = "~/MgtFFSupport.aspx"
        ImageButton7.PostBackUrl = "~/MgtFFSupport.aspx"

        ImageButton2.Attributes.Add("onmouseover", "this.src='images/md_img6_on.gif'")
        ImageButton2.Attributes.Add("onmouseout", "this.src='images/md_img6.gif'")

        ImageButton7.Attributes.Add("onmouseover", "this.src='images/content6_md_on.gif'")
        ImageButton7.Attributes.Add("onmouseout", "this.src='images/content6_md.gif'")

        '3
        ImageButton3.ImageUrl = "~/images/md_img2.gif"
        ImageButton8.ImageUrl = "~/images/content2_md.gif"

        ImageButton3.PostBackUrl = "~/MDDivisionIncome.aspx"
        ImageButton8.PostBackUrl = "~/MDDivisionIncome.aspx"

        ImageButton3.Attributes.Add("onmouseover", "this.src='images/md_img2_on.gif'")
        ImageButton3.Attributes.Add("onmouseout", "this.src='images/md_img2.gif'")

        ImageButton8.Attributes.Add("onmouseover", "this.src='images/content2_md_on.gif'")
        ImageButton8.Attributes.Add("onmouseout", "this.src='images/content2_md.gif'")

        '4
        ImageButton4.ImageUrl = "~/images/md_img3.gif"
        ImageButton10.ImageUrl = "~/images/content3_md.gif"

        ImageButton4.PostBackUrl = "~/MDBalanceSheet.aspx"
        ImageButton10.PostBackUrl = "~/MDBalanceSheet.aspx"

        ImageButton4.Attributes.Add("onmouseover", "this.src='images/md_img3_on.gif'")
        ImageButton4.Attributes.Add("onmouseout", "this.src='images/md_img3.gif'")

        ImageButton10.Attributes.Add("onmouseover", "this.src='images/content3_md_on.gif'")
        ImageButton10.Attributes.Add("onmouseout", "this.src='images/content3_md.gif'")

        '5
        ImageButton5.ImageUrl = "~/images/md_img4.gif"
        ImageButton11.ImageUrl = "~/images/content4_md.gif"

        ImageButton5.PostBackUrl = "~/MDMarginReport.aspx"
        ImageButton11.PostBackUrl = "~/MDMarginReport.aspx"

        ImageButton5.Attributes.Add("onmouseover", "this.src='images/md_img4_on.gif'")
        ImageButton5.Attributes.Add("onmouseout", "this.src='images/md_img4.gif'")

        ImageButton11.Attributes.Add("onmouseover", "this.src='images/content4_md_on.gif'")
        ImageButton11.Attributes.Add("onmouseout", "this.src='images/content4_md.gif'")

        '6
        ImageButton12.ImageUrl = "~/images/md_img5.gif"
        ImageButton13.ImageUrl = "~/images/content5_md.gif"

        ImageButton12.PostBackUrl = "~/MDLabour.aspx"
        ImageButton13.PostBackUrl = "~/MDLabour.aspx"

        ImageButton12.Attributes.Add("onmouseover", "this.src='images/md_img5_on.gif'")
        ImageButton12.Attributes.Add("onmouseout", "this.src='images/md_img5.gif'")

        ImageButton13.Attributes.Add("onmouseover", "this.src='images/content5_md_on.gif'")
        ImageButton13.Attributes.Add("onmouseout", "this.src='images/content5_md.gif'")

        '7
        ImageButton9.ImageUrl = "~/images/md_img3.gif"
        ImageButton14.ImageUrl = "~/images/content7_md.gif"

        'link
        ImageButton9.PostBackUrl = "http://secure.saudi-ericsson.com/receivables/receivables.aspx"
        ImageButton14.PostBackUrl = "http://secure.saudi-ericsson.com/receivables/receivables.aspx"

        ImageButton9.Attributes.Add("onmouseover", "this.src='images/md_img3_on.gif'")
        ImageButton9.Attributes.Add("onmouseout", "this.src='images/md_img3.gif'")

        ImageButton14.Attributes.Add("onmouseover", "this.src='images/content7_md_on.gif'")
        ImageButton14.Attributes.Add("onmouseout", "this.src='images/content7_md.gif'")

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

            If pubUserManager.Trim = "ROBIN.POOLE" Then
                sSql = "Select max(mgt_month) as maxmonths from and_user_month where mgt_year = '" & _
                        DropDownList1.Text.Trim & "' and mgt_status = '0'"
            Else
                sSql = "Select max(mgt_month) as maxmonths from and_user_month where mgt_year = '" & _
                        DropDownList1.Text.Trim & "'"
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

            Else

                Response.Redirect("MgtUnauthorized.aspx")
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

            If pubUserManager.Trim = "ROBIN.POOLE" Then
                sSql = "Select selected_month, selected_date from and_user_selected_month where userid = '" & _
                        pubUser.Trim & "'"
            Else
                sSql = "Select selected_month, selected_date from and_user_selected_month where userid = '" & _
                        pubUserManager.Trim & "'"
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

        If pubUserManager.Trim = "ROBIN.POOLE" Then
            cmdUpdate.CommandText = "Update and_user_parameter set repyear = '" & _
                    DropDownList1.Text.Trim & "', repmonth = '" & pubSelectedMonth & _
                    "', repmonthdes = '" & pubStrMonth & "' where rtrim(userid) = '" & pubUser.Trim & "'"
        Else
            cmdUpdate.CommandText = "Update and_user_parameter set repyear = '" & _
                    DropDownList1.Text.Trim & "', repmonth = '" & pubSelectedMonth & _
                    "', repmonthdes = '" & pubStrMonth & "', userid_selected = '" & _
                    pubUser.Trim & "' where rtrim(userid) = '" & pubUserManager.Trim & "'"
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

        If pubUserManager.Trim = "ROBIN.POOLE" Then
            cmdUpdate.CommandText = "Update and_user_selected_month set selected_month = '" & _
                    pubSelectedMonth & "', selected_date = '" & pubServerDate & _
                    "', selected_year = '" & DropDownList1.Text.Trim & "' where rtrim(userid) = '" & pubUser.Trim & "'"
        Else
            cmdUpdate.CommandText = "Update and_user_selected_month set selected_month = '" & _
                    pubSelectedMonth & "', selected_date = '" & pubServerDate & _
                    "', selected_year = '" & DropDownList1.Text.Trim & "' where rtrim(userid) = '" & pubUserManager.Trim & "'"
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
                If pubUser.Trim = "ROBIN.POOLE" Then
                    sSql = "Select distinct(user_domain) as user_domain from and_user_table " & _
                            "where userid = '" & pubUser.Trim & "'"
                Else
                    sSql = "Select user_domain from and_user_login where userid_check = '" & pubUserManager.Trim & "'"
                End If

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
                    If pubUser.Trim <> "ROBIN.POOLE" Then
                        pubUser = Trim(mReader("userid"))
                    End If

                    pubUserPosition = Trim(mReader("position"))
                    pubUserManager = Trim(mReader("userid_check"))

                End While
            Else
                Response.Redirect("MgtUnauthorized.aspx")
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

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        Menu1.Items.Clear()
        GetMenuMonths()
        GetSelectedMonth()
        GetCheckMonth()
        'SelectJanuary()

    End Sub

    Private Sub CheckSelectedYear()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String

        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        'ConnStr = "packet size=4096;user id=scheme;password=password;data source=SESH9SVR;persist security info=False;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            If pubUserManager.Trim = "ROBIN.POOLE" Then
                sSql = "Select selected_month, selected_date from and_user_selected_month where userid = '" & _
                        pubUser.Trim & "'"
            Else
                sSql = "Select selected_month, selected_date from and_user_selected_month where userid = '" & _
                        pubUserManager.Trim & "'"
            End If


            If pubUserManager.Trim = "ROBIN.POOLE" Then
                sSql = "Select selected_year from and_user_selected_month where userid = '" & _
                        pubUser.Trim & "'"
            Else
                sSql = "Select selected_year from and_user_selected_month where userid = '" & _
                        pubUserManager.Trim & "'"
            End If

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then
                While mReader.Read()
                    DropDownList1.SelectedValue = Trim(mReader("selected_year"))
                End While
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub SelectJanuary()

        Dim strConnStr As String
        strConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"

        Dim MySqlConn As New SqlConnection(strConnStr)

        Dim cmdUpdate As New SqlCommand

        If DropDownList1.Text.Trim = "2011" Then

            UpdateUserParameter2()

            If pubUserManager.Trim = "ROBIN.POOLE" Then
                cmdUpdate.CommandText = "Update and_user_selected_month set selected_month = 'January'," & _
                        "selected_date = '" & pubServerDate & _
                        "', selected_year = '2011' where rtrim(userid) = '" & pubUser.Trim & "'"
            Else
                cmdUpdate.CommandText = "Update and_user_selected_month set selected_month = 'January'," & _
                        "selected_date = '" & pubServerDate & _
                        "', selected_year = '" & DropDownList1.Text.Trim & "' where rtrim(userid) = '" & pubUserManager.Trim & "'"
            End If

            cmdUpdate.Connection = MySqlConn
            cmdUpdate.Connection.Open()
            cmdUpdate.ExecuteNonQuery()
            MySqlConn.Close()
        End If

    End Sub

    Private Sub UpdateUserParameter2()

        Dim strConnStr As String
        strConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        'strConnStr = "packet size=4096;user id=scheme;password=password;data source=SESH9SVR;persist security info=False;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(strConnStr)
        'MySqlConn.Open()

        Dim cmdUpdate As New SqlCommand

        If pubUserManager.Trim = "ROBIN.POOLE" Then
            cmdUpdate.CommandText = "Update and_user_parameter set repyear = '2011', " & _
                    "repmonth = '1', repmonthdes = 'January' where rtrim(userid) = '" & pubUser.Trim & "'"
        Else
            cmdUpdate.CommandText = "Update and_user_parameter set repyear = '2011', " & _
                    "repmonth = '1', repmonthdes = 'January', userid_selected = '" & _
                    pubUser.Trim & "' where rtrim(userid) = '" & pubUserManager.Trim & "'"
        End If

        cmdUpdate.Connection = MySqlConn
        cmdUpdate.Connection.Open()
        cmdUpdate.ExecuteNonQuery()
        MySqlConn.Close()


    End Sub

    Private Sub UpdateFFTag()

        Dim strConnStr As String
        strConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(strConnStr)

        Dim cmdUpdate As New SqlCommand

        cmdUpdate.CommandText = "Update and_user_login set fftag = '0' where userid_check = 'ROBIN.POOLE'"
        cmdUpdate.Connection = MySqlConn
        cmdUpdate.Connection.Open()
        cmdUpdate.ExecuteNonQuery()
        MySqlConn.Close()

    End Sub

End Class
