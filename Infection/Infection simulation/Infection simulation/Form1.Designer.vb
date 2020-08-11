<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.black = New System.Windows.Forms.PictureBox()
        Me.pink = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.graph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Tickspeed = New System.Windows.Forms.TrackBar()
        Me.art = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.black, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.graph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tickspeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(235, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(585, 585)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(79, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "50"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(79, 67)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "100"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Turquoise
        Me.Button1.Location = New System.Drawing.Point(88, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Apply"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Turquoise
        Me.Label1.Location = New System.Drawing.Point(85, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Number of balls"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Turquoise
        Me.Label2.Location = New System.Drawing.Point(95, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tick speed"
        '
        'black
        '
        Me.black.BackColor = System.Drawing.SystemColors.ControlText
        Me.black.Location = New System.Drawing.Point(124, 146)
        Me.black.Name = "black"
        Me.black.Size = New System.Drawing.Size(62, 4)
        Me.black.TabIndex = 7
        Me.black.TabStop = False
        '
        'pink
        '
        Me.pink.BackColor = System.Drawing.Color.Fuchsia
        Me.pink.Location = New System.Drawing.Point(56, 146)
        Me.pink.Name = "pink"
        Me.pink.Size = New System.Drawing.Size(62, 196)
        Me.pink.TabIndex = 8
        Me.pink.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Aquamarine
        Me.Label3.Location = New System.Drawing.Point(140, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Aquamarine
        Me.Label4.Location = New System.Drawing.Point(76, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "0"
        '
        'graph
        '
        ChartArea3.Name = "ChartArea1"
        Me.graph.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.graph.Legends.Add(Legend3)
        Me.graph.Location = New System.Drawing.Point(831, 51)
        Me.graph.Name = "graph"
        Me.graph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series3.Legend = "Legend1"
        Series3.Name = "Infected"
        Me.graph.Series.Add(Series3)
        Me.graph.Size = New System.Drawing.Size(428, 358)
        Me.graph.TabIndex = 11
        Me.graph.Text = "Chart1"
        '
        'Tickspeed
        '
        Me.Tickspeed.BackColor = System.Drawing.Color.Turquoise
        Me.Tickspeed.Location = New System.Drawing.Point(851, 519)
        Me.Tickspeed.Maximum = 100
        Me.Tickspeed.Minimum = 1
        Me.Tickspeed.Name = "Tickspeed"
        Me.Tickspeed.Size = New System.Drawing.Size(388, 45)
        Me.Tickspeed.TabIndex = 12
        Me.Tickspeed.Value = 1
        '
        'art
        '
        Me.art.AutoSize = True
        Me.art.BackColor = System.Drawing.Color.Turquoise
        Me.art.Location = New System.Drawing.Point(12, 601)
        Me.art.Name = "art"
        Me.art.Size = New System.Drawing.Size(45, 17)
        Me.art.TabIndex = 14
        Me.art.Text = "Art?"
        Me.art.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Turquoise
        Me.Label5.Location = New System.Drawing.Point(1008, 503)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Tick speed"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(1271, 630)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.art)
        Me.Controls.Add(Me.Tickspeed)
        Me.Controls.Add(Me.graph)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pink)
        Me.Controls.Add(Me.black)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "Form1"
        Me.Text = "Equalibrium simulation"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.black, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.graph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tickspeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents black As PictureBox
    Friend WithEvents pink As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents graph As DataVisualization.Charting.Chart
    Friend WithEvents Tickspeed As TrackBar
    Friend WithEvents art As CheckBox
    Friend WithEvents Label5 As Label
End Class
