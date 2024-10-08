Public Class Form_Fail

    Private Sub ButtonYES_Click(sender As Object, e As EventArgs) Handles ButtonYES.Click
        Upgrade_Firm_process = "PASS"

        'MsgBox("pass")
        Me.Close()
    End Sub

    Private Sub ButtonNO_Click(sender As Object, e As EventArgs) Handles ButtonNO.Click
        Upgrade_Firm_process = "FAIL"
        Me.Size = New System.Drawing.Size(500, 400)
        'MsgBox("fail")
        Me.Panel1.Show()


        'Me.ButtonYES.Enabled = False


    End Sub

    Private Sub Form_Fail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel1.Hide()
        Me.Size = New System.Drawing.Size(500, 150)
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False

        'CheckBox1.CheckState = False
        'CheckBox2.CheckState = False
        'CheckBox3.CheckState = False
        'CheckBox4.CheckState = False
    End Sub

    Private Sub ButtonDONE_Click(sender As Object, e As EventArgs) Handles ButtonDONE.Click
        If CheckBox1.Checked = True Then
            If TextBoxPrimary.Text = "" Or TextBoxSecondary.Text = "" Then
                'Form_Fail.TextBoxPrimary.Select()
                MsgBox("error code belum diisi")
            ElseIf TextBoxPrimary.Text <> "" And TextBoxSecondary.Text <> "" Then
                fail1 = "|Firmware download failed (error code Primary:" & TextBoxPrimary.Text & ", Secondary:" & TextBoxSecondary.Text & ")|"
            End If
        End If

        If CheckBox2.Checked = True Then
            fail2 = "|Reprogram waiting too long or stop|"
        End If

        If CheckBox3.Checked = True Then
            fail3 = "|Modem COM not detected or not stable|"
        End If

        If CheckBox4.Checked = True Then
            fail4 = "|Fail due to other slots Modem plug in|"
        End If

        If CheckBox2.Checked = True Or CheckBox3.Checked = True Or CheckBox4.Checked = True Or
            (CheckBox1.Checked = True And TextBoxPrimary.Text <> "" And TextBoxSecondary.Text <> "") Then
            Me.Close()
        Else
            MsgBox("Check salah atau error code belum diisi")
        End If
    End Sub

    Private Sub TextBoxPrimary_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPrimary.TextChanged
        CheckBox1.Checked = True
    End Sub

    Private Sub TextBoxSecondary_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSecondary.TextChanged
        CheckBox1.Checked = True
    End Sub
End Class