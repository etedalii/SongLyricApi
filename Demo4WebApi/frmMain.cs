using SongLyricDataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4WebApi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

         private void menuGenre_Click(object sender, EventArgs e)
        {
            frmGenre artist = new frmGenre();
            artist.ShowDialog();
        }

        private void menuArtist_Click(object sender, EventArgs e)
        {
            frmArtist frm = new frmArtist();
            frm.ShowDialog();
        }

        private void menuSong_Click(object sender, EventArgs e)
        {
            frmSong frm = new frmSong();
            frm.ShowDialog();
        }

        private void menuAlbum_Click(object sender, EventArgs e)
        {
            frmAlbum frm = new frmAlbum();
            frm.ShowDialog();
        }

        private void menuAlbumDetail_Click(object sender, EventArgs e)
        {

        }
    }
}