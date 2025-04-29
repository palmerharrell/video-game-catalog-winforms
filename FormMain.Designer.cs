namespace VideoGameCollection_WinForms
{
    partial class FormMain
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
            btnDebug = new Button();
            gameList = new ListBox();
            picBoxGameImage = new PictureBox();
            lblTitle = new Label();
            lblDescription = new Label();
            lblGenre = new Label();
            lblPlatform = new Label();
            lblReleaseYear = new Label();
            lblDeveloper = new Label();
            lblPublisher = new Label();
            txtbxTitle = new TextBox();
            txtbxGenre = new TextBox();
            txtbxPlatform = new TextBox();
            txtbxReleaseYear = new TextBox();
            txtbxDeveloper = new TextBox();
            txtbxPublisher = new TextBox();
            txtbxDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picBoxGameImage).BeginInit();
            SuspendLayout();
            // 
            // btnDebug
            // 
            btnDebug.Location = new Point(905, 486);
            btnDebug.Name = "btnDebug";
            btnDebug.Size = new Size(75, 23);
            btnDebug.TabIndex = 0;
            btnDebug.Text = "Debug";
            btnDebug.UseVisualStyleBackColor = true;
            btnDebug.Click += BtnDebug_Click;
            // 
            // gameList
            // 
            gameList.FormattingEnabled = true;
            gameList.ItemHeight = 15;
            gameList.Location = new Point(10, 10);
            gameList.Name = "gameList";
            gameList.Size = new Size(160, 499);
            gameList.TabIndex = 1;
            gameList.SelectedIndexChanged += gameList_SelectedIndexChanged;
            // 
            // picBoxGameImage
            // 
            picBoxGameImage.Location = new Point(217, 10);
            picBoxGameImage.MaximumSize = new Size(300, 450);
            picBoxGameImage.Name = "picBoxGameImage";
            picBoxGameImage.Size = new Size(300, 450);
            picBoxGameImage.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxGameImage.TabIndex = 2;
            picBoxGameImage.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(562, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 15);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(562, 174);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(80, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.TopRight;
            // 
            // lblGenre
            // 
            lblGenre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGenre.Location = new Point(562, 39);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(80, 15);
            lblGenre.TabIndex = 5;
            lblGenre.Text = "Genre";
            lblGenre.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPlatform
            // 
            lblPlatform.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPlatform.Location = new Point(562, 66);
            lblPlatform.Name = "lblPlatform";
            lblPlatform.Size = new Size(80, 15);
            lblPlatform.TabIndex = 6;
            lblPlatform.Text = "Platform";
            lblPlatform.TextAlign = ContentAlignment.TopRight;
            // 
            // lblReleaseYear
            // 
            lblReleaseYear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReleaseYear.Location = new Point(562, 93);
            lblReleaseYear.Name = "lblReleaseYear";
            lblReleaseYear.Size = new Size(80, 15);
            lblReleaseYear.TabIndex = 8;
            lblReleaseYear.Text = "Release Year";
            lblReleaseYear.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDeveloper
            // 
            lblDeveloper.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeveloper.Location = new Point(562, 120);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(80, 15);
            lblDeveloper.TabIndex = 9;
            lblDeveloper.Text = "Developer";
            lblDeveloper.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPublisher
            // 
            lblPublisher.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPublisher.Location = new Point(562, 147);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(80, 15);
            lblPublisher.TabIndex = 10;
            lblPublisher.Text = "Publisher";
            lblPublisher.TextAlign = ContentAlignment.TopRight;
            // 
            // txtbxTitle
            // 
            txtbxTitle.Location = new Point(660, 9);
            txtbxTitle.Name = "txtbxTitle";
            txtbxTitle.Size = new Size(320, 23);
            txtbxTitle.TabIndex = 11;
            // 
            // txtbxGenre
            // 
            txtbxGenre.Location = new Point(660, 36);
            txtbxGenre.Name = "txtbxGenre";
            txtbxGenre.Size = new Size(320, 23);
            txtbxGenre.TabIndex = 12;
            // 
            // txtbxPlatform
            // 
            txtbxPlatform.Location = new Point(660, 63);
            txtbxPlatform.Name = "txtbxPlatform";
            txtbxPlatform.Size = new Size(320, 23);
            txtbxPlatform.TabIndex = 13;
            // 
            // txtbxReleaseYear
            // 
            txtbxReleaseYear.Location = new Point(660, 90);
            txtbxReleaseYear.Name = "txtbxReleaseYear";
            txtbxReleaseYear.Size = new Size(320, 23);
            txtbxReleaseYear.TabIndex = 14;
            // 
            // txtbxDeveloper
            // 
            txtbxDeveloper.Location = new Point(660, 117);
            txtbxDeveloper.Name = "txtbxDeveloper";
            txtbxDeveloper.Size = new Size(320, 23);
            txtbxDeveloper.TabIndex = 15;
            // 
            // txtbxPublisher
            // 
            txtbxPublisher.Location = new Point(660, 144);
            txtbxPublisher.Name = "txtbxPublisher";
            txtbxPublisher.Size = new Size(320, 23);
            txtbxPublisher.TabIndex = 16;
            // 
            // txtbxDescription
            // 
            txtbxDescription.Location = new Point(660, 171);
            txtbxDescription.Multiline = true;
            txtbxDescription.Name = "txtbxDescription";
            txtbxDescription.Size = new Size(320, 75);
            txtbxDescription.TabIndex = 17;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 518);
            Controls.Add(txtbxDescription);
            Controls.Add(txtbxPublisher);
            Controls.Add(txtbxDeveloper);
            Controls.Add(txtbxReleaseYear);
            Controls.Add(txtbxPlatform);
            Controls.Add(txtbxGenre);
            Controls.Add(txtbxTitle);
            Controls.Add(lblPublisher);
            Controls.Add(lblDeveloper);
            Controls.Add(lblReleaseYear);
            Controls.Add(lblPlatform);
            Controls.Add(lblGenre);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(picBoxGameImage);
            Controls.Add(gameList);
            Controls.Add(btnDebug);
            MinimumSize = new Size(1005, 557);
            Name = "FormMain";
            Text = "Video Game Catalog";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxGameImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDebug;
        private ListBox gameList;
        private PictureBox picBoxGameImage;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblGenre;
        private Label lblPlatform;
        private Label lblReleaseYear;
        private Label lblDeveloper;
        private Label lblPublisher;
        private TextBox txtbxTitle;
        private TextBox txtbxGenre;
        private TextBox txtbxPlatform;
        private TextBox txtbxReleaseYear;
        private TextBox txtbxDeveloper;
        private TextBox txtbxPublisher;
        private TextBox txtbxDescription;
    }
}
