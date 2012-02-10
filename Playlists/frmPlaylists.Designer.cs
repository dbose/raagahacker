namespace RaagaHacker.Playlists
{
    partial class frmPlaylists
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Current Playlist");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlaylists));
            this.tvPlaylists = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlaySelected = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmuNewPlayList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPlaylistSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cmuNewPlayList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvPlaylists
            // 
            this.tvPlaylists.CheckBoxes = true;
            this.tvPlaylists.ImageIndex = 0;
            this.tvPlaylists.ImageList = this.imageList1;
            this.tvPlaylists.Location = new System.Drawing.Point(21, 48);
            this.tvPlaylists.Name = "tvPlaylists";
            treeNode2.ImageIndex = -2;
            treeNode2.Name = "nodeCurrentPlaylist";
            treeNode2.Text = "Current Playlist";
            this.tvPlaylists.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvPlaylists.SelectedImageIndex = 0;
            this.tvPlaylists.Size = new System.Drawing.Size(355, 360);
            this.tvPlaylists.TabIndex = 0;
            this.tvPlaylists.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPlaylists_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "aktion.ico");
            this.imageList1.Images.SetKeyName(1, "Note musique.ico");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.pictureBox2.Image = global::RaagaHacker.Properties.Resources.WalkMan;
            this.pictureBox2.Location = new System.Drawing.Point(21, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Songs Added To Playlist";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPlaySelected
            // 
            this.btnPlaySelected.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPlaySelected.Location = new System.Drawing.Point(21, 414);
            this.btnPlaySelected.Name = "btnPlaySelected";
            this.btnPlaySelected.Size = new System.Drawing.Size(99, 29);
            this.btnPlaySelected.TabIndex = 4;
            this.btnPlaySelected.Text = "Play Selected ...";
            this.btnPlaySelected.UseVisualStyleBackColor = true;
            this.btnPlaySelected.Click += new System.EventHandler(this.btnPlaySelected_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(292, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmuNewPlayList
            // 
            this.cmuNewPlayList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlaylistSaveAs});
            this.cmuNewPlayList.Name = "cmuNewPlayList";
            this.cmuNewPlayList.Size = new System.Drawing.Size(153, 48);
            // 
            // mnuPlaylistSaveAs
            // 
            this.mnuPlaylistSaveAs.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.mnuPlaylistSaveAs.Name = "mnuPlaylistSaveAs";
            this.mnuPlaylistSaveAs.Size = new System.Drawing.Size(152, 22);
            this.mnuPlaylistSaveAs.Text = "Save As ...";
            this.mnuPlaylistSaveAs.Click += new System.EventHandler(this.mnuPlaylistSaveAs_Click);
            // 
            // frmPlaylists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.ClientSize = new System.Drawing.Size(398, 455);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnPlaySelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvPlaylists);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlaylists";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playlist - RaagaHacker v1.0.1";
            this.Load += new System.EventHandler(this.frmPlaylists_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cmuNewPlayList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvPlaylists;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlaySelected;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmuNewPlayList;
        private System.Windows.Forms.ToolStripMenuItem mnuPlaylistSaveAs;
    }
}