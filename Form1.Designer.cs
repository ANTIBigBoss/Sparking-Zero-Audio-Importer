namespace SparkingZeroAudioImporter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtModName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplaceWith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkExportHCAOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(8, 555);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(642, 39);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Create Ryo Mod Folder";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtModName
            // 
            this.txtModName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtModName.Location = new System.Drawing.Point(12, 37);
            this.txtModName.Name = "txtModName";
            this.txtModName.Size = new System.Drawing.Size(401, 31);
            this.txtModName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the Title of your Ryo mod here:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(9, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Drag your audio file(s) here ( .wav only )";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(471, 96);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(181, 28);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Entire Table";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowDrop = true;
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.Color.Violet;
            this.dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FilePath,
            this.ReplaceWith,
            this.Loop});
            this.dgvFiles.Location = new System.Drawing.Point(8, 126);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(641, 423);
            this.dgvFiles.TabIndex = 9;
            // 
            // FilePath
            // 
            this.FilePath.HeaderText = "Song to Import";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // ReplaceWith
            // 
            this.ReplaceWith.DataPropertyName = "Constants.Songs";
            this.ReplaceWith.HeaderText = "Sparking Zero Song to Replace";
            this.ReplaceWith.Name = "ReplaceWith";
            // 
            // Loop
            // 
            this.Loop.HeaderText = "Should Song Loop?";
            this.Loop.Name = "Loop";
            // 
            // chkExportHCAOnly
            // 
            this.chkExportHCAOnly.AutoSize = true;
            this.chkExportHCAOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkExportHCAOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExportHCAOnly.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkExportHCAOnly.Location = new System.Drawing.Point(435, 1);
            this.chkExportHCAOnly.Name = "chkExportHCAOnly";
            this.chkExportHCAOnly.Size = new System.Drawing.Size(225, 76);
            this.chkExportHCAOnly.TabIndex = 10;
            this.chkExportHCAOnly.Text = "Click this checkbox if you \r\ndon\'t want to make a Ryo \r\nReloaded-II Mod and only " +
    "\r\nwant the .hca audio files";
            this.chkExportHCAOnly.UseVisualStyleBackColor = false;
            this.chkExportHCAOnly.CheckedChanged += new System.EventHandler(this.chkExportHCAOnly_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1188, 596);
            this.Controls.Add(this.chkExportHCAOnly);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModName);
            this.Controls.Add(this.btnProcess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ANTIBigBoss\' Sparking Zero Audio Import Tool";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtModName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplaceWith;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loop;
        private System.Windows.Forms.CheckBox chkExportHCAOnly;
    }
}

