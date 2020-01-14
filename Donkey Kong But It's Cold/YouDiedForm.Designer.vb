<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YouDiedForm
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
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.btnEndGame = New System.Windows.Forms.Button()
        Me.txtTemp = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(30, 356)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(75, 23)
        Me.btnRestart.TabIndex = 0
        Me.btnRestart.Text = "Restart?"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'btnEndGame
        '
        Me.btnEndGame.Location = New System.Drawing.Point(408, 356)
        Me.btnEndGame.Name = "btnEndGame"
        Me.btnEndGame.Size = New System.Drawing.Size(75, 23)
        Me.btnEndGame.TabIndex = 1
        Me.btnEndGame.Text = "End Game?"
        Me.btnEndGame.UseVisualStyleBackColor = True
        '
        'txtTemp
        '
        Me.txtTemp.Location = New System.Drawing.Point(62, 87)
        Me.txtTemp.Name = "txtTemp"
        Me.txtTemp.Size = New System.Drawing.Size(395, 20)
        Me.txtTemp.TabIndex = 2
        Me.txtTemp.Text = "Temp"
        '
        'YouDiedForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 391)
        Me.Controls.Add(Me.txtTemp)
        Me.Controls.Add(Me.btnEndGame)
        Me.Controls.Add(Me.btnRestart)
        Me.Name = "YouDiedForm"
        Me.Text = "YouDiedForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents btnEndGame As System.Windows.Forms.Button
    Friend WithEvents txtTemp As System.Windows.Forms.TextBox
End Class
