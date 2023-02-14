﻿using ScintillaNET;
using VisualBasicDebugger.Properties;

namespace VisualBasicDebugger {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerateTraceCode = new System.Windows.Forms.Button();
            this.mainTextEditor = new ScintillaNET.Scintilla();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.btnGenerateTraceCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainTextEditor, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1253, 716);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btnGenerateTraceCode
            // 
            this.btnGenerateTraceCode.Location = new System.Drawing.Point(1106, 3);
            this.btnGenerateTraceCode.Name = "btnGenerateTraceCode";
            this.btnGenerateTraceCode.Size = new System.Drawing.Size(133, 30);
            this.btnGenerateTraceCode.TabIndex = 9;
            this.btnGenerateTraceCode.Text = "Generate trace code";
            this.btnGenerateTraceCode.UseVisualStyleBackColor = true;
            this.btnGenerateTraceCode.Click += new System.EventHandler(this.btnGenerateTraceCode_Click);
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
            this.mainTextEditor.Location = new System.Drawing.Point(3, 3);
            this.mainTextEditor.Name = "mainTextEditor";
            this.mainTextEditor.ScrollWidth = 345;
            this.mainTextEditor.Size = new System.Drawing.Size(1097, 710);
            this.mainTextEditor.TabIndents = true;
            this.mainTextEditor.TabIndex = 10;
            this.mainTextEditor.Text = resources.GetString("mainTextEditor.Text");
            this.mainTextEditor.UseRightToLeftReadingLayout = false;
            this.mainTextEditor.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 716);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGenerateTraceCode;
        private Scintilla mainTextEditor;
    }
}

