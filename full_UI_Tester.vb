Imports Microsoft.VisualBasic

Imports UI.BlueAlliance.BlueAlli
Imports UI.BlueAlliance.Blue_UI_Block
Imports UI.Full_UI
Imports UI.Match_Control_UI
Imports UI.New_UI
Imports UI.RedAlliance.RedAlli
Imports UI.RedAlliance.Red_UI_Block
Imports java.awt.Toolkit
Public Class full_UI_Tester
    Inherits javax.swing.JFrame

    Public Sub New()
        MyBase.New()
        Me.initComponents()
        Me.setTitle("(O!FMS) Open Field Managment System")
        Me.setIconImage(Toolkit.getDefaultToolkit.getImage(getClass.getClassLoader.getResource("OFMS/LogoFiles/ofms logo.png")))
        Me.setResizable(True)
        Me.setUpIndicators()
    End Sub

    Public Sub setUpIndicators()
        System.out.println("Full UI - Set Up Indicators")
        '<editor-fold defaultstate="collapsed" desc="Set Team Indicators">
        Dim tempB_Alli As BlueAlli = full_UI1.getNew_UI.getAllisUI.getBlue
        Dim tempB1 As Blue_UI_Block = tempB_Alli.getBlue1
        Main.layer.setBlue1(tempB1.getTeamIndic, tempB1.getBypass, tempB1.getVoltIndic, tempB1.getRob_Com, tempB1.getDS_Com)
        Dim tempB2 As Blue_UI_Block = tempB_Alli.getBlue2
        Main.layer.setBlue2(tempB2.getTeamIndic, tempB2.getBypass, tempB2.getVoltIndic, tempB2.getRob_Com, tempB2.getDS_Com)
        Dim tempB3 As Blue_UI_Block = tempB_Alli.getBlue3
        Main.layer.setBlue3(tempB3.getTeamIndic, tempB3.getBypass, tempB3.getVoltIndic, tempB3.getRob_Com, tempB3.getDS_Com)
        Dim tempR_Alli As RedAlli = full_UI1.getNew_UI.getAllisUI.getRed
        Dim tempR1 As Red_UI_Block = tempR_Alli.get1
        Main.layer.setRed1(tempR1.getTeamIndic, tempR1.getBypass, tempR1.getVoltIndic, tempR1.getRob_Com, tempR1.getDS_Com)
        Dim tempR2 As Red_UI_Block = tempR_Alli.get2
        Main.layer.setRed2(tempR2.getTeamIndic, tempR2.getBypass, tempR2.getVoltIndic, tempR2.getRob_Com, tempR2.getDS_Com)
        Dim tempR3 As Red_UI_Block = tempR_Alli.get3
        Main.layer.setRed3(tempR3.getTeamIndic, tempR3.getBypass, tempR3.getVoltIndic, tempR3.getRob_Com, tempR3.getDS_Com)
        '</editor-fold>
        Dim mcui As Match_Control_UI = full_UI1.getMatchControl
        Main.layer.setSideIndicators(full_UI1.getNew_UI.getRedIndicator, full_UI1.getNew_UI.getBlueIndicator)
        Main.layer.setFullFieldReady(full_UI1.getNew_UI.getFullFieldIndic)
        Main.layer.setMatchButton(mcui.getMatchButton)
        Main.layer.setResetButton(mcui.getResetButton)
        Main.layer.setTimeSetters(mcui.getAutonField, mcui.getTeleField)
        Main.layer.setMatchTimeField(full_UI1.getNew_UI.getFullFieldIndic)
        Main.layer.setStopButton(mcui.getStopMatchButton)
        Main.layer.setProgressBar(full_UI1.getNew_UI.getProgBar)
        Main.layer.setSwitchViewButton(mcui.getSwitchButton)
    End Sub

    Public Function getFullUI() As Full_UI
        Return full_UI1
    End Function

    <SuppressWarnings("unchecked")> _
    Private Sub initComponents()
        full_UI1 = New UI.Full_UI
        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE)
        setMinimumSize(New java.awt.Dimension(810, 775))
        Dim layout As javax.swing.GroupLayout = New javax.swing.GroupLayout(getContentPane)
        getContentPane.setLayout(layout)
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(full_UI1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(full_UI1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
        pack()
    End Sub

    ' </editor-fold>//GEN-END:initComponents
    Public Shared Sub main(ByVal args() As String)
        '<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        Try
            For Each info As javax.swing.UIManager.LookAndFeelInfo In javax.swing.UIManager.getInstalledLookAndFeels
                If "Nimbus".equals(info.getName) Then
                    javax.swing.UIManager.setLookAndFeel(info.getClassName)
                    Exit For
                End If

            Next
        Catch ex As ClassNotFoundException
            java.util.logging.Logger.getLogger(full_UI_Tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
        Catch ex As InstantiationException
            java.util.logging.Logger.getLogger(full_UI_Tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
        Catch ex As IllegalAccessException
            java.util.logging.Logger.getLogger(full_UI_Tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
        Catch ex As javax.swing.UnsupportedLookAndFeelException
            java.util.logging.Logger.getLogger(full_UI_Tester.class.getName).log(java.util.logging.Level.SEVERE, Nothing, ex)
        End Try

        '</editor-fold>
        java.awt.EventQueue.invokeLater(New Runnable)
    End Sub

    ' Variables declaration - do not modify//GEN-BEGIN:variables
    Private full_UI1 As UI.Full_UI

    ' End of variables declaration//GEN-END:variables
    Private Function getNewUI() As New_UI
        Throw New UnsupportedOperationException("Not supported yet.")
    End Function
End Class
