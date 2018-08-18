<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FaceRecognation
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
        Me.ComboBox_Devices = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.imageBox1 = New Emgu.CV.UI.ImageBox()
        Me.imageBoxFrameGrabber = New Emgu.CV.UI.ImageBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        CType(Me.imageBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imageBoxFrameGrabber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox_Devices
        '
        Me.ComboBox_Devices.FormattingEnabled = True
        Me.ComboBox_Devices.Location = New System.Drawing.Point(17, 167)
        Me.ComboBox_Devices.Name = "ComboBox_Devices"
        Me.ComboBox_Devices.Size = New System.Drawing.Size(178, 21)
        Me.ComboBox_Devices.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 143)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 21)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(58, 170)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(106, 20)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.Text = "Ehab"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.TextBox1)
        Me.groupBox1.Controls.Add(Me.Button4)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.imageBox1)
        Me.groupBox1.Location = New System.Drawing.Point(532, 252)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(206, 242)
        Me.groupBox1.TabIndex = 14
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Training: "
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(14, 208)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(160, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "2. Add face"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(11, 173)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(41, 13)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Name: "
        '
        'imageBox1
        '
        Me.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageBox1.Location = New System.Drawing.Point(11, 18)
        Me.imageBox1.Name = "imageBox1"
        Me.imageBox1.Size = New System.Drawing.Size(163, 134)
        Me.imageBox1.TabIndex = 5
        Me.imageBox1.TabStop = False
        '
        'imageBoxFrameGrabber
        '
        Me.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageBoxFrameGrabber.Location = New System.Drawing.Point(12, 4)
        Me.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber"
        Me.imageBoxFrameGrabber.Size = New System.Drawing.Size(514, 490)
        Me.imageBoxFrameGrabber.TabIndex = 13
        Me.imageBoxFrameGrabber.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(9, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 19)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Nobody"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.Black
        Me.label5.Location = New System.Drawing.Point(9, 23)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(197, 15)
        Me.label5.TabIndex = 17
        Me.label5.Text = "Persons present in the scene:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 194)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(179, 37)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "1. Detect and recognize"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.Red
        Me.label3.Location = New System.Drawing.Point(163, 124)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(16, 16)
        Me.label3.TabIndex = 15
        Me.label3.Text = "0"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.ComboBox_Devices)
        Me.groupBox2.Controls.Add(Me.Button1)
        Me.groupBox2.Controls.Add(Me.Label4)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.Button3)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(532, 4)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(208, 242)
        Me.groupBox2.TabIndex = 15
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Results: "
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(10, 92)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(179, 15)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Number of faces detected: "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 502)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageBoxFrameGrabber)
        Me.Controls.Add(Me.groupBox2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.imageBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imageBoxFrameGrabber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox_Devices As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents imageBox1 As Emgu.CV.UI.ImageBox
    Private WithEvents imageBoxFrameGrabber As Emgu.CV.UI.ImageBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label

End Class
