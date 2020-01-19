<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.cmbPavlovSelect = New System.Windows.Forms.ComboBox
        Me.tbGameName = New System.Windows.Forms.TextBox
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnCheckForUpdate = New System.Windows.Forms.Button
        Me.btnChangeGameName = New System.Windows.Forms.Button
        Me.btnSetPermissions = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnOpenLogs = New System.Windows.Forms.Button
        Me.txtConsoleDisplay = New System.Windows.Forms.TextBox
        Me.btnAbout = New System.Windows.Forms.Button
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.txtNotifier = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPavlovSelect
        '
        Me.cmbPavlovSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPavlovSelect.FormattingEnabled = True
        Me.cmbPavlovSelect.Location = New System.Drawing.Point(150, 115)
        Me.cmbPavlovSelect.Name = "cmbPavlovSelect"
        Me.cmbPavlovSelect.Size = New System.Drawing.Size(300, 21)
        Me.cmbPavlovSelect.TabIndex = 1
        '
        'tbGameName
        '
        Me.tbGameName.Location = New System.Drawing.Point(150, 195)
        Me.tbGameName.Name = "tbGameName"
        Me.tbGameName.Size = New System.Drawing.Size(300, 20)
        Me.tbGameName.TabIndex = 2
        '
        'btnUpdate
        '
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Location = New System.Drawing.Point(195, 142)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(107, 21)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Install To Quest"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnCheckForUpdate
        '
        Me.btnCheckForUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnCheckForUpdate.Location = New System.Drawing.Point(309, 142)
        Me.btnCheckForUpdate.Name = "btnCheckForUpdate"
        Me.btnCheckForUpdate.Size = New System.Drawing.Size(107, 21)
        Me.btnCheckForUpdate.TabIndex = 4
        Me.btnCheckForUpdate.Text = "Check For Updates"
        Me.btnCheckForUpdate.UseVisualStyleBackColor = True
        '
        'btnChangeGameName
        '
        Me.btnChangeGameName.ForeColor = System.Drawing.Color.Black
        Me.btnChangeGameName.Location = New System.Drawing.Point(195, 221)
        Me.btnChangeGameName.Name = "btnChangeGameName"
        Me.btnChangeGameName.Size = New System.Drawing.Size(107, 21)
        Me.btnChangeGameName.TabIndex = 5
        Me.btnChangeGameName.Text = "Change Name"
        Me.btnChangeGameName.UseVisualStyleBackColor = True
        '
        'btnSetPermissions
        '
        Me.btnSetPermissions.ForeColor = System.Drawing.Color.Black
        Me.btnSetPermissions.Location = New System.Drawing.Point(309, 221)
        Me.btnSetPermissions.Name = "btnSetPermissions"
        Me.btnSetPermissions.Size = New System.Drawing.Size(107, 21)
        Me.btnSetPermissions.TabIndex = 6
        Me.btnSetPermissions.Text = "Set Permissions"
        Me.btnSetPermissions.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Impact", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label1.Location = New System.Drawing.Point(150, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Selected Pavlov Build"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Impact", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkSeaGreen
        Me.Label2.Location = New System.Drawing.Point(150, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(300, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "In-Game Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(138, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(237, 68)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "PAVLOV"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Ink Free", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(147, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Umbustado's"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(355, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 32)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Shack"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Ink Free", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label6.Location = New System.Drawing.Point(370, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Installer"
        '
        'btnOpenLogs
        '
        Me.btnOpenLogs.ForeColor = System.Drawing.Color.Black
        Me.btnOpenLogs.Location = New System.Drawing.Point(195, 248)
        Me.btnOpenLogs.Name = "btnOpenLogs"
        Me.btnOpenLogs.Size = New System.Drawing.Size(221, 21)
        Me.btnOpenLogs.TabIndex = 14
        Me.btnOpenLogs.Text = "Open Logs"
        Me.btnOpenLogs.UseVisualStyleBackColor = True
        '
        'txtConsoleDisplay
        '
        Me.txtConsoleDisplay.BackColor = System.Drawing.Color.Black
        Me.txtConsoleDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConsoleDisplay.ForeColor = System.Drawing.Color.Yellow
        Me.txtConsoleDisplay.Location = New System.Drawing.Point(0, -1)
        Me.txtConsoleDisplay.MaxLength = 9999999
        Me.txtConsoleDisplay.Multiline = True
        Me.txtConsoleDisplay.Name = "txtConsoleDisplay"
        Me.txtConsoleDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsoleDisplay.Size = New System.Drawing.Size(599, 311)
        Me.txtConsoleDisplay.TabIndex = 16
        '
        'btnAbout
        '
        Me.btnAbout.ForeColor = System.Drawing.Color.Black
        Me.btnAbout.Location = New System.Drawing.Point(195, 275)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(221, 21)
        Me.btnAbout.TabIndex = 17
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.BackColor = System.Drawing.Color.Transparent
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtNotifier, Me.ProgressBar})
        Me.StatusBar.Location = New System.Drawing.Point(0, 313)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(599, 22)
        Me.StatusBar.SizingGrip = False
        Me.StatusBar.TabIndex = 18
        Me.StatusBar.Text = "StatusBar"
        '
        'txtNotifier
        '
        Me.txtNotifier.AutoSize = False
        Me.txtNotifier.Name = "txtNotifier"
        Me.txtNotifier.Size = New System.Drawing.Size(449, 17)
        Me.UpdateNotifier("txtNotifier")
        Me.txtNotifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar
        '
        Me.ProgressBar.AutoSize = False
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(145, 16)
        Me.ProgressBar.Value = 50
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.UPSI.My.Resources.Resources.ss_f1715f00fdb90e66e4ac9f98ee0c8432e0d925ce_600x338
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(599, 335)
        Me.Controls.Add(Me.txtConsoleDisplay)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnOpenLogs)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSetPermissions)
        Me.Controls.Add(Me.btnChangeGameName)
        Me.Controls.Add(Me.btnCheckForUpdate)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.tbGameName)
        Me.Controls.Add(Me.cmbPavlovSelect)
        Me.ForeColor = System.Drawing.Color.Yellow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Umbustado's Pavlov Shack Installer"
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPavlovSelect As System.Windows.Forms.ComboBox
    Friend WithEvents tbGameName As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnCheckForUpdate As System.Windows.Forms.Button
    Friend WithEvents btnChangeGameName As System.Windows.Forms.Button
    Friend WithEvents btnSetPermissions As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNotifier As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnOpenLogs As System.Windows.Forms.Button
    Friend WithEvents txtConsoleDisplay As System.Windows.Forms.TextBox
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar

End Class
