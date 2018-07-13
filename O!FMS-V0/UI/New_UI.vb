Imports Microsoft.VisualBasic
Imports O_FMS_V0.DSReceiver
Imports O_FMS_V0.GovernThread
Imports O_FMS_V0.Main

Public Class New_UI
    Inherits javax.swing.JPanel

    Private Shared _instance As New_UI

    Public Sub New()
        MyBase.New()
        Me.initComponents()
        System.Console.Write("CREATING NEW UI")
        _instance = Me
        Me.addHierarchyListener(New HierarchyListener)
    End Sub

    Public Shared Function getInstance() As New_UI
        Return _instance
    End Function

    Protected Function setupListenersWhenConnected() As Boolean
        Dim parentFrame As JFrame = CType(SwingUtilities.getWindowAncestor(Me), JFrame)
        If (parentFrame Is Nothing) Then
            Return False
        End If

        parentFrame.addWindowListener(New WindowAdapter)
        Return True
    End Function

    Public Function getAllisUI() As Allis_UI
        Return allis_UI1
    End Function

    Public Function getFullFieldIndic() As JTextField
        Return timeFullFieldIdicator
    End Function

    Public Function getBlueIndicator() As Label
        Return allis_UI1.getBlue.getBlueIndic
    End Function

    Public Function getRedIndicator() As Label
        Return allis_UI1.getRed.getRedIndic
    End Function

    Public Function getProgBar() As JProgressBar
        Return matchProgressBar
    End Function

    Public Function getMessagesTextArea() As JTextArea
        Return allis_UI1.getMessagesArea
    End Function

    <SuppressWarnings("unchecked")> _
    Private Sub initComponents()
        matchProgressBar = New javax.swing.JProgressBar
        timeFullFieldIdicator = New javax.swing.JTextField
        allis_UI1 = New UI.Allis_UI
        Background(New java.awt.Color(0, 0, 0))
        timeFullFieldIdicator.setEditable(False)
        timeFullFieldIdicator.setBackground(New java.awt.Color(153, 153, 153))
        timeFullFieldIdicator.setFont(New java.awt.Font("Tahoma", 1, 48))
        ' NOI18N
        timeFullFieldIdicator.setHorizontalAlignment(javax.swing.JTextField.CENTER)
        timeFullFieldIdicator.setText("010")
        Dim layout As javax.swing.GroupLayout = New javax.swing.GroupLayout(Me)
        Me.setLayout(layout)
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup.addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup.addGap(312, 312, 312).addComponent(timeFullFieldIdicator, javax.swing.GroupLayout.PREFERRED_SIZE, 172, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(0, 0, Short.MAX_VALUE)).addGroup(layout.createSequentialGroup.addContainerGap.addComponent(matchProgressBar, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup.addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(allis_UI1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap))
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup.addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(timeFullFieldIdicator, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(allis_UI1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(matchProgressBar, javax.swing.GroupLayout.PREFERRED_SIZE, 34, javax.swing.GroupLayout.PREFERRED_SIZE)))
    End Sub

    ' </editor-fold>//GEN-END:initComponents
    ' Variables declaration - do not modify//GEN-BEGIN:variables
    Private allis_UI1 As UI.Allis_UI

    Private matchProgressBar As javax.swing.JProgressBar

    Private timeFullFieldIdicator As javax.swing.JTextField
End Class
