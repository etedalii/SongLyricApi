using SongLyricEntities;
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
    public partial class frmAlbum : Form
    {
        public frmAlbum()
        {
            InitializeComponent();
        }

        private async Task LoadComboBoxes()
        {
            var genres = await new WebApiHelper<Genre>().GetListAsync("api/genres/");
            var artists = await new WebApiHelper<Artist>().GetListAsync("api/artists/");

            cmbGenre.DisplayMember = "GenreName";
            cmbGenre.ValueMember = "Id";
            cmbGenre.DataSource = genres.ToList();

            cmbArtist.DisplayMember = "ArtistName";
            cmbArtist.ValueMember = "Id";
            cmbArtist.DataSource = artists.ToList();
        }

        private async Task LoadData()
        {
            dgvAlbum.Rows.Clear();
            foreach (var item in await new WebApiHelper<Album>().GetListAsync("api/albums/"))
            {
                dgvAlbum.Rows.Add(item.Id, item.AlbumName, item.ReleaseDate.ToString("yyyy/MM/dd"));
                dgvAlbum.Rows[dgvAlbum.RowCount - 1].Tag = item.Id;
            }
        }

        private async void frmAlbum_Load(object sender, EventArgs e)
        {
            await LoadComboBoxes();
        }
    }
}
