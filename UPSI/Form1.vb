Imports System.Environment
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.IO.Compression
Imports Ionic.Zip
Imports System.Configuration.install


Public Class Main
    Public appData As String = Environment.SystemDirectory.Substring(0, 2) & "\UPSI"
    Public Busy As Boolean = False
    Public extStorage As String
    Public WriteLog As StreamWriter
    Public QuietDownload As Boolean = False
    '   Public UpdateServer As String = "http://192.168.1.225/" ' internal test server
    Public UpdateServer As String = "http://thesideloader.co.uk/"

    Private Sub AllOn(ByVal boolONOFF As Boolean)

        '   Make all form objects invisible or visible
        Panel1.Visible = boolONOFF
        Panel2.Visible = boolONOFF
        Label1.Visible = boolONOFF
        Label2.Visible = boolONOFF
        cmbPavlovSelect.Visible = boolONOFF
        tbGameName.Visible = boolONOFF
        btnCheckForUpdate.Visible = boolONOFF
        btnChangeGameName.Visible = boolONOFF
        btnSetPermissions.Visible = boolONOFF
        btnOpenLogs.Visible = boolONOFF
        btnAbout.Visible = boolONOFF
        btnUpdate.Visible = boolONOFF
        Me.ControlBox = boolONOFF

    End Sub

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Logfile("Program Closing")
        CloseLog()
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AllOn(False)
        InitialSetup()
        Me.Show()
        ResponsiveSleep(1000)
        CheckAppData()
        Logfile("Checking for program update")
        CheckForAppUpdates(UpdateServer)
        CheckForUpdates()
        Buttons(0, 1, 1, 1, 1)
        btnUpdate.Select()
        AllOn(True)
        ResponsiveSleep(2000)
        UpdateNotifier("Ready")
    End Sub
    Private Sub CheckForAppUpdates(ByVal txtServer As String)
        Dim txtReturn As String
        WebDownload(txtServer & "upsi.txt", appData & "\temp\ver.txt", "Please wait - Checking for updates", True)
        Dim fsUpdate As New StreamReader(appData & "\temp\ver.txt")
        txtReturn = fsUpdate.ReadLine()
        fsUpdate.Close()
        File.Delete(appData & "\temp\ver.txt")
        Logfile("Found " & txtReturn)
        If txtReturn.Contains(Application.ProductVersion) = False Then
            UpdateNotifier("Program update found")
            Select Case MsgBox("Update to version " & txtReturn & " is available.  Click OK to start update", MsgBoxStyle.YesNo, Application.ProductName & " v" & Application.ProductVersion)
                Case MsgBoxResult.Yes
                    Logfile("Update triggered")
                    WebDownload(txtServer & "upsisetup.msi", appData & "\temp\upsisetup.msi", "Please wait - Downloading program update", True)
                    Logfile("running new setup")
                    _Run("msiexec.exe", " /i " & appData & "\temp\upsisetup.msi /quiet")
                    End
                Case MsgBoxResult.No
            End Select
        End If
        ResponsiveSleep(2000)
        UpdateNotifier("Ready")
    End Sub

    Private Sub InitialSetup()

        Buttons(2, 2, 2, 2, 2)
        Me.Text = Application.ProductName & " v" & Application.ProductVersion
        txtConsoleDisplay.Text = ""
        txtConsoleDisplay.Visible = False
        txtNotifier.Visible = True
        ProgressBar.Value = 0
        ProgressBar.Visible = False
        UpdateNotifier("Please wait - Performing start up checks")
        If Control.ModifierKeys = Keys.Shift Then
            ' Shift is being held down
            Select Case MsgBox("Do you want to delete UPSI folders - this will make it like you have just installed UPSI and run it for the first time ?", MsgBoxStyle.YesNo, "Umbustado's Paclov Shack Installer")
                Case MsgBoxResult.Yes
                    System.IO.Directory.Delete(appData, True)
                Case MsgBoxResult.No
            End Select
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Install_Pavlov()
        ResponsiveSleep(2000)
        UpdateNotifier("Ready")

    End Sub

    Private Sub btnCheckForUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckForUpdate.Click

        CheckForUpdates()
        ResponsiveSleep(2000)
        UpdateNotifier("Ready")

    End Sub

    Private Sub btnChangeGameName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGameName.Click

        ChangeName()
        ResponsiveSleep(2000)
        UpdateNotifier("Ready")

    End Sub

    Private Sub btnSetPermissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPermissions.Click

        SetPermissions()
        ResponsiveSleep(2000)
        UpdateNotifier("Ready")

    End Sub

    Private Sub btnOpenLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenLogs.Click

        Process.Start(appData & "\logs")

    End Sub

    Private Sub OpenLogFile()

        Dim strLogFileName As String = appData & "\logs\log-" & DateTime.Today.Year.ToString("0000") & DateTime.Today.Month.ToString("00") & DateTime.Today.Day.ToString("00") & ".txt"
        Try
            If (Not File.Exists(strLogFileName)) Then
                WriteLog = File.CreateText(strLogFileName)
            Else
                WriteLog = File.AppendText(strLogFileName)
            End If
            Logfile("********************************************")
            Logfile("******         " & Application.ProductName & " v" & Application.ProductVersion & "         *******")
            Logfile("******        Program Started        *******")
            Logfile("********************************************")

        Catch ex As IOException
            MsgBox("Error writing to log file.")
        End Try

    End Sub


    Private Sub Logfile(ByVal txtEntry As String)

        WriteLog.WriteLine(DateTime.Now & " - " & txtEntry)
        WriteLog.Flush()

    End Sub

    Private Sub SetPermissions()

        Logfile("Setting Permissions")
        If cmbPavlovSelect.SelectedItem.ToString = "" Then
            Logfile("No build selected")
            MsgBox("No build selected")
            Exit Sub
        End If
        Dim txtReturn As String = ""
        Dim srcDir As String = appData & "\downloads\" & cmbPavlovSelect.SelectedItem & "\"
        Logfile("Folder set to " & srcDir)
        If GetQuest() = True Then
            UpdateNotifier("Setting permissions ......")
            txtConsoleDisplay.Clear()
            txtConsoleDisplay.Visible = True
            txtConsole("Granting Permissions ....")
            txtConsole("")
            txtConsole(" - Record Audio")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO")
            txtConsole(txtReturn)
            txtConsole(" - Read External Storage")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE")
            txtConsole(txtReturn)
            txtConsole(" - Write External Storage")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE")
            txtConsole(txtReturn)
            txtConsole("")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", " kill-server")
            txtConsole("All Done")
            UpdateNotifier("All Done")
            ResponsiveSleep(5000)
            txtConsoleDisplay.Visible = False
        Else
            MsgBox("Quest not found - please try again")
            Logfile("Quest not found")
        End If

    End Sub

    Private Sub ChangeName()

        Logfile("Changing name")
        If cmbPavlovSelect.SelectedItem.ToString = "" Then
            Logfile("No build selected")
            MsgBox("No build selected")
            Exit Sub
        End If
        Dim txtReturn As String = ""
        Dim srcDir As String = appData & "\downloads\" & cmbPavlovSelect.SelectedItem & "\"
        Logfile("Folder set to " & srcDir)
        If GetQuest() = True Then
            UpdateNotifier("Starting name change ......")
            Logfile("Starting name change")
            txtConsoleDisplay.Clear()
            txtConsoleDisplay.Visible = True
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell ""echo $EXTERNAL_STORAGE""")
            extStorage = txtReturn.Substring(0, Len(txtReturn) - 2)
            txtConsole("External storage found at " & extStorage)
            txtConsole("")
            txtConsole("Setting name to " & tbGameName.Text)
            WriteNameToFile(tbGameName.Text, srcDir)
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "push " & srcDir & "name.txt " & extStorage & "/pavlov.name.txt")
            txtConsole(txtReturn)
            txtConsole("")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", " kill-server")
            txtConsole("All Done")
            UpdateNotifier("All Done")
            ResponsiveSleep(5000)
            txtConsoleDisplay.Visible = False
        Else
            Logfile("Quest not found")
            MsgBox("Quest not found - please try again")
        End If

    End Sub

    Private Sub CheckAppData()

        If System.IO.Directory.Exists(appData) Then
            System.IO.Directory.Delete(appData & "\temp\", True)
            ResponsiveSleep(500)
            System.IO.Directory.CreateDirectory(appData & "\temp")
            If Not System.IO.Directory.Exists(appData & "\logs") Then
                System.IO.Directory.CreateDirectory(appData & "\logs")
            End If
            OpenLogFile()
            Logfile("Checking system folders")
            Logfile("Checking ADB")
            If Not System.IO.Directory.Exists(appData & "\adb") Then
                Logfile("Downloading ADB files")
                WebDownload("https://dl.google.com/android/repository/platform-tools-latest-windows.zip", appData & "\temp\ADB.zip", "Downloading ADB tools", False)
                UnpackZip(appData & "\temp\", appData & "\", "ADB.zip")
                System.IO.File.Delete(appData & "\temp\ADB.zip")
            End If
            Logfile("Checking downloads")
            If Not System.IO.Directory.Exists(appData & "\downloads") Then
                System.IO.Directory.CreateDirectory(appData & "\downloads")
            End If
            Logfile("System folders found - filling combo")
            FillCombo()
        Else
            System.IO.Directory.CreateDirectory(appData)
            System.IO.Directory.CreateDirectory(appData & "\temp")
            System.IO.Directory.CreateDirectory(appData & "\downloads")
            System.IO.Directory.CreateDirectory(appData & "\logs")
            OpenLogFile()
            Logfile("System folders not found !")
            Logfile("Creating system folders")
            Logfile("Downloading ADB files")
            WebDownload("https://dl.google.com/android/repository/platform-tools-latest-windows.zip", appData & "\temp\ADB.zip", "Downloading ADB tools", False)
            UnpackZip(appData & "\temp\", appData & "\", "ADB.zip")
            System.IO.File.Delete(appData & "\temp\ADB.zip")
        End If
        Buttons(0, 0, 1, 1, 1)

    End Sub

    Private Sub CheckForUpdates()

        Dim txtZipName As String = GetHeader()
        Logfile("Checking local build")
        If CheckDownloads(txtZipName.Substring(0, Len(txtZipName) - 4)) = True Then
            Logfile("Local build is current")
            UpdateNotifier("Pavlov build is current")
        Else
            Logfile("Pavlov build is outdated")
            UpdateNotifier("Pavlov build is outdated - Downloading new build")
            ResponsiveSleep(2000)
            WebDownload("http://34.98.81.223/" & txtZipName, appData & "\temp\" & txtZipName, "Downloading " & txtZipName, False)
            UnpackZip(appData & "\temp\", appData & "\downloads\", txtZipName, ".apk\.obb\name.txt")
            Logfile("Deleting " & txtZipName)
            System.IO.File.Delete(appData & "\temp\" & txtZipName)
            FillCombo()
            FillName()
        End If
        Buttons(1, 1, 0, 0, 0)

    End Sub

    Private Sub WebDownload(ByVal txtSource As String, ByVal txtDestination As String, ByVal txtMessage As String, ByVal boolQuiet As Boolean)

        QuietDownload = boolQuiet
        If QuietDownload = False Then
            Logfile("Downloading " & txtSource)
            UpdateNotifier(txtMessage)
            ProgressBar.Value = 0
            ProgressBar.Visible = True
        End If
        Busy = True
        Dim _WebClient As New System.Net.WebClient()
        AddHandler _WebClient.DownloadFileCompleted, AddressOf _DownloadFileCompleted
        AddHandler _WebClient.DownloadProgressChanged, AddressOf _DownloadProgressChanged
        _WebClient.DownloadFileAsync(New Uri(txtSource), txtDestination)
        Do While Busy = True
            ResponsiveSleep(1000)
        Loop

    End Sub

    Private Sub _DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)

        If QuietDownload = False Then
            Logfile("Download completed")
            UpdateNotifier("Download completed")
            ProgressBar.Value = 0
            ProgressBar.Visible = False
        Else
            QuietDownload = False
        End If
        Busy = False
        ResponsiveSleep(2000)

    End Sub

    Private Sub _DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)

        If QuietDownload = False Then
            UpdateNotifier("Downloading " & e.BytesReceived.ToString("N0") & " of " & e.TotalBytesToReceive.ToString("N0") & " bytes (" & e.ProgressPercentage.ToString & "%)")
            ProgressBar.Value = e.ProgressPercentage
        End If

    End Sub

    Private Sub FillCombo()

        Logfile("Filling combo box")
        cmbPavlovSelect.Items.Clear()
        Dim arrDir As Array
        Dim Package As String
        For Each Dir As String In Directory.GetDirectories(appData & "\downloads\")
            arrDir = Split(Dir.ToString, "\")
            Package = arrDir(UBound(arrDir))
            cmbPavlovSelect.Items.Add(Package)
            Logfile("Adding " & Package)
        Next
        If cmbPavlovSelect.Items.Count > 0 Then cmbPavlovSelect.SelectedIndex = cmbPavlovSelect.Items.Count - 1

    End Sub

    Private Sub FillName()

        Logfile("Filling name box")
        If System.IO.File.Exists(appData & "\downloads\" & cmbPavlovSelect.SelectedItem.ToString & "\name.txt") Then
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(appData & "\downloads\" & cmbPavlovSelect.SelectedItem.ToString & "\name.txt")
            tbGameName.Text = fileReader.ReadLine()
            fileReader.Close()
            Logfile("using " & appData & "\downloads\" & cmbPavlovSelect.SelectedItem.ToString & "\name.txt """ & tbGameName.Text & """")
        Else
            Logfile("Using default name ""Change_Me""")
            tbGameName.Text = "Change_Me"
        End If

    End Sub

    Public Sub UnpackZip(ByVal txtSource As String, ByVal txtDestination As String, ByVal txtFilename As String, Optional ByVal txtFileType As String = "")
        Dim boolFlag As Boolean = False
        Dim arrFlagFile As Array
        Dim txtFlagFile As String
        Dim ZipToUnpack As String = txtSource & txtFilename
        Dim TargetDir As String = txtDestination & txtFilename.Substring(0, Len(txtFilename) - 4)
        Logfile("Unpacking " & ZipToUnpack & " to " & TargetDir)
        arrFlagFile = Split(txtFileType, "\")
        ProgressBar.Value = 0
        ProgressBar.Visible = True
        txtConsoleDisplay.Visible = True
        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            AddHandler zip1.ExtractProgress, AddressOf MyExtractProgress
            Dim e As ZipEntry
            For Each e In zip1
                For Each txtFlagFile In arrFlagFile
                    If e.FileName.EndsWith(txtFlagFile) = True Then
                        txtConsole("Extracting " & e.FileName)
                        Logfile(e.FileName)
                        e.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently)
                    End If
                Next
            Next
        End Using
        txtConsoleDisplay.Visible = False
        txtConsoleDisplay.Text = ""
        Logfile("Done")
        UpdateNotifier("Done")
        ProgressBar.Visible = False

    End Sub

    Public Sub MyExtractProgress(ByVal sender As Object, ByVal e As Ionic.Zip.ExtractProgressEventArgs)

        Dim PCDone As Int16
        If e.BytesTransferred = 0 Or e.TotalBytesToTransfer = 0 Then
            PCDone = 0
        Else
            PCDone = e.BytesTransferred / (e.TotalBytesToTransfer / 100)
        End If
        UpdateNotifier(e.CurrentEntry.FileName & " Progress " & PCDone.ToString & "%")
        ProgressBar.Value = PCDone

    End Sub

    Public Function CheckDownloads(ByVal txtFoldername As String)

        Logfile("Checking for " & txtFoldername)
        If System.IO.Directory.Exists(appData & "\downloads\" & txtFoldername) = True Then
            Logfile(txtFoldername & " Found")
            CheckDownloads = True
        Else
            Logfile(txtFoldername & " Not found")
            CheckDownloads = False
        End If

    End Function

    Public Function GetHeader()

        Logfile("Checking Online Pavlov build")
        Dim txtReturn As String = ""
        Dim boolTag As Boolean = False
        Dim XMLSTR2 As String = ""
        Dim m_xmld As XmlDocument
        UpdateNotifier("Checking Online Pavlov build")
        m_xmld = New XmlDocument
        Logfile("Checking http://34.98.81.223/")
        m_xmld.Load("http://34.98.81.223/")
        XMLSTR2 = m_xmld.InnerXml.Substring(103, Len(m_xmld.InnerXml) - 103)
        m_xmld.InnerXml = "<ListBucketResult>" & XMLSTR2
        Dim xmlReader As New XmlNodeReader(m_xmld)
        While xmlReader.Read()
            Select Case xmlReader.NodeType
                Case XmlNodeType.Element
                    If xmlReader.Name = "Key" Then
                        boolTag = True
                    Else
                        boolTag = False
                    End If

                    Exit Select
                Case XmlNodeType.Text
                    If boolTag = True Then
                        If xmlReader.Value.Substring(Len(xmlReader.Value) - 4, 4) = ".zip" Then
                            txtReturn = xmlReader.Value
                        End If
                    End If
                    Exit Select
            End Select
        End While
        Logfile("Found Version " & txtReturn)
        GetHeader = txtReturn

    End Function

    Private Sub txtConsole(ByVal txtMessage As String)

        txtConsoleDisplay.AppendText(txtMessage & vbCrLf)
        If txtMessage <> "" Then Logfile(txtMessage)
        txtConsoleDisplay.Refresh()

    End Sub

    Private Function CleanResponse(ByVal txtString As String)

        Dim n As Int16
        Dim txtTest As String = ""
        For n = 0 To Len(txtString) - 1
            If Asc(txtString.Substring(n, 1)) = 13 Or Asc(txtString.Substring(n, 1)) = 10 Or Asc(txtString.Substring(n, 1)) = 9 Then
                txtTest = txtTest & " "
            Else
                txtTest = txtTest & txtString.Substring(n, 1)
            End If
        Next
        CleanResponse = Trim(txtTest)

    End Function

    Public Sub UpdateNotifier(ByVal txtMessage As String)

        txtNotifier.Text = txtMessage
        StatusBar.Refresh()

    End Sub

    Public Function GetQuest()

        Dim txtDevice, txtResponse, txtTEST
        Dim arrResponse As Array
        Logfile("Finding Quest")
        UpdateNotifier("Please connect your Quest ....")
        txtTEST = ""
        txtResponse = _Run(appData & "\ADB\platform-tools\adb.exe", "wait-for-device")
        ResponsiveSleep(1000)
        txtResponse = _Run(appData & "\ADB\platform-tools\adb.exe", " -d devices")
        arrResponse = Split(CleanResponse(txtResponse), " ")
        txtDevice = (arrResponse(UBound(arrResponse) - 1))
        UpdateNotifier("Device Found : " & txtDevice)
        ResponsiveSleep(1000)
        If txtDevice = "device" Then
            Logfile("Quest not found")
            GetQuest = False
        Else
            Logfile("Device " & txtDevice & " found")
            GetQuest = True
        End If

    End Function

    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)

        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500) : Application.DoEvents()
        Next i

    End Sub

    Private Sub cmbPavlovSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPavlovSelect.SelectedIndexChanged

        FillName()

    End Sub


    Private Function _Run(ByVal txtCommand As String, ByVal txtAugs As String)

        Dim myProcess As Process = New Process()
        Dim txtRunOutput As String
        myProcess.StartInfo.FileName = txtCommand
        myProcess.StartInfo.UseShellExecute = False
        myProcess.StartInfo.CreateNoWindow = True
        myProcess.StartInfo.RedirectStandardInput = True
        myProcess.StartInfo.RedirectStandardOutput = True
        myProcess.StartInfo.RedirectStandardError = True
        myProcess.StartInfo.Arguments = txtAugs
        myProcess.Start()
        Dim sIn As StreamWriter = myProcess.StandardInput
        Dim sOut As StreamReader = myProcess.StandardOutput
        Dim sErr As StreamReader = myProcess.StandardError
        txtRunOutput = sOut.ReadToEnd()
        Do While myProcess.HasExited = False
            ResponsiveSleep(500)
        Loop
        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
        _Run = txtRunOutput
        ResponsiveSleep(500)

    End Function

    Private Sub Buttons(ByVal Install As Integer, ByVal Update As Integer, ByVal Changename As Integer, ByVal SetPerms As Integer, ByVal Logs As Integer)

        ' Enable or disable buttons
        ' 0 = no effect
        ' 1 = enabled
        ' 2 = disabled

        If Install = 1 Then btnUpdate.Enabled = True
        If Install = 2 Then btnUpdate.Enabled = False
        If Update = 1 Then btnCheckForUpdate.Enabled = True
        If Update = 2 Then btnCheckForUpdate.Enabled = False
        If Changename = 1 Then btnChangeGameName.Enabled = True
        If Changename = 2 Then btnChangeGameName.Enabled = False
        If SetPerms = 1 Then btnSetPermissions.Enabled = True
        If SetPerms = 2 Then btnSetPermissions.Enabled = False
        If Logs = 1 Then btnOpenLogs.Enabled = True
        If Logs = 2 Then btnOpenLogs.Enabled = False

    End Sub

    Private Sub CloseLog()

        WriteLog.Close()

    End Sub


    Private Sub Install_Pavlov()

        Logfile("Installing Pavlov")
        If cmbPavlovSelect.SelectedItem.ToString = "" Then
            Logfile("No build selected")
            MsgBox("No build selected")
            Exit Sub
        End If
        Dim txtReturn As String = ""
        Dim srcDir As String = appData & "\downloads\" & cmbPavlovSelect.SelectedItem & "\"
        If GetQuest() = True Then
            Logfile("Starting Install from " & srcDir)
            UpdateNotifier("Starting Install ......")
            txtConsoleDisplay.Clear()
            txtConsoleDisplay.Visible = True
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell ""echo $EXTERNAL_STORAGE""")
            extStorage = txtReturn.Substring(0, Len(txtReturn) - 2)
            txtConsole("External storage found at " & extStorage)
            txtConsole("")
            txtConsole("Uninstalling existing application. Failures here can almost always be ignored.")
            txtConsole("")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "uninstall com.davevillz.pavlov")
            txtConsole(txtReturn)
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "uninstall com.vankrupt.pavlov")
            txtConsole(txtReturn)
            txtConsole("")
            txtConsole("Now installing Pavlov. Failures here indicate a problem with the device (connection or storage permissions) and are fatal.")
            txtConsole("")
            txtConsole("Installing apk ...")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "install " & srcDir & "Pavlov-Android-Shipping-armv7-es2.apk")
            txtConsole("")
            txtConsole(txtReturn)
            txtConsole("")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/UE4Game/Pavlov")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/UE4Game/UE4CommandLine.txt")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/obb/com.vankrupt.pavlov")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/Android/obb/com.vankrupt.pavlov")
            txtConsole("Granting Permissions ....")
            txtConsole("")
            txtConsole(" - Record Audio")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO")
            txtConsole(txtReturn)
            txtConsole(" - Read External Storage")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE")
            txtConsole(txtReturn)
            txtConsole(" - Write External Storage")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE")
            txtConsole(txtReturn)
            txtConsole("")
            txtConsole("Setting name to " & tbGameName.Text)
            WriteNameToFile(tbGameName.Text, srcDir)
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "push " & srcDir & "name.txt " & extStorage & "/pavlov.name.txt")
            txtConsole(txtReturn)
            txtConsole("")
            txtConsole("Installing new data. Failures here indicate storage problems (missing SD card or bad permissions) and are fatal.")
            txtConsole("Installing OBB file")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "push " & srcDir & "main.22.com.vankrupt.pavlov.obb " & extStorage & "/Download/obb/com.vankrupt.pavlov/main.22.com.vankrupt.pavlov.obb")
            txtConsole(txtReturn)
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", "shell mv " & extStorage & "/Download/obb/com.vankrupt.pavlov " & extStorage & "/Android/obb/com.vankrupt.pavlov")
            txtConsole(txtReturn)
            txtConsole("")
            txtReturn = _Run(appData & "\ADB\platform-tools\adb.exe", " kill-server")
            txtConsole("All Done.")
            UpdateNotifier("All Done")
            ResponsiveSleep(5000)
            txtConsoleDisplay.Visible = False
        Else
            MsgBox("Quest not found - please try again")
        End If

    End Sub
    Public Sub WriteNameToFile(ByVal txtName As String, ByVal srcFolder As String)

        Dim strFile As String = srcFolder & "name.txt"
        Logfile("updating " & strFile & " to " & txtName)
        Dim sw As StreamWriter
        If System.IO.File.Exists(strFile) Then System.IO.File.Delete(strFile)
        Try
            sw = File.CreateText(strFile)
            sw.WriteLine(txtName)
            sw.Close()
            Logfile("Name.txt written")
        Catch ex As IOException
            Logfile("Error writing to name.txt")
            MsgBox("Error writing to name.txt")
        End Try

    End Sub


    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click

        AboutBox1.ShowDialog()

    End Sub

End Class


