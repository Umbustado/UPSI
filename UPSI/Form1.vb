Imports System.Environment
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.IO.Compression
Imports Ionic.Zip


Public Class Main
    Public appData As String = GetFolderPath(SpecialFolder.LocalApplicationData) & "\UPSI"
    Public Busy As Boolean = False
    Public extStorage As String

    Private Sub AllOn(ByVal boolONOFF As Boolean)
        Label1.Visible = boolONOFF
        Label2.Visible = boolONOFF
        ComboBox1.Visible = boolONOFF
        TextBox1.Visible = boolONOFF
        button1.Visible = boolONOFF
        button2.Visible = boolONOFF
        Button3.Visible = boolONOFF
        Button4.Visible = boolONOFF
        Button5.Visible = boolONOFF
        btnUpdate.Visible = boolONOFF

    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AllOn(False)
        InitialSetup()
        Me.Show()
        ResponsiveSleep(5000)
        CheckAppData()
        CheckForUpdates()
        Buttons(0, 1, 1, 1, 1)
        AllOn(True)

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Install_Pavlov()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckForUpdates()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        changename()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SetPermissions()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Process.Start(appData & "\logs")

    End Sub
    Private Sub StartLogfile()
        Logfile("********************************************")
        Logfile("******        Program Started        *******")
        Logfile("********************************************")

    End Sub

    Private Sub Logfile(ByVal txtEntry As String)
        Dim strFile As String = appData & "\logs\log-" & DateTime.Today.Year.ToString("0000") & DateTime.Today.Month.ToString("00") & DateTime.Today.Day.ToString("00") & ".txt"
        Dim oFile As StreamWriter
        Try
            If (Not File.Exists(strFile)) Then
                oFile = File.CreateText(strFile)
                oFile.WriteLine("UPSI Log for " & DateTime.Today.ToString("dd/mm/yyyy"))
            Else
                oFile = File.AppendText(strFile)
            End If
            oFile.WriteLine(DateTime.Now & " - " & txtEntry)
            oFile.Close()
        Catch ex As IOException
            MsgBox("Error writing to log file.")
        End Try
    End Sub

    Private Sub SetPermissions()
        Logfile("Setting Permissions")
        If ComboBox1.SelectedItem.ToString = "" Then
            Logfile("No build selected")
            MsgBox("No build selected")
            Exit Sub
        End If
        Dim txt1 As String = ""
        Dim srcDir As String = appData & "\downloads\" & ComboBox1.SelectedItem & "\"
        Logfile("Folder set to " & srcDir)
        If GetQuest() = True Then
            ToolStripStatusLabel2.Text = "Setting permissions ......"
            TextBox2.Clear()
            TextBox2.Visible = True
            txtConsole("Granting Permissions ....")
            txtConsole("")
            txtConsole(" - Record Audio")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO")
            txtConsole(txt1)
            txtConsole(" - Read External Storage")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE")
            txtConsole(txt1)
            txtConsole(" - Write External Storage")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE")
            txtConsole(txt1)
            txtConsole("")
            txtConsole("All Done")
            ToolStripStatusLabel2.Text = "All Done"
            ResponsiveSleep(5000)
            TextBox2.Visible = False
        Else
            MsgBox("Quest not found - please try again")
            Logfile("Quest not found")
        End If

    End Sub

    Private Sub ChangeName()
        Logfile("Changing name")
        If ComboBox1.SelectedItem.ToString = "" Then
            Logfile("No build selected")
            MsgBox("No build selected")
            Exit Sub
        End If
        Dim txt1 As String = ""
        Dim srcDir As String = appData & "\downloads\" & ComboBox1.SelectedItem & "\"
        Logfile("Folder set to " & srcDir)
        If GetQuest() = True Then
            ToolStripStatusLabel2.Text = "Starting name change ......"
            Logfile("Starting name change")
            TextBox2.Clear()
            TextBox2.Visible = True
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell ""echo $EXTERNAL_STORAGE""")
            extStorage = txt1.Substring(0, Len(txt1) - 2)
            txtConsole("External storage found at " & extStorage)
            txtConsole("")
            txtConsole("Setting name to " & TextBox1.Text)
            WriteNameToFile(TextBox1.Text, srcDir)
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "push " & srcDir & "name.txt " & extStorage & "/pavlov.name.txt")
            txtConsole(txt1)
            txtConsole("")
            txtConsole("All Done")
            ToolStripStatusLabel2.Text = "All Done"
            ResponsiveSleep(5000)
            TextBox2.Visible = False
        Else
            Logfile("Quest not found")
            MsgBox("Quest not found - please try again")
        End If

    End Sub


    Private Sub InitialSetup()
        Buttons(2, 2, 2, 2, 2)
        TextBox2.Visible = False
        ToolStripStatusLabel2.Text = "Please wait - Performing start up checks"
        ToolStripStatusLabel2.Visible = True
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Visible = False
        StatusStrip1.Refresh()

    End Sub
    Private Sub CheckAppData()
        If System.IO.Directory.Exists(appData) Then
            StartLogfile()
            Logfile("Checking system folders")
            Logfile("System folders found - filling combo")
            FillCombo()
        Else
            System.IO.Directory.CreateDirectory(appData)
            System.IO.Directory.CreateDirectory(appData & "\temp")
            System.IO.Directory.CreateDirectory(appData & "\downloads")
            System.IO.Directory.CreateDirectory(appData & "\logs")
            StartLogfile()
            Logfile("Checking system folders")
            Logfile("Creating system folders")

            WebDownload("https://dl.google.com/android/repository/platform-tools-latest-windows.zip", appData & "\temp\ADB.zip", "Downloading ADB tools")
            UnpackZip(appData & "\temp\", appData & "\", "ADB.zip")
        End If
        Buttons(0, 0, 1, 1, 1)
    End Sub

    Private Sub CheckForUpdates()
        Dim txtZipName As String = GetHeader()
        Logfile("Checking local build")
        If CheckDownloads(txtZipName.Substring(0, Len(txtZipName) - 4)) = True Then
            Logfile("Local build is current")
            ToolStripStatusLabel2.Text = "Pavlov build is current"
        Else
            Logfile("Pavlov build is outdated")
            WebDownload("http://34.98.81.223/" & txtZipName, appData & "\temp\" & txtZipName, "Downloading " & txtZipName)
            UnpackZip(appData & "\temp\", appData & "\downloads\", txtZipName)
            FillCombo()
            FillName()
        End If
        Buttons(1, 1, 0, 0, 0)
    End Sub

    Private Sub WebDownload(ByVal txtSource As String, ByVal txtDestination As String, ByVal txtMessage As String)
        Logfile("Downloading " & txtSource)
        ToolStripStatusLabel2.Text = txtMessage
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Visible = True
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
        Logfile("Download complete")
        ToolStripStatusLabel2.Text = "Download completed"
        StatusStrip1.Refresh()
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Visible = False
        Busy = False
        ResponsiveSleep(2000)

    End Sub

    Private Sub _DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        ToolStripStatusLabel2.Text = "Downloading " & e.BytesReceived.ToString & " of " & e.TotalBytesToReceive.ToString & " bytes (" & e.ProgressPercentage.ToString & "%)"
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub FillCombo()
        Logfile("Filling combo box")
        ComboBox1.Items.Clear()
        Dim arrDir As Array
        Dim Package As String
        For Each Dir As String In Directory.GetDirectories(appData & "\downloads\")
            arrDir = Split(Dir.ToString, "\")
            Package = arrDir(UBound(arrDir))
            ComboBox1.Items.Add(Package)
            Logfile(Package)
        Next
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub FillName()
        Logfile("Filling name box")
        If System.IO.File.Exists(appData & "\downloads\" & ComboBox1.SelectedItem.ToString & "\name.txt") Then
            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(appData & "\downloads\" & ComboBox1.SelectedItem.ToString & "\name.txt")
            TextBox1.Text = fileReader.ReadLine()
            fileReader.Close()
            Logfile("using " & appData & "\downloads\" & ComboBox1.SelectedItem.ToString & "\name.txt """ & TextBox1.Text & "")
        Else
            Logfile("Using default name ""Change_Me""")
            TextBox1.Text = "Change_Me"
        End If

    End Sub

    Public Sub UnpackZip(ByVal txtSource As String, ByVal txtDestination As String, ByVal txtFilename As String)
        Dim ZipToUnpack As String = txtSource & txtFilename
        Dim TargetDir As String = txtDestination & txtFilename.Substring(0, Len(txtFilename) - 4)
        Logfile("Unpacking " & ZipToUnpack & " to " & TargetDir)
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Visible = True
        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            AddHandler zip1.ExtractProgress, AddressOf MyExtractProgress
            Dim e As ZipEntry
            For Each e In zip1
                e.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently)
                Logfile(e.FileName)
            Next
        End Using
        Logfile("Done")
        ToolStripStatusLabel2.Text = "Done"
        ToolStripProgressBar1.Visible = False
        Logfile("Deleting " & ZipToUnpack)
        System.IO.File.Delete(ZipToUnpack)
    End Sub

    Public Sub MyExtractProgress(ByVal sender As Object, ByVal e As Ionic.Zip.ExtractProgressEventArgs)
        Dim PCDone As Int16
        If e.BytesTransferred = 0 Or e.TotalBytesToTransfer = 0 Then
            PCDone = 0
        Else
            PCDone = e.BytesTransferred / (e.TotalBytesToTransfer / 100)
        End If
        ToolStripStatusLabel2.Text = "Extracting " & e.CurrentEntry.ToString.Substring(10, Len(e.CurrentEntry.ToString) - 10) & " (" & PCDone.ToString & "%)"
        StatusStrip1.Refresh()
        ToolStripProgressBar1.Value = PCDone

    End Sub

    Public Function CheckDownloads(ByVal txtFoldername As String)
        Logfile("Checking for " & txtFoldername)
        If System.IO.Directory.Exists(appData & "\downloads\" & txtFoldername) = True Then
            Logfile("Found")
            CheckDownloads = True
        Else
            Logfile("Not found")
            CheckDownloads = False
        End If
    End Function

    Public Function GetHeader()
        Logfile("Checking Pavlov build")
        Dim txt1 As String = ""
        Dim boolTag As Boolean = False
        Dim XMLSTR2 As String = ""
        Dim m_xmld As XmlDocument
        ToolStripStatusLabel2.Text = "Checking Pavlov build"
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
                            txt1 = xmlReader.Value
                        End If
                    End If
                    Exit Select
            End Select
        End While
        Logfile("Found " & txt1)
        GetHeader = txt1
    End Function

    Private Sub txtConsole(ByVal txtMessage As String)
        TextBox2.AppendText(txtMessage & vbCrLf)
        If txtMessage <> "" Then Logfile(txtMessage)
        TextBox2.Refresh()
    End Sub

    Public Function GetQuest()
        Dim txtDevice, txtResponse, txtTEST, T2 As String
        Dim arrResponse As Array
        Dim n As Int16
        Logfile("Finding Quest")
        ToolStripStatusLabel2.Text = "Please connect your Quest ...."
        StatusStrip1.Refresh()
        txtTEST = ""
        txtResponse = _Run(appData & "\ADB\platform-tools\adb.exe", "wait-for-device")
        ResponsiveSleep(1000)
        txtResponse = _Run(appData & "\ADB\platform-tools\adb.exe", " -d devices")
        For n = 0 To Len(txtResponse) - 1
            If Asc(txtResponse.Substring(n, 1)) = 13 Or Asc(txtResponse.Substring(n, 1)) = 10 Or Asc(txtResponse.Substring(n, 1)) = 9 Then
                txtTEST = txtTEST & " "
            Else
                txtTEST = txtTEST & txtResponse.Substring(n, 1)
            End If
            T2 = Trim(txtTEST)
            arrResponse = Split(T2, " ")
        Next
        txtDevice = (arrResponse(UBound(arrResponse) - 1))
        ToolStripStatusLabel2.Text = "Device Found : " & txtDevice
        StatusStrip1.Refresh()
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        FillName()
    End Sub


    Private Function _Run(ByVal txtCommand As String, ByVal txtAugs As String)
        Dim myProcess As Process = New Process()
        Dim s As String

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

        s = sOut.ReadToEnd()

        Do While myProcess.HasExited = False
            ResponsiveSleep(500)
        Loop

        sIn.Close()
        sOut.Close()
        sErr.Close()
        myProcess.Close()
        _Run = s
        ResponsiveSleep(500)
    End Function

    Private Sub Buttons(ByVal Install As Integer, ByVal Update As Integer, ByVal Changename As Integer, ByVal SetPerms As Integer, ByVal Logs As Integer)
        If Install = 1 Then btnUpdate.Enabled = True
        If Install = 2 Then btnUpdate.Enabled = False
        If Update = 1 Then Button1.Enabled = True
        If Update = 2 Then Button1.Enabled = False
        If Changename = 1 Then Button2.Enabled = True
        If Changename = 2 Then Button2.Enabled = False
        If SetPerms = 1 Then Button3.Enabled = True
        If SetPerms = 2 Then Button3.Enabled = False
        If Logs = 1 Then Button4.Enabled = True
        If Logs = 2 Then Button4.Enabled = False
    End Sub



    Private Sub Install_Pavlov()
        Logfile("Installing Pavlov")
        If ComboBox1.SelectedItem.ToString = "" Then
            Logfile("No build selected")
            MsgBox("No build selected")
            Exit Sub
        End If
        Dim txt1 As String = ""
        Dim srcDir As String = appData & "\downloads\" & ComboBox1.SelectedItem & "\"
        If GetQuest() = True Then
            Logfile("Starting Install from " & srcDir)
            ToolStripStatusLabel2.Text = "Starting Install ......"
            TextBox2.Clear()
            TextBox2.Visible = True
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell ""echo $EXTERNAL_STORAGE""")
            extStorage = txt1.Substring(0, Len(txt1) - 2)
            txtConsole("External storage found at " & extStorage)
            txtConsole("")
            txtConsole("Uninstalling existing application. Failures here can almost always be ignored.")
            txtConsole("")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "uninstall com.davevillz.pavlov")
            txtConsole(txt1)
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "uninstall com.vankrupt.pavlov")
            txtConsole(txt1)
            txtConsole("")
            txtConsole("Now installing Pavlov. Failures here indicate a problem with the device (connection or storage permissions) and are fatal.")
            txtConsole("")
            txtConsole("Installing apk ...")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "install " & srcDir & "Pavlov-Android-Shipping-armv7-es2.apk")
            txtConsole("")
            txtConsole(txt1)
            txtConsole("")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/UE4Game/Pavlov")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/UE4Game/UE4CommandLine.txt")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/obb/com.vankrupt.pavlov")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell rm -r " & extStorage & "/Android/obb/com.vankrupt.pavlov")
            txtConsole("Granting Permissions ....")
            txtConsole("")
            txtConsole(" - Record Audio")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO")
            txtConsole(txt1)
            txtConsole(" - Read External Storage")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE")
            txtConsole(txt1)
            txtConsole(" - Write External Storage")
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE")
            txtConsole(txt1)
            txtConsole("")
            txtConsole("Setting name to " & TextBox1.Text)
            WriteNameToFile(TextBox1.Text, srcDir)
            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "push " & srcDir & "name.txt " & extStorage & "/pavlov.name.txt")
            txtConsole(txt1)
            txtConsole("")
            txtConsole("Installing new data. Failures here indicate storage problems (missing SD card or bad permissions) and are fatal.")
            txtConsole("Installing OBB file")

            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "push " & srcDir & "main.22.com.vankrupt.pavlov.obb " & extStorage & "/Download/obb/com.vankrupt.pavlov/main.22.com.vankrupt.pavlov.obb")
            txtConsole(txt1)

            txt1 = _Run(appData & "\ADB\platform-tools\adb.exe", "shell mv " & extStorage & "/Download/obb/com.vankrupt.pavlov " & extStorage & "/Android/obb/com.vankrupt.pavlov")
            txtConsole(txt1)
            txtConsole("")
            txtConsole("All Done.")
            ToolStripStatusLabel2.Text = "All Done"
            ResponsiveSleep(5000)
            TextBox2.Visible = False
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

    Public Function DownloadFile(ByVal _URL As String, ByVal _SaveAs As String)
        Try
            Dim _WebClient As New System.Net.WebClient()
            ' Downloads the resource with the specified URI to a local file.
            _WebClient.DownloadFile(_URL, _SaveAs)
        Catch _Exception As Exception
            ' Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
        End Try
        DownloadFile = ""
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AboutBox1.ShowDialog()
    End Sub
End Class


