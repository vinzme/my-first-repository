#Region "Imports"

Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web.UI.Page
Imports System.IO
Imports Microsoft.Reporting.WebForms

#End Region

Partial Class MgtMemos
    Inherits System.Web.UI.Page

    Dim pubUser As String
    Dim pubDomain As String

    Dim pubSelectedMonth As String
    Dim pubSelectedYear As String
    Dim pubUserPosition As String
    Dim pubUserManager As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sUser() As String = Split(User.Identity.Name, "\")
        Dim sDomain As String = sUser(0)
        Dim sUserId As String = sUser(1)

        pubUser = UCase(sUserId)

        pubDomain = UCase(sDomain)
        pubUserPosition = "User"

        CheckPubUser()

        CheckUserAuthority()

        GetSelectedPeriod()
        GetMgtFilename()
        If Not IsPostBack Then
            If MultiView1.ActiveViewIndex = 1 Then
                GetPages()
            End If
        End If

    End Sub

    Private Sub CheckPubUser()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "Select userid, userid_check, position from and_user_login where userid_check = '" & pubUser.Trim & "'"

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

    Private Sub GetSelectedPeriod()

        Dim ConnStr As String
        Dim sSql As String

        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            If pubUserPosition = "Manager" Then
                sSql = "Select selected_month, selected_year from and_user_selected_month where userid = '" & _
                        pubUserManager.Trim & "'"
            Else
                sSql = "Select selected_month, selected_year from and_user_selected_month where userid = '" & _
                        pubUser.Trim & "'"
            End If

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    pubSelectedMonth = Trim(mReader("selected_month"))
                    pubSelectedYear = Trim(mReader("selected_year"))

                    '********
                    '
                    If pubSelectedYear.Trim = "2011" And pubSelectedMonth.Trim = "January" Then
                        pubSelectedMonth = "1"
                    End If

                End While

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetMgtFilename()

        Dim ConnStr As String
        Dim sSql As String

        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "Select doc_filename, page_count from and_user_mgt_doc where userid = '" & _
                    pubUser.Trim & "' and doc_month = '" & pubSelectedMonth.Trim & _
                    "' and doc_year = '" & pubSelectedYear.Trim & "' and page_no = '1'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    If mReader("page_count") = 1 Then
                        Image2.ImageUrl = "~/memos/" & Trim(mReader("doc_filename"))
                        MultiView1.ActiveViewIndex = 0
                    Else

                        Image3.ImageUrl = "~/memos/" & Trim(mReader("doc_filename"))
                        MultiView1.ActiveViewIndex = 1

                    End If
                End While

            Else

                MultiView1.ActiveViewIndex = 0
                Image2.ImageUrl = "~/memos/nomemo.gif"
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

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

    Private Sub GetPages()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        Dim i As Integer
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try
            i = 0
            sSql = "Select page_no from and_user_mgt_doc where userid = '" & _
                    pubUser.Trim & "' and doc_month = '" & pubSelectedMonth.Trim & _
                    "' and doc_year = '" & pubSelectedYear.Trim & "' order by page_no"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    RadioButtonList1.Items.Add("Page " & Trim(mReader("page_no".ToString)))

                End While

            End If

            RadioButtonList1.Items(0).Selected = True

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        GetMgtFilePages()
    End Sub

    Private Sub GetMgtFilePages()

        Dim ConnStr As String
        Dim sSql As String

        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try

            sSql = "Select doc_filename from and_user_mgt_doc where userid = '" & _
                    pubUser.Trim & "' and doc_month = '" & pubSelectedMonth.Trim & _
                    "' and doc_year = '" & pubSelectedYear.Trim & "' and page_no = '" & _
                    RadioButtonList1.SelectedIndex + 1 & "'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    Image3.ImageUrl = "~/memos/" & Trim(mReader("doc_filename"))

                End While

            Else

                MultiView1.ActiveViewIndex = 0
                Image3.ImageUrl = "~/memos/nomemo.gif"
            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

End Class
