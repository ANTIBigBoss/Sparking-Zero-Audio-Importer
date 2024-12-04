using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SparkingZeroAudioImporter
{

    public partial class Form1 : Form
    {
        private string baseModPath;

        public Form1()
        {
            InitializeComponent();

            dgvFiles.AllowDrop = true;
            dgvFiles.DragEnter += DgvFiles_DragEnter;
            dgvFiles.DragDrop += DgvFiles_DragDrop;

            InitializeDataGridViewColumns();

            chkExportHCAOnly.CheckedChanged += chkExportHCAOnly_CheckedChanged;
        }


        /// <summary>
        /// Initializes the columns of the DataGridView. I did this here since it seemed easier than navigatng the designer.
        /// Probably not the best way to do it but it works for me.
        /// </summary>
        private void InitializeDataGridViewColumns()
        {
            dgvFiles.Columns.Clear();

            DataGridViewTextBoxColumn fileNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FileName",
                HeaderText = "Audio to Import",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvFiles.Columns.Add(fileNameColumn);

            // Hidden column to store the full file path so the user only sees the file name and the table doesn't get cluttered
            DataGridViewTextBoxColumn fullPathColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullPath",
                HeaderText = "Full Path",
                ReadOnly = true,
                Visible = false
            };
            dgvFiles.Columns.Add(fullPathColumn);

            DataGridViewComboBoxColumn replaceWithColumn = new DataGridViewComboBoxColumn
            {
                Name = "ReplaceWith",
                HeaderText = "Sparking Zero Song to Replace",
                DataSource = Constants.Songs,
                DisplayMember = "DisplayName",
                ValueMember = "FileName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvFiles.Columns.Add(replaceWithColumn);

            DataGridViewCheckBoxColumn loopColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Loop",
                HeaderText = "Loop?",
                TrueValue = true,
                FalseValue = false,
                ValueType = typeof(bool),
                ThreeState = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvFiles.Columns.Add(loopColumn);
        }


        private void DgvFiles_DragEnter(object sender, DragEventArgs e)
        {
            // Allow only file drops
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// Handles the DragDrop event for the DataGridView to add files to the grid.
        /// Automatically assigns songs from Constants.Songs in sequence. As this might be helpful 
        /// if users just want to import a bunch of songs at once. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="DragEventArgs"/> that contains the event data.</param>
        private void DgvFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (Constants.Songs == null || Constants.Songs.Count == 0)
            {
                MessageBox.Show("Constants.Songs Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            int totalSongs = Constants.Songs.Count;

            int existingRows = dgvFiles.Rows.Count;

            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                string extension = Path.GetExtension(file).ToLowerInvariant();

                if (extension == ".wav" || extension == ".mp3" || extension == ".ogg")
                {
                    bool exists = false;
                    foreach (DataGridViewRow row in dgvFiles.Rows)
                    {
                        if (row.Cells["FullPath"].Value.ToString().Equals(file, StringComparison.OrdinalIgnoreCase))
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        int rowIndex = dgvFiles.Rows.Add();
                        dgvFiles.Rows[rowIndex].Cells["FileName"].Value = Path.GetFileName(file);
                        dgvFiles.Rows[rowIndex].Cells["FullPath"].Value = file;

                        int songIndex = (existingRows + i) % totalSongs;

                        dgvFiles.Rows[rowIndex].Cells["ReplaceWith"].Value = Constants.Songs[songIndex].FileName;

                        dgvFiles.Rows[rowIndex].Cells["Loop"].Value = true;
                    }
                }
                else
                {
                    MessageBox.Show("Unsupported file format. Please use .wav, .mp3, or .ogg files.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Handles the Click event of the Process button to start processing the files.
        /// Checks for duplicate song assignments before processing, since we can't have duplicate file
        /// names in the mod folder without issues or overwriting.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!chkExportHCAOnly.Checked)
            {
                baseModPath = HelperMethods.FindOrSetBaseModPath();

                if (string.IsNullOrWhiteSpace(baseModPath))
                {
                    MessageBox.Show("Ryo Reloaded-II Mods folder not found. Please ensure it is installed.", "Mods Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Original logic when not exporting HCA files only
                if (string.IsNullOrWhiteSpace(txtModName.Text))
                {
                    MessageBox.Show("Please enter a mod name.", "Mod Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvFiles.Rows.Count == 0)
                {
                    MessageBox.Show("Please add at least one audio file.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!HelperMethods.EnsureVGAudioCliExists())
                {
                    return;
                }

                // Check for duplicate song replacements
                HashSet<string> songIdentifiers = new HashSet<string>();
                foreach (DataGridViewRow row in dgvFiles.Rows)
                {
                    string songIdentifier = row.Cells["ReplaceWith"].Value as string;
                    if (string.IsNullOrEmpty(songIdentifier))
                    {
                        MessageBox.Show("Please ensure all files have a song selected to replace.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!songIdentifiers.Add(songIdentifier))
                    {
                        MessageBox.Show($"Duplicate song replacement detected for '{songIdentifier}'. Each song can only be replaced once.", "Duplicate Song Replacement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Process each file
                foreach (DataGridViewRow row in dgvFiles.Rows)
                {
                    string inputFile = row.Cells["FullPath"].Value as string;
                    string songIdentifier = row.Cells["ReplaceWith"].Value as string;
                    bool isLooping = row.Cells["Loop"].Value != null && (bool)row.Cells["Loop"].Value;

                    if (string.IsNullOrEmpty(inputFile))
                    {
                        MessageBox.Show("Please ensure all files have a valid file path.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    HelperMethods.ProcessFile(inputFile, songIdentifier, isLooping, txtModName.Text.Trim(), baseModPath);
                }

                // Inform the user where the mod folder was created
                string modFolderPath = Path.Combine(baseModPath, txtModName.Text.Trim());
                MessageBox.Show($"Processing complete. Mod folder created at:\n{modFolderPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Logic when exporting HCA files only
                if (dgvFiles.Rows.Count == 0)
                {
                    MessageBox.Show("Please add at least one audio file.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!HelperMethods.EnsureVGAudioCliExists())
                {
                    return;
                }

                foreach (DataGridViewRow row in dgvFiles.Rows)
                {
                    string inputFile = row.Cells["FullPath"].Value as string;
                    bool isLooping = row.Cells["Loop"].Value != null && (bool)row.Cells["Loop"].Value;

                    if (string.IsNullOrEmpty(inputFile))
                    {
                        MessageBox.Show("Please ensure all files have a valid file path.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    HelperMethods.ProcessFileExportHCAOnly(inputFile, isLooping);
                }

                // Inform the user where the HCA files were saved
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string outputDirectory = Path.Combine(desktopPath, "Sparking Zero Formatted Songs");
                MessageBox.Show($"HCA files exported successfully to:\n{outputDirectory}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of the Clear button to clear the DataGridView. This is useful if the user 
        /// wants to start over, or if they want to create a new mod pack altogether.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvFiles.Rows.Clear();
        }


        /// <summary>
        /// When checked, disables the mod name TextBox, changes the text on the button to be more 
        /// clear as to what the button does, and hides the 'ReplaceWith' column.
        /// When unchecked, enables the mod name TextBox, changes the text on the button back to 
        /// normal which is making a Ryo Mod Folder, and shows the 'ReplaceWith' column.
        ///</summary>
        private void chkExportHCAOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExportHCAOnly.Checked)
            {
                txtModName.Enabled = false;
                txtModName.Text = string.Empty;

                dgvFiles.Columns["ReplaceWith"].Visible = false;
                btnProcess.Text = "Export HCA Audio Files";
            }
            else
            {
                txtModName.Enabled = true;

                dgvFiles.Columns["ReplaceWith"].Visible = true;
                btnProcess.Text = "Create Ryo Mod Folder";
            }
        }

    }
}