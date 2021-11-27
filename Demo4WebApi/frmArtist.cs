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
    public partial class frmArtist : Form
    {
        private int id = 0;

        public frmArtist()
        {
            InitializeComponent();
        }

        private async Task LoadData()
        {
            dgvArtist.Rows.Clear();
            foreach (var item in await new WebApiHelper<Artist>().GetListAsync("api/artists/"))
            {
                dgvArtist.Rows.Add(item.Id, item.ArtistName, item.ActiveFrom.ToString("yyyy/MM/dd"));
                dgvArtist.Rows[dgvArtist.RowCount - 1].Tag = item.Id;
            }
        }

        private async void frmArtist_Load(object sender, EventArgs e)
        {
            await LoadData();
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
                var item = await new WebApiHelper<Artist>().GetByIdAsync("api/artists/", Convert.ToInt32(txtId.Text));
                if (item != null)
                {
                    dgvArtist.Rows.Clear();
                    dgvArtist.Rows.Add(item.Id, item.ArtistName, item.ActiveFrom);
                    dgvArtist.Rows[dgvArtist.RowCount - 1].Tag = item.Id;
                }
                else
                    MessageBox.Show("The record not found!");
            }
        }

        private async void dgvArtist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var rowId = Convert.ToInt32(dgvArtist.Rows[e.RowIndex].Tag);
                if (e.ColumnIndex == 3)
                {
                    id = Convert.ToInt32(rowId);
                    txtArtistName.Text = dgvArtist.CurrentRow.Cells[1].Value.ToString();
                    dtpActiveFrom.Text = dgvArtist.CurrentRow.Cells[2].Value.ToString();
                    dtpActiveFrom.Value = Convert.ToDateTime(dgvArtist.CurrentRow.Cells[2].Value.ToString());
                }
                else if (e.ColumnIndex == 4)
                {
                    if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await new WebApiHelper<Artist>().DeleteAsync("api/artists/", rowId);
                        if (result)
                        {
                            dgvArtist.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtArtistName.Text))
            {
                if (id == 0)
                {
                    Artist entity = new Artist();
                    entity.ArtistName = txtArtistName.Text;
                    entity.ActiveFrom = dtpActiveFrom.Value;

                    var result = await new WebApiHelper<Artist>().AddAsync("api/artists", entity);
                    if (result != null)
                        await LoadData();
                }
                else
                {
                    Artist entity = new Artist();
                    entity.ArtistName = txtArtistName.Text;
                    entity.ActiveFrom = dtpActiveFrom.Value;
                    entity.Id = id;

                    if (await new WebApiHelper<Artist>().UpdateAsync("api/artists/", id, entity))
                        await LoadData();

                    id = 0;
                }
                txtArtistName.Text = "";
            }
        }
    }
}