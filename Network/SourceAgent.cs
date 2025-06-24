using BananaModManager.Utils;
using BananaModManager.Classes;
using BananaModManager.Utils.SimpleJSON;
using System.Net;

namespace BananaModManager.Utils
{
    public class SourceAgent
    {
        public static List<string> sources = new();
        public static List<SourceInfo> TrustSourceList = new();

        public static string Repo_API_Endpoint = "";

        public static string GatherWebContent(string URL)
        {
            HttpWebRequest RQuest = (HttpWebRequest)HttpWebRequest.Create(URL);
            RQuest.Method = "GET";
            RQuest.KeepAlive = true;
            RQuest.UserAgent = "BMMSourceAgent";

            HttpWebResponse Response = (HttpWebResponse)RQuest.GetResponse();
            StreamReader Sr = new StreamReader(Response.GetResponseStream());
            string Code = Sr.ReadToEnd();
            Sr.Close();
            return Code;
        }

        public static bool IsTrustedSource(string URL)
        {
            foreach (SourceInfo src in TrustSourceList)
                if (src.Link == URL)
                    return true;

            return false;
        }

        public static SourceInfo? GetSourceInfo(string URL)
        {
            foreach (SourceInfo src in TrustSourceList)
                if (src.Link == URL)
                    return src;

            return null;
        }

        public static List<ReleaseInfo> GatherSources()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.txp"))
            {
                List<string> newFile = new();

                newFile.Add("# This is the sources file for BananaModManager");
                newFile.Add("# You can make comments by using \"#\"");
                newFile.Add("# Everything's in Txt++ format");
                newFile.Add("");
                newFile.Add("https://raw.githubusercontent.com/DeveloperPixel0/BananaModInfo/refs/heads/master/modinfo.json");

                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.txp", newFile);
            }

            TextPlusPlus.DefineVariable("default", "https://raw.githubusercontent.com/DeveloperPixel0/BananaModInfo/refs/heads/master/modinfo.json");
            // ^^^^^^^^ $default

            sources = TextPlusPlus.ParseSourceFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources_banana.txp");

            if (sources.Count == 0)
                sources.Add("https://raw.githubusercontent.com/DeveloperPixel0/BananaModInfo/refs/heads/master/modinfo.json");

            List<ReleaseInfo> mods = new();

            foreach (string sourceURL in sources)
            {
                var decodedMods = JSON.Parse(GatherWebContent(sourceURL));
                var allMods = decodedMods.AsArray;

                for (int i = 0; i < allMods.Count; i++)
                {
                    JSONNode current = allMods[i];
                    ReleaseInfo release = new ReleaseInfo(current["name"], current["author"], current["group"], current["download_url"], current["install_location"], current["git_path"], current["dependencies"].AsArray);
                    mods.Add(release);
                }
            }

            // trusted source info
            var srclist = JSON.Parse(GatherWebContent("https://raw.githubusercontent.com/sirkingbinx/PygmyModManager/refs/heads/master/trusted_sources.json"));
            var allSrc = srclist.AsArray;

            var thisCurrent = allSrc[0];
            Repo_API_Endpoint = "https://api.github.com/repos/";

            for (int i = 0; i < allSrc.Count; i++)
            {
                JSONNode current = allSrc[i];
                SourceInfo release = new SourceInfo(current["title"], current["link"]);
                TrustSourceList.Add(release);
            }

            return mods;
        }
    }
}
