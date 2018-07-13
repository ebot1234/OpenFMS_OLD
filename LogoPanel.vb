Imports Microsoft.VisualBasic



Public Class LogoPanel
    Inherits javax.swing.JPanel

    Public Sub New()
        MyBase.New()
        Me.initComponents()
        'setBounds(0, 0, WIDTH, HEIGHT);
    End Sub

    Public Function getLogoHeight() As Integer
        System.out.println(("Height: " + jLabel1.getIcon.getIconHeight))
        ' getHeight());
        Dim height As Integer = (jLabel1.getIcon.getIconHeight + jLabel2.getIcon.getIconHeight)
        Return height
    End Function

    Public Function getLogoWidth() As Integer
        System.out.println(("Width: " + jLabel1.getIcon.getIconWidth))
        Dim width As Integer = jLabel1.getIcon.getIconWidth
        ' + jLabel2.getIcon().getIconWidth();
        Return width
    End Function

    <SuppressWarnings("unchecked")> _
    Private Sub initComponents()
        jLabel1 = New javax.swing.JLabel
        jLabel2 = New javax.swing.JLabel
        setBackground(New java.awt.Color(0, 0, 0))
        setEnabled(False)
        jLabel1.setIcon(New javax.swing.ImageIcon(getClass.getResource("/OFMS/LogoFiles/O!FMS DE Logo (Custom).png")))
        ' NOI18N
        jLabel2.setIcon(New javax.swing.ImageIcon(getClass.getResource("/OFMS/LogoFiles/adc_logo_241x209.png")))
        ' NOI18N
        Dim layout As javax.swing.GroupLayout = New javax.swing.GroupLayout(Me)
        Me.setLayout(layout)
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jLabel1).addGroup(layout.createSequentialGroup.addGap(39, 39, 39).addComponent(jLabel2)))
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup.addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel2).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)))
    End Sub

    ' </editor-fold>//GEN-END:initComponents
    ' Variables declaration - do not modify//GEN-BEGIN:variables
    Private jLabel1 As javax.swing.JLabel

    Private jLabel2 As javax.swing.JLabel
End Class