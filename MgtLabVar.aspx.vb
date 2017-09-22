#Region "Imports"

Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web.UI.Page
Imports System.IO
Imports Microsoft.Reporting.WebForms

#End Region
Partial Class MgtLabVar
    Inherits System.Web.UI.Page
    Dim pubUser As String
    Dim pubDomain As String
    Dim pubUserPosition As String
    Dim pubUserManager As String

    Dim pubUserDesign As String
    Dim pubUserYear As String
    Dim pubUserMonth As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sUser() As String = Split(User.Identity.Name, "\")
        Dim sDomain As String = sUser(0)
        Dim sUserId As String = sUser(1)

        If Not IsPostBack Then



            pubUser = UCase(sUserId)

            pubDomain = UCase(sDomain)
            pubUserPosition = "User"

            CheckPubUser()
            CheckUserAuthority()

            GetUserCategory()

            GetDateParameters()

            DisplayReport()

            
        End If
    End Sub

    Private Sub DisplayReport()
        Dim sReportName As String

        sReportName = "AB" + pubUserDesign + pubUserYear + pubUserMonth

        Literal1.Text = "<IFRAME NAME = 'map_frame' height='680px' width='100%'  scrolling='auto' SRC='Variance Report/" & sReportName & ".htm' />"

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

    Private Sub GetUserCategory()

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
            sSql = "Select category, designation from and_user_table where rtrim(userid) = '" & pubUser.Trim & "' and report_module = '5'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()
                    Select Case Trim(mReader("category"))
                        Case "713"
                            Button1.PostBackUrl = "~/MgtLabour713.aspx"
                        Case "1"
                            Button1.PostBackUrl = "~/MDLabour.aspx"
                        Case Else
                            Button1.PostBackUrl = "~/MgtLabour.aspx"
                    End Select
                    pubUserDesign = Trim(mReader("designation"))
                End While

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetDateParameters()

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

            If pubUserPosition = "Manager" Then
                sSql = "Select repyear, repmonth, repmonthdes from and_user_parameter where rtrim(userid) = '" & pubUserManager.Trim & "'"

            Else
                sSql = "Select repyear, repmonth, repmonthdes from and_user_parameter where rtrim(userid) = '" & pubUser.Trim & "'"
            End If

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()

                    pubUserYear = Trim(mReader("repyear".Trim))
                    pubUserMonth = "0" + Trim(mReader("repmonth".Trim))
                    
                End While

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
End Class
