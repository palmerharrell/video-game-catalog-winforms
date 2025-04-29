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
            lblPublisherValue = new Label();
            lblDeveloperValue = new Label();
            lblReleaseYearValue = new Label();
            lblPlatformValue = new Label();
            lblGenreValue = new Label();
            lblDescriptionValue = new Label();
            lblTitleValue = new Label();
            ((System.ComponentModel.ISupportInitialize)picBoxGameImage).BeginInit();
            SuspendLayout();
            // 
            // btnDebug
            // 
            btnDebug.Location = new Point(448, 486);
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
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(562, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(562, 174);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(71, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGenre.Location = new Point(562, 39);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(42, 15);
            lblGenre.TabIndex = 5;
            lblGenre.Text = "Genre";
            // 
            // lblPlatform
            // 
            lblPlatform.AutoSize = true;
            lblPlatform.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPlatform.Location = new Point(562, 66);
            lblPlatform.Name = "lblPlatform";
            lblPlatform.Size = new Size(56, 15);
            lblPlatform.TabIndex = 6;
            lblPlatform.Text = "Platform";
            // 
            // lblReleaseYear
            // 
            lblReleaseYear.AutoSize = true;
            lblReleaseYear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReleaseYear.Location = new Point(562, 93);
            lblReleaseYear.Name = "lblReleaseYear";
            lblReleaseYear.Size = new Size(77, 15);
            lblReleaseYear.TabIndex = 8;
            lblReleaseYear.Text = "Release Year";
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeveloper.Location = new Point(562, 120);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(66, 15);
            lblDeveloper.TabIndex = 9;
            lblDeveloper.Text = "Developer";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPublisher.Location = new Point(562, 147);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(58, 15);
            lblPublisher.TabIndex = 10;
            lblPublisher.Text = "Publisher";
            // 
            // lblPublisherValue
            // 
            lblPublisherValue.AutoSize = true;
            lblPublisherValue.Location = new Point(663, 147);
            lblPublisherValue.Name = "lblPublisherValue";
            lblPublisherValue.Size = new Size(56, 15);
            lblPublisherValue.TabIndex = 17;
            lblPublisherValue.Text = "Publisher";
            // 
            // lblDeveloperValue
            // 
            lblDeveloperValue.AutoSize = true;
            lblDeveloperValue.Location = new Point(663, 120);
            lblDeveloperValue.Name = "lblDeveloperValue";
            lblDeveloperValue.Size = new Size(60, 15);
            lblDeveloperValue.TabIndex = 16;
            lblDeveloperValue.Text = "Developer";
            // 
            // lblReleaseYearValue
            // 
            lblReleaseYearValue.AutoSize = true;
            lblReleaseYearValue.Location = new Point(663, 93);
            lblReleaseYearValue.Name = "lblReleaseYearValue";
            lblReleaseYearValue.Size = new Size(71, 15);
            lblReleaseYearValue.TabIndex = 15;
            lblReleaseYearValue.Text = "Release Year";
            // 
            // lblPlatformValue
            // 
            lblPlatformValue.AutoSize = true;
            lblPlatformValue.Location = new Point(663, 66);
            lblPlatformValue.Name = "lblPlatformValue";
            lblPlatformValue.Size = new Size(53, 15);
            lblPlatformValue.TabIndex = 14;
            lblPlatformValue.Text = "Platform";
            // 
            // lblGenreValue
            // 
            lblGenreValue.AutoSize = true;
            lblGenreValue.Location = new Point(663, 39);
            lblGenreValue.Name = "lblGenreValue";
            lblGenreValue.Size = new Size(38, 15);
            lblGenreValue.TabIndex = 13;
            lblGenreValue.Text = "Genre";
            // 
            // lblDescriptionValue
            // 
            lblDescriptionValue.AutoSize = true;
            lblDescriptionValue.Location = new Point(663, 174);
            lblDescriptionValue.Name = "lblDescriptionValue";
            lblDescriptionValue.Size = new Size(67, 15);
            lblDescriptionValue.TabIndex = 12;
            lblDescriptionValue.Text = "Description";
            // 
            // lblTitleValue
            // 
            lblTitleValue.AutoSize = true;
            lblTitleValue.Location = new Point(663, 12);
            lblTitleValue.Name = "lblTitleValue";
            lblTitleValue.Size = new Size(30, 15);
            lblTitleValue.TabIndex = 11;
            lblTitleValue.Text = "Title";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 518);
            Controls.Add(lblPublisherValue);
            Controls.Add(lblDeveloperValue);
            Controls.Add(lblReleaseYearValue);
            Controls.Add(lblPlatformValue);
            Controls.Add(lblGenreValue);
            Controls.Add(lblDescriptionValue);
            Controls.Add(lblTitleValue);
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
        private Label lblPublisherValue;
        private Label lblDeveloperValue;
        private Label lblReleaseYearValue;
        private Label lblPlatformValue;
        private Label lblGenreValue;
        private Label lblDescriptionValue;
        private Label lblTitleValue;
    }
}
