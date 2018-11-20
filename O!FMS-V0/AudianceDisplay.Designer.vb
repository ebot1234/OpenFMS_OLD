<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AudianceDisplay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AudianceDisplay))
        Me.MatchNumb = New System.Windows.Forms.Label()
        Me.RedTeam1 = New System.Windows.Forms.Label()
        Me.RedTeam2lbl = New System.Windows.Forms.Label()
        Me.RedTeam3 = New System.Windows.Forms.Label()
        Me.Timerlbl = New System.Windows.Forms.Label()
        Me.BlueTeam1lbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BlueTeam3 = New System.Windows.Forms.Label()
        Me.BlueTeam2 = New System.Windows.Forms.Label()
        Me.FirstLogo = New System.Windows.Forms.PictureBox()
        Me.RedScoreLbl = New System.Windows.Forms.Label()
        Me.BlueScoreLbl = New System.Windows.Forms.Label()
        Me.RedScorePanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pre_StartPanel = New System.Windows.Forms.Panel()
        Me.Red1Lbl = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.FirstLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RedScorePanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Pre_StartPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MatchNumb
        '
        Me.MatchNumb.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.MatchNumb.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MatchNumb.Location = New System.Drawing.Point(619, 525)
        Me.MatchNumb.Name = "MatchNumb"
        Me.MatchNumb.Size = New System.Drawing.Size(184, 31)
        Me.MatchNumb.TabIndex = 1
        Me.MatchNumb.Text = "MatchNumber"
        Me.MatchNumb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RedTeam1
        '
        Me.RedTeam1.AutoSize = True
        Me.RedTeam1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.RedTeam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam1.Location = New System.Drawing.Point(3, 570)
        Me.RedTeam1.Name = "RedTeam1"
        Me.RedTeam1.Size = New System.Drawing.Size(148, 31)
        Me.RedTeam1.TabIndex = 2
        Me.RedTeam1.Text = "RedTeam1"
        '
        'RedTeam2lbl
        '
        Me.RedTeam2lbl.AutoSize = True
        Me.RedTeam2lbl.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.RedTeam2lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam2lbl.Location = New System.Drawing.Point(3, 600)
        Me.RedTeam2lbl.Name = "RedTeam2lbl"
        Me.RedTeam2lbl.Size = New System.Drawing.Size(148, 31)
        Me.RedTeam2lbl.TabIndex = 3
        Me.RedTeam2lbl.Text = "RedTeam2"
        '
        'RedTeam3
        '
        Me.RedTeam3.AutoSize = True
        Me.RedTeam3.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.RedTeam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam3.Location = New System.Drawing.Point(3, 631)
        Me.RedTeam3.Name = "RedTeam3"
        Me.RedTeam3.Size = New System.Drawing.Size(148, 31)
        Me.RedTeam3.TabIndex = 4
        Me.RedTeam3.Text = "RedTeam3"
        '
        'Timerlbl
        '
        Me.Timerlbl.AutoSize = True
        Me.Timerlbl.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Timerlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timerlbl.Location = New System.Drawing.Point(658, 589)
        Me.Timerlbl.Name = "Timerlbl"
        Me.Timerlbl.Size = New System.Drawing.Size(68, 73)
        Me.Timerlbl.TabIndex = 5
        Me.Timerlbl.Text = "0"
        Me.Timerlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BlueTeam1lbl
        '
        Me.BlueTeam1lbl.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.BlueTeam1lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam1lbl.Location = New System.Drawing.Point(1216, 570)
        Me.BlueTeam1lbl.Name = "BlueTeam1lbl"
        Me.BlueTeam1lbl.Size = New System.Drawing.Size(152, 31)
        Me.BlueTeam1lbl.TabIndex = 6
        Me.BlueTeam1lbl.Text = "BlueTeam1"
        Me.BlueTeam1lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lime
        Me.Panel1.Controls.Add(Me.Pre_StartPanel)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 515)
        Me.Panel1.TabIndex = 7
        '
        'BlueTeam3
        '
        Me.BlueTeam3.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.BlueTeam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam3.Location = New System.Drawing.Point(1217, 632)
        Me.BlueTeam3.Name = "BlueTeam3"
        Me.BlueTeam3.Size = New System.Drawing.Size(152, 31)
        Me.BlueTeam3.TabIndex = 8
        Me.BlueTeam3.Text = "BlueTeam3"
        Me.BlueTeam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BlueTeam2
        '
        Me.BlueTeam2.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.BlueTeam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam2.Location = New System.Drawing.Point(1217, 601)
        Me.BlueTeam2.Name = "BlueTeam2"
        Me.BlueTeam2.Size = New System.Drawing.Size(152, 31)
        Me.BlueTeam2.TabIndex = 9
        Me.BlueTeam2.Text = "BlueTeam2"
        Me.BlueTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FirstLogo
        '
        Me.FirstLogo.BackColor = System.Drawing.Color.Transparent
        Me.FirstLogo.BackgroundImage = Global.O_FMS_V0.My.Resources.Resources.FIRST_Horz_RGB
        Me.FirstLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FirstLogo.InitialImage = CType(resources.GetObject("FirstLogo.InitialImage"), System.Drawing.Image)
        Me.FirstLogo.Location = New System.Drawing.Point(1156, 518)
        Me.FirstLogo.Name = "FirstLogo"
        Me.FirstLogo.Size = New System.Drawing.Size(218, 44)
        Me.FirstLogo.TabIndex = 10
        Me.FirstLogo.TabStop = False
        '
        'RedScoreLbl
        '
        Me.RedScoreLbl.AutoSize = True
        Me.RedScoreLbl.BackColor = System.Drawing.Color.Red
        Me.RedScoreLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedScoreLbl.Location = New System.Drawing.Point(51, 35)
        Me.RedScoreLbl.Name = "RedScoreLbl"
        Me.RedScoreLbl.Size = New System.Drawing.Size(68, 73)
        Me.RedScoreLbl.TabIndex = 11
        Me.RedScoreLbl.Text = "0"
        '
        'BlueScoreLbl
        '
        Me.BlueScoreLbl.AutoSize = True
        Me.BlueScoreLbl.BackColor = System.Drawing.Color.Blue
        Me.BlueScoreLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueScoreLbl.Location = New System.Drawing.Point(51, 34)
        Me.BlueScoreLbl.Name = "BlueScoreLbl"
        Me.BlueScoreLbl.Size = New System.Drawing.Size(68, 73)
        Me.BlueScoreLbl.TabIndex = 12
        Me.BlueScoreLbl.Text = "0"
        '
        'RedScorePanel
        '
        Me.RedScorePanel.BackColor = System.Drawing.Color.Red
        Me.RedScorePanel.Controls.Add(Me.RedScoreLbl)
        Me.RedScorePanel.Location = New System.Drawing.Point(448, 564)
        Me.RedScorePanel.Name = "RedScorePanel"
        Me.RedScorePanel.Size = New System.Drawing.Size(160, 139)
        Me.RedScorePanel.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Blue
        Me.Panel2.Controls.Add(Me.BlueScoreLbl)
        Me.Panel2.Location = New System.Drawing.Point(815, 564)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(160, 139)
        Me.Panel2.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(994, 525)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Match Type"
        '
        'Pre_StartPanel
        '
        Me.Pre_StartPanel.BackColor = System.Drawing.Color.White
        Me.Pre_StartPanel.Controls.Add(Me.Red1Lbl)
        Me.Pre_StartPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pre_StartPanel.Location = New System.Drawing.Point(0, 0)
        Me.Pre_StartPanel.Name = "Pre_StartPanel"
        Me.Pre_StartPanel.Size = New System.Drawing.Size(1369, 515)
        Me.Pre_StartPanel.TabIndex = 0
        '
        'Red1Lbl
        '
        Me.Red1Lbl.AutoSize = True
        Me.Red1Lbl.Location = New System.Drawing.Point(50, 107)
        Me.Red1Lbl.Name = "Red1Lbl"
        Me.Red1Lbl.Size = New System.Drawing.Size(95, 38)
        Me.Red1Lbl.TabIndex = 0
        Me.Red1Lbl.Text = "Red1"
        '
        'AudianceDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.O_FMS_V0.My.Resources.Resources.ScoreBoard
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1370, 705)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RedScorePanel)
        Me.Controls.Add(Me.FirstLogo)
        Me.Controls.Add(Me.BlueTeam3)
        Me.Controls.Add(Me.BlueTeam2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BlueTeam1lbl)
        Me.Controls.Add(Me.Timerlbl)
        Me.Controls.Add(Me.RedTeam3)
        Me.Controls.Add(Me.RedTeam2lbl)
        Me.Controls.Add(Me.RedTeam1)
        Me.Controls.Add(Me.MatchNumb)
        Me.Name = "AudianceDisplay"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "AudianceDisplay"
        Me.Panel1.ResumeLayout(False)
        CType(Me.FirstLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RedScorePanel.ResumeLayout(False)
        Me.RedScorePanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Pre_StartPanel.ResumeLayout(False)
        Me.Pre_StartPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MatchNumb As Label
    Friend WithEvents RedTeam1 As Label
    Friend WithEvents RedTeam2lbl As Label
    Friend WithEvents RedTeam3 As Label
    Friend WithEvents Timerlbl As Label
    Friend WithEvents BlueTeam1lbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BlueTeam3 As Label
    Friend WithEvents BlueTeam2 As Label
    Friend WithEvents FirstLogo As PictureBox
    Friend WithEvents RedScoreLbl As Label
    Friend WithEvents BlueScoreLbl As Label
    Friend WithEvents RedScorePanel As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Pre_StartPanel As Panel
    Friend WithEvents Red1Lbl As Label
End Class
