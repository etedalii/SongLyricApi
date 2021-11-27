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
    public partial class frmAlbumDetail : Form
    {
        private int id = 0;
        public frmAlbumDetail()
        {
            InitializeComponent();
        }

        private async Task LoadComboBoxes()
        {
            var songs = await new WebApiHelper<Song>().GetListAsync("api/songs/");
            var albums = await new WebApiHelper<Album>().GetListAsync("api/albums/");

            cmbSong.DisplayMember = "Title";
            cmbSong.ValueMember = "Id";
            cmbSong.DataSource = songs.ToList();

            cmbAlbum.DisplayMember = "AlbumName";
            cmbAlbum.ValueMember = "Id";
            cmbAlbum.DataSource = albums.ToList();
        }

        private async Task LoadData()
        {
            dgvAlbumDetail.Rows.Clear();
            foreach (var item in await new WebApiHelper<AlbumDetailDto>().GetListAsync("api/albumdetails/"))
            {
                dgvAlbumDetail.Rows.Add(item.Id, item.AlbumName, item.SongTitle);
                dgvAlbumDetail.Rows[dgvAlbumDetail.RowCount - 1].Tag = item.Id;
            }
        }


        private async void frmAlbumDetail_Load(object sender, EventArgs e)
        {
            await LoadComboBoxes(); 
            await LoadData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            AlbumDetail entity = new AlbumDetail();
            entity.AlbumId = Convert.ToInt32(cmbAlbum.SelectedValue);
            entity.SongId = Convert.ToInt32(cmbSong.SelectedValue);
            if (id == 0)
            {
                var result = await new WebApiHelper<AlbumDetail>().AddAsync("api/albumdetails", entity);
                if (result != null)
                    await LoadData();
            }
            else
            {
                entity.Id = id;

                if (await new WebApiHelper<AlbumDetail>().UpdateAsync("api/albumdetails/", id, entity))
                    await LoadData();

                id = 0;
            }
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var item = await new WebApiHelper<AlbumDetailDto>().GetByIdAsync("api/albumdetails/", Convert.ToInt32(txtId.Text));
                if (item != null)
                {
                    dgvAlbumDetail.Rows.Clear();
                    dgvAlbumDetail.Rows.Add(item.Id, item.AlbumName, item.SongTitle);
                    dgvAlbumDetail.Rows[dgvAlbumDetail.RowCount - 1].Tag = item.Id;
                }
                else
                    MessageBox.Show("The record not found!");
            }
        }

        private async void dgvAlbumDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var rowId = Convert.ToInt32(dgvAlbumDetail.Rows[e.RowIndex].Tag);
                if (e.ColumnIndex == 3)
                {
                    id = Convert.ToInt32(rowId);
                    cmbAlbum.Text = dgvAlbumDetail.CurrentRow.Cells[1].Value.ToString();
                    cmbSong.Text = dgvAlbumDetail.CurrentRow.Cells[2].Value.ToString();
                }
                else if (e.ColumnIndex == 4)
                {
                    if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await new WebApiHelper<Album>().DeleteAsync("api/albumdetails/", rowId);
                        if (result)
                        {
                            dgvAlbumDetail.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }
    }
}
