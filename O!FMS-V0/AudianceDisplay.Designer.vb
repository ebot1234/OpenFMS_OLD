<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AudianceDisplay
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
        Me.RedTeam1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Redteam2 = New System.Windows.Forms.Label()
        Me.RedTeam3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BlueTeam3 = New System.Windows.Forms.Label()
        Me.BlueTeam2 = New System.Windows.Forms.Label()
        Me.BlueTeam1 = New System.Windows.Forms.Label()
        Me.RedScore = New System.Windows.Forms.Label()
        Me.BlueScore = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'RedTeam1
        '
        Me.RedTeam1.AutoSize = True
        Me.RedTeam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam1.ForeColor = System.Drawing.Color.White
        Me.RedTeam1.Location = New System.Drawing.Point(3, 0)
        Me.RedTeam1.Name = "RedTeam1"
        Me.RedTeam1.Size = New System.Drawing.Size(59, 24)
        Me.RedTeam1.TabIndex = 0
        Me.RedTeam1.Text = "Red1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.RedScore)
        Me.Panel1.Controls.Add(Me.RedTeam3)
        Me.Panel1.Controls.Add(Me.Redteam2)
        Me.Panel1.Controls.Add(Me.RedTeam1)
        Me.Panel1.Location = New System.Drawing.Point(1, 380)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 100)
        Me.Panel1.TabIndex = 1
        '
        'Redteam2
        '
        Me.Redteam2.AutoSize = True
        Me.Redteam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Redteam2.ForeColor = System.Drawing.Color.White
        Me.Redteam2.Location = New System.Drawing.Point(3, 30)
        Me.Redteam2.Name = "Redteam2"
        Me.Redteam2.Size = New System.Drawing.Size(59, 24)
        Me.Redteam2.TabIndex = 1
        Me.Redteam2.Text = "Red2"
        '
        'RedTeam3
        '
        Me.RedTeam3.AutoSize = True
        Me.RedTeam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam3.ForeColor = System.Drawing.Color.White
        Me.RedTeam3.Location = New System.Drawing.Point(3, 60)
        Me.RedTeam3.Name = "RedTeam3"
        Me.RedTeam3.Size = New System.Drawing.Size(59, 24)
        Me.RedTeam3.TabIndex = 2
        Me.RedTeam3.Text = "Red3"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Blue
        Me.Panel2.Controls.Add(Me.BlueScore)
        Me.Panel2.Controls.Add(Me.BlueTeam3)
        Me.Panel2.Controls.Add(Me.BlueTeam2)
        Me.Panel2.Controls.Add(Me.BlueTeam1)
        Me.Panel2.Location = New System.Drawing.Point(482, 380)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(432, 100)
        Me.Panel2.TabIndex = 3
        '
        'BlueTeam3
        '
        Me.BlueTeam3.AutoSize = True
        Me.BlueTeam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam3.ForeColor = System.Drawing.Color.White
        Me.BlueTeam3.Location = New System.Drawing.Point(369, 60)
        Me.BlueTeam3.Name = "BlueTeam3"
        Me.BlueTeam3.Size = New System.Drawing.Size(63, 24)
        Me.BlueTeam3.TabIndex = 2
        Me.BlueTeam3.Text = "Blue3"
        '
        'BlueTeam2
        '
        Me.BlueTeam2.AutoSize = True
        Me.BlueTeam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam2.ForeColor = System.Drawing.Color.White
        Me.BlueTeam2.Location = New System.Drawing.Point(369, 30)
        Me.BlueTeam2.Name = "BlueTeam2"
        Me.BlueTeam2.Size = New System.Drawing.Size(63, 24)
        Me.BlueTeam2.TabIndex = 1
        Me.BlueTeam2.Text = "Blue2"
        '
        'BlueTeam1
        '
        Me.BlueTeam1.AutoSize = True
        Me.BlueTeam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam1.ForeColor = System.Drawing.Color.White
        Me.BlueTeam1.Location = New System.Drawing.Point(369, 0)
        Me.BlueTeam1.Name = "BlueTeam1"
        Me.BlueTeam1.Size = New System.Drawing.Size(63, 24)
        Me.BlueTeam1.TabIndex = 0
        Me.BlueTeam1.Text = "Blue1"
        '
        'RedScore
        '
        Me.RedScore.AutoSize = True
        Me.RedScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedScore.ForeColor = System.Drawing.Color.White
        Me.RedScore.Location = New System.Drawing.Point(195, 30)
        Me.RedScore.Name = "RedScore"
        Me.RedScore.Size = New System.Drawing.Size(131, 46)
        Me.RedScore.TabIndex = 3
        Me.RedScore.Text = "Score"
        '
        'BlueScore
        '
        Me.BlueScore.AutoSize = True
        Me.BlueScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueScore.ForeColor = System.Drawing.Color.White
        Me.BlueScore.Location = New System.Drawing.Point(3, 30)
        Me.BlueScore.Name = "BlueScore"
        Me.BlueScore.Size = New System.Drawing.Size(131, 46)
        Me.BlueScore.TabIndex = 4
        Me.BlueScore.Text = "Score"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(27, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 46)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Timer"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Location = New System.Drawing.Point(323, 380)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(165, 100)
        Me.Panel3.TabIndex = 5
        '
        'AudianceDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lime
        Me.ClientSize = New System.Drawing.Size(915, 481)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AudianceDisplay"
        Me.Text = "AudianceDisplay"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RedTeam1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RedScore As System.Windows.Forms.Label
    Friend WithEvents RedTeam3 As System.Windows.Forms.Label
    Friend WithEvents Redteam2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BlueScore As System.Windows.Forms.Label
    Friend WithEvents BlueTeam3 As System.Windows.Forms.Label
    Friend WithEvents BlueTeam2 As System.Windows.Forms.Label
    Friend WithEvents BlueTeam1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
