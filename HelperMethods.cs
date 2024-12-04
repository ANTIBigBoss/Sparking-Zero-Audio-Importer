using NAudio.Wave;
using NAudio.Vorbis;
using Sparking_Zero_Audio_Importer.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace SparkingZeroAudioImporter
{
    public static class HelperMethods
    {
        /// <summary>
        /// Ensures that VGAudioCli.exe exists in the application directory.
        /// If it doesn't, it automatically downloads it from the specified URL.
        /// </summary>
        /// <returns>True if VGAudioCli.exe is available, false otherwise.</returns>
        public static bool EnsureVGAudioCliExists()
        {
            string vgaudioCliPath = Path.Combine(Application.StartupPath, "VGAudioCli.exe");
            if (File.Exists(vgaudioCliPath))
            {
                return true;
            }
            else
            {
                string downloadUrl = "https://mgs1.blob.core.windows.net/mgs1blob/DBZAudio/VGAudioCli.exe";
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(downloadUrl, vgaudioCliPath);
                    }

                    if (File.Exists(vgaudioCliPath))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to download VGAudioCli.exe.",
                            "Download Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error downloading VGAudioCli.exe:\n{ex.Message}",
                        "Download Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Finds or sets the base mod path where the mods are stored. Attempts to locate the Mods folder or 
        /// prompts the user to select it.
        /// </summary>
        public static string FindOrSetBaseModPath()
        {
            string baseModPath;

            if (!string.IsNullOrEmpty(Settings.Default.BaseModPath) && Directory.Exists(Settings.Default.BaseModPath))
            {
                baseModPath = Settings.Default.BaseModPath;
                return baseModPath;
            }

            // Attempt to find the Reloaded-II\Mods folder in common locations
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

            // If not found, prompt the user to select the Mods folder
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
        /// Validates whether the provided path is a valid Reloaded-II Mods folder.
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

        #region Audio Conversions

        /// <summary>
        /// Converts an audio file (WAV, MP3, OGG) to 16-bit 44.1kHz PCM WAV format.
        /// Returns the path to the converted file.
        /// </summary>
        /// <param name="inputFilePath">The path to the original audio file.</param>
        /// <returns>The path to the converted WAV file.</returns>
        public static string ConvertToPCM(string inputFilePath)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(inputFilePath) + "_converted.wav");

            try
            {
                using (var reader = CreateAudioFileReader(inputFilePath))
                {
                    var newFormat = new WaveFormat(44100, 16, reader.WaveFormat.Channels);
                    using (var conversionStream = new MediaFoundationResampler(reader, newFormat))
                    {
                        conversionStream.ResamplerQuality = 60; // Adjust quality as needed
                        WaveFileWriter.CreateWaveFile(tempFilePath, conversionStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting file '{inputFilePath}':\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return tempFilePath;
        }

        /// <summary>
        /// Creates a WaveStream for the specified audio file.
        /// Supports WAV, MP3, and OGG formats.
        /// </summary>
        /// <param name="filePath">The path to the audio file.</param>
        /// <returns>A WaveStream for the specified file.</returns>
        public static WaveStream CreateAudioFileReader(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".wav":
                    return new WaveFileReader(filePath);
                case ".mp3":
                    return new Mp3FileReader(filePath);
                case ".ogg":
                    return new VorbisWaveReader(filePath); // Requires NAudio.Vorbis
                default:
                    throw new InvalidOperationException("Unsupported file format");
            }
        }

        /// <summary>
        /// Retrieves the duration, sample rate, and total samples of an audio file. This is needed
        /// for knowing if a converted file is valid and for generating the loop parameter for VGAudioCli.
        /// </summary>
        /// <param name="audioFile">The path to the audio file.</param>
        /// <param name="sampleRate">The sample rate of the audio file.</param>
        /// <param name="totalSamples">The total number of samples in the audio file.</param>
        /// <returns>The duration of the audio file as a <see cref="TimeSpan"/>.</returns>
        public static TimeSpan GetAudioFileDuration(string audioFile, out int sampleRate, out int totalSamples)
        {
            try
            {
                using (var reader = CreateAudioFileReader(audioFile))
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
                MessageBox.Show($"Error reading audio file '{audioFile}':\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sampleRate = 0;
                totalSamples = 0;
                return TimeSpan.Zero;
            }
        }

        #endregion

        /// <summary>
        /// Processes an audio file, converting it to an HCA file and placing it in the appropriate mod folder.
        /// Converts the audio file to 16-bit 44.1kHz PCM WAV format if needed.
        /// Generates the ModConfig.json at this point so we can fill the details in it.
        /// </summary>
        /// <param name="inputFile">The path to the audio file to process.</param>
        /// <param name="songIdentifier">The identifier of the song to replace.</param>
        /// <param name="isLooping">Indicates whether the song should loop.</param>
        /// <param name="modName">The name of the mod.</param>
        /// <param name="baseModPath">The base path to the mods folder.</param>
        public static void ProcessFile(string inputFile, string songIdentifier, bool isLooping, string modName, string baseModPath)
        {
            string convertedFile = ConvertToPCM(inputFile);
            if (convertedFile == null)
            {
                return;
            }

            TimeSpan duration = GetAudioFileDuration(convertedFile, out int sampleRate, out int totalSamples);
            if (totalSamples <= 0)
            {
                MessageBox.Show($"Invalid total samples calculated for '{convertedFile}'. If this persists, please raise an issue on GitHub or Nexus Mods.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string loopParameter = isLooping ? $"-l 0-{totalSamples - 1}" : "--no-loop";

            string vgaudioCliPath = Path.Combine(Application.StartupPath, "VGAudioCli.exe");
            if (!File.Exists(vgaudioCliPath))
            {
                MessageBox.Show("VGAudioCli.exe not found in the application directory. Please ensure it is present.", "VGAudioCli.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string outputFileName = songIdentifier;
            string outputHcaPath = Path.Combine(Application.StartupPath, outputFileName);

            string arguments = $"{loopParameter} -i \"{convertedFile}\" -o \"{outputHcaPath}\"";

            File.AppendAllText(Path.Combine(Application.StartupPath, "Sparking Zero Audio Importer Log.txt"), arguments + "\n");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = vgaudioCliPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Application.StartupPath
            };

            Process proc = new Process { StartInfo = psi };

            try
            {
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();

                string logContent = $"Arguments: {arguments}\nOutput:\n{output}\nError:\n{error}\n";
                File.AppendAllText(Path.Combine(Application.StartupPath, "Sparking Zero Audio Importer Log.txt"), logContent);

                if (proc.ExitCode != 0)
                {
                    MessageBox.Show($"Error processing '{inputFile}':\nExit Code: {proc.ExitCode}\nError Output: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(outputHcaPath))
                {
                    MessageBox.Show($"The output HCA file was not created at '{outputHcaPath}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while processing '{inputFile}':\n{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (File.Exists(convertedFile))
                {
                    try
                    {
                        File.Delete(convertedFile);
                    }
                    catch { }
                }
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
        /// Processes an audio file and exports it as an HCA file without creating a mod folder or ModConfig.json file. 
        /// Converts the audio file to 16-bit 44.1kHz PCM WAV format if needed.
        /// Useful for users who just want to convert an audio file to HCA for their own use.
        /// </summary>
        /// <param name="inputFile">The path to the audio file to process.</param>
        /// <param name="isLooping">Indicates whether the song should loop.</param>
        public static void ProcessFileExportHCAOnly(string inputFile, bool isLooping)
        {
            string convertedFile = ConvertToPCM(inputFile);
            if (convertedFile == null)
            {
                return;
            }

            TimeSpan duration = GetAudioFileDuration(convertedFile, out int sampleRate, out int totalSamples);
            if (totalSamples <= 0)
            {
                MessageBox.Show($"Invalid total samples calculated for '{convertedFile}'. If this persists, please raise an issue on GitHub or Nexus Mods.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string loopParameter = isLooping ? $"-l 0-{totalSamples - 1}" : "--no-loop";

            string vgaudioCliPath = Path.Combine(Application.StartupPath, "VGAudioCli.exe");
            if (!File.Exists(vgaudioCliPath))
            {
                MessageBox.Show("VGAudioCli.exe not found in the application directory. Please ensure it is present.", "VGAudioCli.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string originalFileName = Path.GetFileNameWithoutExtension(inputFile);
            string outputFileName = originalFileName + ".hca";

            // Output directory on the desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string outputDirectory = Path.Combine(desktopPath, "Sparking Zero Formatted Songs");
            Directory.CreateDirectory(outputDirectory);

            string outputHcaPath = Path.Combine(outputDirectory, outputFileName);

            string arguments = $"{loopParameter} -i \"{convertedFile}\" -o \"{outputHcaPath}\"";

            File.AppendAllText(Path.Combine(Application.StartupPath, "Sparking Zero Audio Importer Log.txt"), arguments + "\n");

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = vgaudioCliPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = Application.StartupPath
            };

            Process proc = new Process { StartInfo = psi };

            try
            {
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();

                string logContent = $"Arguments: {arguments}\nOutput:\n{output}\nError:\n{error}\n";
                File.AppendAllText(Path.Combine(Application.StartupPath, "Sparking Zero Audio Importer Log.txt"), logContent);

                if (proc.ExitCode != 0)
                {
                    MessageBox.Show($"Error processing '{inputFile}':\nExit Code: {proc.ExitCode}\nError Output: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(outputHcaPath))
                {
                    MessageBox.Show($"The output HCA file was not created at '{outputHcaPath}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception while processing '{inputFile}':\n{ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                // Clean up the converted file
                if (File.Exists(convertedFile))
                {
                    try
                    {
                        File.Delete(convertedFile);
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Generates the ModConfig.json file for the mod in Ryo Reloaded-II.
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
