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
    }
}
