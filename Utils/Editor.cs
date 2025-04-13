using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    TextEditor
    Small & simple text editor for people using WinForms
    Comes with open & saving, you can specify a file to open on startup

    Usage:
            Editor newEditor = new Editor("C:\Users\Me\Documents\file.txt");

    MIT License

    Copyright (c) 2025 SirKingBinx

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

namespace PygmyModManager.Utils
{
    #region Main

    public class Editor : Form
    {
        bool dirty = false;
        bool loading = false;

        bool selfLoaded = false;

        public Editor(string path = "")
        {
            InitializeComponent();

            OpenFile(path);
        }

        public Editor(string fileContent, string filename)
        {
            InitializeComponent();

            OpenFile("", fileContent, filename);
        }

        void OpenFile(string path = "", string lines = null, string thisFilename = "none")
        {
            loading = true;
            string filename = "";

            selfLoaded = thisFilename != "none";

            if (path == "" && thisFilename == "none")
            {
                DialogResult userChoseFile = openFileDialog1.ShowDialog();

                if (!(userChoseFile == DialogResult.OK)) Close();
                filename = openFileDialog1.FileName;
            }
            else
            {
                if (thisFilename != "none")
                    filename = thisFilename;
                else
                    filename = path;
            }

            this.Text = "Text Editor - " + Path.GetFileName(filename);
            fileLocationBox.Text = thisFilename != "none" ? thisFilename : filename;
            fileContentBox.Text = lines == null ? File.ReadAllText(filename) : lines;
            loading = false;
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileContentBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileContentBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileContentBox.Paste();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";

            if (fileLocationBox.Text == "" | selfLoaded == true)
            {
                DialogResult doSaveIt = saveFileDialog1.ShowDialog();

                if (doSaveIt == DialogResult.OK)
                    path = saveFileDialog1.FileName;
                else
                    return; // cancel
            }
            else
            {
                path = fileLocationBox.Text;
            }

            File.WriteAllText(path, fileContentBox.Text); // yes, it has multiline support, don't worry :)
            this.Text = "Text Editor - " + Path.GetFileName(fileLocationBox.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void fileContentBox_TextChanged(object sender, EventArgs e)
        {
            if (loading | dirty == true) return;

            dirty = true;
            this.Text = this.Text + "*"; // dirty indicator
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
        #region Window Creation

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            closeButton = new Button();
            fileLabel = new Label();
            openFileBtn = new Button();
            fileLocationBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            fileContentBox = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveChangesToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();

            this.Text = "Text Editor";

            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;

            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveChangesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;

            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(434, 510);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(72, 23);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // fileLabel
            // 
            fileLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fileLabel.AutoSize = true;
            fileLabel.Location = new Point(6, 515);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(28, 15);
            fileLabel.TabIndex = 1;
            fileLabel.Text = "File:";
            // 
            // openFileBtn
            // 
            openFileBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            openFileBtn.Location = new Point(404, 510);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(24, 23);
            openFileBtn.TabIndex = 2;
            openFileBtn.Text = "..";
            openFileBtn.UseVisualStyleBackColor = true;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // fileLocationBox
            // 
            fileLocationBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileLocationBox.Location = new Point(35, 510);
            fileLocationBox.Name = "fileLocationBox";
            fileLocationBox.ReadOnly = true;
            fileLocationBox.Size = new Size(363, 23);
            fileLocationBox.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog";
            // 
            // fileContentBox
            // 
            fileContentBox.AcceptsReturn = true;
            fileContentBox.AcceptsTab = true;
            fileContentBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileContentBox.ContextMenuStrip = contextMenuStrip1;
            fileContentBox.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileContentBox.Location = new Point(0, 0);
            fileContentBox.Multiline = true;
            fileContentBox.Name = "fileContentBox";
            fileContentBox.ScrollBars = ScrollBars.Both;
            fileContentBox.Size = new Size(512, 507);
            fileContentBox.TabIndex = 4;
            fileContentBox.TextChanged += fileContentBox_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator1, openToolStripMenuItem, saveChangesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 120);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(103, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(103, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(103, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(100, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveChangesToolStripMenuItem
            // 
            saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            saveChangesToolStripMenuItem.Size = new Size(103, 22);
            saveChangesToolStripMenuItem.Text = "Save";
            saveChangesToolStripMenuItem.Click += saveChangesToolStripMenuItem_Click;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 537);
            Controls.Add(fileContentBox);
            Controls.Add(fileLocationBox);
            Controls.Add(openFileBtn);
            Controls.Add(fileLabel);
            Controls.Add(closeButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Editor";
            Text = "Text Editor";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        #region Designer Vars

        private Button closeButton;
        private Label fileLabel;
        private Button openFileBtn;
        private TextBox fileLocationBox;
        private OpenFileDialog openFileDialog1;
        private TextBox fileContentBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveChangesToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem openToolStripMenuItem;

        #endregion
    }
}
