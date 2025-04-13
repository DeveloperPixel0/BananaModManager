namespace PygmyModManager.Pages
{
    partial class Preferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            button1 = new Button();
            tabControl1 = new TabControl();
            sourcesPrefPage = new TabPage();
            linkLabel1 = new LinkLabel();
            sourcesListVisual = new ListView();
            sourceHelpLabel = new Label();
            sourcesAddTxtVisual = new TextBox();
            sourcesAddBtnVisual = new Button();
            label1 = new Label();
            prefLoadSourcesOnStartup = new CheckBox();
            appearancePrefPage = new TabPage();
            modMgrDisplayName = new TextBox();
            modMgrDisplayNameLabel = new Label();
            infoLabel = new Label();
            tabControl1.SuspendLayout();
            sourcesPrefPage.SuspendLayout();
            appearancePrefPage.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(333, 423);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(sourcesPrefPage);
            tabControl1.Controls.Add(appearancePrefPage);
            tabControl1.Location = new Point(1, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(412, 418);
            tabControl1.TabIndex = 1;
            // 
            // sourcesPrefPage
            // 
            sourcesPrefPage.Controls.Add(linkLabel1);
            sourcesPrefPage.Controls.Add(sourcesListVisual);
            sourcesPrefPage.Controls.Add(sourceHelpLabel);
            sourcesPrefPage.Controls.Add(sourcesAddTxtVisual);
            sourcesPrefPage.Controls.Add(sourcesAddBtnVisual);
            sourcesPrefPage.Controls.Add(label1);
            sourcesPrefPage.Controls.Add(prefLoadSourcesOnStartup);
            sourcesPrefPage.Location = new Point(4, 24);
            sourcesPrefPage.Name = "sourcesPrefPage";
            sourcesPrefPage.Padding = new Padding(3);
            sourcesPrefPage.Size = new Size(404, 390);
            sourcesPrefPage.TabIndex = 0;
            sourcesPrefPage.Text = "Sources";
            sourcesPrefPage.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(6, 286);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(226, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "You can also edit the sources file yourself.";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // sourcesListVisual
            // 
            sourcesListVisual.CheckBoxes = true;
            sourcesListVisual.Location = new Point(7, 32);
            sourcesListVisual.Name = "sourcesListVisual";
            sourcesListVisual.Size = new Size(389, 223);
            sourcesListVisual.TabIndex = 6;
            sourcesListVisual.UseCompatibleStateImageBehavior = false;
            sourcesListVisual.View = View.List;
            // 
            // sourceHelpLabel
            // 
            sourceHelpLabel.AutoSize = true;
            sourceHelpLabel.Location = new Point(11, 353);
            sourceHelpLabel.Name = "sourceHelpLabel";
            sourceHelpLabel.Size = new Size(382, 30);
            sourceHelpLabel.TabIndex = 5;
            sourceHelpLabel.Text = "To remove a source, uncheck it. Press \"Close\" to save your changes and\r\nclose preferences.";
            // 
            // sourcesAddTxtVisual
            // 
            sourcesAddTxtVisual.Location = new Point(7, 259);
            sourcesAddTxtVisual.Name = "sourcesAddTxtVisual";
            sourcesAddTxtVisual.Size = new Size(327, 23);
            sourcesAddTxtVisual.TabIndex = 4;
            // 
            // sourcesAddBtnVisual
            // 
            sourcesAddBtnVisual.Location = new Point(339, 259);
            sourcesAddBtnVisual.Name = "sourcesAddBtnVisual";
            sourcesAddBtnVisual.Size = new Size(57, 23);
            sourcesAddBtnVisual.TabIndex = 3;
            sourcesAddBtnVisual.Text = "Add";
            sourcesAddBtnVisual.UseVisualStyleBackColor = true;
            sourcesAddBtnVisual.Click += sourcesAddBtnVisual_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 11);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 2;
            label1.Text = "All Sources";
            // 
            // prefLoadSourcesOnStartup
            // 
            prefLoadSourcesOnStartup.AutoSize = true;
            prefLoadSourcesOnStartup.Checked = true;
            prefLoadSourcesOnStartup.CheckState = CheckState.Checked;
            prefLoadSourcesOnStartup.Location = new Point(7, 331);
            prefLoadSourcesOnStartup.Name = "prefLoadSourcesOnStartup";
            prefLoadSourcesOnStartup.Size = new Size(154, 19);
            prefLoadSourcesOnStartup.TabIndex = 0;
            prefLoadSourcesOnStartup.Text = "Load Sources on Startup";
            prefLoadSourcesOnStartup.UseVisualStyleBackColor = true;
            // 
            // appearancePrefPage
            // 
            appearancePrefPage.Controls.Add(modMgrDisplayName);
            appearancePrefPage.Controls.Add(modMgrDisplayNameLabel);
            appearancePrefPage.Location = new Point(4, 24);
            appearancePrefPage.Name = "appearancePrefPage";
            appearancePrefPage.Padding = new Padding(3);
            appearancePrefPage.Size = new Size(404, 390);
            appearancePrefPage.TabIndex = 1;
            appearancePrefPage.Text = "Appearance";
            appearancePrefPage.UseVisualStyleBackColor = true;
            // 
            // modMgrDisplayName
            // 
            modMgrDisplayName.Location = new Point(96, 8);
            modMgrDisplayName.MaxLength = 60;
            modMgrDisplayName.Name = "modMgrDisplayName";
            modMgrDisplayName.Size = new Size(302, 23);
            modMgrDisplayName.TabIndex = 1;
            // 
            // modMgrDisplayNameLabel
            // 
            modMgrDisplayNameLabel.AutoSize = true;
            modMgrDisplayNameLabel.Location = new Point(9, 12);
            modMgrDisplayNameLabel.Name = "modMgrDisplayNameLabel";
            modMgrDisplayNameLabel.Size = new Size(83, 15);
            modMgrDisplayNameLabel.TabIndex = 0;
            modMgrDisplayNameLabel.Text = "Display Name:";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(7, 426);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(0, 15);
            infoLabel.TabIndex = 2;
            // 
            // Preferences
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 450);
            ControlBox = false;
            Controls.Add(infoLabel);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Preferences";
            Text = "Preferences";
            tabControl1.ResumeLayout(false);
            sourcesPrefPage.ResumeLayout(false);
            sourcesPrefPage.PerformLayout();
            appearancePrefPage.ResumeLayout(false);
            appearancePrefPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TabControl tabControl1;
        private TabPage sourcesPrefPage;
        private TabPage appearancePrefPage;
        private CheckBox prefLoadSourcesOnStartup;
        private Label sourceHelpLabel;
        private TextBox sourcesAddTxtVisual;
        private Button sourcesAddBtnVisual;
        private Label label1;
        private Label infoLabel;
        private ListView sourcesListVisual;
        private TextBox modMgrDisplayName;
        private Label modMgrDisplayNameLabel;
        private LinkLabel linkLabel1;
    }
}