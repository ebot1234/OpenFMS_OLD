<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main_Panel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Panel))
        Me.MatchNum = New System.Windows.Forms.TextBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Red3Sur = New System.Windows.Forms.Label()
        Me.Red2Sur = New System.Windows.Forms.Label()
        Me.Red1Sur = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RBypass3 = New System.Windows.Forms.CheckBox()
        Me.RDQ3 = New System.Windows.Forms.CheckBox()
        Me.RBypass2 = New System.Windows.Forms.CheckBox()
        Me.RDQ2 = New System.Windows.Forms.CheckBox()
        Me.RedVolt3 = New System.Windows.Forms.Label()
        Me.RedVolt2 = New System.Windows.Forms.Label()
        Me.RedVolt1 = New System.Windows.Forms.Label()
        Me.RBypass1 = New System.Windows.Forms.CheckBox()
        Me.RDQ1 = New System.Windows.Forms.CheckBox()
        Me.RedTeam3 = New System.Windows.Forms.Label()
        Me.RedTeam2 = New System.Windows.Forms.Label()
        Me.RedTeam1 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.R3Estop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R3Robot = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R3DS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R2Estop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R2Robot = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R2DS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R1Estop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R1Robot = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.R1DS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.FMSMasterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me._O_FMSDataSet = New O_FMS_V0._O_FMSDataSet()
        Me.MatchLoad_Btn = New System.Windows.Forms.Button()
        Me.StartMatch_btn = New System.Windows.Forms.Button()
        Me.AbortMatch_btn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Blue3Sur = New System.Windows.Forms.Label()
        Me.Blue2Sur = New System.Windows.Forms.Label()
        Me.Blue1Sur = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BBypass3 = New System.Windows.Forms.CheckBox()
        Me.BDQ3 = New System.Windows.Forms.CheckBox()
        Me.BBypass2 = New System.Windows.Forms.CheckBox()
        Me.BDQ2 = New System.Windows.Forms.CheckBox()
        Me.BlueVolt3 = New System.Windows.Forms.Label()
        Me.BlueVolt2 = New System.Windows.Forms.Label()
        Me.BlueVolt1 = New System.Windows.Forms.Label()
        Me.BBypass1 = New System.Windows.Forms.CheckBox()
        Me.BDQ1 = New System.Windows.Forms.CheckBox()
        Me.BlueTeam3 = New System.Windows.Forms.Label()
        Me.BlueTeam2 = New System.Windows.Forms.Label()
        Me.BlueTeam1 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.B3Estop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B3Robot = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B3DS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B2Estop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B2Robot = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B2DS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B1Estop = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B1Robot = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.B1DS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.FMSMasterTableAdapter = New O_FMS_V0._O_FMSDataSetTableAdapters.FMSMasterTableAdapter()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Ctime = New System.Windows.Forms.Label()
        Me.Pre_Start_btn = New System.Windows.Forms.Button()
        Me.matchTimerLbl = New System.Windows.Forms.Label()
        Me.MatchMessages = New System.Windows.Forms.Label()
        Me.SandStormMessage = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.WarmUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AutoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PauseTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TeleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.EndGameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MatchPlay = New System.Windows.Forms.Button()
        Me.FinalScoreBtn = New System.Windows.Forms.Button()
        Me.PreMatchBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LedPatternTestBtn = New System.Windows.Forms.Button()
        Me.DSLightTestBtn = New System.Windows.Forms.Button()
        Me.ScoringTableLightTestBtn = New System.Windows.Forms.Button()
        Me.ConnectPLCBtn = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        CType(Me.FMSMasterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._O_FMSDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MatchNum
        '
        Me.MatchNum.Location = New System.Drawing.Point(124, 12)
        Me.MatchNum.Name = "MatchNum"
        Me.MatchNum.Size = New System.Drawing.Size(44, 20)
        Me.MatchNum.TabIndex = 9
        '
        'Save_btn
        '
        Me.Save_btn.Location = New System.Drawing.Point(473, 532)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(149, 23)
        Me.Save_btn.TabIndex = 10
        Me.Save_btn.Text = "Save && Next Match"
        Me.Save_btn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumTurquoise
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Red3Sur)
        Me.Panel1.Controls.Add(Me.Red2Sur)
        Me.Panel1.Controls.Add(Me.Red1Sur)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.RBypass3)
        Me.Panel1.Controls.Add(Me.RDQ3)
        Me.Panel1.Controls.Add(Me.RBypass2)
        Me.Panel1.Controls.Add(Me.RDQ2)
        Me.Panel1.Controls.Add(Me.RedVolt3)
        Me.Panel1.Controls.Add(Me.RedVolt2)
        Me.Panel1.Controls.Add(Me.RedVolt1)
        Me.Panel1.Controls.Add(Me.RBypass1)
        Me.Panel1.Controls.Add(Me.RDQ1)
        Me.Panel1.Controls.Add(Me.RedTeam3)
        Me.Panel1.Controls.Add(Me.RedTeam2)
        Me.Panel1.Controls.Add(Me.RedTeam1)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(24, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(336, 356)
        Me.Panel1.TabIndex = 11
        '
        'Red3Sur
        '
        Me.Red3Sur.AutoSize = True
        Me.Red3Sur.Location = New System.Drawing.Point(288, 72)
        Me.Red3Sur.Name = "Red3Sur"
        Me.Red3Sur.Size = New System.Drawing.Size(14, 13)
        Me.Red3Sur.TabIndex = 29
        Me.Red3Sur.Text = "S"
        '
        'Red2Sur
        '
        Me.Red2Sur.AutoSize = True
        Me.Red2Sur.Location = New System.Drawing.Point(288, 45)
        Me.Red2Sur.Name = "Red2Sur"
        Me.Red2Sur.Size = New System.Drawing.Size(14, 13)
        Me.Red2Sur.TabIndex = 28
        Me.Red2Sur.Text = "S"
        '
        'Red1Sur
        '
        Me.Red1Sur.AutoSize = True
        Me.Red1Sur.Location = New System.Drawing.Point(288, 20)
        Me.Red1Sur.Name = "Red1Sur"
        Me.Red1Sur.Size = New System.Drawing.Size(14, 13)
        Me.Red1Sur.TabIndex = 27
        Me.Red1Sur.Text = "S"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.ForeColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(255, -1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Bypass"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.ForeColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(226, -1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "DQ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(203, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "E"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(165, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Robot"
        '
        'RBypass3
        '
        Me.RBypass3.AutoSize = True
        Me.RBypass3.Location = New System.Drawing.Point(267, 71)
        Me.RBypass3.Name = "RBypass3"
        Me.RBypass3.Size = New System.Drawing.Size(15, 14)
        Me.RBypass3.TabIndex = 15
        Me.RBypass3.UseVisualStyleBackColor = True
        '
        'RDQ3
        '
        Me.RDQ3.AutoSize = True
        Me.RDQ3.Location = New System.Drawing.Point(234, 71)
        Me.RDQ3.Name = "RDQ3"
        Me.RDQ3.Size = New System.Drawing.Size(15, 14)
        Me.RDQ3.TabIndex = 14
        Me.RDQ3.UseVisualStyleBackColor = True
        '
        'RBypass2
        '
        Me.RBypass2.AutoSize = True
        Me.RBypass2.Location = New System.Drawing.Point(267, 45)
        Me.RBypass2.Name = "RBypass2"
        Me.RBypass2.Size = New System.Drawing.Size(15, 14)
        Me.RBypass2.TabIndex = 13
        Me.RBypass2.UseVisualStyleBackColor = True
        '
        'RDQ2
        '
        Me.RDQ2.AutoSize = True
        Me.RDQ2.Location = New System.Drawing.Point(234, 45)
        Me.RDQ2.Name = "RDQ2"
        Me.RDQ2.Size = New System.Drawing.Size(15, 14)
        Me.RDQ2.TabIndex = 12
        Me.RDQ2.UseVisualStyleBackColor = True
        '
        'RedVolt3
        '
        Me.RedVolt3.AutoSize = True
        Me.RedVolt3.Location = New System.Drawing.Point(77, 71)
        Me.RedVolt3.Name = "RedVolt3"
        Me.RedVolt3.Size = New System.Drawing.Size(43, 13)
        Me.RedVolt3.TabIndex = 11
        Me.RedVolt3.Text = "Voltage"
        '
        'RedVolt2
        '
        Me.RedVolt2.AutoSize = True
        Me.RedVolt2.Location = New System.Drawing.Point(77, 46)
        Me.RedVolt2.Name = "RedVolt2"
        Me.RedVolt2.Size = New System.Drawing.Size(43, 13)
        Me.RedVolt2.TabIndex = 10
        Me.RedVolt2.Text = "Voltage"
        '
        'RedVolt1
        '
        Me.RedVolt1.AutoSize = True
        Me.RedVolt1.Location = New System.Drawing.Point(77, 18)
        Me.RedVolt1.Name = "RedVolt1"
        Me.RedVolt1.Size = New System.Drawing.Size(43, 13)
        Me.RedVolt1.TabIndex = 9
        Me.RedVolt1.Text = "Voltage"
        '
        'RBypass1
        '
        Me.RBypass1.AutoSize = True
        Me.RBypass1.Location = New System.Drawing.Point(267, 19)
        Me.RBypass1.Name = "RBypass1"
        Me.RBypass1.Size = New System.Drawing.Size(15, 14)
        Me.RBypass1.TabIndex = 6
        Me.RBypass1.UseVisualStyleBackColor = True
        '
        'RDQ1
        '
        Me.RDQ1.AutoSize = True
        Me.RDQ1.Location = New System.Drawing.Point(234, 19)
        Me.RDQ1.Name = "RDQ1"
        Me.RDQ1.Size = New System.Drawing.Size(15, 14)
        Me.RDQ1.TabIndex = 4
        Me.RDQ1.UseVisualStyleBackColor = True
        '
        'RedTeam3
        '
        Me.RedTeam3.AutoSize = True
        Me.RedTeam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.RedTeam3.Location = New System.Drawing.Point(4, 71)
        Me.RedTeam3.Name = "RedTeam3"
        Me.RedTeam3.Size = New System.Drawing.Size(77, 15)
        Me.RedTeam3.TabIndex = 2
        Me.RedTeam3.Text = "RedTeam3"
        '
        'RedTeam2
        '
        Me.RedTeam2.AutoSize = True
        Me.RedTeam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.RedTeam2.Location = New System.Drawing.Point(3, 45)
        Me.RedTeam2.Name = "RedTeam2"
        Me.RedTeam2.Size = New System.Drawing.Size(77, 15)
        Me.RedTeam2.TabIndex = 1
        Me.RedTeam2.Text = "RedTeam2"
        '
        'RedTeam1
        '
        Me.RedTeam1.AutoSize = True
        Me.RedTeam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RedTeam1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.RedTeam1.Location = New System.Drawing.Point(4, 18)
        Me.RedTeam1.Name = "RedTeam1"
        Me.RedTeam1.Size = New System.Drawing.Size(77, 15)
        Me.RedTeam1.TabIndex = 0
        Me.RedTeam1.Text = "RedTeam1"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.R3Estop, Me.R3Robot, Me.R3DS, Me.R2Estop, Me.R2Robot, Me.R2DS, Me.R1Estop, Me.R1Robot, Me.R1DS})
        Me.ShapeContainer1.Size = New System.Drawing.Size(336, 356)
        Me.ShapeContainer1.TabIndex = 5
        Me.ShapeContainer1.TabStop = False
        '
        'R3Estop
        '
        Me.R3Estop.BackColor = System.Drawing.Color.Yellow
        Me.R3Estop.BorderWidth = 2
        Me.R3Estop.CornerRadius = 1
        Me.R3Estop.FillColor = System.Drawing.Color.LimeGreen
        Me.R3Estop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R3Estop.Location = New System.Drawing.Point(200, 66)
        Me.R3Estop.Name = "R3Estop"
        Me.R3Estop.Size = New System.Drawing.Size(18, 17)
        '
        'R3Robot
        '
        Me.R3Robot.BackColor = System.Drawing.Color.Yellow
        Me.R3Robot.BorderWidth = 2
        Me.R3Robot.CornerRadius = 1
        Me.R3Robot.FillColor = System.Drawing.Color.LimeGreen
        Me.R3Robot.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R3Robot.Location = New System.Drawing.Point(170, 66)
        Me.R3Robot.Name = "R3Robot"
        Me.R3Robot.Size = New System.Drawing.Size(18, 17)
        '
        'R3DS
        '
        Me.R3DS.BackColor = System.Drawing.Color.Yellow
        Me.R3DS.BorderWidth = 2
        Me.R3DS.CornerRadius = 1
        Me.R3DS.FillColor = System.Drawing.Color.LimeGreen
        Me.R3DS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R3DS.Location = New System.Drawing.Point(140, 66)
        Me.R3DS.Name = "R3DS"
        Me.R3DS.Size = New System.Drawing.Size(18, 17)
        '
        'R2Estop
        '
        Me.R2Estop.BackColor = System.Drawing.Color.Yellow
        Me.R2Estop.BorderWidth = 2
        Me.R2Estop.CornerRadius = 1
        Me.R2Estop.FillColor = System.Drawing.Color.LimeGreen
        Me.R2Estop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R2Estop.Location = New System.Drawing.Point(200, 40)
        Me.R2Estop.Name = "R2Estop"
        Me.R2Estop.Size = New System.Drawing.Size(18, 17)
        '
        'R2Robot
        '
        Me.R2Robot.BackColor = System.Drawing.Color.Yellow
        Me.R2Robot.BorderWidth = 2
        Me.R2Robot.CornerRadius = 1
        Me.R2Robot.FillColor = System.Drawing.Color.LimeGreen
        Me.R2Robot.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R2Robot.Location = New System.Drawing.Point(170, 40)
        Me.R2Robot.Name = "R2Robot"
        Me.R2Robot.Size = New System.Drawing.Size(18, 17)
        '
        'R2DS
        '
        Me.R2DS.BackColor = System.Drawing.Color.Yellow
        Me.R2DS.BorderWidth = 2
        Me.R2DS.CornerRadius = 1
        Me.R2DS.FillColor = System.Drawing.Color.LimeGreen
        Me.R2DS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R2DS.Location = New System.Drawing.Point(140, 40)
        Me.R2DS.Name = "R2DS"
        Me.R2DS.Size = New System.Drawing.Size(18, 17)
        '
        'R1Estop
        '
        Me.R1Estop.BackColor = System.Drawing.Color.Yellow
        Me.R1Estop.BorderWidth = 2
        Me.R1Estop.CornerRadius = 1
        Me.R1Estop.FillColor = System.Drawing.Color.LimeGreen
        Me.R1Estop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R1Estop.Location = New System.Drawing.Point(200, 14)
        Me.R1Estop.Name = "R1Estop"
        Me.R1Estop.Size = New System.Drawing.Size(18, 17)
        '
        'R1Robot
        '
        Me.R1Robot.BackColor = System.Drawing.Color.Yellow
        Me.R1Robot.BorderWidth = 2
        Me.R1Robot.CornerRadius = 1
        Me.R1Robot.FillColor = System.Drawing.Color.LimeGreen
        Me.R1Robot.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R1Robot.Location = New System.Drawing.Point(170, 14)
        Me.R1Robot.Name = "R1Robot"
        Me.R1Robot.Size = New System.Drawing.Size(18, 17)
        '
        'R1DS
        '
        Me.R1DS.BackColor = System.Drawing.Color.Yellow
        Me.R1DS.BorderWidth = 2
        Me.R1DS.CornerRadius = 1
        Me.R1DS.FillColor = System.Drawing.Color.LimeGreen
        Me.R1DS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.R1DS.Location = New System.Drawing.Point(140, 14)
        Me.R1DS.Name = "R1DS"
        Me.R1DS.Size = New System.Drawing.Size(18, 17)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(63, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "MATCH #"
        '
        'FMSMasterBindingSource
        '
        Me.FMSMasterBindingSource.DataMember = "FMSMaster"
        Me.FMSMasterBindingSource.DataSource = Me.BindingSource1
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = Me._O_FMSDataSet
        Me.BindingSource1.Position = 0
        '
        '_O_FMSDataSet
        '
        Me._O_FMSDataSet.DataSetName = "_O_FMSDataSet"
        Me._O_FMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MatchLoad_Btn
        '
        Me.MatchLoad_Btn.Location = New System.Drawing.Point(174, 9)
        Me.MatchLoad_Btn.Name = "MatchLoad_Btn"
        Me.MatchLoad_Btn.Size = New System.Drawing.Size(75, 23)
        Me.MatchLoad_Btn.TabIndex = 16
        Me.MatchLoad_Btn.Text = "Load Match"
        Me.MatchLoad_Btn.UseVisualStyleBackColor = True
        '
        'StartMatch_btn
        '
        Me.StartMatch_btn.Location = New System.Drawing.Point(423, 143)
        Me.StartMatch_btn.Name = "StartMatch_btn"
        Me.StartMatch_btn.Size = New System.Drawing.Size(75, 23)
        Me.StartMatch_btn.TabIndex = 17
        Me.StartMatch_btn.Text = "Start Match"
        Me.StartMatch_btn.UseVisualStyleBackColor = True
        '
        'AbortMatch_btn
        '
        Me.AbortMatch_btn.Location = New System.Drawing.Point(423, 172)
        Me.AbortMatch_btn.Name = "AbortMatch_btn"
        Me.AbortMatch_btn.Size = New System.Drawing.Size(75, 23)
        Me.AbortMatch_btn.TabIndex = 18
        Me.AbortMatch_btn.Text = "Abort Match"
        Me.AbortMatch_btn.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MediumTurquoise
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.Blue3Sur)
        Me.Panel2.Controls.Add(Me.Blue2Sur)
        Me.Panel2.Controls.Add(Me.Blue1Sur)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.BBypass3)
        Me.Panel2.Controls.Add(Me.BDQ3)
        Me.Panel2.Controls.Add(Me.BBypass2)
        Me.Panel2.Controls.Add(Me.BDQ2)
        Me.Panel2.Controls.Add(Me.BlueVolt3)
        Me.Panel2.Controls.Add(Me.BlueVolt2)
        Me.Panel2.Controls.Add(Me.BlueVolt1)
        Me.Panel2.Controls.Add(Me.BBypass1)
        Me.Panel2.Controls.Add(Me.BDQ1)
        Me.Panel2.Controls.Add(Me.BlueTeam3)
        Me.Panel2.Controls.Add(Me.BlueTeam2)
        Me.Panel2.Controls.Add(Me.BlueTeam1)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Location = New System.Drawing.Point(550, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(346, 356)
        Me.Panel2.TabIndex = 20
        '
        'Blue3Sur
        '
        Me.Blue3Sur.AutoSize = True
        Me.Blue3Sur.Location = New System.Drawing.Point(290, 71)
        Me.Blue3Sur.Name = "Blue3Sur"
        Me.Blue3Sur.Size = New System.Drawing.Size(14, 13)
        Me.Blue3Sur.TabIndex = 32
        Me.Blue3Sur.Text = "S"
        '
        'Blue2Sur
        '
        Me.Blue2Sur.AutoSize = True
        Me.Blue2Sur.Location = New System.Drawing.Point(290, 45)
        Me.Blue2Sur.Name = "Blue2Sur"
        Me.Blue2Sur.Size = New System.Drawing.Size(14, 13)
        Me.Blue2Sur.TabIndex = 31
        Me.Blue2Sur.Text = "S"
        '
        'Blue1Sur
        '
        Me.Blue1Sur.AutoSize = True
        Me.Blue1Sur.Location = New System.Drawing.Point(290, 19)
        Me.Blue1Sur.Name = "Blue1Sur"
        Me.Blue1Sur.Size = New System.Drawing.Size(14, 13)
        Me.Blue1Sur.TabIndex = 30
        Me.Blue1Sur.Text = "S"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label17.ForeColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(263, -1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "Bypass"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label18.ForeColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(234, -1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(23, 13)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "DQ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.Location = New System.Drawing.Point(205, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "E"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(165, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Robot"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Yellow
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(137, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "DS"
        '
        'BBypass3
        '
        Me.BBypass3.AutoSize = True
        Me.BBypass3.Location = New System.Drawing.Point(267, 71)
        Me.BBypass3.Name = "BBypass3"
        Me.BBypass3.Size = New System.Drawing.Size(15, 14)
        Me.BBypass3.TabIndex = 15
        Me.BBypass3.UseVisualStyleBackColor = True
        '
        'BDQ3
        '
        Me.BDQ3.AutoSize = True
        Me.BDQ3.Location = New System.Drawing.Point(234, 71)
        Me.BDQ3.Name = "BDQ3"
        Me.BDQ3.Size = New System.Drawing.Size(15, 14)
        Me.BDQ3.TabIndex = 14
        Me.BDQ3.UseVisualStyleBackColor = True
        '
        'BBypass2
        '
        Me.BBypass2.AutoSize = True
        Me.BBypass2.Location = New System.Drawing.Point(267, 45)
        Me.BBypass2.Name = "BBypass2"
        Me.BBypass2.Size = New System.Drawing.Size(15, 14)
        Me.BBypass2.TabIndex = 13
        Me.BBypass2.UseVisualStyleBackColor = True
        '
        'BDQ2
        '
        Me.BDQ2.AutoSize = True
        Me.BDQ2.Location = New System.Drawing.Point(234, 45)
        Me.BDQ2.Name = "BDQ2"
        Me.BDQ2.Size = New System.Drawing.Size(15, 14)
        Me.BDQ2.TabIndex = 12
        Me.BDQ2.UseVisualStyleBackColor = True
        '
        'BlueVolt3
        '
        Me.BlueVolt3.AutoSize = True
        Me.BlueVolt3.Location = New System.Drawing.Point(77, 72)
        Me.BlueVolt3.Name = "BlueVolt3"
        Me.BlueVolt3.Size = New System.Drawing.Size(43, 13)
        Me.BlueVolt3.TabIndex = 11
        Me.BlueVolt3.Text = "Voltage"
        '
        'BlueVolt2
        '
        Me.BlueVolt2.AutoSize = True
        Me.BlueVolt2.Location = New System.Drawing.Point(77, 45)
        Me.BlueVolt2.Name = "BlueVolt2"
        Me.BlueVolt2.Size = New System.Drawing.Size(43, 13)
        Me.BlueVolt2.TabIndex = 10
        Me.BlueVolt2.Text = "Voltage"
        '
        'BlueVolt1
        '
        Me.BlueVolt1.AutoSize = True
        Me.BlueVolt1.Location = New System.Drawing.Point(77, 18)
        Me.BlueVolt1.Name = "BlueVolt1"
        Me.BlueVolt1.Size = New System.Drawing.Size(43, 13)
        Me.BlueVolt1.TabIndex = 9
        Me.BlueVolt1.Text = "Voltage"
        '
        'BBypass1
        '
        Me.BBypass1.AutoSize = True
        Me.BBypass1.Location = New System.Drawing.Point(267, 19)
        Me.BBypass1.Name = "BBypass1"
        Me.BBypass1.Size = New System.Drawing.Size(15, 14)
        Me.BBypass1.TabIndex = 6
        Me.BBypass1.UseVisualStyleBackColor = True
        '
        'BDQ1
        '
        Me.BDQ1.AutoSize = True
        Me.BDQ1.Location = New System.Drawing.Point(234, 19)
        Me.BDQ1.Name = "BDQ1"
        Me.BDQ1.Size = New System.Drawing.Size(15, 14)
        Me.BDQ1.TabIndex = 4
        Me.BDQ1.UseVisualStyleBackColor = True
        '
        'BlueTeam3
        '
        Me.BlueTeam3.AutoSize = True
        Me.BlueTeam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BlueTeam3.Location = New System.Drawing.Point(4, 71)
        Me.BlueTeam3.Name = "BlueTeam3"
        Me.BlueTeam3.Size = New System.Drawing.Size(80, 15)
        Me.BlueTeam3.TabIndex = 2
        Me.BlueTeam3.Text = "BlueTeam3"
        '
        'BlueTeam2
        '
        Me.BlueTeam2.AutoSize = True
        Me.BlueTeam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BlueTeam2.Location = New System.Drawing.Point(3, 45)
        Me.BlueTeam2.Name = "BlueTeam2"
        Me.BlueTeam2.Size = New System.Drawing.Size(80, 15)
        Me.BlueTeam2.TabIndex = 1
        Me.BlueTeam2.Text = "BlueTeam2"
        '
        'BlueTeam1
        '
        Me.BlueTeam1.AutoSize = True
        Me.BlueTeam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlueTeam1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BlueTeam1.Location = New System.Drawing.Point(4, 18)
        Me.BlueTeam1.Name = "BlueTeam1"
        Me.BlueTeam1.Size = New System.Drawing.Size(80, 15)
        Me.BlueTeam1.TabIndex = 0
        Me.BlueTeam1.Text = "BlueTeam1"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.B3Estop, Me.B3Robot, Me.B3DS, Me.B2Estop, Me.B2Robot, Me.B2DS, Me.B1Estop, Me.B1Robot, Me.B1DS})
        Me.ShapeContainer2.Size = New System.Drawing.Size(346, 356)
        Me.ShapeContainer2.TabIndex = 5
        Me.ShapeContainer2.TabStop = False
        '
        'B3Estop
        '
        Me.B3Estop.BackColor = System.Drawing.Color.Yellow
        Me.B3Estop.BorderWidth = 2
        Me.B3Estop.CornerRadius = 1
        Me.B3Estop.FillColor = System.Drawing.Color.LimeGreen
        Me.B3Estop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B3Estop.Location = New System.Drawing.Point(200, 66)
        Me.B3Estop.Name = "B3Estop"
        Me.B3Estop.Size = New System.Drawing.Size(18, 17)
        '
        'B3Robot
        '
        Me.B3Robot.BackColor = System.Drawing.Color.Yellow
        Me.B3Robot.BorderWidth = 2
        Me.B3Robot.CornerRadius = 1
        Me.B3Robot.FillColor = System.Drawing.Color.LimeGreen
        Me.B3Robot.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B3Robot.Location = New System.Drawing.Point(170, 66)
        Me.B3Robot.Name = "B3Robot"
        Me.B3Robot.Size = New System.Drawing.Size(18, 17)
        '
        'B3DS
        '
        Me.B3DS.BackColor = System.Drawing.Color.Yellow
        Me.B3DS.BorderWidth = 2
        Me.B3DS.CornerRadius = 1
        Me.B3DS.FillColor = System.Drawing.Color.LimeGreen
        Me.B3DS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B3DS.Location = New System.Drawing.Point(140, 66)
        Me.B3DS.Name = "B3DS"
        Me.B3DS.Size = New System.Drawing.Size(18, 17)
        '
        'B2Estop
        '
        Me.B2Estop.BackColor = System.Drawing.Color.Yellow
        Me.B2Estop.BorderWidth = 2
        Me.B2Estop.CornerRadius = 1
        Me.B2Estop.FillColor = System.Drawing.Color.LimeGreen
        Me.B2Estop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B2Estop.Location = New System.Drawing.Point(200, 40)
        Me.B2Estop.Name = "B2Estop"
        Me.B2Estop.Size = New System.Drawing.Size(18, 17)
        '
        'B2Robot
        '
        Me.B2Robot.BackColor = System.Drawing.Color.Yellow
        Me.B2Robot.BorderWidth = 2
        Me.B2Robot.CornerRadius = 1
        Me.B2Robot.FillColor = System.Drawing.Color.LimeGreen
        Me.B2Robot.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B2Robot.Location = New System.Drawing.Point(170, 40)
        Me.B2Robot.Name = "B2Robot"
        Me.B2Robot.Size = New System.Drawing.Size(18, 17)
        '
        'B2DS
        '
        Me.B2DS.BackColor = System.Drawing.Color.Yellow
        Me.B2DS.BorderWidth = 2
        Me.B2DS.CornerRadius = 1
        Me.B2DS.FillColor = System.Drawing.Color.LimeGreen
        Me.B2DS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B2DS.Location = New System.Drawing.Point(140, 40)
        Me.B2DS.Name = "B2DS"
        Me.B2DS.Size = New System.Drawing.Size(18, 17)
        '
        'B1Estop
        '
        Me.B1Estop.BackColor = System.Drawing.Color.Yellow
        Me.B1Estop.BorderWidth = 2
        Me.B1Estop.CornerRadius = 1
        Me.B1Estop.FillColor = System.Drawing.Color.LimeGreen
        Me.B1Estop.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B1Estop.Location = New System.Drawing.Point(200, 14)
        Me.B1Estop.Name = "B1Estop"
        Me.B1Estop.Size = New System.Drawing.Size(18, 17)
        '
        'B1Robot
        '
        Me.B1Robot.BackColor = System.Drawing.Color.Yellow
        Me.B1Robot.BorderWidth = 2
        Me.B1Robot.CornerRadius = 1
        Me.B1Robot.FillColor = System.Drawing.Color.LimeGreen
        Me.B1Robot.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B1Robot.Location = New System.Drawing.Point(170, 14)
        Me.B1Robot.Name = "B1Robot"
        Me.B1Robot.Size = New System.Drawing.Size(18, 17)
        '
        'B1DS
        '
        Me.B1DS.BackColor = System.Drawing.Color.Yellow
        Me.B1DS.BorderWidth = 2
        Me.B1DS.CornerRadius = 1
        Me.B1DS.FillColor = System.Drawing.Color.LimeGreen
        Me.B1DS.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.B1DS.Location = New System.Drawing.Point(140, 14)
        Me.B1DS.Name = "B1DS"
        Me.B1DS.Size = New System.Drawing.Size(18, 17)
        '
        'FMSMasterTableAdapter
        '
        Me.FMSMasterTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(161, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "DS"
        '
        'Ctime
        '
        Me.Ctime.AutoSize = True
        Me.Ctime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctime.Location = New System.Drawing.Point(795, 9)
        Me.Ctime.Name = "Ctime"
        Me.Ctime.Size = New System.Drawing.Size(0, 20)
        Me.Ctime.TabIndex = 24
        '
        'Pre_Start_btn
        '
        Me.Pre_Start_btn.Location = New System.Drawing.Point(423, 114)
        Me.Pre_Start_btn.Name = "Pre_Start_btn"
        Me.Pre_Start_btn.Size = New System.Drawing.Size(75, 23)
        Me.Pre_Start_btn.TabIndex = 25
        Me.Pre_Start_btn.Text = "Pre-Start"
        Me.Pre_Start_btn.UseVisualStyleBackColor = True
        '
        'matchTimerLbl
        '
        Me.matchTimerLbl.AutoSize = True
        Me.matchTimerLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.matchTimerLbl.Location = New System.Drawing.Point(447, 75)
        Me.matchTimerLbl.Name = "matchTimerLbl"
        Me.matchTimerLbl.Size = New System.Drawing.Size(25, 25)
        Me.matchTimerLbl.TabIndex = 26
        Me.matchTimerLbl.Text = "0"
        Me.matchTimerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MatchMessages
        '
        Me.MatchMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MatchMessages.Location = New System.Drawing.Point(392, 19)
        Me.MatchMessages.Name = "MatchMessages"
        Me.MatchMessages.Size = New System.Drawing.Size(139, 20)
        Me.MatchMessages.TabIndex = 27
        Me.MatchMessages.Text = "Match Not Started"
        Me.MatchMessages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SandStormMessage
        '
        Me.SandStormMessage.Location = New System.Drawing.Point(427, 236)
        Me.SandStormMessage.Name = "SandStormMessage"
        Me.SandStormMessage.Size = New System.Drawing.Size(71, 13)
        Me.SandStormMessage.TabIndex = 28
        Me.SandStormMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(439, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 16)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Timer"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'AutoTimer
        '
        '
        'TeleTimer
        '
        '
        'EndGameTimer
        '
        '
        'MatchPlay
        '
        Me.MatchPlay.Location = New System.Drawing.Point(91, 24)
        Me.MatchPlay.Name = "MatchPlay"
        Me.MatchPlay.Size = New System.Drawing.Size(75, 34)
        Me.MatchPlay.TabIndex = 31
        Me.MatchPlay.Text = "Match Play"
        Me.MatchPlay.UseVisualStyleBackColor = True
        '
        'FinalScoreBtn
        '
        Me.FinalScoreBtn.Location = New System.Drawing.Point(182, 24)
        Me.FinalScoreBtn.Name = "FinalScoreBtn"
        Me.FinalScoreBtn.Size = New System.Drawing.Size(85, 36)
        Me.FinalScoreBtn.TabIndex = 32
        Me.FinalScoreBtn.Text = "Final Score"
        Me.FinalScoreBtn.UseVisualStyleBackColor = True
        '
        'PreMatchBtn
        '
        Me.PreMatchBtn.Location = New System.Drawing.Point(6, 23)
        Me.PreMatchBtn.Name = "PreMatchBtn"
        Me.PreMatchBtn.Size = New System.Drawing.Size(75, 36)
        Me.PreMatchBtn.TabIndex = 33
        Me.PreMatchBtn.Text = "Pre-Match"
        Me.PreMatchBtn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.PreMatchBtn)
        Me.GroupBox1.Controls.Add(Me.FinalScoreBtn)
        Me.GroupBox1.Controls.Add(Me.MatchPlay)
        Me.GroupBox1.Location = New System.Drawing.Point(920, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 99)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Video Switcher"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.LedPatternTestBtn)
        Me.GroupBox2.Controls.Add(Me.DSLightTestBtn)
        Me.GroupBox2.Controls.Add(Me.ScoringTableLightTestBtn)
        Me.GroupBox2.Controls.Add(Me.ConnectPLCBtn)
        Me.GroupBox2.Location = New System.Drawing.Point(920, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 169)
        Me.GroupBox2.TabIndex = 35
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FTA's Only"
        '
        'LedPatternTestBtn
        '
        Me.LedPatternTestBtn.Location = New System.Drawing.Point(158, 64)
        Me.LedPatternTestBtn.Name = "LedPatternTestBtn"
        Me.LedPatternTestBtn.Size = New System.Drawing.Size(117, 39)
        Me.LedPatternTestBtn.TabIndex = 4
        Me.LedPatternTestBtn.Text = "Light Pattern Test"
        Me.LedPatternTestBtn.UseVisualStyleBackColor = True
        '
        'DSLightTestBtn
        '
        Me.DSLightTestBtn.Location = New System.Drawing.Point(21, 64)
        Me.DSLightTestBtn.Name = "DSLightTestBtn"
        Me.DSLightTestBtn.Size = New System.Drawing.Size(119, 39)
        Me.DSLightTestBtn.TabIndex = 3
        Me.DSLightTestBtn.Text = "DS Light Test"
        Me.DSLightTestBtn.UseVisualStyleBackColor = True
        '
        'ScoringTableLightTestBtn
        '
        Me.ScoringTableLightTestBtn.Location = New System.Drawing.Point(91, 113)
        Me.ScoringTableLightTestBtn.Name = "ScoringTableLightTestBtn"
        Me.ScoringTableLightTestBtn.Size = New System.Drawing.Size(119, 39)
        Me.ScoringTableLightTestBtn.TabIndex = 2
        Me.ScoringTableLightTestBtn.Text = "Scoring Table Light Test"
        Me.ScoringTableLightTestBtn.UseVisualStyleBackColor = True
        '
        'ConnectPLCBtn
        '
        Me.ConnectPLCBtn.Location = New System.Drawing.Point(91, 23)
        Me.ConnectPLCBtn.Name = "ConnectPLCBtn"
        Me.ConnectPLCBtn.Size = New System.Drawing.Size(119, 36)
        Me.ConnectPLCBtn.TabIndex = 0
        Me.ConnectPLCBtn.Text = "Connect PLC"
        Me.ConnectPLCBtn.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(0, 103)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(333, 253)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Red Scoring"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(0, 138)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(346, 218)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Blue Scoring"
        '
        'Main_Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1235, 565)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.SandStormMessage)
        Me.Controls.Add(Me.MatchMessages)
        Me.Controls.Add(Me.matchTimerLbl)
        Me.Controls.Add(Me.Pre_Start_btn)
        Me.Controls.Add(Me.Ctime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.AbortMatch_btn)
        Me.Controls.Add(Me.StartMatch_btn)
        Me.Controls.Add(Me.MatchLoad_Btn)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Save_btn)
        Me.Controls.Add(Me.MatchNum)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main_Panel"
        Me.Text = "Main_Panel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FMSMasterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._O_FMSDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MatchNum As System.Windows.Forms.TextBox
    Friend WithEvents Save_btn As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RedTeam3 As System.Windows.Forms.Label
    Friend WithEvents RedTeam2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents MatchLoad_Btn As System.Windows.Forms.Button
    Friend WithEvents StartMatch_btn As System.Windows.Forms.Button
    Friend WithEvents AbortMatch_btn As System.Windows.Forms.Button
    Friend WithEvents RBypass1 As System.Windows.Forms.CheckBox
    Friend WithEvents RDQ1 As System.Windows.Forms.CheckBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents _O_FMSDataSet As O_FMS_V0._O_FMSDataSet
    Friend WithEvents RedVolt3 As System.Windows.Forms.Label
    Friend WithEvents RedVolt2 As System.Windows.Forms.Label
    Friend WithEvents RedVolt1 As System.Windows.Forms.Label
    Friend WithEvents RBypass3 As System.Windows.Forms.CheckBox
    Friend WithEvents RDQ3 As System.Windows.Forms.CheckBox
    Friend WithEvents RBypass2 As System.Windows.Forms.CheckBox
    Friend WithEvents RDQ2 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BBypass3 As System.Windows.Forms.CheckBox
    Friend WithEvents BDQ3 As System.Windows.Forms.CheckBox
    Friend WithEvents BBypass2 As System.Windows.Forms.CheckBox
    Friend WithEvents BDQ2 As System.Windows.Forms.CheckBox
    Friend WithEvents BlueVolt3 As System.Windows.Forms.Label
    Friend WithEvents BlueVolt2 As System.Windows.Forms.Label
    Friend WithEvents BlueVolt1 As System.Windows.Forms.Label
    Friend WithEvents BBypass1 As System.Windows.Forms.CheckBox
    Friend WithEvents BDQ1 As System.Windows.Forms.CheckBox
    Friend WithEvents BlueTeam3 As System.Windows.Forms.Label
    Friend WithEvents BlueTeam2 As System.Windows.Forms.Label
    Friend WithEvents BlueTeam1 As System.Windows.Forms.Label
    Friend WithEvents FMSMasterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FMSMasterTableAdapter As O_FMS_V0._O_FMSDataSetTableAdapters.FMSMasterTableAdapter
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Ctime As System.Windows.Forms.Label
    ' Friend WithEvents OpcSystems1 As OPCSystemsService.OPCSystems
    ' Private WithEvents ClientAceDA_Junction1 As Kepware.ClientAce.DA_Junction.ClientAceDA_Junction
    Friend WithEvents RedTeam1 As System.Windows.Forms.Label
    Private WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Private WithEvents R1Estop As PowerPacks.RectangleShape
    Private WithEvents R1Robot As PowerPacks.RectangleShape
    Private WithEvents R1DS As PowerPacks.RectangleShape
    Private WithEvents R3Estop As PowerPacks.RectangleShape
    Private WithEvents R3Robot As PowerPacks.RectangleShape
    Private WithEvents R3DS As PowerPacks.RectangleShape
    Private WithEvents R2Estop As PowerPacks.RectangleShape
    Private WithEvents R2Robot As PowerPacks.RectangleShape
    Private WithEvents R2DS As PowerPacks.RectangleShape
    Private WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
    Private WithEvents B3Estop As PowerPacks.RectangleShape
    Private WithEvents B3Robot As PowerPacks.RectangleShape
    Private WithEvents B3DS As PowerPacks.RectangleShape
    Private WithEvents B2Estop As PowerPacks.RectangleShape
    Private WithEvents B2Robot As PowerPacks.RectangleShape
    Private WithEvents B2DS As PowerPacks.RectangleShape
    Private WithEvents B1Estop As PowerPacks.RectangleShape
    Private WithEvents B1Robot As PowerPacks.RectangleShape
    Private WithEvents B1DS As PowerPacks.RectangleShape
    Friend WithEvents Pre_Start_btn As Button
    Friend WithEvents matchTimerLbl As Label
    Friend WithEvents MatchMessages As Label
    Friend WithEvents SandStormMessage As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Red1Sur As System.Windows.Forms.Label
    Friend WithEvents Red3Sur As System.Windows.Forms.Label
    Friend WithEvents Red2Sur As System.Windows.Forms.Label
    Friend WithEvents Blue3Sur As System.Windows.Forms.Label
    Friend WithEvents Blue2Sur As System.Windows.Forms.Label
    Friend WithEvents Blue1Sur As System.Windows.Forms.Label
    Public WithEvents WarmUpTimer As Timer
    Friend WithEvents AutoTimer As Timer
    Friend WithEvents PauseTimer As Timer
    Friend WithEvents TeleTimer As Timer
    Friend WithEvents EndGameTimer As Timer
    Friend WithEvents MatchPlay As Button
    Friend WithEvents FinalScoreBtn As Button
    Friend WithEvents PreMatchBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ConnectPLCBtn As Button
    Friend WithEvents LedPatternTestBtn As Button
    Friend WithEvents DSLightTestBtn As Button
    Friend WithEvents ScoringTableLightTestBtn As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
End Class
