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
        Me.btnChangeGameName = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtConsoleDisplay = New System.Windows.Forms.TextBox
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.txtNotifier = New System.Windows.Forms.ToolStripStatusLabel
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCheckForUpdate = New System.Windows.Forms.Button
        Me.btnSetPermissions = New System.Windows.Forms.Button
        Me.btnOpenLogs = New System.Windows.Forms.Button
        Me.btnAbout = New System.Windows.Forms.Button
        Me.StatusBar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPavlovSelect
        '
        Me.cmbPavlovSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPavlovSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPavlovSelect.FormattingEnabled = True
        Me.cmbPavlovSelect.Location = New System.Drawing.Point(10, 36)
        Me.cmbPavlovSelect.Name = "cmbPavlovSelect"
        Me.cmbPavlovSelect.Size = New System.Drawing.Size(343, 28)
        Me.cmbPavlovSelect.TabIndex = 1
        '
        'tbGameName
        '
        Me.tbGameName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGameName.Location = New System.Drawing.Point(10, 36)
        Me.tbGameName.Name = "tbGameName"
        Me.tbGameName.Size = New System.Drawing.Size(343, 26)
        Me.tbGameName.TabIndex = 2
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green
        Me.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Location = New System.Drawing.Point(359, 20)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(134, 60)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Install To Quest"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnChangeGameName
        '
        Me.btnChangeGameName.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnChangeGameName.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnChangeGameName.FlatAppearance.BorderSize = 0
        Me.btnChangeGameName.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green
        Me.btnChangeGameName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btnChangeGameName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnChangeGameName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeGameName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeGameName.ForeColor = System.Drawing.Color.Black
        Me.btnChangeGameName.Location = New System.Drawing.Point(359, 20)
        Me.btnChangeGameName.Name = "btnChangeGameName"
        Me.btnChangeGameName.Size = New System.Drawing.Size(134, 60)
        Me.btnChangeGameName.TabIndex = 5
        Me.btnChangeGameName.Text = "Change Name"
        Me.btnChangeGameName.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Impact", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Selected Pavlov Build"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Impact", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Teal
        Me.Label2.Location = New System.Drawing.Point(10, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(343, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "In-Game Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(193, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(318, 77)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "PAVLOV"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(203, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 26)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Umbustado's"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 30.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(486, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 46)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Shack"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label6.Location = New System.Drawing.Point(518, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 26)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Installer"
        '
        'txtConsoleDisplay
        '
        Me.txtConsoleDisplay.BackColor = System.Drawing.Color.Black
        Me.txtConsoleDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConsoleDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsoleDisplay.ForeColor = System.Drawing.Color.Yellow
        Me.txtConsoleDisplay.Location = New System.Drawing.Point(12, 8)
        Me.txtConsoleDisplay.MaxLength = 9999999
        Me.txtConsoleDisplay.Multiline = True
        Me.txtConsoleDisplay.Name = "txtConsoleDisplay"
        Me.txtConsoleDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsoleDisplay.Size = New System.Drawing.Size(796, 419)
        Me.txtConsoleDisplay.TabIndex = 16
        Me.txtConsoleDisplay.Text = "Text Display"
        '
        'StatusBar
        '
        Me.StatusBar.BackColor = System.Drawing.Color.Transparent
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtNotifier, Me.ProgressBar})
        Me.StatusBar.Location = New System.Drawing.Point(0, 430)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(820, 30)
        Me.StatusBar.SizingGrip = False
        Me.StatusBar.TabIndex = 18
        Me.StatusBar.Text = "StatusBar"
        '
        'txtNotifier
        '
        Me.txtNotifier.AutoSize = False
        Me.txtNotifier.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotifier.Name = "txtNotifier"
        Me.txtNotifier.Size = New System.Drawing.Size(669, 25)
        Me.txtNotifier.Text = "Notifier"
        Me.txtNotifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar
        '
        Me.ProgressBar.AutoSize = False
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(145, 24)
        Me.ProgressBar.Value = 50
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.cmbPavlovSelect)
        Me.Panel2.Location = New System.Drawing.Point(74, 150)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(507, 100)
        Me.Panel2.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnChangeGameName)
        Me.Panel1.Controls.Add(Me.tbGameName)
        Me.Panel1.Location = New System.Drawing.Point(74, 282)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(507, 100)
        Me.Panel1.TabIndex = 21
        '
        'btnCheckForUpdate
        '
        Me.btnCheckForUpdate.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnCheckForUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCheckForUpdate.FlatAppearance.BorderSize = 0
        Me.btnCheckForUpdate.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green
        Me.btnCheckForUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btnCheckForUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCheckForUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckForUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckForUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnCheckForUpdate.Location = New System.Drawing.Point(619, 171)
        Me.btnCheckForUpdate.Name = "btnCheckForUpdate"
        Me.btnCheckForUpdate.Size = New System.Drawing.Size(134, 30)
        Me.btnCheckForUpdate.TabIndex = 4
        Me.btnCheckForUpdate.Text = "Check For Updates"
        Me.btnCheckForUpdate.UseVisualStyleBackColor = False
        '
        'btnSetPermissions
        '
        Me.btnSetPermissions.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnSetPermissions.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSetPermissions.FlatAppearance.BorderSize = 0
        Me.btnSetPermissions.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green
        Me.btnSetPermissions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btnSetPermissions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSetPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetPermissions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPermissions.ForeColor = System.Drawing.Color.Black
        Me.btnSetPermissions.Location = New System.Drawing.Point(619, 201)
        Me.btnSetPermissions.Name = "btnSetPermissions"
        Me.btnSetPermissions.Size = New System.Drawing.Size(134, 30)
        Me.btnSetPermissions.TabIndex = 6
        Me.btnSetPermissions.Text = "Set Permissions"
        Me.btnSetPermissions.UseVisualStyleBackColor = False
        '
        'btnOpenLogs
        '
        Me.btnOpenLogs.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnOpenLogs.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnOpenLogs.FlatAppearance.BorderSize = 0
        Me.btnOpenLogs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green
        Me.btnOpenLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btnOpenLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnOpenLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenLogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenLogs.ForeColor = System.Drawing.Color.Black
        Me.btnOpenLogs.Location = New System.Drawing.Point(619, 303)
        Me.btnOpenLogs.Name = "btnOpenLogs"
        Me.btnOpenLogs.Size = New System.Drawing.Size(134, 30)
        Me.btnOpenLogs.TabIndex = 14
        Me.btnOpenLogs.Text = "Open Logs"
        Me.btnOpenLogs.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAbout.FlatAppearance.BorderSize = 0
        Me.btnAbout.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green
        Me.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.ForeColor = System.Drawing.Color.Black
        Me.btnAbout.Location = New System.Drawing.Point(619, 333)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(134, 30)
        Me.btnAbout.TabIndex = 17
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.UPSI.My.Resources.Resources.ss_f1715f00fdb90e66e4ac9f98ee0c8432e0d925ce_600x338
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(820, 460)
        Me.Controls.Add(Me.txtConsoleDisplay)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnOpenLogs)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSetPermissions)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCheckForUpdate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.ForeColor = System.Drawing.Color.Yellow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPavlovSelect As System.Windows.Forms.ComboBox
    Friend WithEvents tbGameName As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnChangeGameName As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNotifier As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConsoleDisplay As System.Windows.Forms.TextBox
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCheckForUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSetPermissions As System.Windows.Forms.Button
    Friend WithEvents btnOpenLogs As System.Windows.Forms.Button
    Friend WithEvents btnAbout As System.Windows.Forms.Button

End Class
