
namespace VisualBasicDebugger.Forms.Welcome {
    partial class FormWelcome {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.borderPanel = new System.Windows.Forms.Panel();
            this.btnOpenNewProject = new System.Windows.Forms.Button();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblOpenRecentProject = new System.Windows.Forms.Label();
            this.lstProjects = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.borderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderPanel
            // 
            this.borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderPanel.Controls.Add(this.btnClose);
            this.borderPanel.Controls.Add(this.btnOpenNewProject);
            this.borderPanel.Controls.Add(this.lblTitle2);
            this.borderPanel.Controls.Add(this.lblTitle1);
            this.borderPanel.Controls.Add(this.lblOpenRecentProject);
            this.borderPanel.Controls.Add(this.lstProjects);
            this.borderPanel.Location = new System.Drawing.Point(0, 0);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(800, 450);
            this.borderPanel.TabIndex = 5;
            this.borderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderPanel_MouseDown);
            // 
            // btnOpenNewProject
            // 
            this.btnOpenNewProject.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnOpenNewProject.FlatAppearance.BorderSize = 0;
            this.btnOpenNewProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenNewProject.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenNewProject.Location = new System.Drawing.Point(541, 219);
            this.btnOpenNewProject.Name = "btnOpenNewProject";
            this.btnOpenNewProject.Size = new System.Drawing.Size(246, 63);
            this.btnOpenNewProject.TabIndex = 9;
            this.btnOpenNewProject.Text = "Open New Project";
            this.btnOpenNewProject.UseVisualStyleBackColor = false;
            this.btnOpenNewProject.Click += new System.EventHandler(this.btnOpenNewProject_Click);
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Microsoft PhagsPa", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.Location = new System.Drawing.Point(479, 39);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(129, 82);
            this.lblTitle2.TabIndex = 8;
            this.lblTitle2.Text = "IDE";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Mistral", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.Location = new System.Drawing.Point(158, 50);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(315, 76);
            this.lblTitle1.TabIndex = 5;
            this.lblTitle1.Text = "Visual Studio";
            // 
            // lblOpenRecentProject
            // 
            this.lblOpenRecentProject.AutoSize = true;
            this.lblOpenRecentProject.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenRecentProject.Location = new System.Drawing.Point(17, 195);
            this.lblOpenRecentProject.Name = "lblOpenRecentProject";
            this.lblOpenRecentProject.Size = new System.Drawing.Size(162, 21);
            this.lblOpenRecentProject.TabIndex = 7;
            this.lblOpenRecentProject.Text = "Open a recent project:";
            // 
            // lstProjects
            // 
            this.lstProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.lstProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstProjects.HideSelection = false;
            this.lstProjects.Location = new System.Drawing.Point(21, 219);
            this.lstProjects.Name = "lstProjects";
            this.lstProjects.Size = new System.Drawing.Size(499, 186);
            this.lstProjects.TabIndex = 6;
            this.lstProjects.TileSize = new System.Drawing.Size(100, 100);
            this.lstProjects.UseCompatibleStateImageBehavior = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(765, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.borderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.FormWelcome_Load);
            this.borderPanel.ResumeLayout(false);
            this.borderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel borderPanel;
        private System.Windows.Forms.Button btnOpenNewProject;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblOpenRecentProject;
        private System.Windows.Forms.ListView lstProjects;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnClose;
    }
}