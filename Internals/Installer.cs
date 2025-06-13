using PygmyModManager.Classes;
using PygmyModManager.Internals.SimpleJSON;
using System.Net;

namespace PygmyModManager.Internals
{
    public class Installer
    {
        public static ReleaseInfo? GetReleaseInfoFromMod(string modName)
        {
            foreach (ReleaseInfo mod in Main.Mods)
            {
                if (mod.Name == modName)
                    return mod;
            }

            return null;
        }

        public static byte[] DownloadFile(string url)
        {
            return new WebClient().DownloadData(url);
        }

        public static void InstallMods(ListView.CheckedListViewItemCollection items2Install, string InstallDir, bool UseGithub)
        {
            foreach (ListViewItem itemToInstall in items2Install)
            {
                ReleaseInfo? modInfo = GetReleaseInfoFromMod(itemToInstall.Text);

                if (modInfo == null)
                    continue;

                string downloadURL = "";
                byte[] content;

                if (modInfo.GitPath != "NONE" && UseGithub == true)
                {
                    // there is somewhere to get repos
                    string download_this_thing = SourceAgent.Repo_API_Endpoint + modInfo.GitPath + "/releases";
                    var releaseJSONData = JSON.Parse(SourceAgent.GatherWebContent(download_this_thing)).AsArray;

                    downloadURL = "";

                    // find the latest STABLE release
                    for (int idx = 0; idx < releaseJSONData.Count; idx++)
                    {
                        if (releaseJSONData[idx]["draft"] == true | releaseJSONData[idx]["prerelease"] == true) { continue; }
                        else
                        {
                            downloadURL = releaseJSONData[idx]["assets"].AsArray[0]["browser_download_url"]; break;
                        }
                    }
                }
                else
                {
                    if (modInfo.Link != "NONE")
                        downloadURL = modInfo.Link;
                    else
                    {
                        DialogResult thing = MessageBox.Show("No download link found for " + modInfo.Name + ". Contact list maintainers.", "Error (skippable)", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                        if (thing == DialogResult.OK)
                            continue;
                        else if (thing == DialogResult.Cancel)
                            return;
                    }
                }

                try
                {
                    content = DownloadFile(downloadURL);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }

                if (content == null) continue;

                string fileName = Path.GetFileName(downloadURL);

                if (Path.GetExtension(fileName).Equals(".dll"))
                {
                    string installLocation = Path.Combine(Main.InstallDir, "BepInEx/plugins");

                    if (modInfo.InstallLocation != String.Empty)
                        installLocation = Path.Combine(Main.InstallDir, modInfo.InstallLocation);

                    string path = Path.Combine(installLocation, fileName);

                    if (File.Exists(path))
                        File.Delete(path);

                    File.WriteAllBytes(path, content);

                }
                else if (Path.GetExtension(fileName).Equals(".zip"))
                {
                    using (MemoryStream ms = new MemoryStream(content))
                    {
                        using (var unzip = new Unzip(ms))
                        {
                            string installLocation = Path.Combine(Main.InstallDir, "BepInEx/plugins");

                            if (modInfo.Name == "BepInEx")
                                installLocation = Main.InstallDir;
                            else if (modInfo.InstallLocation != "")
                                installLocation = Path.Combine(Main.InstallDir, modInfo.InstallLocation);

                            unzip.ExtractToDirectory(installLocation);
                        }
                    }
                }
            }
        }
    }
}
