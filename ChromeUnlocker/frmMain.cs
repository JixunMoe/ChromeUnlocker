using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChromeUnlocker
{
    public partial class frmMain : Form
    {

        private DirectoryInfo myChromeDir;
        private DirectoryInfo currentChromeDir;

        private void _err (String errMsg) {
            _log("Error: " + errMsg);
            MessageBox.Show(errMsg, "Chrome Unlocker",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _log(String str)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke((MethodInvoker)delegate
                {
                    _log(str);
                });
                return;
            }
            txtLog.AppendText("\r\n" + str);
#if DEBUG
            Console.WriteLine(str);
#endif
        }

        byte[] W = ByteConv.ByteConv.GetBytes(@"Policies\");
        int wLen = 0;

        // Half Implementation of KMP algorithm without cache table:
        // http://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm#Description_of_pseudocode_for_the_search_algorithm
        private Boolean rm_Policies ( FileStream fs )
        {
            byte[] S = new byte[fs.Length];
            // We're not expecting chrome to be bigger than 2G.
            fs.Read(S, 0, (int)fs.Length);

            var sLen = S.Length;

            var i = 0;
            var m = 0;
            var hasMatch = false;
            
            while (m + i < sLen)
            {
                if (W[i] == S[m + i])
                {
                    if (wLen - 1 == i)
                    {
                        hasMatch = true;

                        // Console.WriteLine("Found a match at {0}", m);
                        S[m] = 65; // A
                        _log (String.Format (@"Patched at position: {0:x}", m));

                        // Reset variables
                        m += i;
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                    m += i;
                    i = 0;
                }
            }

            if (hasMatch)
            {
                fs.Seek(0, SeekOrigin.Begin);
                fs.Write(S, 0, S.Length);
            }

            return hasMatch;
        }

        public frmMain()
        {
            InitializeComponent();
            
            // Init 

            myChromeDir = new DirectoryInfo(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"MyChrome\"
            ));

            currentChromeDir = new DirectoryInfo (Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                @"Google\Chrome\Application\"
            ));

            if (!currentChromeDir.Exists)
            {
                _err("Sorry, can't find Chrome on your machine :<");
                Environment.Exit(1);
            }

            if (!myChromeDir.Exists)
                myChromeDir.Create();

            _log(String.Format("Old Chrome Path: {0}", currentChromeDir));
            _log(String.Format("New Chrome Path: {0}", myChromeDir));
        }

        private void doPatch()
        {
            // Search for app dir
            if (!myChromeDir.Exists)
                myChromeDir.Create();

            DirectoryInfo[] dirs = myChromeDir.GetDirectories();
            DirectoryInfo targetDir = null;
            foreach (var dir in dirs)
            {
                if (dir.GetFiles("chrome.dll").Length > 0)
                {
                    targetDir = dir;
                }
            }

            if (targetDir == null)
            {
                _err("Sorry, can't find a valid chrome.dll :<");
                return;
            }

            foreach (var file in targetDir.GetFiles())
            {
                _log(String.Format("Check file {0}", file.Name));
                FileStream f = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                if (!rm_Policies(f))
                {
                    _log("No hit!");
                }
                f.Close();
            }
        }
        
        public void CopyDir (DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (!target.Exists)
            {
                target.Create();
            }

            // Copy each file into it’s new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                _log(String.Format(@"Copying {0}...", fi.Name));
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);

                _log(String.Format("Enter dir {0}...", diSourceSubDir.Name));
                CopyDir(diSourceSubDir, nextTargetSubDir);
                _log(String.Format("Leave dir {0}...", diSourceSubDir.Name));
            }
        }

        BackgroundWorker bw_patch = null;
        private void btn_Patch_Click(object sender, EventArgs e)
        {
            if (bw_patch == null)
            {
                bw_patch = new BackgroundWorker();
                bw_patch.DoWork += bw_patch_DoWork;
            }
            if (!bw_patch.IsBusy)
                bw_patch.RunWorkerAsync();
        }

        void bw_patch_DoWork(object sender, DoWorkEventArgs e)
        {
            doPatch();
            _log("Patch finished!");
        }

        BackgroundWorker bw_Copy = null;
        private void btn_Copy_Click(object sender, EventArgs e)
        {
            if (bw_Copy == null)
            {
                bw_Copy = new BackgroundWorker();
                bw_Copy.DoWork += bw_DoWork;
            }
            if (!bw_Copy.IsBusy)
                bw_Copy.RunWorkerAsync();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            CopyDir(currentChromeDir, myChromeDir);

            _log("Copy chrome complete.");
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo myChrome = new ProcessStartInfo();
                myChrome.Arguments = "";
                if (chkCustomProfile.Checked)
                {
                    // Dir must not end with \ or it will throw error.
                    myChrome.Arguments +=
                        String.Format(" --user-data-dir=\"{0}\"", txtProfileDir.Text.TrimEnd('\\'));
                }

                if (chkCustomProfileName.Checked)
                {
                    myChrome.Arguments +=
                        String.Format(" \"--profile-directory={0}\"", txtCustomProfileName.Text);
                    
                }

                if (!chkCustomProfile.Checked && !chkCustomProfileName.Checked)
                {
                    _log(">> If it opens old chrome, make sure you have completely shutted down old chrome.");
                }

                if (myChrome.Arguments.Length > 0)
                {
                    _log(String.Format("Launching with argument: {0}", myChrome.Arguments));
                }

                myChrome.FileName = Path.Combine(myChromeDir.FullName, "chrome.exe");
                Process.Start(myChrome);
            }
            catch (Exception ex)
            {
                _log(String.Format("Please copy & patch then execute it, error: {0}", ex.Message));
            }
        }

        private void btn_All_Click(object sender, EventArgs e)
        {

        }

        BackgroundWorker bw_rmChrome = null;
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (bw_rmChrome == null)
            {
                bw_rmChrome = new BackgroundWorker();
                bw_rmChrome.DoWork += bw_rmChrome_DoWork;
            }

            if (!bw_rmChrome.IsBusy)
                bw_rmChrome.RunWorkerAsync();
        }

        void bw_rmChrome_DoWork(object sender, DoWorkEventArgs e)
        {
            _log("Removing MyChrome...");
            try
            {
                Directory.Delete(myChromeDir.FullName, true);
            }
            catch (Exception ex)
            {
                _err(String.Format("Uninstall failed:\n {0}", ex.Message));
                return;
            }
            myChromeDir.Create();
            _log("Done remove MyChrome.");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            // Init W
            wLen = W.Length;

            // Init config
            chkCustomProfile.Checked = Properties.Settings.Default.bUseCustomProfileDirectory;
            chkCustomProfileName.Checked = Properties.Settings.Default.bUseCustomProfileName;

            txtProfileDir.Text = Properties.Settings.Default.sCustomProfileDirectory;
            txtCustomProfileName.Text = Properties.Settings.Default.sCustomProfileName;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _log("Saving config...");
            // Save field value before leave.
            Properties.Settings.Default.bUseCustomProfileDirectory = chkCustomProfile.Checked;
            Properties.Settings.Default.bUseCustomProfileName = chkCustomProfileName.Checked;

            Properties.Settings.Default.sCustomProfileDirectory = txtProfileDir.Text;
            Properties.Settings.Default.sCustomProfileName = txtCustomProfileName.Text;
            Properties.Settings.Default.Save();
        }

        private void btnSelectProfileDir_Click(object sender, EventArgs e)
        {
            var profileDirSelect = new FolderBrowser.FolderBrowser();
            profileDirSelect.DirectoryPath = txtProfileDir.Text;
            if (profileDirSelect.OpenDialog(this, "Select your NEW profile directory"))
            {
                txtProfileDir.Text = profileDirSelect.DirectoryPath;
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = @"Ready.";
        }
    }
}
