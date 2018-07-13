Imports Microsoft.VisualBasic

Imports java.awt.Star
Imports javax.swing.Star
Public Class FMS_SplashScreen
    Inherits JWindow

    '    private static JProgressBar progressBar = new JProgressBar();
    '    private static FMS_SplashScreen execute;
    Private Shared count As Integer

    Public Sub New()
        MyBase.New()
        Dim container As Container = getContentPane
        container.setLayout(Nothing)
        Dim a As LogoPanel = New LogoPanel
        a.setBounds(0, 0, CType(a.getLogoWidth, Integer), CType(a.getLogoHeight, Integer))
        container.add(a)
        'setSize(400, 200);
        setSize(a.getLogoWidth, a.getLogoHeight)
        setLocationRelativeTo(Nothing)
        setVisible(True)
    End Sub

    Private Function createImageIcon(ByVal path As String, ByVal description As String) As ImageIcon
        Dim imgURL As java.net.URL = getClass.getResource(path)
        If (Not (imgURL) Is Nothing) Then
            System.out.println("Success")
            Return New ImageIcon(imgURL, description)
        Else
            System.err.println(("Couldn't find file: " + path))
            Return Nothing
        End If

    End Function

    Public Sub splashTheScreen(ByVal daSplash As FMS_SplashScreen)
        Dim kill As Boolean = False
        '        timer1 = new Timer();
        Dim ORIG_TIME_MILLIS As Double = System.currentTimeMillis

        While Not kill
            'count++;
            'progressBar.setValue(count);
            If ((System.currentTimeMillis - ORIG_TIME_MILLIS) _
                        > 1000) Then
                'count == 30
                'timer1.stop();
                daSplash.setVisible(False)
                kill = True
                'load the rest of your application
            End If


        End While

    End Sub
End Class
'
'        ActionListener al = new ActionListener() {
'            @Override
'            public void actionPerformed(java.awt.event.ActionEvent evt) {
'            }
'        };
'        timer1 = new Timer(50, al);
'        timer1.start();
'
'    public static void main(String args[]) {
'        execute = new FMS_SplashScreen();
'    }
'
'new ImageIcon(getClass().getResource("/splashscreen/O!FMS DE Logo (Custom).png"));
'a.setBorder(new javax.swing.border.AbstractBorder() {});//EtchedBorder());
'a.setBackground(new Color(255, 255, 255));
'a.setBounds(0, 0, 350, 100); // Good!
'a.setBounds(a.getBounds());
'a.setLayout(null); //BAD
'a.setVisible(true); // Don't matter