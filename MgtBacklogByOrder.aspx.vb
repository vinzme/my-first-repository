#Region "Imports"

Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web.UI.Page
Imports System.IO
Imports Microsoft.Reporting.WebForms

#End Region

Partial Class MgtBacklogByOrder
    Inherits System.Web.UI.Page

    Dim pubUser As String
    Dim pubDomain As String

    Dim pubUserPosition As String
    Dim pubUserManager As String

    Dim pubUserCat As String
    Dim pubUserYear As String
    Dim pubUserMonth As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sUser() As String = Split(User.Identity.Name, "\")
        Dim sDomain As String = sUser(0)
        Dim sUserId As String = sUser(1)

        pubUser = UCase(sUserId)

        pubDomain = UCase(sDomain)

        pubUserPosition = "User"

        CheckPubUser()
        CheckUserAuthority()

        GetDateParameters()

        If Not IsPostBack Then
            MultiView1.ActiveViewIndex = 0
            GetCostCentre()
        End If

    End Sub

    Private Sub GetDateParameters()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        Dim i As Integer
        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"

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
                    pubUserMonth = Trim(mReader("repmonth".Trim))
                    Label1.Text = "Backlog Report by Order No. for the Month of " & _
                            Trim(mReader("repmonthdes".Trim)) & " " & pubUserYear

                End While

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetCostCentre()

        'Handles reentering the the search
        Dim ConnStr As String
        Dim sSql As String
        Dim strDivision As String
        Dim i As Integer
        Dim y As Integer
        Dim strPeriod As String
        Dim params1(0) As ReportParameter
        Dim params2(0) As ReportParameter
        Dim params3(0) As ReportParameter
        Dim params4(0) As ReportParameter

        ConnStr = "Data Source=SESLSVRHO;User ID=scheme;Password=Er1c550n2;initial catalog=MIS"
        Dim MySqlConn As New SqlConnection(ConnStr)
        MySqlConn.Open()
        Try
            i = 0
            strDivision = ""

            sSql = "Select cost_centre from and_user_user_costcenter where rtrim(userid) = '" & _
                pubUser.Trim & "' and report_module = '2'"

            Dim MySqlCmd As New SqlCommand(sSql, MySqlConn)
            Dim mReader As SqlDataReader

            mReader = MySqlCmd.ExecuteReader()
            If mReader.HasRows Then

                While mReader.Read()
                    i = i + 1
                    strDivision = strDivision & Trim(mReader("cost_centre".Trim))
                End While

            End If

            Dim strTemp(i) As String

            For y = 1 To i
                Select Case y
                    Case 1
                        strTemp(0) = Mid(strDivision, 1, 3)
                    Case 2
                        strTemp(1) = Mid(strDivision, 4, 3)
                    Case 3
                        strTemp(2) = Mid(strDivision, 7, 3)
                    Case 4
                        strTemp(3) = Mid(strDivision, 10, 3)
                    Case 5
                        strTemp(4) = Mid(strDivision, 13, 3)
                    Case 6
                        strTemp(5) = Mid(strDivision, 16, 3)
                    Case 7
                        strTemp(6) = Mid(strDivision, 19, 3)
                    Case 8
                        strTemp(7) = Mid(strDivision, 22, 3)
                    Case 9
                        strTemp(8) = Mid(strDivision, 25, 3)
                    Case 10
                        strTemp(9) = Mid(strDivision, 28, 3)
                    Case 11
                        strTemp(10) = Mid(strDivision, 31, 3)
                    Case 12
                        strTemp(11) = Mid(strDivision, 34, 3)
                    Case 13
                        strTemp(12) = Mid(strDivision, 37, 3)
                    Case 14
                        strTemp(13) = Mid(strDivision, 40, 3)
                End Select
            Next

            If Val(pubUserMonth) < 10 Then
                strPeriod = "0" & pubUserMonth
            Else
                strPeriod = pubUserMonth
            End If

            params1(0) = New ReportParameter("CostCentre", strTemp)
            params2(0) = New ReportParameter("month", strPeriod)
            params3(0) = New ReportParameter("year", Mid(pubUserYear, 3, 2))
            ReportViewer1.ServerReport.SetParameters(params1)
            ReportViewer1.ServerReport.SetParameters(params2)
            ReportViewer1.ServerReport.SetParameters(params3)
            ReportViewer1.ZoomMode = ZoomMode.PageWidth
            ReportViewer1.ServerReport.Refresh()

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
