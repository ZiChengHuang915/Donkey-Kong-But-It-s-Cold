Public Class Form2

    Private Sub n1_Click(sender As Object, e As EventArgs) Handles n1.Click
        nSpeed = 2
        lblNSpeed.Text = "nSpeed = 2"
    End Sub

    Private Sub n2_Click(sender As Object, e As EventArgs) Handles n2.Click
        nSpeed = 3
        lblNSpeed.Text = "nSpeed = 3"
    End Sub

    Private Sub n3_Click(sender As Object, e As EventArgs) Handles n3.Click
        nSpeed = 4
        lblNSpeed.Text = "nSpeed = 4"
    End Sub

    Private Sub StartGame_Click(sender As Object, e As EventArgs) Handles StartGame.Click
        My.Forms.Mainform.Show()
        My.Forms.Mainform.ResetLevel()
        My.Forms.Mainform.GameTimer.Start()
        Me.Close()
    End Sub

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        BallSpeed = 3
        lbB.Text = "BallSpeed = 3"
    End Sub

    Private Sub b2_Click(sender As Object, e As EventArgs) Handles b2.Click
        BallSpeed = 4
        lbB.Text = "BallSpeed = 4"
    End Sub

    Private Sub b3_Click(sender As Object, e As EventArgs) Handles b3.Click
        BallSpeed = 5
        lbB.Text = "BallSpeed = 5"
    End Sub

    Private Sub h1_Click(sender As Object, e As EventArgs) Handles h1.Click
        Hacks = True
        HackLabel.Text = "Hacks is On"
    End Sub

    Private Sub h2_Click(sender As Object, e As EventArgs) Handles h2.Click
        Hacks = False
        HackLabel.Text = "Hacks is Off"
    End Sub

    Private Sub g1_Click(sender As Object, e As EventArgs) Handles g1.Click
        GhostSpeed = 1
        Ghostlabel.Text = "GhostSpeed = 1"
    End Sub

    Private Sub g2_Click(sender As Object, e As EventArgs) Handles g2.Click
        GhostSpeed = 2
        Ghostlabel.Text = "GhostSpeed = 2"
    End Sub

    
End Class