# Sparking Zero Audio Importer

Welcome to the **Sparking Zero Audio Importer**! This tool makes it easy to add your own music to *Dragon Ball Sparking! ZERO*.

---

## Features

- **Easy Conversion:**  
  Turn your `.wav` music files into the game's `.hca` format.

- **Song Replacement:**  
  Choose which in-game songs you want to replace.

- **Automatic Mod Creation:**  
  The tool sets up everything you need for the mod to work.

- **Interface for People Who Don't Like Command Line:**  
  Drag and drop your files and let the tool handle the rest.

---

## Requirements

Before you start, you'll need:

- **[Reloaded II](https://gamebanana.com/tools/6693):**  
  A mod loader for the game.

- **[Ryo Framework](https://drive.google.com/file/d/1vV0cy2KvvajQ-RPiK38f8xhVnW10Sfd7/view):**  
  Allows custom audio in the game.

---

## Installation and Setup

### 1. Install Reloaded II

1. Download and install Reloaded II on your computer.
2. Open Reloaded II.
3. Click **Add an Application**.
4. Navigate to your game folder:  
   `DRAGON BALL Sparking! ZERO\SparkingZERO\Binaries\Win64`
5. Select `SparkingZERO-Win64-Shipping.exe`.

### 2. Install Ryo Framework

1. Download Ryo Framework.
2. Place the Ryo Framework folder into the **Mods** folder of Reloaded II:  
   `Desktop\Reloaded-II\Mods`
3. In Reloaded II:
   - Click **Manage Mods**.
   - Find **Ryo Framework** in the list.
   - Enable it for Sparking Zero.

---

## Using the Tool

### 1. Prepare Your Music Files

- Ensure your music files are in `.wav` format.  
  (Audacity is a great tool for this.)  
  Suggested equalization settings in Audacity:  
  - **30–35 LUFS** for BGM.  
  - **15–20 LUFS** for Sparking.

### 2. Run the Tool

- Open `Sparking Zero Audio Importer.exe`.

### 3. Choose Mod Name

- In the **Mod Name** box, type a name for your mod.  
  (This will create a folder with this name in the Mods directory.) 

### 4. Add Your Music Files

- Drag and drop your `.wav` files into the tool's table.  
  The file names will appear in the list.

### 5. Select Songs to Replace

- For each file, choose which in-game song you want to replace from the dropdown menu.  
- Decide if the song should loop by checking or unchecking the **Loop?** box.

### 6. Process the Files

- Click **Create Ryo Mod Folder**.  
  The tool will convert your files and set up the mod automatically.

---

## Activating Your Mod

### 1. Enable Your Mod in Reloaded II

1. Open Reloaded II.
2. Click **Configure Mods**.
3. Find your mod (by the name you chose in the Sparking Zero Audio Importer).
4. Enable it for Sparking Zero.

### 2. Launch the Game

- Start the game through Reloaded II.  
  Your custom music should now play in the game!

---

## Exporting HCA Files Only (Optional)

If you want to just convert `.wav` files to `.hca` without creating a mod:

1. Check the **Export HCA Only** box in the tool.
2. Click **Export HCA Audio Files**.
3. The converted files will be saved in a folder named `Sparking Zero Formatted Songs`.  
   You can manually use these `.hca` files as needed.

---

## What the Tool Automates

- **Audio Conversion:** Converts your `.wav` files to `.hca` format.
- **Mod Setup:** Creates the necessary folders and files for the mod.
- **Configuration:** Generates configuration files required by Reloaded II.

---

## Credits

- **[Saitsu](https://docs.google.com/document/d/1vpbans9a7kV07LiSKn4xjYswoKTunsRFZQbIW2hQRvE/edit?tab=t.0):**  
  Provided the original guide I based the automating process on.

- **[Reloaded II Team](https://github.com/Reloaded-Project/Reloaded-II):**  
  Providing the modding manager platform.

- **[Ryo Framework Developers](https://github.com/RyoTune/Ryo):**  
  Enabling custom audio in the game.

- **[VGAudio Team](https://github.com/Thealexbarney/VGAudio):**  
  Allowing `.wav` to `.hca` conversion.

- **[ANTIBigBoss (Me)](https://github.com/ANTIBigBoss):** 
  Creator of the Sparking Zero Audio Importer.
---
## Donations (Optional)
  - If you like my projects and would like to support me as a developer you can do so at the Ko-Fi link provided below:
  - [Ko-Fi](https://ko-fi.com/antibigboss)
---
