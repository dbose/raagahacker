using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RaagaHacker.Playlists;

namespace RaagaHacker.Playlists
{
    public partial class frmPlaylists : Form
    {
        private PlaylistManager cachedPlayListManager = null;
        public string SongIDs = "";

        public frmPlaylists()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmPlaylists_Load(object sender, EventArgs e)
        {
            //Check whether global playlistmanager is empty or not
            if (Globals.GetInstance().PlaylistManager != null)
            {
                cachedPlayListManager = Globals.GetInstance().PlaylistManager;

                //Update the UI for playlist
                UpdatePlaylist(cachedPlayListManager);
            }
        }

        private void UpdatePlaylist(PlaylistManager playListManager)
        {
            try
            {
                //
                //This is the code which glues the PlaylistManager with UI
                //

                //Double check
                if (playListManager != null)
                {
                    foreach (Movie movie in playListManager.Movies)
                    {
                        //Create & add the movie node
                        TreeNode tnMovie = new TreeNode(movie.MovieName);

                        //Add the songs under movie
                        TreeNode tnMovieSong = null;
                        foreach (string key in movie.SongCollection)
                        {
                            //Create each song node
                            tnMovieSong = new TreeNode(movie.SongCollection[key]);

                            //Place the song id in associated Tag field
                            tnMovieSong.Tag = key;
                            
                            //Add this to movie node
                            tnMovie.Nodes.Add(tnMovieSong);
                        }

                        //Add this to the root node
                        tvPlaylists.Nodes[0].Nodes.Add(tnMovie);

                    }

                }

            }
            catch(Exception ex)
            {
                frmException frm = new frmException();
                frm.ExceptionDialogTitle = "frmPlaylists::UpdatePlaylist - Error while updating the playlist ";
                frm.ErrorMessage = ex.Message;
                frm.StrackTrace = ex.StackTrace;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Dispose();
                    frm = null;
                }
            }
        }

        //Recursively check/uncheck all child nodes
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void tvPlaylists_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }

        }

        private void btnPlaySelected_Click(object sender, EventArgs e)
        {
            SongIDs = "";
            foreach (TreeNode nodeMovie in tvPlaylists.Nodes[0].Nodes)
            {
                foreach (TreeNode nodeSong in nodeMovie.Nodes)
                {
                    if (nodeSong.Checked == true)
                    {
                        SongIDs += ((string)nodeSong.Tag + ",");
                    }
                }
               
            }

            //Trim any trailing ","
            SongIDs = SongIDs.TrimEnd(",".ToCharArray());
        }

        private void mnuPlaylistSaveAs_Click(object sender, EventArgs e)
        {
            using (frmNewPlaylist newPlaylist = new frmNewPlaylist())
            {
                if (newPlaylist.ShowDialog() == DialogResult.OK)
                {
                    //
                }
            }
        }

        
    }
}