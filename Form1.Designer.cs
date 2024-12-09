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
            btnProcess = new System.Windows.Forms.Button();
            txtModName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnClear = new System.Windows.Forms.Button();
            dgvFiles = new System.Windows.Forms.DataGridView();
            FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ReplaceWith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Loop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            chkExportHCAOnly = new System.Windows.Forms.CheckBox();
            btnSelectFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
            SuspendLayout();
            // 
            // btnProcess
            // 
            btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnProcess.Location = new System.Drawing.Point(9, 637);
            btnProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new System.Drawing.Size(771, 45);
            btnProcess.TabIndex = 3;
            btnProcess.Text = "Create Ryo Mod Folder";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // txtModName
            // 
            txtModName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            txtModName.Location = new System.Drawing.Point(14, 43);
            txtModName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtModName.Name = "txtModName";
            txtModName.Size = new System.Drawing.Size(467, 31);
            txtModName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label1.Location = new System.Drawing.Point(10, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(401, 25);
            label1.TabIndex = 5;
            label1.Text = "Enter the Title of your Ryo mod here:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label3.Location = new System.Drawing.Point(4, 113);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(548, 25);
            label3.TabIndex = 7;
            label3.Text = "Drag your audio file(s) here ( .wav/.mp3/.ogg only )";
            // 
            // btnClear
            // 
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnClear.Location = new System.Drawing.Point(667, 113);
            btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(114, 32);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear Table";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvFiles
            // 
            dgvFiles.AllowDrop = true;
            dgvFiles.AllowUserToAddRows = false;
            dgvFiles.BackgroundColor = System.Drawing.Color.Violet;
            dgvFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { FilePath, ReplaceWith, Loop });
            dgvFiles.Location = new System.Drawing.Point(9, 145);
            dgvFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvFiles.Name = "dgvFiles";
            dgvFiles.Size = new System.Drawing.Size(771, 488);
            dgvFiles.TabIndex = 9;
            // 
            // FilePath
            // 
            FilePath.HeaderText = "Song to Import";
            FilePath.Name = "FilePath";
            FilePath.ReadOnly = true;
            // 
            // ReplaceWith
            // 
            ReplaceWith.DataPropertyName = "Constants.Songs";
            ReplaceWith.HeaderText = "Sparking Zero Song to Replace";
            ReplaceWith.Name = "ReplaceWith";
            // 
            // Loop
            // 
            Loop.HeaderText = "Should Song Loop?";
            Loop.Name = "Loop";
            // 
            // chkExportHCAOnly
            // 
            chkExportHCAOnly.AutoSize = true;
            chkExportHCAOnly.BackColor = System.Drawing.Color.Transparent;
            chkExportHCAOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            chkExportHCAOnly.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            chkExportHCAOnly.Location = new System.Drawing.Point(507, 1);
            chkExportHCAOnly.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkExportHCAOnly.Name = "chkExportHCAOnly";
            chkExportHCAOnly.Size = new System.Drawing.Size(225, 76);
            chkExportHCAOnly.TabIndex = 10;
            chkExportHCAOnly.Text = "Click this checkbox if you \r\ndon't want to make a Ryo \r\nReloaded-II Mod and only \r\nwant the .hca audio files";
            chkExportHCAOnly.UseVisualStyleBackColor = false;
            chkExportHCAOnly.CheckedChanged += chkExportHCAOnly_CheckedChanged;
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSelectFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSelectFiles.Location = new System.Drawing.Point(551, 113);
            btnSelectFiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new System.Drawing.Size(114, 32);
            btnSelectFiles.TabIndex = 11;
            btnSelectFiles.Text = "Add Files";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1386, 688);
            Controls.Add(btnSelectFiles);
            Controls.Add(chkExportHCAOnly);
            Controls.Add(dgvFiles);
            Controls.Add(btnClear);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtModName);
            Controls.Add(btnProcess);
            DoubleBuffered = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "ANTIBigBoss' Sparking Zero Audio Import Tool - Version 1.3";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Button btnSelectFiles;
    }
}

