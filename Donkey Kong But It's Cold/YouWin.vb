Public Class YouWin

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        Me.Hide()
    End Sub

    Private Sub btnEndGame_Click(sender As Object, e As EventArgs) Handles btnEndGame.Click
        Quit = True
        Me.Hide()
    End Sub
End Class