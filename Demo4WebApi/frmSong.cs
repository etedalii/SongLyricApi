using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SongLyricEntities;

namespace Demo4WebApi
{
    public partial class frmSong : Form
    {
        private int id = 0;
        public frmSong()
        {
            InitializeComponent();
        }

        private async Task LoadData()
        {
            dgvSong.Rows.Clear();
            foreach (var item in await new WebApiHelper<Song>().GetListAsync("api/songs"))
            {
                dgvSong.Rows.Add(item.Id, item.Title, item.Lyric, item.ReleaseDate.ToString("yyyy/MM/dd"));
                dgvSong.Rows[dgvSong.RowCount - 1].Tag = item.Id;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            await LoadData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var item = await new WebApiHelper<Song>().GetByIdAsync("api/songs/", Convert.ToInt32(txtId.Text));
                if (item != null)
                {
                    dgvSong.Rows.Clear();
                    dgvSong.Rows.Add(item.Id, item.Title, item.Lyric, item.ReleaseDate.ToString("yyyy/MM/dd"));
                    dgvSong.Rows[dgvSong.RowCount - 1].Tag = item.Id;
                }
                else
                    MessageBox.Show("The record not found!");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSongName.Text))
            {
                if (id == 0)
                {
                    Song entity = new Song();
                    entity.Title = txtSongName.Text;
                    entity.ReleaseDate = dtpActiveFrom.Value;
                    entity.Lyric = txtLyric.Text;

                    var result = await new WebApiHelper<Song>().AddAsync("api/songs", entity);
                    if (result != null)
                        await LoadData();
                }
                else
                {
                    Song entity = new Song();
                    entity.Title = txtSongName.Text;
                    entity.ReleaseDate = dtpActiveFrom.Value;
                    entity.Lyric = txtLyric.Text;
                    entity.Id = id;

                    if (await new WebApiHelper<Song>().UpdateAsync("api/songs/", id, entity))
                        await LoadData();

                    id = 0;
                }
                txtSongName.Text = txtLyric.Text = "";
            }
        }

        private async void dgvSong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var rowId = Convert.ToInt32(dgvSong.Rows[e.RowIndex].Tag);
                if (e.ColumnIndex == 4)
                {
                    id = Convert.ToInt32(rowId);
                    txtSongName.Text = dgvSong.CurrentRow.Cells[1].Value.ToString();
                    txtLyric.Text = dgvSong.CurrentRow.Cells[2].Value.ToString();
                    dtpActiveFrom.Text = dgvSong.CurrentRow.Cells[3].Value.ToString();
                    dtpActiveFrom.Value = Convert.ToDateTime(dgvSong.CurrentRow.Cells[3].Value.ToString());
                }
                else if (e.ColumnIndex == 5)
                {
                    if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await new WebApiHelper<Song>().DeleteAsync("api/songs/", rowId);
                        if (result)
                        {
                            dgvSong.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }

        private async void frmSong_Load(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
