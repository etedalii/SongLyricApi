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
    public partial class frmGenre : Form
    {
        private int id = 0;

        public frmGenre()
        {
            InitializeComponent();
        }

        private async void frmArtist_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            dgvGenre.Rows.Clear();
            foreach (var item in await new WebApiHelper<Genre>().GetListAsync("api/genres/"))
            {
                dgvGenre.Rows.Add(item.Id, item.GenreName);
                dgvGenre.Rows[dgvGenre.RowCount - 1].Tag = item.Id;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGenreName.Text))
            {
                if (id == 0)
                {
                    Genre genre = new Genre();
                    genre.GenreName = txtGenreName.Text;
                    var result = await new WebApiHelper<Genre>().AddAsync("api/genres", genre);
                    if (result != null)
                        await LoadData();
                }
                else
                {
                    Genre genre = new Genre()
                    {
                        GenreName = txtGenreName.Text,
                        Id = id,
                    };
                    if (await new WebApiHelper<Genre>().UpdateAsync("api/genres/", id, genre))
                        await LoadData();

                    id = 0;
                }
                txtGenreName.Text = "";
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var item = await new WebApiHelper<Genre>().GetByIdAsync("api/genres/", Convert.ToInt32(txtId.Text));
                if (item != null)
                {
                    dgvGenre.Rows.Clear();
                    dgvGenre.Rows.Add(item.Id, item.GenreName);
                    dgvGenre.Rows[dgvGenre.RowCount - 1].Tag = item.Id;
                }
                else
                    MessageBox.Show("The record not found!");
            }
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            txtId.Text = String.Empty;
            await LoadData();
        }

        private async void dgvArtist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var rowId = Convert.ToInt32(dgvGenre.Rows[e.RowIndex].Tag);
                if (e.ColumnIndex == 2)
                {
                    id = Convert.ToInt32(rowId);
                    txtGenreName.Text = dgvGenre.CurrentRow.Cells[1].Value.ToString();
                }
                else if (e.ColumnIndex == 3)
                {
                    if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var result = await new WebApiHelper<Genre>().DeleteAsync("api/genres/", rowId);
                        if (result)
                        {
                            dgvGenre.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }
    }
}
