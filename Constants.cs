using System.Collections.Generic;

namespace SparkingZeroAudioImporter
{
    public static class Constants
    {
        /// <summary>
        /// Class to hold all relevant information for each song in the game so it can be displayed in the ComboBox
        /// without us having to fill it in manually for all songs and their sparking versions.
        /// </summary>
        public class SongInfo
        {
            // This will be used to populate the ComboBox for the user to decide which song to replace
            public string DisplayName { get; set; }
            // This will be used to name the file in the .hca format after VGAudioCLI has converted it
            public string FileName { get; set; }
        }

        public static List<SongInfo> Songs = new List<SongInfo>
        {
            // ACB: bgm_main || Cue: 990001 / M_0001
            new SongInfo { DisplayName = "Main Menu Theme", FileName = "M_0001.hca" },

            // ACB: bgm_main || Cue: 990100 / M_0100
            new SongInfo { DisplayName = "Dragon Ball: Sparking! ZERO (Battle Version)", FileName = "M_0100.hca" },

            // ACB: bgm_main || Cue: 990101 / M_0101
            new SongInfo { DisplayName = "Survivor", FileName = "M_0101.hca" },

            // ACB: bgm_main || Cue: 990102 / M_0102
            new SongInfo { DisplayName = "Let the Battle Begin", FileName = "M_0102.hca" },

            // ACB: bgm_main || Cue: 990103 / M_0103
            new SongInfo { DisplayName = "Flurry of Power", FileName = "M_0103.hca" },

            // ACB: bgm_main || Cue: 990104 / M_0104
            new SongInfo { DisplayName = "Believe in Tomorrow", FileName = "M_0104.hca" },

            // ACB: bgm_main || Cue: 990105 / M_0105
            new SongInfo { DisplayName = "Looming Fear", FileName = "M_0105.hca" },

            // ACB: bgm_main || Cue: 990106 / M_0106
            new SongInfo { DisplayName = "Elite Squad", FileName = "M_0106.hca" },

            // ACB: bgm_main || Cue: 990107 / M_0107
            new SongInfo { DisplayName = "Cold-Blooded", FileName = "M_0107.hca" },

            // ACB: bgm_main || Cue: 990108 / M_0108
            new SongInfo { DisplayName = "Death Game", FileName = "M_0108.hca" },

            // ACB: bgm_main || Cue: 990109 / M_0109
            new SongInfo { DisplayName = "I Am the Devil", FileName = "M_0109.hca" },

            // ACB: bgm_main || Cue: 990110 / M_0110
            new SongInfo { DisplayName = "Ascending Hope", FileName = "M_0110.hca" },

            // ACB: bgm_main || Cue: 990111 / M_0111
            new SongInfo { DisplayName = "Limit Breaker", FileName = "M_0111.hca" },

            // ACB: bgm_main || Cue: 990112 / M_0112
            new SongInfo { DisplayName = "Ultimate Impact", FileName = "M_0112.hca" },

            // ACB: bgm_main || Cue: 990113 / M_0113
            new SongInfo { DisplayName = "Adventuring through the Universe", FileName = "M_0113.hca" },

            // ACB: bgm_main || Cue: 990114 / M_0114
            new SongInfo { DisplayName = "Counterattack", FileName = "M_0114.hca" },

            // ACB: bgm_main || Cue: 990115 / M_0115
            new SongInfo { DisplayName = "The Adventure Begins", FileName = "M_0115.hca" },

            // ACB: bgm_main || Cue: 990116 / M_0116
            new SongInfo { DisplayName = "ZENKAI POWER", FileName = "M_0116.hca" },

            // ACB: bgm_main || Cue: 990117 / M_0117
            new SongInfo { DisplayName = "Dragon Spirit", FileName = "M_0117.hca" },

            // ACB: bgm_main || Cue: 990118 / M_0118
            new SongInfo { DisplayName = "My Hero", FileName = "M_0118.hca" },

            // ACB: bgm_main || Cue: 990119 / M_0119
            new SongInfo { DisplayName = "The Greatest Champion", FileName = "M_0119.hca" },

            // ACB: bgm_main || Cue: 990120 / M_0120
            new SongInfo { DisplayName = "Day of Awakening", FileName = "M_0120.hca" },

            // ACB: bgm_main || Cue: 990121 / M_0121
            new SongInfo { DisplayName = "The Final Battle", FileName = "M_0121.hca" },

            // ACB: bgm_main || Cue: 990122 / M_0122
            new SongInfo { DisplayName = "The Last Resort", FileName = "M_0122.hca" },

            // ACB: bgm_main || Cue: 991000 / M_1000
            new SongInfo { DisplayName = "Fighting Spirit", FileName = "M_1000.hca" },

            // ACB: bgm_main || Cue: 991001 / M_1001
            new SongInfo { DisplayName = "Ultra Instinct", FileName = "M_1001.hca" },

            // ACB: bgm_main || Cue: 991002 / M_1002
            new SongInfo { DisplayName = "Let's Rock!", FileName = "M_1002.hca" },

            // ACB: bgm_main || Cue: 991003 / M_1003
            new SongInfo { DisplayName = "Ultimate Fusion", FileName = "M_1003.hca" },

            // ACB: bgm_main || Cue: 991004 / M_1004
            new SongInfo { DisplayName = "Ego above All", FileName = "M_1004.hca" },

            // ACB: bgm_main || Cue: 991005 / M_1005
            new SongInfo { DisplayName = "Evolution", FileName = "M_1005.hca" },

            // ACB: bgm_main || Cue: 991006 / M_1006
            new SongInfo { DisplayName = "Super Earthling", FileName = "M_1006.hca" },

            // ACB: bgm_main || Cue: 991007 / M_1007
            new SongInfo { DisplayName = "Hidden Potential", FileName = "M_1007.hca" },

            // ACB: bgm_main || Cue: 991008 / M_1008
            new SongInfo { DisplayName = "Awakened Child", FileName = "M_1008.hca" },

            // ACB: bgm_main || Cue: 991009 / M_1009
            new SongInfo { DisplayName = "Next-Gen Hero", FileName = "M_1009.hca" },

            // ACB: bgm_main || Cue: 991010 / M_1010
            new SongInfo { DisplayName = "Hidden Power Unleashed", FileName = "M_1010.hca" },

            // ACB: bgm_main || Cue: 991011 / M_1011
            new SongInfo { DisplayName = "Beyond Good and Evil", FileName = "M_1011.hca" },

            // ACB: bgm_main || Cue: 991012 / M_1012
            new SongInfo { DisplayName = "Hope for the Future", FileName = "M_1012.hca" },

            // ACB: bgm_main || Cue: 991013 / M_1013
            new SongInfo { DisplayName = "Lone Wolf", FileName = "M_1013.hca" },

            // ACB: bgm_main || Cue: 991014 / M_1014
            new SongInfo { DisplayName = "Monk-in-Training", FileName = "M_1014.hca" },

            // ACB: bgm_main || Cue: 991015 / M_1015
            new SongInfo { DisplayName = "Master", FileName = "M_1015.hca" },

            // ACB: bgm_main || Cue: 991016 / M_1016
            new SongInfo { DisplayName = "Reign of Terror", FileName = "M_1016.hca" },

            // ACB: bgm_main || Cue: 991017 / M_1017
            new SongInfo { DisplayName = "Ruler of Fear", FileName = "M_1017.hca" },

            // ACB: bgm_main || Cue: 991018 / M_1018
            new SongInfo { DisplayName = "The Most Malevolent Ever", FileName = "M_1018.hca" },

            // ACB: bgm_main || Cue: 991019 / M_1019
            new SongInfo { DisplayName = "Ultimate Cells", FileName = "M_1019.hca" },

            // ACB: bgm_main || Cue: 991020 / M_1020
            new SongInfo { DisplayName = "Ceaseless Terror", FileName = "M_1020.hca" },

            // ACB: bgm_main || Cue: 991021 / M_1021
            new SongInfo { DisplayName = "Innocent Assault", FileName = "M_1021.hca" },

            // ACB: bgm_main || Cue: 991022 / M_1022
            new SongInfo { DisplayName = "Divine Grudge", FileName = "M_1022.hca" },

            // ACB: bgm_main || Cue: 991023 / M_1023
            new SongInfo { DisplayName = "Black Roses", FileName = "M_1023.hca" },

            // ACB: bgm_main || Cue: 991024 / M_1024
            new SongInfo { DisplayName = "The Immortal Divine", FileName = "M_1024.hca" },

            // ACB: bgm_main || Cue: 991025 / M_1025
            new SongInfo { DisplayName = "Strength is Justice", FileName = "M_1025.hca" },

            // ACB: bgm_main || Cue: 991026 / M_1026
            new SongInfo { DisplayName = "Nothing to Lose", FileName = "M_1026.hca" },

            // ACB: bgm_main || Cue: 991027 / M_1027
            new SongInfo { DisplayName = "Super Saiyan", FileName = "M_1027.hca" },

            // ACB: bgm_main || Cue: 991028 / M_1028
            new SongInfo { DisplayName = "True Form", FileName = "M_1028.hca" },

            // ACB: bgm_main || Cue: 991029 / M_1029
            new SongInfo { DisplayName = "Great Ape", FileName = "M_1029.hca" },

            // ACB: bgm_main || Cue: 991030 / M_1030
            new SongInfo { DisplayName = "Within the Light", FileName = "M_1030.hca" },

            // ACB: bgm_main || Cue: 991031 / M_1031
            new SongInfo { DisplayName = "Evil United", FileName = "M_1031.hca" },

            // ACB: bgm_main || Cue: 991032 / M_1032
            new SongInfo { DisplayName = "Pride Troopers", FileName = "M_1032.hca" },

            // ACB: bgm_main || Cue: 991033 / M_1033
            new SongInfo { DisplayName = "God of Destruction", FileName = "M_1033.hca" },

            // ACB: bgm_main || Cue: 991034 / M_1034
            new SongInfo { DisplayName = "Hero of Justice", FileName = "M_1034.hca" },

            // ACB: bgm_main || Cue: 991035 / M_1035
            new SongInfo { DisplayName = "Malice", FileName = "M_1035.hca" },

            // ACB: bgm_main || Cue: 991036 / M_1036
            new SongInfo { DisplayName = "Strangely Innocent", FileName = "M_1036.hca" },

            // ACB: bgm_main || Cue: 991037 / M_1037
            new SongInfo { DisplayName = "Strangely Evil", FileName = "M_1037.hca" },

            // ACB: bgm_main || Cue: 991038 / M_1038
            new SongInfo { DisplayName = "Slapstick Heroes", FileName = "M_1038.hca" },

            // ACB: bgm_main || Cue: 991039 / M_1039
            new SongInfo { DisplayName = "Berserker", FileName = "M_1039.hca" },

            // ACB: bgm_main || Cue: 991040 / M_1040
            new SongInfo { DisplayName = "Realm of the Gods", FileName = "M_1040.hca" },

            // ACB: bgm_main || Cue: 991041 / M_1041
            new SongInfo { DisplayName = "Valkyrie", FileName = "M_1041.hca" },

            // ACB: bgm_main || Cue: 991042 / M_1042
            new SongInfo { DisplayName = "The Power of Love", FileName = "M_1042.hca" },

            // ACB: bgm_main || Cue: 991043 / M_1043
            new SongInfo { DisplayName = "Cruel Galaxy", FileName = "M_1043.hca" },

            // ACB: bgm_main || Cue: 991044 / M_1044
            new SongInfo { DisplayName = "Legendary Warrior", FileName = "M_1044.hca" },

            // ACB: bgm_main || Cue: 10011001 / M_1100
            new SongInfo { DisplayName = "Genkai Toppa X Survivor", FileName = "M_1100.hca" },

            // ACB: bgm_main || Cue: 999999 / BGM_STOP
            new SongInfo { DisplayName = "No Music Option", FileName = "BGM_STOP.hca" },

            // ACB: bgm_main || Cue: 990200 / M_0200
            new SongInfo { DisplayName = "Sparking - Impartial Justice", FileName = "M_0200.hca" },

            // ACB: bgm_main || Cue: 990201 / M_0201
            new SongInfo { DisplayName = "Sparking - Dreadful Villain", FileName = "M_0201.hca" },

            // ACB: bgm_main || Cue: 990202 / M_0202
            new SongInfo { DisplayName = "Sparking - Morally Gray", FileName = "M_0202.hca" },

            // ACB: bgm_main || Cue: 990203 / M_0203
            new SongInfo { DisplayName = "Sparking - Divine Judgment", FileName = "M_0203.hca" },

            // ACB: bgm_main || Cue: 990204 / M_0204
            new SongInfo { DisplayName = "Sparking - Effortless Delights", FileName = "M_0204.hca" },

            // ACB: bgm_main || Cue: 990205 / M_0205
            new SongInfo { DisplayName = "Sparking - Malicious Intent", FileName = "M_0205.hca" },

            // ACB: bgm_main || Cue: 990206 / M_0206
            new SongInfo { DisplayName = "Sparking - Ultimate Survivor", FileName = "M_0206.hca" },

            // ACB: bgm_main || Cue: 990207 / M_0207
            new SongInfo { DisplayName = "Sparking - Absolute Domination", FileName = "M_0207.hca" },

            // ACB: bgm_main || Cue: 990208 / M_0208
            new SongInfo { DisplayName = "Sparking - Swirling Chaos", FileName = "M_0208.hca" },

            // ACB: bgm_main || Cue: 1001000 / M_1000_SPK
            new SongInfo { DisplayName = "Sparking - Fighting Spirit", FileName = "M_1000_SPK.hca" },

            // ACB: bgm_main || Cue: 1001001 / M_1001_SPK
            new SongInfo { DisplayName = "Sparking - Ultra Instinct", FileName = "M_1001_SPK.hca" },

            // ACB: bgm_main || Cue: 1001002 / M_1002_SPK
            new SongInfo { DisplayName = "Sparking - Let's Rock!", FileName = "M_1002_SPK.hca" },

            // ACB: bgm_main || Cue: 1001003 / M_1003_SPK
            new SongInfo { DisplayName = "Sparking - Ultimate Fusion", FileName = "M_1003_SPK.hca" },

            // ACB: bgm_main || Cue: 1001004 / M_1004_SPK
            new SongInfo { DisplayName = "Sparking - Ego above All", FileName = "M_1004_SPK.hca" },

            // ACB: bgm_main || Cue: 1001005 / M_1005_SPK
            new SongInfo { DisplayName = "Sparking - Evolution", FileName = "M_1005_SPK.hca" },

            // ACB: bgm_main || Cue: 1001006 / M_1006_SPK
            new SongInfo { DisplayName = "Sparking - Super Earthling", FileName = "M_1006_SPK.hca" },

            // ACB: bgm_main || Cue: 1001007 / M_1007_SPK
            new SongInfo { DisplayName = "Sparking - Hidden Potential", FileName = "M_1007_SPK.hca" },

            // ACB: bgm_main || Cue: 1001008 / M_1008_SPK
            new SongInfo { DisplayName = "Sparking - Awakened Child", FileName = "M_1008_SPK.hca" },

            // ACB: bgm_main || Cue: 1001009 / M_1009_SPK
            new SongInfo { DisplayName = "Sparking - Next-Gen Hero", FileName = "M_1009_SPK.hca" },

            // ACB: bgm_main || Cue: 1001010 / M_1010_SPK
            new SongInfo { DisplayName = "Sparking - Hidden Power Unleashed", FileName = "M_1010_SPK.hca" },

            // ACB: bgm_main || Cue: 1001011 / M_1011_SPK
            new SongInfo { DisplayName = "Sparking - Beyond Good and Evil", FileName = "M_1011_SPK.hca" },

            // ACB: bgm_main || Cue: 1001012 / M_1012_SPK
            new SongInfo { DisplayName = "Sparking - Hope for the Future", FileName = "M_1012_SPK.hca" },

            // ACB: bgm_main || Cue: 1001013 / M_1013_SPK
            new SongInfo { DisplayName = "Sparking - Lone Wolf", FileName = "M_1013_SPK.hca" },

            // ACB: bgm_main || Cue: 1001014 / M_1014_SPK
            new SongInfo { DisplayName = "Sparking - Monk-in-Training", FileName = "M_1014_SPK.hca" },

            // ACB: bgm_main || Cue: 1001015 / M_1015_SPK
            new SongInfo { DisplayName = "Sparking - Master", FileName = "M_1015_SPK.hca" },

            // ACB: bgm_main || Cue: 1001016 / M_1016_SPK
            new SongInfo { DisplayName = "Sparking - Reign of Terror", FileName = "M_1016_SPK.hca" },

            // ACB: bgm_main || Cue: 1001017 / M_1017_SPK
            new SongInfo { DisplayName = "Sparking - Ruler of Fear", FileName = "M_1017_SPK.hca" },

            // ACB: bgm_main || Cue: 1001018 / M_1018_SPK
            new SongInfo { DisplayName = "Sparking - The Most Malevolent Ever", FileName = "M_1018_SPK.hca" },

            // ACB: bgm_main || Cue: 1001019 / M_1019_SPK
            new SongInfo { DisplayName = "Sparking - Ultimate Cells", FileName = "M_1019_SPK.hca" },

            // ACB: bgm_main || Cue: 1001020 / M_1020_SPK
            new SongInfo { DisplayName = "Sparking - Ceaseless Terror", FileName = "M_1020_SPK.hca" },

            // ACB: bgm_main || Cue: 1001021 / M_1021_SPK
            new SongInfo { DisplayName = "Sparking - Innocent Assault", FileName = "M_1021_SPK.hca" },

            // ACB: bgm_main || Cue: 1001022 / M_1022_SPK
            new SongInfo { DisplayName = "Sparking - Divine Grudge", FileName = "M_1022_SPK.hca" },

            // ACB: bgm_main || Cue: 1001023 / M_1023_SPK
            new SongInfo { DisplayName = "Sparking - Black Roses", FileName = "M_1023_SPK.hca" },

            // ACB: bgm_main || Cue: 1001024 / M_1024_SPK
            new SongInfo { DisplayName = "Sparking - The Immortal Divine", FileName = "M_1024_SPK.hca" },

            // ACB: bgm_main || Cue: 1001025 / M_1025_SPK
            new SongInfo { DisplayName = "Sparking - Strength is Justice", FileName = "M_1025_SPK.hca" },

            // ACB: bgm_main || Cue: 1001026 / M_1026_SPK
            new SongInfo { DisplayName = "Sparking - Nothing to Lose", FileName = "M_1026_SPK.hca" },

            // ACB: bgm_main || Cue: 1001027 / M_1027_SPK
            new SongInfo { DisplayName = "Sparking - Super Saiyan", FileName = "M_1027_SPK.hca" },

            // ACB: bgm_main || Cue: 1001028 / M_1028_SPK
            new SongInfo { DisplayName = "Sparking - True Form", FileName = "M_1028_SPK.hca" },

            // ACB: bgm_main || Cue: 1001029 / M_1029_SPK
            new SongInfo { DisplayName = "Sparking - Great Ape", FileName = "M_1029_SPK.hca" },

            // ACB: bgm_main || Cue: 1001030 / M_1030_SPK
            new SongInfo { DisplayName = "Sparking - Within the Light", FileName = "M_1030_SPK.hca" },

            // ACB: bgm_main || Cue: 1001031 / M_1031_SPK
            new SongInfo { DisplayName = "Sparking - Evil United", FileName = "M_1031_SPK.hca" },

            // ACB: bgm_main || Cue: 1001032 / M_1032_SPK
            new SongInfo { DisplayName = "Sparking - Pride Troopers", FileName = "M_1032_SPK.hca" },

            // ACB: bgm_main || Cue: 1001033 / M_1033_SPK
            new SongInfo { DisplayName = "Sparking - God of Destruction", FileName = "M_1033_SPK.hca" },

            // ACB: bgm_main || Cue: 1001034 / M_1034_SPK
            new SongInfo { DisplayName = "Sparking - Hero of Justice", FileName = "M_1034_SPK.hca" },

            // ACB: bgm_main || Cue: 1001035 / M_1035_SPK
            new SongInfo { DisplayName = "Sparking - Malice", FileName = "M_1035_SPK.hca" },

            // ACB: bgm_main || Cue: 1001036 / M_1036_SPK
            new SongInfo { DisplayName = "Sparking - Strangely Innocent", FileName = "M_1036_SPK.hca" },

            // ACB: bgm_main || Cue: 1001037 / M_1037_SPK
            new SongInfo { DisplayName = "Sparking - Strangely Evil", FileName = "M_1037_SPK.hca" },

            // ACB: bgm_main || Cue: 1001038 / M_1038_SPK
            new SongInfo { DisplayName = "Sparking - Slapstick Heroes", FileName = "M_1038_SPK.hca" },

            // ACB: bgm_main || Cue: 1001039 / M_1039_SPK
            new SongInfo { DisplayName = "Sparking - Berserker", FileName = "M_1039_SPK.hca" },

            // ACB: bgm_main || Cue: 1001040 / M_1040_SPK
            new SongInfo { DisplayName = "Sparking - Realm of the Gods", FileName = "M_1040_SPK.hca" },

            // ACB: bgm_main || Cue: 1001041 / M_1041_SPK
            new SongInfo { DisplayName = "Sparking - Valkyrie", FileName = "M_1041_SPK.hca" },

            // ACB: bgm_main || Cue: 1001042 / M_1042_SPK
            new SongInfo { DisplayName = "Sparking - The Power of Love", FileName = "M_1042_SPK.hca" },

            // ACB: bgm_main || Cue: 1001043 / M_1043_SPK
            new SongInfo { DisplayName = "Sparking - Cruel Galaxy", FileName = "M_1043_SPK.hca" },

            // ACB: bgm_main || Cue: 1001044 / M_1044_SPK
            new SongInfo { DisplayName = "Sparking - Legendary Warrior", FileName = "M_1044_SPK.hca" },

            // ACB: bgm_main || Cue: 10011002 / M_1100_SPK
            new SongInfo { DisplayName = "Sparking - Genkai Toppa X Survivor", FileName = "M_1100_SPK.hca" }

        };

        // TODO: Separate Sparking from BGM to make it easier to find the song you want to replace, then I can set up filtering with a checkbox or something that populates or hides Sparking/BGM songs this will also be helpful for when/if I add the ability to swap voice lines around as well so we can sort by character or something like that
    }
}
