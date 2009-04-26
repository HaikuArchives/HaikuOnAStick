using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

using Haiku.Properties;
using Haiku.Classes;

/* 
 * Copyright 2008 - 2009, Haiku, Inc. All Rights Reserved. 
 * Distributed under the terms of the MIT License. 
 * 
 * Authors: 
 *          Fredrik Modéen, (Firstname@lastname.se)
 *
 * ToDO :
 * - When you select a download site it can look as nothing happens but HaikuOnAStick are getting some data.
 * - Add Welcome package so while waiting one can read them?
 */

namespace Haiku
{
    public partial class HaikuOnAStick : Form
    {
        #region Declarations
        private bool fDeviceExist;
        private bool fErrorHappend;
        private string fOpenFileName;
        private string fBaseDirectory;

        private Color fColorBrowse;
        private Color fColorNetwork;

        private int fSteps;
        private int fAtStep = 1;
        private Classes.Server fServer;

        private Thread fThread;        
        private delegate void WriteToProgressbar(int i);
        private delegate void WriteAString(string str);
        private delegate void WriteTwoStrings(string str1, string str2);
        private delegate void ChangeColor(GroupBox gp, Color c);
        private delegate void SetGUISettings(bool b);
        private delegate void AddObject(object obj);

        #region WriteToUSB
        private List<BackgroundWorker> fBWList;
        private int fNumOfObjWorkedOn;
        #endregion

        #region ZIP
        private string fSourceFile;
        #endregion
        //private string fFileName;
        //private string fSource;

//        private WebClient fWebClient;        

        #endregion
        public HaikuOnAStick()
        {
            InitializeComponent();            
            fColorBrowse = grpBoxBrowse.BackColor;
            fColorNetwork = grpBoxDownload.BackColor;
            openFileDialog.Filter = "Image file (*.image)|*.image|Zip files(*.zip)|*.zip";
            fBaseDirectory = @AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.InitialDirectory = fBaseDirectory;
            btnRefresh_Click(null, null);            
            GetServers();
        }
        #region Developer Made methods
        private void LogError(string str)
        {
            fErrorHappend = true;
            Log(str);
            SetGUI(true);
        }
        public void Log(string str)
        {
            string temp = richTextBox.Text;
            richTextBox.Text = str + "\n";
            richTextBox.Text += temp;
        }

        private void WriteToProgressBarAction(int i)
        {
            if (i < 100)
                progressBar2.Value = i;
        }        
        private void WriteToProgressBarTotal(int i)
        {
            progressBar1.Value = i;
            progressBar2.Value = 0;
        }
        private void ChangeColorGroupBox(GroupBox gp, Color c)
        {
            gp.BackColor = c;
        }
        
        private void GetServers()
        {
            string[] str = Properties.Settings.Default.ServerUrl.Split(';');
            foreach(string s in str)
            {                
                cmbServer.Items.Add(new Classes.Server(s));
            }
        }
        private void AddObjectComboBox(Object obj)
        {
            cmbImage.Items.Add(obj);
            cmbImage.Enabled = true;
        }
        private void GetServerData()
        {
            richTextBox.Invoke(new WriteAString(this.Log), "Get data from server " + fServer.ServerName);
            WebRequest myWebRequest = null;
            WebResponse myWebResponse = null;
            StreamReader readStream = null;
            try
            {
                myWebRequest = WebRequest.Create(fServer.ServerFullPath);
                myWebResponse = myWebRequest.GetResponse();
                Stream ReceiveStream = myWebResponse.GetResponseStream();
                readStream = new StreamReader(ReceiveStream, Encoding.UTF8);

                string input = null;
                string temp;
                while ((input = readStream.ReadLine()) != null)
                {
                    Match m = Regex.Match(input, @Properties.Settings.Default.RegexMatch);
                    if (m.Success)
                    {
                        string[] str = m.Value.Split('/');
                        if (str.Length > 4)
                        {
                            temp = str[4].ToString();
                            temp = temp.Trim();
                            temp = temp.Remove(temp.Length - 1, 1);
                            if (!cmbImage.Items.Contains(temp))
                                cmbImage.Invoke(new AddObject(this.AddObjectComboBox), temp);
                        }
                    }
                }
            }
            catch (WebException wexp)
            {
                richTextBox.Invoke(new WriteAString(this.LogError), wexp.Message);
            }
            catch (Exception ex)
            {
                richTextBox.Invoke(new WriteAString(this.LogError), ex.Message);
            }
            finally
            {
                if (readStream != null && myWebResponse != null)
                {
                    readStream.Close();
                    myWebResponse.Close();
                }
                richTextBox.Invoke(new WriteAString(this.Log), "Done getting server data");
            }
        }

        private void WriteActionLable(string str)
        {
            lblAction.Text = String.Format("Action {0}/{1} : {2}", fAtStep, fSteps, str);
        }
       
        #region SetGUI
        private void SetGUI(bool enabled)
        {
            SetWriteToUSB(!enabled);
            grpBoxBrowse.Enabled = enabled;
            grpBoxDownload.Enabled = enabled;

            if (fDeviceExist)
                btnRefresh.Enabled = enabled;
            chkListBox.Enabled = enabled;
            btnBrowse.Enabled = enabled;
            if (cmbImage.Items.Count > 0)
                cmbImage.Enabled = enabled;
            else
                cmbImage.Enabled = !enabled;
            cmbServer.Enabled = enabled;
        }
        private void SetWriteToUSB(bool enabled)
        {
            btnWriteToUSB.Enabled = enabled;
            btnCancel.Enabled = enabled;
        }
        private void SetSelectedPart(bool first, bool enabled)
        {
            SetGUI(enabled);
            grpBoxBrowse.Enabled = first;
            grpBoxDownload.Enabled = !first;

            btnBrowse.Enabled = !first;
            cmbImage.Enabled = first;
            cmbServer.Enabled = first;
        }
        #endregion
        private void DoneDecompressFile(string str, string fileName)
        {
            Log(str);
            WriteToProgressBarTotal(33 * fAtStep);
            if (!fErrorHappend)
            {
                WriteToFlash(fileName);
            }
        }
        private void DecompressFile(string sourceFile)
        {
            Log("Start Decompressing");
            fAtStep = fSteps - 1;
            WriteActionLable("Decompressing");
            fSourceFile = sourceFile;
            fThread = new Thread(new ThreadStart(DecompressFile));
            fThread.Start();
        }
        private void DecompressFile()
        {
            if (!String.IsNullOrEmpty(fSourceFile))
            {
                try
                {                    
                    FastZipEvents fze = new FastZipEvents();
                    fze.CompletedFile += new CompletedFileHandler(CompletedFile);
                    fze.FileFailure += new FileFailureHandler(FileFailure);
                    fze.Progress += new ProgressHandler(Progress);
                    FastZip fz = new FastZip(fze);
                    fz.ExtractZip(fSourceFile, fBaseDirectory, "");
                }
                catch (Exception ex) {
                    richTextBox.Invoke(new WriteAString(this.LogError), ex.Message);
                }
            }
        }

        private void DoneWritingToFlash(string str)
        {
            Log(str);
            SetGUI(true);
            WriteToProgressBarTotal(33 * fAtStep);
        }
        private void WriteToFlash(string imageName)
        {
            Log("Start Writing to USB");
            fAtStep = fSteps;
            WriteActionLable("Writing to USB");
            string file = fBaseDirectory;
            
            if (useFlashnulToolStripMenuItem.Checked)
                file += Properties.Settings.Default.FlashFileName;
            else
                file += Properties.Settings.Default.FlashFileName;

            string source = string.Empty;

            if (useFlashnulToolStripMenuItem.Checked)
                source = @Settings.Default.FlashFileSource;
            
            if (fBWList == null)
                fBWList = new List<BackgroundWorker>();
            CheckedListBox.CheckedItemCollection obj = chkListBox.CheckedItems;

            ManualResetEvent[] doneEvents = new ManualResetEvent[obj.Count];
            int i = 0;
            foreach (object o in obj)
            {
                if (useFlashnulToolStripMenuItem.Checked)
                    source = string.Format(@Settings.Default.FlashFileSource, o, imageName);
                else
                    source = string.Format(@" {0} -L {1}", o, imageName);
               
                doneEvents[i] = new ManualResetEvent(false);
                USBWriteClass f = new USBWriteClass(file, source, doneEvents[i], this);
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback,i++);
            }
            WorkerCompleted();
        }
        
        private void WorkerCompleted()
        {
            grpBoxBrowse.Invoke(new ChangeColor(this.ChangeColorGroupBox), new object[] { grpBoxBrowse, fColorBrowse });
            grpBoxDownload.Invoke(new ChangeColor(this.ChangeColorGroupBox), new object[] { grpBoxDownload, fColorNetwork });
            this.Invoke(new SetGUISettings(this.SetGUI), true);
            lblAction.Invoke(new WriteAString(this.WriteActionLable), "Done");
            progressBar1.Invoke(new WriteToProgressbar(this.WriteToProgressBarTotal), 100);
        }

        private bool HasRoomForImageAndDownload(int sizeInMB) 
        {
            bool temp = false;
            DriveInfo[] drives = DriveInfo.GetDrives();
            string strDrive = fBaseDirectory.Substring(0, 3);
            foreach (DriveInfo drive in drives)
            {
                if (drive.Name.Equals(strDrive))
                {
                    try
                    {
                        if (((drive.TotalFreeSpace / 1024) / 1024) > (Properties.Settings.Default.USBMemorySize + sizeInMB))
                            temp = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return temp;
        }
        #endregion
        #region Events       
        private void CompletedFile(object sender, ScanEventArgs e)
        {
            richTextBox.Invoke(new WriteTwoStrings(this.DoneDecompressFile), new object[] { "Done Decompressing", fBaseDirectory + e.Name });
        }
        private void FileFailure(object sender, ScanFailureEventArgs e)
        {
            richTextBox.Invoke(new WriteAString(this.LogError), e.Exception.Message);
        }
        private void Progress(object sender, ProgressEventArgs e)
        {            
            progressBar2.Invoke(new WriteToProgressbar(this.WriteToProgressBarAction), (int)e.PercentComplete);
        }

        private void DownLoadFileInBackground(string address, string filename)
        {
            using (WebClient webClient = new WebClient())
            {
                fOpenFileName = filename;
                Uri uri = new Uri(address + filename);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (!HasRoomForImageAndDownload((int)(webResponse.ContentLength / 1024) / 1024))
                {
                    string temp = "You don't have room on your drive to download and extract an image";
                    Log(temp);
                    MessageBox.Show(temp);
                    return;
                }

                WriteActionLable("Downloading");
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                webClient.DownloadFileAsync(uri, filename);
            }
        }
        private void DownloadProgressCallback(Object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Invoke(new WriteToProgressbar(this.WriteToProgressBarAction), e.ProgressPercentage);
        }
        private void DownloadFileCallback(Object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                WriteToProgressBarTotal(33 * fAtStep);
                DecompressFile(fOpenFileName);
            }
        }

        private void cmbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("You have not selected a destination");
                return;
            }
            SetSelectedPart(false, false);
            grpBoxBrowse.BackColor = fColorBrowse;
            grpBoxDownload.BackColor = Color.AliceBlue;
            fSteps = 3;
            progressBar1.Value = 0;
            WriteActionLable("");
            fOpenFileName = "";            
            Log("You have selected file " + cmbImage.SelectedItem.ToString());
        }
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                fServer = cb.SelectedItem as Classes.Server;
                fThread = new Thread(new ThreadStart(GetServerData));
                fThread.Start();

            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection obj = chkListBox.CheckedItems;
            DriveInfo[] drives = DriveInfo.GetDrives();
            string dirName = "";
            foreach (DriveInfo drive in drives)
            {
                dirName = drive.Name.Replace("\\", "");
                if (drive.DriveType == DriveType.Removable)
                {
                    try
                    {
                        if (((drive.TotalSize / 1024) / 1024) > Properties.Settings.Default.USBMemorySize)
                        {
                            if (!chkListBox.Items.Contains(dirName))
                                chkListBox.Items.Add(dirName);
                        }
                    }
                    catch (IOException)
                    {
                        Log("An IOException accured probably are the filesystem not recognized"
                            + "\nWe will run any way but you will need to check that your USB "
                            + "are atleast " + Properties.Settings.Default.USBMemorySize + " big");

                        if (!chkListBox.Items.Contains(dirName))
                            chkListBox.Items.Add(dirName);
                    }
                    catch (Exception ex) 
                    {                        
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            if (chkListBox.Items.Count > 0)
            {
                fDeviceExist = true;
                Log("Device found..");
            }
            else
                Log("No Device was found");

            if (obj.Count > 0)
            {
                foreach (object o in obj) 
                {
                    chkListBox.SelectedItem = o;
                }
            }
            SetGUI(fDeviceExist);
            SetWriteToUSB(false);
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (chkListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("You have not selected a destination");
                return;
            }

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fOpenFileName = openFileDialog.FileName;
                string str = openFileDialog.SafeFileName.ToLower();
                string[] temp = str.Split(new char[]{'.'});
                if (temp[temp.Length-1].ToString().Equals("image"))
                    fSteps = 1;
                else
                    fSteps = 2;
                Log("You have selected file " + fOpenFileName);
                SetSelectedPart(true, false);
                grpBoxBrowse.BackColor = Color.AliceBlue;
                grpBoxDownload.BackColor = fColorNetwork;                
                progressBar1.Value = 0;
                WriteActionLable("");                
                grpBoxBrowse.Focus();
                Invalidate();
            }

            else if (result == DialogResult.Cancel)
            {
                fOpenFileName = "";
                return;
            }
        }        
        private void btnWriteToUSB_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            foreach (object itemChecked in chkListBox.CheckedItems)
            {
                str += itemChecked.ToString() + ", ";
            }

            DialogResult dr = MessageBox.Show("Do you realy want to write a image to " + str, "Write image to USB", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes)
            {
                SetGUI(true);
                SetWriteToUSB(false);
                return;
            }

            try
            {
                SetGUI(false);
                SetWriteToUSB(false);
                if (fSteps == 1)
                {
                    WriteToFlash(fOpenFileName);
                }
                else
                {
                    if (!String.IsNullOrEmpty(fOpenFileName))
                    {
                        DecompressFile(fOpenFileName);
                    }
                    else
                    {
                        DownLoadFileInBackground(@fServer.ServerPath, cmbImage.SelectedItem.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Log("You have Canceled");
            grpBoxBrowse.BackColor = fColorBrowse;
            grpBoxDownload.BackColor = fColorNetwork;
            SetGUI(true);
        }

        private void useToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUSBWriter(false);
        }

        private void dDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUSBWriter(true);
        }

        private void SetUSBWriter(bool useDD)
        {
            useFlashnulToolStripMenuItem.Checked = !useDD;
            useDDToolStripMenuItem.Checked = useDD;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }  
        #endregion
    }
}
