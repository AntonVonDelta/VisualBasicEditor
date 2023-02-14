using ScintillaNET;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
            this.tableLayoutPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tabDocuments = new System.Windows.Forms.TabControl();
            this.mainTextEditor = new ScintillaNET.Scintilla();
            this.tableLayoutSideRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerateTraceCode = new System.Windows.Forms.Button();
            this.tableLayoutPrincipal.SuspendLayout();
            this.tableLayoutSideRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPrincipal
            // 
            this.tableLayoutPrincipal.ColumnCount = 2;
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPrincipal.Controls.Add(this.mainTextEditor, 0, 1);
            this.tableLayoutPrincipal.Controls.Add(this.tabDocuments, 0, 0);
            this.tableLayoutPrincipal.Controls.Add(this.tableLayoutSideRight, 1, 0);
            this.tableLayoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPrincipal.Name = "tableLayoutPrincipal";
            this.tableLayoutPrincipal.RowCount = 2;
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPrincipal.Size = new System.Drawing.Size(1253, 716);
            this.tableLayoutPrincipal.TabIndex = 8;
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
            this.mainTextEditor.Size = new System.Drawing.Size(1097, 684);
            this.mainTextEditor.TabIndents = true;
            this.mainTextEditor.TabIndex = 12;
            this.mainTextEditor.Text = resources.GetString("mainTextEditor.Text");
            this.mainTextEditor.UseRightToLeftReadingLayout = false;
            this.mainTextEditor.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // tableLayoutSideRight
            // 
            this.tableLayoutSideRight.ColumnCount = 1;
            this.tableLayoutSideRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSideRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSideRight.Controls.Add(this.btnGenerateTraceCode, 0, 1);
            this.tableLayoutSideRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSideRight.Location = new System.Drawing.Point(1106, 3);
            this.tableLayoutSideRight.Name = "tableLayoutSideRight";
            this.tableLayoutSideRight.RowCount = 2;
            this.tableLayoutPrincipal.SetRowSpan(this.tableLayoutSideRight, 2);
            this.tableLayoutSideRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.54929F));
            this.tableLayoutSideRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.4507F));
            this.tableLayoutSideRight.Size = new System.Drawing.Size(144, 710);
            this.tableLayoutSideRight.TabIndex = 13;
            // 
            // btnGenerateTraceCode
            // 
            this.btnGenerateTraceCode.Location = new System.Drawing.Point(3, 510);
            this.btnGenerateTraceCode.Name = "btnGenerateTraceCode";
            this.btnGenerateTraceCode.Size = new System.Drawing.Size(133, 30);
            this.btnGenerateTraceCode.TabIndex = 13;
            this.btnGenerateTraceCode.Text = "Generate trace code";
            this.btnGenerateTraceCode.UseVisualStyleBackColor = true;
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
            this.tableLayoutSideRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPrincipal;
        private System.Windows.Forms.TabControl tabDocuments;
        private Scintilla mainTextEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSideRight;
        private System.Windows.Forms.Button btnGenerateTraceCode;
    }
}

