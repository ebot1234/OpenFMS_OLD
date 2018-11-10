<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Match_Generator
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
        Me.components = New System.ComponentModel.Container()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ScheduleGeneratorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Directory = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Teams = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Rounds = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.matchQuality = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScheduleGeneratorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Teams, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rounds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ScheduleGeneratorBindingSource
        '
        Me.ScheduleGeneratorBindingSource.DataSource = GetType(O_FMS_V0.Schedule_Generator)
        '
        'Directory
        '
        Me.Directory.AllowDrop = True
        Me.Directory.Location = New System.Drawing.Point(6, 16)
        Me.Directory.Name = "Directory"
        Me.Directory.Size = New System.Drawing.Size(177, 20)
        Me.Directory.TabIndex = 0
        Me.Directory.Text = "C:\OFMS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(190, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(418, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Location of Teams LIst (# of teams in list must match Selected #) "
        '
        'Teams
        '
        Me.Teams.Location = New System.Drawing.Point(6, 59)
        Me.Teams.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Teams.Name = "Teams"
        Me.Teams.Size = New System.Drawing.Size(120, 20)
        Me.Teams.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(190, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(330, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "# Teams (# of teams in list must match Selected #) "
        '
        'Rounds
        '
        Me.Rounds.Location = New System.Drawing.Point(18, 135)
        Me.Rounds.Name = "Rounds"
        Me.Rounds.Size = New System.Drawing.Size(120, 20)
        Me.Rounds.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(202, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "# Rounds per Team"
        '
        'matchQuality
        '
        Me.matchQuality.FormattingEnabled = True
        Me.matchQuality.Items.AddRange(New Object() {"Fair", "Good", "Best"})
        Me.matchQuality.Location = New System.Drawing.Point(18, 184)
        Me.matchQuality.MaxDropDownItems = 3
        Me.matchQuality.Name = "matchQuality"
        Me.matchQuality.Size = New System.Drawing.Size(121, 21)
        Me.matchQuality.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(202, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Match Generation Quality"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Create Teams List"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(202, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(374, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Creates Team List from teams in database table 'teaminfo'"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Directory)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Teams)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(640, 88)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Teams List"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 291)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Generate Matches"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(202, 294)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(452, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Matches will be generated and added to the database table 'MatchList'"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 356)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 23)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Generate Schedule"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Match_Generator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 502)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.matchQuality)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Rounds)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Match_Generator"
        Me.Text = "Match_Generator"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScheduleGeneratorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Teams, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rounds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ScheduleGeneratorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Directory As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Teams As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Rounds As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents matchQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
