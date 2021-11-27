using SongLyricEntities;
using SongLyricEntities.DTOs;
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
        private int id = 0;

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
            foreach (var item in await new WebApiHelper<AlbumDto>().GetListAsync("api/albums/"))
            {
                dgvAlbum.Rows.Add(item.Id, item.AlbumName, item.ReleaseDate.ToString("yyyy/MM/dd"), item.ArtistName, item.GenreName);
                dgvAlbum.Rows[dgvAlbum.RowCount - 1].Tag = item.Id;
            }
        }

        private async void frmAlbum_Load(object sender, EventArgs e)
        {
            await LoadComboBoxes();
            await LoadData();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAlbumName.Text))
            {
                Album entity = new Album();
                if (id == 0)
                {
                    entity.AlbumName = txtAlbumName.Text;
                    entity.GenreId = Convert.ToInt32(cmbGenre.SelectedValue);
                    entity.ArtistId = Convert.ToInt32(cmbArtist.SelectedValue);
                    entity.ReleaseDate = dtpActiveFrom.Value;

                    var result = await new WebApiHelper<Album>().AddAsync("api/albums", entity);
                    if (result != null)
                        await LoadData();
                }
                else
                {
                    entity.AlbumName = txtAlbumName.Text;
                    entity.GenreId = Convert.ToInt32(cmbGenre.SelectedValue);
                    entity.ArtistId = Convert.ToInt32(cmbArtist.SelectedValue);
                    entity.ReleaseDate = dtpActiveFrom.Value;
                    entity.Id = id;

                    if (await new WebApiHelper<Album>().UpdateAsync("api/albums/", id, entity))
                        await LoadData();

                    id = 0;
                }
                txtAlbumName.Text = "";
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void dgvAlbum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var rowId = Convert.ToInt32(dgvAlbum.Rows[e.RowIndex].Tag);
                if (e.ColumnIndex == 5)
                {
                    id = Convert.ToInt32(rowId);
                    txtAlbumName.Text = dgvAlbum.CurrentRow.Cells[1].Value.ToString();
                    dtpActiveFrom.Text = dgvAlbum.CurrentRow.Cells[2].Value.ToString();
                    dtpActiveFrom.Value = Convert.ToDateTime(dgvAlbum.CurrentRow.Cells[2].Value.ToString());

                    cmbArtist.Text = dgvAlbum.CurrentRow.Cells[3].Value.ToString();
                    cmbGenre.Text = dgvAlbum.CurrentRow.Cells[4].Value.ToString();
                }
                else if (e.ColumnIndex == 6)
                {
                    if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await new WebApiHelper<Album>().DeleteAsync("api/albums/", rowId);
                        if (result)
                        {
                            dgvAlbum.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var item = await new WebApiHelper<AlbumDto>().GetByIdAsync("api/albums/", Convert.ToInt32(txtId.Text));
                if (item != null)
                {
                    dgvAlbum.Rows.Clear();
                    dgvAlbum.Rows.Add(item.Id, item.AlbumName, item.ReleaseDate.ToString("yyyy/MM/dd"), item.ArtistName, item.GenreName);
                    dgvAlbum.Rows[dgvAlbum.RowCount - 1].Tag = item.Id;
                }
                else
                    MessageBox.Show("The record not found!");
            }
        }
    }
}
