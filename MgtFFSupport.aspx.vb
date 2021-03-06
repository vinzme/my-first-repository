#Region "Imports"

Imports System.Data.SqlClient
Imports System.Security.Principal
Imports System.Web.UI.Page
Imports System.IO
Imports Microsoft.Reporting.WebForms

#End Region

Partial Class MgtFFSupport
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
        GetCostCentre()

        If Not IsPostBack Then
            MultiView1.ActiveViewIndex = 0
            If pubUser.Trim = "ROBIN.POOLE" Then
                Button1.PostBackUrl = "~/MgtReportFF.aspx"
            End If
        End If

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        Select Case RadioButtonList1.SelectedIndex
            Case "0"
                RadioButtonList2.Visible = True
                MultiView1.ActiveViewIndex = 0
            Case "1"
                RadioButtonList2.Visible = True
                MultiView1.ActiveViewIndex = 0
            Case "2"
                RadioButtonList2.Visible = False
                MultiView1.ActiveViewIndex = 1
            Case "3"
                RadioButtonList2.Visible = True
                MultiView1.ActiveViewIndex = 2
            Case "4"
                RadioButtonList2.Visible = False
                MultiView1.ActiveViewIndex = 3
        End Select

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
                    pubUserMonth = Trim(mReader("repmonth".Trim))
                    Label1.Text = Trim(mReader("repmonthdes".Trim)) & " " & pubUserYear

                End While

            End If

        Catch ex As Exception

        Finally
            MySqlConn.Close()
        End Try

    End Sub

    Private Sub GetCostCentre()

        Dim params1(0) As ReportParameter
        Dim params2(0) As ReportParameter
        Dim params3(0) As ReportParameter
        Dim params4(0) As ReportParameter

        Select Case RadioButtonList1.SelectedIndex
            Case 0
                params1(0) = New ReportParameter("MYear", Mid(pubUserYear, 3, 2))
                params2(0) = New ReportParameter("MMonth", pubUserMonth)
                If RadioButtonList2.SelectedValue = 0 Then
                    params3(0) = New ReportParameter("MType", "M")
                Else
                    params3(0) = New ReportParameter("MType", "Y")
                End If
                params4(0) = New ReportParameter("DType", "D")

                ReportViewer1.ServerReport.SetParameters(params1)
                ReportViewer1.ServerReport.SetParameters(params2)
                ReportViewer1.ServerReport.SetParameters(params3)
                ReportViewer1.ServerReport.SetParameters(params4)
                ReportViewer1.ServerReport.Refresh()

            Case 1
                params1(0) = New ReportParameter("MYear", Mid(pubUserYear, 3, 2))
                params2(0) = New ReportParameter("MMonth", pubUserMonth)
                If RadioButtonList2.SelectedValue = 0 Then
                    params3(0) = New ReportParameter("MType", "M")
                Else
                    params3(0) = New ReportParameter("MType", "Y")
                End If
                params4(0) = New ReportParameter("DType", "C")
                ReportViewer1.ServerReport.SetParameters(params1)
                ReportViewer1.ServerReport.SetParameters(params2)
                ReportViewer1.ServerReport.SetParameters(params3)
                ReportViewer1.ServerReport.SetParameters(params4)
                ReportViewer1.ServerReport.Refresh()

            Case 2
                params1(0) = New ReportParameter("MYear", Mid(pubUserYear, 3, 2))
                params2(0) = New ReportParameter("MMonth", pubUserMonth)
                ReportViewer2.ServerReport.SetParameters(params1)
                ReportViewer2.ServerReport.SetParameters(params2)
                ReportViewer2.ServerReport.Refresh()

            Case 3
                params1(0) = New ReportParameter("MYear", Mid(pubUserYear, 3, 2))
                params2(0) = New ReportParameter("MMonth", pubUserMonth)
                If RadioButtonList2.SelectedValue = 0 Then
                    params3(0) = New ReportParameter("MType", "M")
                Else
                    params3(0) = New ReportParameter("MType", "Y")
                End If
                ReportViewer3.ServerReport.SetParameters(params1)
                ReportViewer3.ServerReport.SetParameters(params2)
                ReportViewer3.ServerReport.SetParameters(params3)
                ReportViewer3.ServerReport.Refresh()

            Case 4
                params1(0) = New ReportParameter("MYear", Mid(pubUserYear, 3, 2))
                params2(0) = New ReportParameter("MMonth", pubUserMonth)
                ReportViewer4.ServerReport.SetParameters(params1)
                ReportViewer4.ServerReport.SetParameters(params2)
                ReportViewer4.ServerReport.Refresh()
        End Select


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

                    If pubUser.Trim <> "ROBIN.POOLE" Then
                        pubUser = Trim(mReader("userid"))
                    End If

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
