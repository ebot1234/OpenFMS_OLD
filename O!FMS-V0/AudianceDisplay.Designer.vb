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
        Me.PreStartPanel = New System.Windows.Forms.Panel()
        Me.BlueTeamsLbl = New System.Windows.Forms.Label()
        Me.RedTeamsLbl = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Red2Lbl = New System.Windows.Forms.Label()
        Me.Red3Lbl = New System.Windows.Forms.Label()
        Me.Blue2Lbl = New System.Windows.Forms.Label()
        Me.Blue3Lbl = New System.Windows.Forms.Label()
        Me.Blue1Lbl = New System.Windows.Forms.Label()
        Me.RedTeam1lbl = New System.Windows.Forms.Label()
        Me.BlueTeam3 = New System.Windows.Forms.Label()
        Me.BlueTeam2 = New System.Windows.Forms.Label()
        Me.FirstLogo = New System.Windows.Forms.PictureBox()
        Me.RedScoreLbl = New System.Windows.Forms.Label()
        Me.BlueScoreLbl = New System.Windows.Forms.Label()
        Me.RedScorePanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrestartCover = New System.Windows.Forms.Panel()
        Me.FinalScoreBox = New System.Windows.Forms.PictureBox()
        Me.Winner = New System.Windows.Forms.Label()
        Me.WinningAlliance = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.PreStartPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RedScorePanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PrestartCover.SuspendLayout()
        CType(Me.FinalScoreBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.PreStartPanel)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1364, 515)
        Me.Panel1.TabIndex = 7
        '
        'PreStartPanel
        '
        Me.PreStartPanel.BackColor = System.Drawing.Color.White
        Me.PreStartPanel.BackgroundImage = Global.O_FMS_V0.My.Resources.Resources.Pre_Match_Image
        Me.PreStartPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PreStartPanel.Controls.Add(Me.BlueTeamsLbl)
        Me.PreStartPanel.Controls.Add(Me.RedTeamsLbl)
        Me.PreStartPanel.Controls.Add(Me.PictureBox1)
        Me.PreStartPanel.Controls.Add(Me.Red2Lbl)
        Me.PreStartPanel.Controls.Add(Me.Red3Lbl)
        Me.PreStartPanel.Controls.Add(Me.Blue2Lbl)
        Me.PreStartPanel.Controls.Add(Me.Blue3Lbl)
        Me.PreStartPanel.Controls.Add(Me.Blue1Lbl)
        Me.PreStartPanel.Controls.Add(Me.RedTeam1lbl)
        Me.PreStartPanel.Location = New System.Drawing.Point(0, 0)
        Me.PreStartPanel.Name = "PreStartPanel"
        Me.PreStartPanel.Size = New System.Drawing.Size(1369, 515)
        Me.PreStartPanel.TabIndex = 0
        '
        'BlueTeamsLbl
        '
        Me.BlueTeamsLbl.AutoSize = True
        Me.BlueTeamsLbl.BackColor = System.Drawing.Color.Transparent
        Me.BlueTeamsLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeamsLbl.Location = New System.Drawing.Point(412, 106)
        Me.BlueTeamsLbl.Name = "BlueTeamsLbl"
        Me.BlueTeamsLbl.Size = New System.Drawing.Size(166, 31)
        Me.BlueTeamsLbl.TabIndex = 8
        Me.BlueTeamsLbl.Text = "Blue Teams:"
        '
        'RedTeamsLbl
        '
        Me.RedTeamsLbl.AutoSize = True
        Me.RedTeamsLbl.BackColor = System.Drawing.Color.Transparent
        Me.RedTeamsLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeamsLbl.Location = New System.Drawing.Point(66, 106)
        Me.RedTeamsLbl.Name = "RedTeamsLbl"
        Me.RedTeamsLbl.Size = New System.Drawing.Size(162, 31)
        Me.RedTeamsLbl.TabIndex = 7
        Me.RedTeamsLbl.Text = "Red Teams:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.O_FMS_V0.My.Resources.Resources.FirstPowerUpLogo
        Me.PictureBox1.Location = New System.Drawing.Point(829, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(477, 361)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Red2Lbl
        '
        Me.Red2Lbl.AutoSize = True
        Me.Red2Lbl.BackColor = System.Drawing.Color.Transparent
        Me.Red2Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Red2Lbl.Location = New System.Drawing.Point(96, 233)
        Me.Red2Lbl.Name = "Red2Lbl"
        Me.Red2Lbl.Size = New System.Drawing.Size(86, 31)
        Me.Red2Lbl.TabIndex = 5
        Me.Red2Lbl.Text = "Red 2"
        '
        'Red3Lbl
        '
        Me.Red3Lbl.AutoSize = True
        Me.Red3Lbl.BackColor = System.Drawing.Color.Transparent
        Me.Red3Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Red3Lbl.Location = New System.Drawing.Point(96, 316)
        Me.Red3Lbl.Name = "Red3Lbl"
        Me.Red3Lbl.Size = New System.Drawing.Size(86, 31)
        Me.Red3Lbl.TabIndex = 4
        Me.Red3Lbl.Text = "Red 3"
        '
        'Blue2Lbl
        '
        Me.Blue2Lbl.AutoSize = True
        Me.Blue2Lbl.BackColor = System.Drawing.Color.Transparent
        Me.Blue2Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Blue2Lbl.Location = New System.Drawing.Point(442, 233)
        Me.Blue2Lbl.Name = "Blue2Lbl"
        Me.Blue2Lbl.Size = New System.Drawing.Size(90, 31)
        Me.Blue2Lbl.TabIndex = 3
        Me.Blue2Lbl.Text = "Blue 2"
        '
        'Blue3Lbl
        '
        Me.Blue3Lbl.AutoSize = True
        Me.Blue3Lbl.BackColor = System.Drawing.Color.Transparent
        Me.Blue3Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Blue3Lbl.Location = New System.Drawing.Point(442, 316)
        Me.Blue3Lbl.Name = "Blue3Lbl"
        Me.Blue3Lbl.Size = New System.Drawing.Size(90, 31)
        Me.Blue3Lbl.TabIndex = 2
        Me.Blue3Lbl.Text = "Blue 3"
        '
        'Blue1Lbl
        '
        Me.Blue1Lbl.AutoSize = True
        Me.Blue1Lbl.BackColor = System.Drawing.Color.Transparent
        Me.Blue1Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Blue1Lbl.Location = New System.Drawing.Point(442, 155)
        Me.Blue1Lbl.Name = "Blue1Lbl"
        Me.Blue1Lbl.Size = New System.Drawing.Size(90, 31)
        Me.Blue1Lbl.TabIndex = 1
        Me.Blue1Lbl.Text = "Blue 1"
        '
        'RedTeam1lbl
        '
        Me.RedTeam1lbl.AutoSize = True
        Me.RedTeam1lbl.BackColor = System.Drawing.Color.Transparent
        Me.RedTeam1lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam1lbl.Location = New System.Drawing.Point(96, 155)
        Me.RedTeam1lbl.Name = "RedTeam1lbl"
        Me.RedTeam1lbl.Size = New System.Drawing.Size(86, 31)
        Me.RedTeam1lbl.TabIndex = 0
        Me.RedTeam1lbl.Text = "Red 1"
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
        'PrestartCover
        '
        Me.PrestartCover.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.PrestartCover.Controls.Add(Me.WinningAlliance)
        Me.PrestartCover.Controls.Add(Me.Winner)
        Me.PrestartCover.Controls.Add(Me.FinalScoreBox)
        Me.PrestartCover.Location = New System.Drawing.Point(0, 518)
        Me.PrestartCover.Name = "PrestartCover"
        Me.PrestartCover.Size = New System.Drawing.Size(1368, 185)
        Me.PrestartCover.TabIndex = 14
        '
        'FinalScoreBox
        '
        Me.FinalScoreBox.BackgroundImage = Global.O_FMS_V0.My.Resources.Resources.FinalScore
        Me.FinalScoreBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FinalScoreBox.Location = New System.Drawing.Point(0, 3)
        Me.FinalScoreBox.Name = "FinalScoreBox"
        Me.FinalScoreBox.Size = New System.Drawing.Size(1368, 182)
        Me.FinalScoreBox.TabIndex = 0
        Me.FinalScoreBox.TabStop = False
        '
        'Winner
        '
        Me.Winner.AutoSize = True
        Me.Winner.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Winner.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Winner.Location = New System.Drawing.Point(547, 73)
        Me.Winner.Name = "Winner"
        Me.Winner.Size = New System.Drawing.Size(146, 42)
        Me.Winner.TabIndex = 1
        Me.Winner.Text = "Winner:"
        '
        'WinningAlliance
        '
        Me.WinningAlliance.AutoSize = True
        Me.WinningAlliance.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WinningAlliance.Location = New System.Drawing.Point(699, 77)
        Me.WinningAlliance.Name = "WinningAlliance"
        Me.WinningAlliance.Size = New System.Drawing.Size(139, 39)
        Me.WinningAlliance.TabIndex = 2
        Me.WinningAlliance.Text = "Alliance"
        '
        'AudianceDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.O_FMS_V0.My.Resources.Resources.ScoreBoard
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1370, 705)
        Me.Controls.Add(Me.PrestartCover)
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
        Me.PreStartPanel.ResumeLayout(False)
        Me.PreStartPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RedScorePanel.ResumeLayout(False)
        Me.RedScorePanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PrestartCover.ResumeLayout(False)
        Me.PrestartCover.PerformLayout()
        CType(Me.FinalScoreBox, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PreStartPanel As Panel
    Friend WithEvents Red2Lbl As Label
    Friend WithEvents Red3Lbl As Label
    Friend WithEvents Blue2Lbl As Label
    Friend WithEvents Blue3Lbl As Label
    Friend WithEvents Blue1Lbl As Label
    Friend WithEvents RedTeam1lbl As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BlueTeamsLbl As Label
    Friend WithEvents RedTeamsLbl As Label
    Friend WithEvents PrestartCover As Panel
    Friend WithEvents FinalScoreBox As PictureBox
    Friend WithEvents WinningAlliance As Label
    Friend WithEvents Winner As Label
End Class
