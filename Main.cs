using BananaModManager.Classes;
using BananaModManager.Internals;
using BananaModManager.Utils;

namespace BananaModManager
{
    public partial class Main : Form
    {
        public static List<ReleaseInfo> Mods = new();

        public Main()
        {
            InitializeComponent();

            // Get install dir
            installLocationBox.Text = FindCapuchin.GetLocation();

            if (installLocationBox.Text == "")
                Application.Exit();

            // Get mods from sources
            Mods = SourceAgent.GatherSources();
            RenderMods();
        }

        public void AssignGroupToMod(ReleaseInfo mod, ListViewItem item)
        {
            foreach (ListViewGroup lvGroup in modsBox.Groups)
            {
                if (mod.Group.ToLower().Contains(lvGroup.Header.ToLower()))
                {
                    item.Group = lvGroup;
                    return;
                }
            }

            ListViewGroup thisBrandNewGroup = new();
            modsBox.Groups.Add(thisBrandNewGroup);

            thisBrandNewGroup.Header = mod.Group;
        }

        public void RenderMods()
        {
            modsBox.Items.Clear();
            modsBox.Groups.Clear();

            foreach (ReleaseInfo thisMod in Mods)
                modsBox.Groups.Add(new ListViewGroup(thisMod.Group));

            foreach (ReleaseInfo thisMod in Mods)
            {
                ListViewItem assignedItem = modsBox.Items.Add(thisMod.Name);
                assignedItem.SubItems.Add(thisMod.Author);

                AssignGroupToMod(thisMod, assignedItem);
            }
        }

        private void installButton_Click(object? sender, EventArgs e)
        {
            Task.Run(() =>
            {
                installButton.Enabled = false;
                Installer.InstallMods(modsBox.CheckedItems, installLocationBox.Text);
                installButton.Enabled = true;
            });
        }

        private void selectInstallBtn_Click(object sender, EventArgs e)
        {
            string newInstallLocation = FindCapuchin.CustomLocation();

            if (newInstallLocation != "")
                installLocationBox.Text = newInstallLocation;
        }
    }
}
