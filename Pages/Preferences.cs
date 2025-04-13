using Microsoft.Win32;
using PygmyModManager.Classes;
using PygmyModManager.Internals;
using PygmyModManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PygmyModManager.Pages
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
            LoadSourcesVisual();

            modMgrDisplayName.Text = Main.DisplayName != null ? Main.DisplayName : "Binx's Mod Manager";
            prefLoadSourcesOnStartup.Checked = Main.LoadMods;
        }

        void LoadSourcesVisual()
        {
            sourcesListVisual.Clear();

            foreach (string sourceURL in SourceAgent.sources)
            {
                ListViewItem t;
                if (SourceAgent.IsTrustedSource(sourceURL))
                {
                    SourceInfo thisThing = SourceAgent.GetSourceInfo(sourceURL);
                    t = sourcesListVisual.Items.Add("[Verified] " + thisThing.Title);
                }
                else
                {
                    t = sourcesListVisual.Items.Add(sourceURL);
                }

                t.Checked = true;
                t.SubItems.Add(sourceURL);

                // add item & check it by default
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SourceAgent.sources = new List<string>();

            foreach (ListViewItem checkedItem in sourcesListVisual.CheckedItems)
            {
                SourceAgent.sources.Add(checkedItem.SubItems[0].Text);
            }

            // (Sources) Load Sources on Startup
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\CMC\BananaModManager", "LoadModsOnStartup", this.prefLoadSourcesOnStartup.Checked ? "YES" : "NO");

            // (Appearance) Display Name
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\CMC\BananaModManager", "DisplayName", this.modMgrDisplayName.Text);

            this.Close();
        }

        private void sourcesAddBtnVisual_Click(object sender, EventArgs e)
        {
            SourceAgent.sources.Add(sourcesAddTxtVisual.Text);
            LoadSourcesVisual();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Editor(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.txp").ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(Main.InstallDir + @"\");
        }
    }
}
