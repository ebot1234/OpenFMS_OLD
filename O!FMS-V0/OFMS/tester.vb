Imports Microsoft.VisualBasic

'Imports UI.BlueAlliance.BlueAlli
'Imports UI.BlueAlliance.Blue_UI_Block
'Imports UI.Match_Control_UI
'Imports UI.New_UI
'Imports UI.RedAlliance.RedAlli
'Imports UI.RedAlliance.Red_UI_Block
'Imports java.awt.Toolkit
'Public Class tester
'    Inherits javax.swing.JFrame

'    Private new_UI1 As New_UI

'    Public Sub New()
'        MyBase.New()
'        Me.initComponents()
'        Me.new_UI1 = simple_UI1.getNewUI
'        Me.setUpIndicators()
'        System.out.println("MainFMSDialog Constructor")
'        Me.setTitle("(O!FMS) Open Field Managment System")
'        Me.setIconImage(Toolkit.getDefaultToolkit.getImage(getClass.getClassLoader.getResource("OFMS/LogoFiles/ofms logo.png")))
'        Me.setResizable(False)
'    End Sub

'    Public Function getNewUI() As New_UI
'        Return Me.new_UI1
'    End Function

'    Public Sub setUpIndicators()
'        Console.Out.Write("Simple UI - Set Up Indicators")
'        '<editor-fold defaultstate="collapsed" desc="Set Team Indicators">
'        Dim tempB_Alli As BlueAlli = Me.new_UI1.getAllisUI.getBlue
'        Dim tempB1 As Blue_UI_Block = tempB_Alli.getBlue1
'        Main.layer.setBlue1(tempB1.getTeamIndic, tempB1.getBypass, tempB1.getVoltIndic, tempB1.getRob_Com, tempB1.getDS_Com)
'        Dim tempB2 As Blue_UI_Block = tempB_Alli.getBlue2
'        Main.layer.setBlue2(tempB2.getTeamIndic, tempB2.getBypass, tempB2.getVoltIndic, tempB2.getRob_Com, tempB2.getDS_Com)
'        Dim tempB3 As Blue_UI_Block = tempB_Alli.getBlue3
'        Main.layer.setBlue3(tempB3.getTeamIndic, tempB3.getBypass, tempB3.getVoltIndic, tempB3.getRob_Com, tempB3.getDS_Com)
'        Dim tempR_Alli As RedAlli = Me.new_UI1.getAllisUI.getRed
'        Dim tempR1 As Red_UI_Block = tempR_Alli.get1
'        Main.layer.setRed1(tempR1.getTeamIndic, tempR1.getBypass, tempR1.getVoltIndic, tempR1.getRob_Com, tempR1.getDS_Com)
'        Dim tempR2 As Red_UI_Block = tempR_Alli.get2
'        Main.layer.setRed2(tempR2.getTeamIndic, tempR2.getBypass, tempR2.getVoltIndic, tempR2.getRob_Com, tempR2.getDS_Com)
'        Dim tempR3 As Red_UI_Block = tempR_Alli.get3
'        Main.layer.setRed3(tempR3.getTeamIndic, tempR3.getBypass, tempR3.getVoltIndic, tempR3.getRob_Com, tempR3.getDS_Com)
'        '</editor-fold>
'        Dim mcui As Match_Control_UI = simple_UI1.getMatchControl
'        Main.layer.setSideIndicators(Me.new_UI1.getRedIndicator, Me.new_UI1.getBlueIndicator)
'        Main.layer.setFullFieldReady(Me.new_UI1.getFullFieldIndic)
'        Main.layer.setMatchButton(mcui.getMatchButton)
'        Main.layer.setResetButton(mcui.getResetButton)
'        Main.layer.setTimeSetters(mcui.getAutonField, mcui.getTeleField)
'        Main.layer.setMatchTimeField(Me.new_UI1.getFullFieldIndic)
'        Main.layer.setStopButton(mcui.getStopMatchButton)
'        Main.layer.setProgressBar(Me.new_UI1.getProgBar)
'        Main.layer.setSwitchViewButton(mcui.getSwitchButton)
'    End Sub

'    <SuppressWarnings("unchecked")> _
'    Private Sub initComponents()
'        simple_UI1 = New UI.Simple_UI
'        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE)
'        setBackground(New java.awt.Color(0, 0, 0))
'        setBounds(New java.awt.Rectangle(0, 0, 0, 0))
'        setMaximumSize(New java.awt.Dimension(805, 525))
'        setMinimumSize(New java.awt.Dimension(805, 525))
'        setPreferredSize(New java.awt.Dimension(805, 525))
'        addComponentListener(New java.awt.event.ComponentAdapter)
'        addHierarchyBoundsListener(New java.awt.event.HierarchyBoundsListener)
'        Dim layout As javax.swing.GroupLayout = New javax.swing.GroupLayout(getContentPane)
'        getContentPane.setLayout(layout)
'        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(simple_UI1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
'        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(simple_UI1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
'        pack()
'    End Sub

' </editor-fold>//GEN-END:initComponents
'Private Sub BoundsChanged(ByVal evt As java.awt.event.HierarchyEvent)
'GEN-FIRST:event_BoundsChanged
'End Sub

'GEN-LAST:event_BoundsChanged
'Private Sub Bounds2Changed(ByVal evt As java.awt.event.ComponentEvent)
'GEN-FIRST:event_Bounds2Changed
'End Sub

'GEN-LAST:event_Bounds2Changed
'Public Shared Sub main(ByVal args() As String)
'    '<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
'    Try
'        For Each info As javax.swing.UIManager.LookAndFeelInfo In javax.swing.UIManager.getInstalledLookAndFeels
'            If "Nimbus".Equals(info.getName) Then
'                javax.swing.UIManager.setLookAndFeel(info.getClassName)
'                Exit For
'            End If

'        Next
'    Catch ex As ClassNotFoundException
'        java.util.logging.Logger.getLogger(tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
'    Catch ex As InstantiationException
'        java.util.logging.Logger.getLogger(tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
'    Catch ex As IllegalAccessException
'        java.util.logging.Logger.getLogger(tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
'    Catch ex As javax.swing.UnsupportedLookAndFeelException
'        java.util.logging.Logger.getLogger(tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
'    End Try

'    '</editor-fold>
'    java.awt.EventQueue.invokeLater(New Runnable)
'End Sub

'' Variables declaration - do not modify//GEN-BEGIN:variables
''Private simple_UI1 As UI.Simple_UI
'End Class
