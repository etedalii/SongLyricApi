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
            this.menuAlbum = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuAlbum});
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
            // 
            // menuAlbum
            // 
            this.menuAlbum.Name = "menuAlbum";
            this.menuAlbum.Size = new System.Drawing.Size(55, 20);
            this.menuAlbum.Text = "Album";
            this.menuAlbum.Click += new System.EventHandler(this.menuAlbum_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(734, 404);
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
        private System.Windows.Forms.ToolStripMenuItem menuAlbum;
    }
}
