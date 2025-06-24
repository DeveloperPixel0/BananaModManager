namespace BananaModManager
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "test", "test" }, -1);
            selectInstallBtn = new Button();
            installLocationBox = new TextBox();
            modsBox = new ListView();
            Mod = new ColumnHeader();
            Author = new ColumnHeader();
            installButton = new Button();
            SuspendLayout();
            // 
            // selectInstallBtn
            // 
            selectInstallBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectInstallBtn.Location = new Point(570, 12);
            selectInstallBtn.Name = "selectInstallBtn";
            selectInstallBtn.Size = new Size(25, 23);
            selectInstallBtn.TabIndex = 0;
            selectInstallBtn.Text = "..";
            selectInstallBtn.UseVisualStyleBackColor = true;
            selectInstallBtn.Click += selectInstallBtn_Click;
            // 
            // installLocationBox
            // 
            installLocationBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            installLocationBox.Location = new Point(12, 12);
            installLocationBox.Name = "installLocationBox";
            installLocationBox.ReadOnly = true;
            installLocationBox.Size = new Size(552, 23);
            installLocationBox.TabIndex = 1;
            // 
            // modsBox
            // 
            modsBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modsBox.CheckBoxes = true;
            modsBox.Columns.AddRange(new ColumnHeader[] { Mod, Author });
            listViewItem1.StateImageIndex = 0;
            modsBox.Items.AddRange(new ListViewItem[] { listViewItem1 });
            modsBox.Location = new Point(12, 41);
            modsBox.Name = "modsBox";
            modsBox.Size = new Size(583, 363);
            modsBox.TabIndex = 2;
            modsBox.UseCompatibleStateImageBehavior = false;
            modsBox.View = View.Details;
            // 
            // Mod
            // 
            Mod.Text = "Mod";
            Mod.Width = 315;
            // 
            // Author
            // 
            Author.Text = "Author";
            Author.Width = 165;
            // 
            // installButton
            // 
            installButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            installButton.Location = new Point(512, 410);
            installButton.Name = "installButton";
            installButton.Size = new Size(83, 23);
            installButton.TabIndex = 3;
            installButton.Text = "Install";
            installButton.UseVisualStyleBackColor = true;
            installButton.Click += installButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 441);
            Controls.Add(installButton);
            Controls.Add(modsBox);
            Controls.Add(installLocationBox);
            Controls.Add(selectInstallBtn);
            Name = "Main";
            Text = "BananaModManager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectInstallBtn;
        private TextBox installLocationBox;
        private ListView modsBox;
        private ColumnHeader Mod;
        private ColumnHeader Author;
        private Button installButton;
    }
}
