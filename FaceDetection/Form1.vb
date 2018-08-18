Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports Emgu.CV.UI
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Public Class FaceRecognation
    Inherits Form
    Private currentFrame As Image(Of Bgr, Byte)


    Public grabber As Emgu.CV.Capture

    Private face As HaarCascade

    Private eye As HaarCascade

    Private mouth As HaarCascade

    Private body As HaarCascade

    Private bodyupper As HaarCascade

    Private bodylower As HaarCascade



    Private font As MCvFont = New MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5, 0.5)

    Private result As Image(Of Emgu.CV.Structure.Gray, Byte)

    Private TrainedFace As Image(Of Emgu.CV.Structure.Gray, Byte)

    Private gray As Image(Of Emgu.CV.Structure.Gray, Byte)

    Private trainingImages As List(Of Image(Of Emgu.CV.Structure.Gray, Byte)) = New List(Of Image(Of Emgu.CV.Structure.Gray, Byte))()

    Private labels As List(Of String) = New List(Of String)()

    Private NamePersons As List(Of String) = New List(Of String)()

    Private ContTrain As Integer

    Private NumLabels As Integer

    Private t As Integer

    Private name As String

    Private names As String

    Public Sub New()
        MyBase.New()
        Me.InitializeComponent()
        Me.face = New HaarCascade("haarcascade_frontalface_default.xml")
        Me.eye = New HaarCascade("haarcascade_eye.xml")
        Me.mouth = New HaarCascade("Mouth.xml")
        Me.body = New HaarCascade("haarcascade_fullbody.xml")

        Me.bodyupper = New HaarCascade("haarcascade_upperbody.xml")
        Me.bodylower = New HaarCascade("haarcascade_lowerbody.xml")


        Try
            Dim Labelsinfo As String = File.ReadAllText(String.Concat(Application.StartupPath, "/TrainedFaces/TrainedLabels.txt"))
            Dim Labels As String() = Labelsinfo.Split(New Char() {"%"c})
            Me.NumLabels = Convert.ToInt16(Labels(0))
            Me.ContTrain = Me.NumLabels
            For tf As Integer = 1 To Me.NumLabels + 1
                Dim LoadFaces As String = String.Concat("face", tf, ".bmp")
                Me.trainingImages.Add(New Image(Of Emgu.CV.Structure.Gray, Byte)(String.Concat(Application.StartupPath, "/TrainedFaces/", LoadFaces)))
                Me.labels.Add(Labels(tf))
            Next

        Catch exception As System.Exception
            MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub


    Dim t0 As Type = Type.GetTypeFromProgID("SAPI.SpVoice")
    Dim voice As Object = Activator.CreateInstance(t0)
    Dim check As String
    Public opencam As String
    Sub speakname(ByVal name As String)
        If check <> name Then

            '  t0 = Type.GetTypeFromProgID("SAPI.SpVoice")
            '  voice = Activator.CreateInstance(t0)

            '  voice.Speak("how are you " & name)

        End If
        If check <> name And check = "Ehab" Then



            voice.Speak("how are you " & name)

        End If
        check = name
    End Sub

    Public Sub FrameGrabber(ByVal sender As Object, ByVal e As EventArgs)
        If opencam = "yes" Then
            Me.label3.Text = "0"
            Me.NamePersons.Add("")
            Me.currentFrame = Me.grabber.QueryFrame().Resize(514, 478, INTER.CV_INTER_CUBIC)
            '514, 478
            Me.gray = Me.currentFrame.Convert(Of Gray, Byte)()
            Dim facesDetected As MCvAvgComp()() = Me.gray.DetectHaarCascade(Me.face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))
            Dim array As MCvAvgComp() = facesDetected(0)
            For i As Integer = 0 To array.Length - 1
                Dim f As MCvAvgComp = array(i)
                'Detecet Face 
                Me.t += 1
                Me.result = Me.currentFrame.Copy(f.rect).Convert(Of Gray, Byte)().Resize(100, 100, INTER.CV_INTER_CUBIC)
                Me.currentFrame.Draw(f.rect, New Bgr(Color.Red), 2)
                : If Me.trainingImages.ToArray().Length <> 0 Then
                    : Dim termCrit As MCvTermCriteria = New MCvTermCriteria(Me.ContTrain, 0.001)
                    : Dim recognizer As EigenObjectRecognizer = New EigenObjectRecognizer(Me.trainingImages.ToArray(), Me.labels.ToArray(), 3000.0, termCrit)
                    : Me.name = recognizer.Recognize(Me.result)
                    : Dim arg_192_0 As Image(Of Bgr, Byte) = Me.currentFrame
                    : Dim arg_192_1 As String = Me.name
                    : Dim rect As Rectangle = f.rect
                    : Dim arg_183_0 As Integer = rect.X - 2
                    : Dim rect2 As Rectangle = f.rect
                    : arg_192_0.Draw(arg_192_1, Me.font, New Point(arg_183_0, rect2.Y - 2), New Bgr(Color.Orange))
                    : arg_192_0.Draw(Today, Me.font, New Point(arg_183_0, rect2.Y + 20), New Bgr(Color.Orange))
                    : arg_192_0.Draw(TimeOfDay, Me.font, New Point(arg_183_0 + 150, rect2.Y + 20), New Bgr(Color.Orange))
                    : speakname(arg_192_1)

                    Dim bdyupr As MCvAvgComp()() = Me.gray.DetectHaarCascade(Me.bodyupper, 1.2, 1, CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT, New Size(50, 50))

                    For Each bdyup As MCvAvgComp In bdyupr(0)
                        '  Me.currentFrame.Draw(bdyup.rect, New Bgr(Color.Blue), 3)
                    Next

                    Dim bdylow As MCvAvgComp()() = Me.gray.DetectHaarCascade(Me.bodylower, 1.2, 1, CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT, New Size(50, 50))

                    For Each bdylw As MCvAvgComp In bdylow(0)
                        '     Me.currentFrame.Draw(bdylw.rect, New Bgr(Color.Blue), 3)
                    Next

                    Dim bodys As MCvAvgComp()() = Me.gray.DetectHaarCascade(Me.body, 1.2, 1, CvEnum.HAAR_DETECTION_TYPE.FIND_BIGGEST_OBJECT, New Size(50, 50))

                    For Each body As MCvAvgComp In bodys(0)
                        '   Me.currentFrame.Draw(body.rect, New Bgr(Color.Blue), 3)
                    Next
                    'Detecet eyes
                    : For Each f0 As MCvAvgComp() In facesDetected
                        'Set the region of interest on the faces
                        Me.gray.ROI = f.rect
                        : Dim eyesDetected = Me.gray.DetectHaarCascade(Me.eye, 1.3, 12, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))
                        : Me.gray.ROI = Rectangle.Empty
                        : For Each m In eyesDetected(0)
                            Dim eyeRect As Rectangle = m.rect
                            eyeRect.Offset(f.rect.X, f.rect.Y)
                            : Me.currentFrame.Draw(eyeRect, New Bgr(Color.Green), 1)

                            : Next

                        : Next
                    'Detecet mouth
                    : For Each f0 As MCvAvgComp() In facesDetected
                        'Set the region of interest on the faces
                        : Me.gray.ROI = f.rect
                        : Dim mouthsDetected = Me.gray.DetectHaarCascade(Me.mouth, 1.3, 12, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))
                        : Me.gray.ROI = Rectangle.Empty
                        : For Each m In mouthsDetected(0)
                            : Dim mouthRect As Rectangle = m.rect
                            : mouthRect.Offset(f.rect.X, f.rect.Y)
                            ' Me.currentFrame.Draw(mouthRect, New Bgr(Color.Yellow), 1)
                            : Next

                        : Next
                    : End If
                : Me.NamePersons(Me.t - 1) = Me.name
                : Me.NamePersons.Add("")
                : Me.label3.Text = facesDetected(0).Length.ToString()
                : Next
            Me.t = 0
            For nnn As Integer = 0 To facesDetected(0).Length - 1
                Me.names = Me.names + Me.NamePersons(nnn) + ", "
            Next
            Me.imageBoxFrameGrabber.Image = Me.currentFrame
            ' sir.imageBoxFrameGrabber.Image = Me.currentFrame
            Me.Label4.Text = Me.names
            Me.names = ""
            Me.NamePersons.Clear()
        ElseIf opencam <> "yes" Then
            Me.grabber.Dispose()
        ElseIf opencam = "body" Then

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.grabber = New Emgu.CV.Capture(ComboBox_Devices.SelectedIndex)
        Me.grabber.QueryFrame()
        opencam = "yes"
        AddHandler Application.Idle, New EventHandler(AddressOf FrameGrabber)
        Me.Button3.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        '   514, 478
        Try
            Me.ContTrain = Me.ContTrain + 1
            Me.gray = Me.grabber.QueryGrayFrame().Resize(320, 240, INTER.CV_INTER_CUBIC)
            Dim facesDetected As MCvAvgComp()() = Me.gray.DetectHaarCascade(Me.face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New System.Drawing.Size(20, 20))
            Dim mCvAvgCompArray As MCvAvgComp() = facesDetected(0)
            Dim num As Integer = 0
            If (num < CInt(mCvAvgCompArray.Length)) Then
                Dim f As MCvAvgComp = mCvAvgCompArray(num)
                Me.TrainedFace = Me.currentFrame.Copy(f.rect).Convert(Of Emgu.CV.Structure.Gray, Byte)()
            End If
            Me.TrainedFace = Me.result.Resize(100, 100, INTER.CV_INTER_CUBIC)
            Me.trainingImages.Add(Me.TrainedFace)
            Me.labels.Add(Me.TextBox1.Text)
            Me.imageBox1.Image = Me.TrainedFace
            Dim str As String = String.Concat(Application.StartupPath, "/TrainedFaces/TrainedLabels.txt")
            Dim length As Integer = CInt(Me.trainingImages.ToArray().Length)
            File.WriteAllText(str, String.Concat(length.ToString(), "%"))
            Dim i As Integer = 1
            Do
                Dim array As Image(Of Emgu.CV.Structure.Gray, Byte) = Me.trainingImages.ToArray()(i - 1)
                Dim startupPath() As Object = {Application.StartupPath, "/TrainedFaces/face", i, ".bmp"}
                DirectCast(array, CvArray(Of Byte)).Save(String.Concat(startupPath))
                File.AppendAllText(String.Concat(Application.StartupPath, "/TrainedFaces/TrainedLabels.txt"), String.Concat(Me.labels.ToArray()(i - 1), "%"))
                i = i + 1
            Loop While i < CInt(Me.trainingImages.ToArray().Length) + 1
            MessageBox.Show(String.Concat(Me.TextBox1.Text, "´s face detected and added :)"), "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Catch
            MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        opencam = "no"
        Me.grabber.Dispose()
        Me.Button3.Enabled = True

    End Sub

    Private Sub FaceRecognation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        opencam = "no"
        Me.grabber.Dispose()
        Me.Button3.Enabled = True
    End Sub
    Public WithEvents cam As New DSCamCapture
    Private Sub FaceRecognation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox_Devices.Items.AddRange(cam.GetCaptureDevices)
        If ComboBox_Devices.Items.Count > 0 Then ComboBox_Devices.SelectedIndex = 0

    End Sub
End Class