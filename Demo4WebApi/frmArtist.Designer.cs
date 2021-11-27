namespace Demo4WebApi
{
    partial class frmArtist
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.MaskedTextBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvArtist = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActiveFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpActiveFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtist)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Controls.Add(this.btnShowAll);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 71);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(29, 25);
            this.txtId.Mask = "0000000";
            this.txtId.Name = "txtId";
            this.txtId.PromptChar = ' ';
            this.txtId.Size = new System.Drawing.Size(134, 23);
            this.txtId.TabIndex = 3;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(278, 24);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(103, 23);
            this.btnShowAll.TabIndex = 2;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(169, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id";
            // 
            // dgvArtist
            // 
            this.dgvArtist.AllowUserToAddRows = false;
            this.dgvArtist.AllowUserToDeleteRows = false;
            this.dgvArtist.AllowUserToOrderColumns = true;
            this.dgvArtist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ArtistName,
            this.ActiveFrom,
            this.edit,
            this.Delete});
            this.dgvArtist.Location = new System.Drawing.Point(3, 89);
            this.dgvArtist.MultiSelect = false;
            this.dgvArtist.Name = "dgvArtist";
            this.dgvArtist.ReadOnly = true;
            this.dgvArtist.RowHeadersVisible = false;
            this.dgvArtist.RowTemplate.Height = 25;
            this.dgvArtist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArtist.Size = new System.Drawing.Size(607, 249);
            this.dgvArtist.TabIndex = 4;
            this.dgvArtist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArtist_CellClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // ArtistName
            // 
            this.ArtistName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ArtistName.HeaderText = "Artist Name";
            this.ArtistName.MinimumWidth = 100;
            this.ArtistName.Name = "ArtistName";
            this.ArtistName.ReadOnly = true;
            // 
            // ActiveFrom
            // 
            this.ActiveFrom.HeaderText = "Active From";
            this.ActiveFrom.Name = "ActiveFrom";
            this.ActiveFrom.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.FillWeight = 50F;
            this.edit.HeaderText = "Edit";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "Edit";
            this.edit.ToolTipText = "Edit";
            this.edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 50F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpActiveFrom);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtArtistName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 95);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Record";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(88, 25);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(196, 23);
            this.txtArtistName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist Name:";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(262, 446);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Active From:";
            // 
            // dtpActiveFrom
            // 
            this.dtpActiveFrom.Location = new System.Drawing.Point(379, 25);
            this.dtpActiveFrom.Name = "dtpActiveFrom";
            this.dtpActiveFrom.Size = new System.Drawing.Size(200, 23);
            this.dtpActiveFrom.TabIndex = 3;
            // 
            // frmArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 479);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvArtist);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArtist";
            this.ShowInTaskbar = false;
            this.Text = "Artist";
            this.Load += new System.EventHandler(this.frmArtist_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtist)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txtId;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActiveFrom;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DateTimePicker dtpActiveFrom;
        private System.Windows.Forms.Label label3;
    }
}