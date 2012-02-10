namespace RaagaHacker.Playlists
{
    partial class frmNewPlaylist
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPlaylist = new System.Windows.Forms.TextBox();
            this.btnNewPlaylist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Playlist Name :";
            // 
            // txtNewPlaylist
            // 
            this.txtNewPlaylist.Location = new System.Drawing.Point(18, 32);
            this.txtNewPlaylist.Name = "txtNewPlaylist";
            this.txtNewPlaylist.Size = new System.Drawing.Size(233, 20);
            this.txtNewPlaylist.TabIndex = 1;
            // 
            // btnNewPlaylist
            // 
            this.btnNewPlaylist.Location = new System.Drawing.Point(261, 28);
            this.btnNewPlaylist.Name = "btnNewPlaylist";
            this.btnNewPlaylist.Size = new System.Drawing.Size(74, 27);
            this.btnNewPlaylist.TabIndex = 2;
            this.btnNewPlaylist.Text = "Save";
            this.btnNewPlaylist.UseVisualStyleBackColor = true;
            // 
            // frmNewPlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RaagaHacker.Properties.Resources.metallic_background;
            this.ClientSize = new System.Drawing.Size(342, 71);
            this.Controls.Add(this.btnNewPlaylist);
            this.Controls.Add(this.txtNewPlaylist);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewPlaylist";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Playlist - RaagaHacker v.1.0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPlaylist;
        private System.Windows.Forms.Button btnNewPlaylist;
    }
}