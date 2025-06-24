using BananaModManager.Utils.SimpleJSON;

namespace BananaModManager.Classes
{
    /*
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

    // this is changed a lil to remove all the shit we dont need

    public class ReleaseInfo
    {
        public string Link;
        public string Name;
        public string Author;
        public string GitPath;
        public string Group;
        public string InstallLocation;
        public List<string> Dependencies = new List<string>();

        public ReleaseInfo(string _name, string _author, string _group, string _link, string _installLocation, string _gitPath, JSONArray dependencies)
        {
            Name = _name;
            Author = _author;
            Group = _group;
            Link = (_gitPath != null && Name != "BepInEx") ? "NONE" : _link;
            GitPath = (_gitPath != null && Name != "BepInEx") ? _gitPath : "NONE";
            InstallLocation = _installLocation;

            if (_name == "BepInEx") { GitPath = "NONE"; }

            for (int i = 0; i < dependencies.Count; i++)
                Dependencies.Add(dependencies[i]);
        }
    }
}