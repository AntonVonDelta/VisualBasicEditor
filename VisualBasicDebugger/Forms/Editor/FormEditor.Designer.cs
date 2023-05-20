using ScintillaNET;
using System.Resources;
using VisualBasicDebugger.Properties;

namespace VisualBasicDebugger.Forms.Editor {
    partial class FormEditor {
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
            this.tableLayoutPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tabView = new System.Windows.Forms.TabControl();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.tabCollapse = new System.Windows.Forms.TabPage();
            this.tabDocuments = new System.Windows.Forms.TabControl();
            this.tableLayoutSideRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerateTraceCode = new System.Windows.Forms.Button();
            this.treeSolutionView = new System.Windows.Forms.TreeView();
            this.mainTextEditor = new ScintillaNET.Scintilla();
            this.tableLayoutPrincipal.SuspendLayout();
            this.tabView.SuspendLayout();
            this.tableLayoutSideRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPrincipal
            // 
            this.tableLayoutPrincipal.ColumnCount = 2;
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPrincipal.Controls.Add(this.tabView, 0, 2);
            this.tableLayoutPrincipal.Controls.Add(this.tabDocuments, 0, 0);
            this.tableLayoutPrincipal.Controls.Add(this.tableLayoutSideRight, 1, 0);
            this.tableLayoutPrincipal.Controls.Add(this.mainTextEditor, 0, 1);
            this.tableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            this.tableLayoutPrincipal.RowCount = 3;
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPrincipal.Size = new System.Drawing.Size(1253, 716);
            this.tableLayoutPrincipal.TabIndex = 8;
            // 
            // tabView
            // 
            this.tabView.Controls.Add(this.tabOutput);
            this.tabView.Controls.Add(this.tabCollapse);
            this.tabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabView.HotTrack = true;
            this.tabView.Location = new System.Drawing.Point(3, 496);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.Size = new System.Drawing.Size(1097, 217);
            this.tabView.TabIndex = 14;
            this.tabView.SelectedIndexChanged += new System.EventHandler(this.tabView_SelectedIndexChanged);
            // 
            // tabOutput
            // 
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(1089, 191);
            this.tabOutput.TabIndex = 0;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // tabCollapse
            // 
            this.tabCollapse.Location = new System.Drawing.Point(4, 22);
            this.tabCollapse.Name = "tabCollapse";
            this.tabCollapse.Padding = new System.Windows.Forms.Padding(3);
            this.tabCollapse.Size = new System.Drawing.Size(1089, 191);
            this.tabCollapse.TabIndex = 1;
            this.tabCollapse.Tag = "Collapse";
            this.tabCollapse.Text = "↓";
            this.tabCollapse.UseVisualStyleBackColor = true;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocuments.HotTrack = true;
            this.tabDocuments.Location = new System.Drawing.Point(3, 3);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.SelectedIndex = 0;
            this.tabDocuments.Size = new System.Drawing.Size(1097, 20);
            this.tabDocuments.TabIndex = 10;
            this.tabDocuments.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabDocuments_Selected);
            // 
            // tableLayoutSideRight
            // 
            this.tableLayoutSideRight.ColumnCount = 1;
            this.tableLayoutSideRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSideRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSideRight.Controls.Add(this.btnGenerateTraceCode, 0, 1);
            this.tableLayoutSideRight.Controls.Add(this.treeSolutionView, 0, 0);
            this.tableLayoutSideRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSideRight.Location = new System.Drawing.Point(1106, 3);
            this.tableLayoutSideRight.Name = "tableLayoutSideRight";
            this.tableLayoutSideRight.RowCount = 2;
            this.tableLayoutPrincipal.SetRowSpan(this.tableLayoutSideRight, 3);
            this.tableLayoutSideRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.54929F));
            this.tableLayoutSideRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.4507F));
            this.tableLayoutSideRight.Size = new System.Drawing.Size(144, 710);
            this.tableLayoutSideRight.TabIndex = 13;
            // 
            // btnGenerateTraceCode
            // 
            this.btnGenerateTraceCode.Location = new System.Drawing.Point(3, 511);
            this.btnGenerateTraceCode.Name = "btnGenerateTraceCode";
            this.btnGenerateTraceCode.Size = new System.Drawing.Size(133, 30);
            this.btnGenerateTraceCode.TabIndex = 13;
            this.btnGenerateTraceCode.Text = "Generate trace code";
            this.btnGenerateTraceCode.UseVisualStyleBackColor = true;
            this.btnGenerateTraceCode.Click += new System.EventHandler(this.btnGenerateTraceCode_Click);
            // 
            // treeSolutionView
            // 
            this.treeSolutionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSolutionView.Location = new System.Drawing.Point(3, 3);
            this.treeSolutionView.Name = "treeSolutionView";
            this.treeSolutionView.Size = new System.Drawing.Size(138, 502);
            this.treeSolutionView.TabIndex = 14;
            // 
            // mainTextEditor
            // 
            this.mainTextEditor.AutoCMaxHeight = 9;
            this.mainTextEditor.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            this.mainTextEditor.CaretLineBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainTextEditor.CaretLineFrame = 1;
            this.mainTextEditor.CaretLineVisible = true;
            this.mainTextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTextEditor.LexerName = null;
            this.mainTextEditor.Location = new System.Drawing.Point(3, 29);
            this.mainTextEditor.Name = "mainTextEditor";
            this.mainTextEditor.ScrollWidth = 345;
            this.mainTextEditor.Size = new System.Drawing.Size(1097, 461);
            this.mainTextEditor.TabIndents = true;
            this.mainTextEditor.TabIndex = 12;
            this.mainTextEditor.UseRightToLeftReadingLayout = false;
            this.mainTextEditor.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 716);
            this.Controls.Add(this.tableLayoutPrincipal);
            this.Name = "FormEditor";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPrincipal.ResumeLayout(false);
            this.tabView.ResumeLayout(false);
            this.tableLayoutSideRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPrincipal;
        private System.Windows.Forms.TabControl tabDocuments;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSideRight;
        private System.Windows.Forms.Button btnGenerateTraceCode;
        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TabPage tabCollapse;
        private System.Windows.Forms.TreeView treeSolutionView;
        private Scintilla mainTextEditor;
    }
}

