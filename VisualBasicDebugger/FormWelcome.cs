﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualBasicDebugger {
    public partial class FormWelcome : Form {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

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
            lblTitle1.MouseDown += (object mouseSender, MouseEventArgs mouseArgs) => {
                RedirectMouseInputToForm(mouseArgs);
            };

            lblTitle2.MouseDown += (object mouseSender, MouseEventArgs mouseArgs) => {
                RedirectMouseInputToForm(mouseArgs);
            };
        }

        private void FormWelcome_MouseDown(object sender, MouseEventArgs e) {
            RedirectMouseInputToForm(e);
        }

        private void btnOpenNewProject_Click(object sender, EventArgs e) {
            FormEditor formEditor = new FormEditor();
            formEditor.Show();
        }
    }
}
