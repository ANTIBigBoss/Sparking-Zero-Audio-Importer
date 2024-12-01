using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;
using Sparking_Zero_Audio_Importer.Properties;

namespace SparkingZeroAudioImporter
{
    public static class HelperMethods
    {

        /// <summary>
        /// Finds or sets the base mod path where the mods are stored. Attempts to locate the Mods folder or 
        /// prompts the user to select it. Realistically with Ryo Reloaded-II's base install it should end up 
        /// Desktop/Reloaded-II/Mods I don't think it has options to install elsewhere, granted they could move it.
        /// </summary>
        public static string FindOrSetBaseModPath()
        {
            string baseModPath;

            if (!string.IsNullOrEmpty(Settings.Default.BaseModPath) && Directory.Exists(Settings.Default.BaseModPath))
            {
                baseModPath = Settings.Default.BaseModPath;
                return baseModPath;
            }

            // Attempt to find the Reloaded-II\Mods folder in common locations realistcally it should find
            // it on the desktop since I'm 99% sure that's where Ryo Reloaded-II installs by default.
            List<string> possiblePaths = new List<string>
        {
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reloaded-II", "Mods"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Reloaded-II", "Mods"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Reloaded-II", "Mods"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Reloaded-II", "Mods"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Reloaded-II", "Mods"),
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reloaded-II", "Mods")
        };

            foreach (string path in possiblePaths)
            {
                if (Directory.Exists(path))
                {
                    baseModPath = path;
                    Settings.Default.BaseModPath = baseModPath;
                    Settings.Default.Save();
                    return baseModPath;
                }
            }

            // If not found, prompt the user to select the Mods folder, might remove this if users find it annoying.
            MessageBox.Show("The Reloaded-II Mods folder could not be found. Please select the folder.", "Mods Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the Reloaded-II Mods folder";
                folderDialog.ShowNewFolderButton = false;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;
                    if (IsValidModsFolder(selectedPath))
                    {
                        baseModPath = selectedPath;
                        Settings.Default.BaseModPath = baseModPath;
                        Settings.Default.Save();
                        return baseModPath;
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not appear to be the Reloaded-II Mods folder. Please select the correct folder.", "Invalid Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return FindOrSetBaseModPath(); // Try again
                    }
                }
                else
                {
                    MessageBox.Show("The Mods folder is required to proceed.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    return null;
                }
            }
        }

        /// <summary>
        /// Validates whether the provided path is a valid Reloaded-II Mods folder. If it isn't valid, the user will be prompted to
        /// select the correct folder through a dialog box. Realistcally if it appears the user probably doesn't have 
        /// Ryo Reloaded-II installed, small chance it's located on a different drive. It's good to have this pop up anyway 
        /// so they know something is missing. The readme for this will explain the dependencies needed.
        /// </summary>
        /// <param name="path">The path to validate.</param>
        /// <returns>True if the path is valid; otherwise, false.</returns>
        public static bool IsValidModsFolder(string path)
        {
            var directories = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            bool containsReloadedII = false;
            bool endsWithMods = false;

            foreach (var dir in directories)
            {
                if (string.Equals(dir, "Reloaded-II", StringComparison.OrdinalIgnoreCase))
                {
                    containsReloadedII = true;
                }
            }

            if (string.Equals(Path.GetFileName(path), "Mods", StringComparison.OrdinalIgnoreCase))
            {
                endsWithMods = true;
            }

            return containsReloadedII && endsWithMods;
        }

        /// <summary>
        /// Retrieves the duration, sample rate, and total samples of a WAV file. These are required for the 
        /// command line arguments of VGAudioCli.exe. The basic math is: totalSamples = totalBytes / (bytesPerSample * channels).
        /// </summary>
        /// <param name="wavFile">The path to the WAV file.</param>
        /// <param name="sampleRate">The sample rate of the WAV file.</param>
        /// <param name="totalSamples">The total number of samples in the WAV file.</param>
        /// <returns>The duration of the WAV file as a <see cref="TimeSpan"/>.</returns>
        public static TimeSpan GetWavFileDuration(string wavFile, out int sampleRate, out int totalSamples)
        {
            try
            {
                using (var reader = new AudioFileReader(wavFile))
                {
                    sampleRate = reader.WaveFormat.SampleRate;
                    int bitsPerSample = reader.WaveFormat.BitsPerSample;
                    int channels = reader.WaveFormat.Channels;
                    long totalBytes = reader.Length;
                    int bytesPerSample = bitsPerSample / 8;
                    totalSamples = (int)(totalBytes / (bytesPerSample * channels));

                    return reader.TotalTime;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading WAV file duration:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sampleRate = 0;
                totalSamples = 0;
                return TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Processes a WAV file, converting it to an HCA file and placing it in the appropriate mod folder.
        /// Generates the ModConfig.json at this point so we can fill the details in it.
        /// </summary>
        /// <param name="wavFile">The path to the WAV file to process.</param>
        /// <param name="songIdentifier">The identifier of the song to replace.</param>
        /// <param name="isLooping">Indicates whether the song should loop.</param>
        /// </summary>
        public static void ProcessFile(string wavFile, string songIdentifier, bool isLooping, string modName, string baseModPath)
        {
            TimeSpan duration = GetWavFileDuration(wavFile, out int sampleRate, out int totalSamples);
            if (totalSamples <= 0)
            {
                MessageBox.Show($"Invalid total samples calculated for {wavFile}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string loopParameter = isLooping ? $"-l 0-{totalSamples - 1}" : "--no-loop";

            // Use VGAudioCli.exe from the application directory, unless the user moves it this should work with no issues.
            string vgaudioCliPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VGAudioCli.exe");
            if (!File.Exists(vgaudioCliPath))
            {
                MessageBox.Show("VGAudioCli.exe not found in the application directory. Please ensure it is present.", "VGAudioCli.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string outputFileName = songIdentifier;

            string outputHcaPath = Path.Combine(Environment.CurrentDirectory, outputFileName);

            string arguments = $"{loopParameter} -i \"{wavFile}\" \"{outputHcaPath}\"";

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sparking Zero Audio Importer Log.txt"), arguments + "\n");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = vgaudioCliPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Environment.CurrentDirectory
            };

            Process proc = new Process { StartInfo = psi };

            try
            {
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sparking Zero Audio Importer Log.txt"), output + error + "\n");

                if (proc.ExitCode != 0)
                {
                    MessageBox.Show($"Error processing {wavFile}:\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(outputHcaPath))
                {
                    MessageBox.Show($"The output HCA file was not created at {outputHcaPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while processing {wavFile}:\n{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string modFolderPath = Path.Combine(baseModPath, modName);
            string ryoFolderPath = Path.Combine(modFolderPath, "Ryo", "SPARKINGZERO-WIN64-SHIPPING", "bgm_main.acb");

            Directory.CreateDirectory(ryoFolderPath);

            string destinationHcaFile = Path.Combine(ryoFolderPath, outputFileName);

            if (File.Exists(destinationHcaFile))
                File.Delete(destinationHcaFile);

            File.Move(outputHcaPath, destinationHcaFile);

            string modConfigPath = Path.Combine(modFolderPath, "ModConfig.json");
            if (!File.Exists(modConfigPath))
            {
                GenerateModConfig(modConfigPath, modName);
            }
        }

        /// <summary>
        /// Basically the same as ProcessFile but this one just doesn't create a mod folder or ModConfig.json file.
        /// Helpful for users who just want to convert a WAV to HCA for their own personal use, or for modders who
        /// have a different method of creating their mods, or may already have a mod folder to add to.
        /// </summary>
        /// <param name="wavFile"></param>
        /// <param name="isLooping"></param>
        public static void ProcessFileExportHCAOnly(string wavFile, bool isLooping)
        {
            TimeSpan duration = GetWavFileDuration(wavFile, out int sampleRate, out int totalSamples);
            if (totalSamples <= 0)
            {
                MessageBox.Show($"Invalid total samples calculated for {wavFile}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string loopParameter = isLooping ? $"-l 0-{totalSamples - 1}" : "--no-loop";

            string vgaudioCliPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VGAudioCli.exe");
            if (!File.Exists(vgaudioCliPath))
            {
                MessageBox.Show("VGAudioCli.exe not found in the application directory. Please ensure it is present.", "VGAudioCli.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string originalFileName = Path.GetFileNameWithoutExtension(wavFile);
            string outputFileName = originalFileName + ".hca";

            string outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sparking Zero Formatted Songs");
            Directory.CreateDirectory(outputDirectory);

            string outputHcaPath = Path.Combine(outputDirectory, outputFileName);

            string arguments = $"{loopParameter} -i \"{wavFile}\" \"{outputHcaPath}\"";

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sparking Zero Audio Importer Log.txt"), arguments + "\n");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = vgaudioCliPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Environment.CurrentDirectory
            };

            Process proc = new Process { StartInfo = psi };

            try
            {
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sparking Zero Audio Importer Log.txt"), output + error + "\n");

                if (proc.ExitCode != 0)
                {
                    MessageBox.Show($"Error processing {wavFile}:\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(outputHcaPath))
                {
                    MessageBox.Show($"The output HCA file was not created at {outputHcaPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while processing {wavFile}:\n{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        /// <summary>
        /// Generates the ModConfig.json file for the mod in Ryo Reloaded-II. This will take the name they wrote in the 
        /// textbox earlier and use it to fill in the ModConfig.json file. This will make it easier for users to submit 
        /// their mods to game modding sites.
        /// </summary>
        /// <param name="modConfigPath">The path where ModConfig.json will be created.</param>
        /// <param name="modName">The name of the mod.</param>
        public static void GenerateModConfig(string modConfigPath, string modName)
        {
            string modConfigContent = $@"{{
      ""ModId"": ""{modName}"",
      ""ModName"": ""{modName}"",
      ""ModAuthor"": ""ANTIBigBoss's Audio Import Tool"",
      ""ModVersion"": ""1.0.0"",
      ""ModDescription"": ""Auto-generated audio mod named: {modName} for Dragon Ball Sparking Zero."",
      ""ModDll"": """",
      ""ModIcon"": """",
      ""ModR2RManagedDll32"": """",
      ""ModR2RManagedDll64"": """",
      ""ModNativeDll32"": """",
      ""ModNativeDll64"": """",
      ""Tags"": [],
      ""CanUnload"": null,
      ""HasExports"": null,
      ""IsLibrary"": false,
      ""ReleaseMetadataFileName"": ""{modName}.ReleaseMetadata.json"",
      ""PluginData"": {{
        ""GameBananaDependencies"": {{
          ""IdToConfigMap"": {{
            ""Ryo.Reloaded"": {{
              ""Config"": {{
                ""ItemType"": ""Mod"",
                ""ItemId"": 495507
              }},
              ""ReleaseMetadataName"": ""Ryo.Reloaded.ReleaseMetadata.json""
            }}
          }}
        }},
        ""GitHubDependencies"": {{
          ""IdToConfigMap"": {{
            ""reloaded.sharedlib.hooks"": {{
              ""Config"": {{
                ""UserName"": ""Sewer56"",
                ""RepositoryName"": ""Reloaded.SharedLib.Hooks.ReloadedII"",
                ""UseReleaseTag"": true,
                ""AssetFileName"": ""reloaded.sharedlib.hooks.zip""
              }},
              ""ReleaseMetadataName"": ""Sewer56.Update.ReleaseMetadata.json""
            }},
            ""SharedScans.Reloaded"": {{
              ""Config"": {{
                ""UserName"": ""RyoTune"",
                ""RepositoryName"": ""SharedScans"",
                ""UseReleaseTag"": false,
                ""AssetFileName"": ""Mod.zip""
              }},
              ""ReleaseMetadataName"": ""SharedScans.Reloaded.ReleaseMetadata.json""
            }},
            ""Reloaded.Memory.SigScan.ReloadedII"": {{
              ""Config"": {{
                ""UserName"": ""Reloaded-Project"",
                ""RepositoryName"": ""Reloaded.Memory.SigScan"",
                ""UseReleaseTag"": false,
                ""AssetFileName"": ""Mod.zip""
              }},
              ""ReleaseMetadataName"": ""Reloaded.Memory.SigScan.ReloadedII.ReleaseMetadata.json""
            }}
          }}
        }}
      }},
      ""IsUniversalMod"": false,
      ""ModDependencies"": [
        ""Ryo.Reloaded""
      ],
      ""OptionalDependencies"": [],
      ""SupportedAppId"": [
        ""sparkingzero-win64-shipping.exe""
      ],
      ""ProjectUrl"": """"
    }}";

            File.WriteAllText(modConfigPath, modConfigContent);
        }
    }
}