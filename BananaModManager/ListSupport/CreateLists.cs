// Bingus note:
// A lot of this code is borrowed from CMM and mechanicmonke which i've stored in CMMRemnants

using System;
using BananaModManager.CMMRemnants;
using CapuchinModManager.Main;

namespace BananaModManager.CMMLists {
    public class ListPromptBox() {
        // will handle getting the lists n everything for you

        string jsonListToGrab = new CMMRemnants.StringPromptBox("Paste the URL of the modlist you want to track.");

        JSONNode tryParse;
        bool success;

        try
        {
            tryParse = JSON.Parse(DownloadSite("https://raw.githubusercontent.com/binguszingus/capuchinmodinfo/master/mods.json"));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show("There was an error parsing the JSON for mods.", "JSON Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            success = false;
        }

        if (!success) return;

        var ModsList = ModsJSON.AsArray;

        for (int i = 0; i < ModsList.Count; i++)
        {
            JSONNode current = ModsList[i];
            ReleaseInfo release = new ReleaseInfo(current["name"], current["author"], current["version"], current["group"], current["download_url"], current["install_location"], current["git_path"], current["dependencies"].AsArray, current["mod_loader"]);

            Mods.Add(release);
        }
    }
}