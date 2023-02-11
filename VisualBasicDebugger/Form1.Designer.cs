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
            this.btnUnusedVariables = new System.Windows.Forms.Button();
            this.btnGenerateTraceCode = new System.Windows.Forms.Button();
            this.btnColorize = new System.Windows.Forms.Button();
            this.mainTextEditor = new ScintillaNET.Scintilla();
            this.SuspendLayout();
            // 
            // btnUnusedVariables
            // 
            this.btnUnusedVariables.Location = new System.Drawing.Point(1108, 12);
            this.btnUnusedVariables.Name = "btnUnusedVariables";
            this.btnUnusedVariables.Size = new System.Drawing.Size(133, 30);
            this.btnUnusedVariables.TabIndex = 1;
            this.btnUnusedVariables.Text = "Check unused variables";
            this.btnUnusedVariables.UseVisualStyleBackColor = true;
            this.btnUnusedVariables.Click += new System.EventHandler(this.btnUnusedVariables_Click);
            // 
            // btnGenerateTraceCode
            // 
            this.btnGenerateTraceCode.Location = new System.Drawing.Point(1108, 48);
            this.btnGenerateTraceCode.Name = "btnGenerateTraceCode";
            this.btnGenerateTraceCode.Size = new System.Drawing.Size(133, 30);
            this.btnGenerateTraceCode.TabIndex = 4;
            this.btnGenerateTraceCode.Text = "Generate trace code";
            this.btnGenerateTraceCode.UseVisualStyleBackColor = true;
            this.btnGenerateTraceCode.Click += new System.EventHandler(this.btnGenerateTraceCode_Click);
            // 
            // btnColorize
            // 
            this.btnColorize.Location = new System.Drawing.Point(1108, 84);
            this.btnColorize.Name = "btnColorize";
            this.btnColorize.Size = new System.Drawing.Size(133, 30);
            this.btnColorize.TabIndex = 6;
            this.btnColorize.Text = "Colorize";
            this.btnColorize.UseVisualStyleBackColor = true;
            this.btnColorize.Click += new System.EventHandler(this.btnColorize_Click);
            // 
            // mainTextEditor
            // 
            this.mainTextEditor.AutoCMaxHeight = 9;
            this.mainTextEditor.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            this.mainTextEditor.CaretLineBackColor = System.Drawing.Color.Black;
            this.mainTextEditor.CaretLineVisible = false;
            this.mainTextEditor.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainTextEditor.LexerName = null;
            this.mainTextEditor.Location = new System.Drawing.Point(0, 0);
            this.mainTextEditor.Name = "mainTextEditor";
            this.mainTextEditor.ScrollWidth = 351;
            this.mainTextEditor.Size = new System.Drawing.Size(1102, 716);
            this.mainTextEditor.TabIndents = true;
            this.mainTextEditor.TabIndex = 7;
            this.mainTextEditor.Text = resources.GetString("mainTextEditor.Text");
            this.mainTextEditor.UseRightToLeftReadingLayout = false;
            this.mainTextEditor.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 716);
            this.Controls.Add(this.mainTextEditor);
            this.Controls.Add(this.btnColorize);
            this.Controls.Add(this.btnGenerateTraceCode);
            this.Controls.Add(this.btnUnusedVariables);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUnusedVariables;
        private System.Windows.Forms.Button btnGenerateTraceCode;
        private System.Windows.Forms.Button btnColorize;
        private ScintillaNET.Scintilla mainTextEditor;
    }
}

