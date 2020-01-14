<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YouWin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.btnEndGame = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(68, 69)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "temp"
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(12, 204)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(75, 23)
        Me.btnRestart.TabIndex = 1
        Me.btnRestart.Text = "Restart?"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'btnEndGame
        '
        Me.btnEndGame.Location = New System.Drawing.Point(197, 204)
        Me.btnEndGame.Name = "btnEndGame"
        Me.btnEndGame.Size = New System.Drawing.Size(75, 23)
        Me.btnEndGame.TabIndex = 2
        Me.btnEndGame.Text = "End Game?"
        Me.btnEndGame.UseVisualStyleBackColor = True
        '
        'YouWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnEndGame)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "YouWin"
        Me.Text = "YouWin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents btnEndGame As System.Windows.Forms.Button
End Class
