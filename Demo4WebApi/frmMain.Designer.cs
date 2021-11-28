namespace Demo4WebApi
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuGenre = new System.Windows.Forms.ToolStripMenuItem();
            this.menuArtist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSong = new System.Windows.Forms.ToolStripMenuItem();
            this.SAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAlbumDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSong = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtLyric = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(290, 17);
            this.toolStripStatusLabel1.Text = "Centennial College 2021 Mohammad Etedali - Han Lu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGenre,
            this.menuArtist,
            this.menuSong,
            this.SAlbum});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuGenre
            // 
            this.menuGenre.Name = "menuGenre";
            this.menuGenre.Size = new System.Drawing.Size(50, 20);
            this.menuGenre.Text = "Genre";
            this.menuGenre.Click += new System.EventHandler(this.menuGenre_Click);
            // 
            // menuArtist
            // 
            this.menuArtist.Name = "menuArtist";
            this.menuArtist.Size = new System.Drawing.Size(47, 20);
            this.menuArtist.Text = "Artist";
            this.menuArtist.Click += new System.EventHandler(this.menuArtist_Click);
            // 
            // menuSong
            // 
            this.menuSong.Name = "menuSong";
            this.menuSong.Size = new System.Drawing.Size(46, 20);
            this.menuSong.Text = "Song";
            this.menuSong.Click += new System.EventHandler(this.menuSong_Click);
            // 
            // SAlbum
            // 
            this.SAlbum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAlbum,
            this.menuAlbumDetail});
            this.SAlbum.Name = "SAlbum";
            this.SAlbum.Size = new System.Drawing.Size(55, 20);
            this.SAlbum.Text = "Album";
            // 
            // menuAlbum
            // 
            this.menuAlbum.Name = "menuAlbum";
            this.menuAlbum.Size = new System.Drawing.Size(145, 22);
            this.menuAlbum.Text = "Album";
            this.menuAlbum.Click += new System.EventHandler(this.menuAlbum_Click);
            // 
            // menuAlbumDetail
            // 
            this.menuAlbumDetail.Name = "menuAlbumDetail";
            this.menuAlbumDetail.Size = new System.Drawing.Size(145, 22);
            this.menuAlbumDetail.Text = "AlbumDetails";
            this.menuAlbumDetail.Click += new System.EventHandler(this.menuAlbumDetail_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Song Title";
            // 
            // txtSong
            // 
            this.txtSong.Location = new System.Drawing.Point(76, 33);
            this.txtSong.Name = "txtSong";
            this.txtSong.Size = new System.Drawing.Size(198, 23);
            this.txtSong.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(280, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(132, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search Lyric";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtLyric
            // 
            this.txtLyric.Location = new System.Drawing.Point(12, 62);
            this.txtLyric.Multiline = true;
            this.txtLyric.Name = "txtLyric";
            this.txtLyric.ReadOnly = true;
            this.txtLyric.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyric.Size = new System.Drawing.Size(710, 317);
            this.txtLyric.TabIndex = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(734, 404);
            this.Controls.Add(this.txtLyric);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo 4 WebAPI";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuGenre;
        private System.Windows.Forms.ToolStripMenuItem menuArtist;
        private System.Windows.Forms.ToolStripMenuItem menuSong;
        private System.Windows.Forms.ToolStripMenuItem SAlbum;
        private System.Windows.Forms.ToolStripMenuItem menuAlbum;
        private System.Windows.Forms.ToolStripMenuItem menuAlbumDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSong;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtLyric;
    }
}
