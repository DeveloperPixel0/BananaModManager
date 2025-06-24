using Microsoft.Win32;

namespace BananaModManager.Utils
{
    public class FindCapuchin
    {
        /*
         * Some of this code is refactored code from original MMM so I felt I had to give credit to it
         * BTW whoever ends up managing MMM in the long run PLEASE make the switch to storing your path
         * in the registry instead of .txt files
         * 
         * Yes it is incredibly refactored and you almost can't recognize it but I'd rather add an extra
         * license to the source than get the repo taken down for not doing that
         * 
         * - binx
          
                        MIT License

                        Copyright (c) 2021 Steven 🎀

                        Permission is hereby granted, free of charge, to any person obtaining a copy
                        of this software and associated documentation files (the "Software"), to deal
                        in the Software without restriction, including without limitation the rights
                        to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                        copies of the Software, and to permit persons to whom the Software is
                        furnished to do so, subject to the following conditions:

                        The above copyright notice and this permission notice shall be included in all
                        copies or substantial portions of the Software.

                        THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                        IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                        FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                        AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                        LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                        OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                        SOFTWARE.
        */

        public static string TrySteam()
        {
            string steamL = GetSteamLocation();

            if (Directory.Exists(steamL) && steamL != "")
                return steamL;

            return Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Capuchin") 
                    ? "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Capuchin"
                    : "";
        }

        public static string GetLocation()
        {
            string r = TrySteam();

            if (r != "")
            {
                return r;
            } else
            {
                OpenFileDialog thing = new();
                thing.Title = "Select Capuchin.exe";

                DialogResult selectIt = thing.ShowDialog();
                if (selectIt == DialogResult.Cancel) Application.Exit();

                if (thing.SafeFileName == "Capuchin.exe")
                {
                    return Path.GetDirectoryName(thing.FileName);
                } else
                {
                    MessageBox.Show("The file was not Capuchin.exe. Reopen and try again.", "That's not Capuchin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

            return "";
        }

        public static string CustomLocation()
        {
            OpenFileDialog thing = new();
            thing.Title = "Select Capuchin.exe";

            DialogResult selectIt = thing.ShowDialog();

            if (selectIt == DialogResult.OK)
            {
                if (thing.SafeFileName == "Capuchin.exe")
                    return Path.GetDirectoryName(thing.FileName);
                else
                    MessageBox.Show("The file was not Capuchin.exe. Reopen and try again.", "That's not Capuchin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }

        private static string GetSteamLocation() =>
            (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 2767950", "InstallLocation", "");
    }
}
