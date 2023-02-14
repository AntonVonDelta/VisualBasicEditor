using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualBasicDebugger.Forms.Editor;

namespace VisualBasicDebugger.Forms.Welcome {
    public partial class FormWelcome : Form {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private List<string> historyProjects = new List<string>();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public FormWelcome() {
            InitializeComponent();
        }

        private void RedirectMouseInputToForm(MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FormWelcome_Load(object sender, EventArgs e) {
            if (Properties.Settings.Default.HistoryProjects == null)
                Properties.Settings.Default.HistoryProjects = new List<string>();

            foreach (var projectPath in Properties.Settings.Default.HistoryProjects) {
                var item = new ListViewItem(Path.GetFileName(projectPath));
                item.SubItems.Add(projectPath);
                lstProjects.Items.Add(item);
            }

            lblTitle1.MouseDown += (object mouseSender, MouseEventArgs mouseArgs) => {
                RedirectMouseInputToForm(mouseArgs);
            };

            lblTitle2.MouseDown += (object mouseSender, MouseEventArgs mouseArgs) => {
                RedirectMouseInputToForm(mouseArgs);
            };
        }

        private void btnOpenNewProject_Click(object sender, EventArgs e) {
            string projectPath;
            FormEditor formEditor;
            CommonOpenFileDialog folderBrowserDialog = new CommonOpenFileDialog();

            folderBrowserDialog.InitialDirectory = Directory.GetCurrentDirectory();
            folderBrowserDialog.IsFolderPicker = true;

            if (folderBrowserDialog.ShowDialog() != CommonFileDialogResult.Ok) {
                return;
            }

            projectPath = folderBrowserDialog.FileName;
            formEditor = new FormEditor(projectPath);
            formEditor.Show();

            Properties.Settings.Default.HistoryProjects.Add(projectPath);
            Properties.Settings.Default.Save();
        }

        private void borderPanel_MouseDown(object sender, MouseEventArgs e) {
            RedirectMouseInputToForm(e);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e) {
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e) {
            btnClose.BackColor = Color.FromArgb(251, 251, 251);
            btnClose.ForeColor = Color.Black;
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
