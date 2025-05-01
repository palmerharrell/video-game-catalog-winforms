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
            components = new System.ComponentModel.Container();
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
            btnAddGame = new Button();
            btnDeleteGame = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            grpbxDetail = new GroupBox();
            btnDeleteImage = new Button();
            btnAddImage = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)picBoxGameImage).BeginInit();
            grpbxDetail.SuspendLayout();
            SuspendLayout();
            // 
            // btnDebug
            // 
            btnDebug.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            gameList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameList.FormattingEnabled = true;
            gameList.ItemHeight = 15;
            gameList.Location = new Point(10, 10);
            gameList.MaximumSize = new Size(220, 0);
            gameList.MinimumSize = new Size(183, 469);
            gameList.Name = "gameList";
            gameList.Size = new Size(183, 469);
            gameList.TabIndex = 1;
            gameList.SelectedIndexChanged += gameList_SelectedIndexChanged;
            // 
            // picBoxGameImage
            // 
            picBoxGameImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            picBoxGameImage.BorderStyle = BorderStyle.FixedSingle;
            picBoxGameImage.Location = new Point(217, 10);
            picBoxGameImage.MaximumSize = new Size(600, 0);
            picBoxGameImage.MinimumSize = new Size(300, 300);
            picBoxGameImage.Name = "picBoxGameImage";
            picBoxGameImage.Size = new Size(300, 469);
            picBoxGameImage.SizeMode = PictureBoxSizeMode.Zoom;
            picBoxGameImage.TabIndex = 2;
            picBoxGameImage.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(8, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 15);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.Location = new Point(8, 284);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(80, 15);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            lblDescription.TextAlign = ContentAlignment.TopRight;
            // 
            // lblGenre
            // 
            lblGenre.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblGenre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGenre.Location = new Point(8, 173);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(80, 15);
            lblGenre.TabIndex = 5;
            lblGenre.Text = "Genre";
            lblGenre.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPlatform
            // 
            lblPlatform.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPlatform.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPlatform.Location = new Point(8, 99);
            lblPlatform.Name = "lblPlatform";
            lblPlatform.Size = new Size(80, 15);
            lblPlatform.TabIndex = 6;
            lblPlatform.Text = "Platform";
            lblPlatform.TextAlign = ContentAlignment.TopRight;
            // 
            // lblReleaseYear
            // 
            lblReleaseYear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblReleaseYear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReleaseYear.Location = new Point(8, 136);
            lblReleaseYear.Name = "lblReleaseYear";
            lblReleaseYear.Size = new Size(80, 15);
            lblReleaseYear.TabIndex = 8;
            lblReleaseYear.Text = "Release Year";
            lblReleaseYear.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDeveloper
            // 
            lblDeveloper.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDeveloper.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeveloper.Location = new Point(8, 210);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(80, 15);
            lblDeveloper.TabIndex = 9;
            lblDeveloper.Text = "Developer";
            lblDeveloper.TextAlign = ContentAlignment.TopRight;
            // 
            // lblPublisher
            // 
            lblPublisher.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblPublisher.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPublisher.Location = new Point(8, 247);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(80, 15);
            lblPublisher.TabIndex = 10;
            lblPublisher.Text = "Publisher";
            lblPublisher.TextAlign = ContentAlignment.TopRight;
            // 
            // txtbxTitle
            // 
            txtbxTitle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxTitle.Location = new Point(106, 28);
            txtbxTitle.MaximumSize = new Size(640, 23);
            txtbxTitle.MinimumSize = new Size(320, 23);
            txtbxTitle.Name = "txtbxTitle";
            txtbxTitle.Size = new Size(320, 23);
            txtbxTitle.TabIndex = 11;
            txtbxTitle.KeyUp += txtbxAnyField_KeyUp;
            // 
            // txtbxGenre
            // 
            txtbxGenre.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxGenre.Location = new Point(106, 170);
            txtbxGenre.Name = "txtbxGenre";
            txtbxGenre.Size = new Size(320, 23);
            txtbxGenre.TabIndex = 12;
            txtbxGenre.KeyUp += txtbxAnyField_KeyUp;
            // 
            // txtbxPlatform
            // 
            txtbxPlatform.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxPlatform.Location = new Point(106, 96);
            txtbxPlatform.Name = "txtbxPlatform";
            txtbxPlatform.Size = new Size(320, 23);
            txtbxPlatform.TabIndex = 13;
            txtbxPlatform.KeyUp += txtbxAnyField_KeyUp;
            // 
            // txtbxReleaseYear
            // 
            txtbxReleaseYear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxReleaseYear.Location = new Point(106, 133);
            txtbxReleaseYear.Name = "txtbxReleaseYear";
            txtbxReleaseYear.Size = new Size(320, 23);
            txtbxReleaseYear.TabIndex = 14;
            txtbxReleaseYear.KeyUp += txtbxAnyField_KeyUp;
            // 
            // txtbxDeveloper
            // 
            txtbxDeveloper.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxDeveloper.Location = new Point(106, 207);
            txtbxDeveloper.Name = "txtbxDeveloper";
            txtbxDeveloper.Size = new Size(320, 23);
            txtbxDeveloper.TabIndex = 15;
            txtbxDeveloper.KeyUp += txtbxAnyField_KeyUp;
            // 
            // txtbxPublisher
            // 
            txtbxPublisher.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxPublisher.Location = new Point(106, 244);
            txtbxPublisher.Name = "txtbxPublisher";
            txtbxPublisher.Size = new Size(320, 23);
            txtbxPublisher.TabIndex = 16;
            txtbxPublisher.KeyUp += txtbxAnyField_KeyUp;
            // 
            // txtbxDescription
            // 
            txtbxDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtbxDescription.Location = new Point(106, 281);
            txtbxDescription.Multiline = true;
            txtbxDescription.Name = "txtbxDescription";
            txtbxDescription.Size = new Size(320, 75);
            txtbxDescription.TabIndex = 17;
            txtbxDescription.KeyUp += txtbxAnyField_KeyUp;
            // 
            // btnAddGame
            // 
            btnAddGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddGame.BackgroundImage = Properties.Resources.PlusSignGreen;
            btnAddGame.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddGame.Location = new Point(46, 485);
            btnAddGame.Name = "btnAddGame";
            btnAddGame.Size = new Size(25, 25);
            btnAddGame.TabIndex = 18;
            toolTip1.SetToolTip(btnAddGame, "Add Game");
            btnAddGame.UseVisualStyleBackColor = true;
            btnAddGame.Click += btnAddGame_Click;
            // 
            // btnDeleteGame
            // 
            btnDeleteGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteGame.BackgroundImage = Properties.Resources.MinusSignRed;
            btnDeleteGame.BackgroundImageLayout = ImageLayout.Zoom;
            btnDeleteGame.Location = new Point(101, 485);
            btnDeleteGame.Name = "btnDeleteGame";
            btnDeleteGame.Size = new Size(25, 25);
            btnDeleteGame.TabIndex = 19;
            toolTip1.SetToolTip(btnDeleteGame, "Delete Game");
            btnDeleteGame.UseVisualStyleBackColor = true;
            btnDeleteGame.Click += btnDeleteGame_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Enabled = false;
            btnSave.Location = new Point(149, 382);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(302, 382);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // grpbxDetail
            // 
            grpbxDetail.Anchor = AnchorStyles.Right;
            grpbxDetail.Controls.Add(lblTitle);
            grpbxDetail.Controls.Add(lblPlatform);
            grpbxDetail.Controls.Add(lblReleaseYear);
            grpbxDetail.Controls.Add(lblGenre);
            grpbxDetail.Controls.Add(lblDeveloper);
            grpbxDetail.Controls.Add(lblPublisher);
            grpbxDetail.Controls.Add(lblDescription);
            grpbxDetail.Controls.Add(txtbxTitle);
            grpbxDetail.Controls.Add(txtbxPlatform);
            grpbxDetail.Controls.Add(txtbxReleaseYear);
            grpbxDetail.Controls.Add(txtbxGenre);
            grpbxDetail.Controls.Add(txtbxDeveloper);
            grpbxDetail.Controls.Add(txtbxPublisher);
            grpbxDetail.Controls.Add(txtbxDescription);
            grpbxDetail.Controls.Add(btnSave);
            grpbxDetail.Controls.Add(btnCancel);
            grpbxDetail.Location = new Point(533, 53);
            grpbxDetail.Name = "grpbxDetail";
            grpbxDetail.Size = new Size(444, 426);
            grpbxDetail.TabIndex = 22;
            grpbxDetail.TabStop = false;
            // 
            // btnDeleteImage
            // 
            btnDeleteImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteImage.BackgroundImage = Properties.Resources.MinusSignRed;
            btnDeleteImage.BackgroundImageLayout = ImageLayout.Zoom;
            btnDeleteImage.Location = new Point(372, 485);
            btnDeleteImage.Name = "btnDeleteImage";
            btnDeleteImage.Size = new Size(25, 25);
            btnDeleteImage.TabIndex = 24;
            toolTip1.SetToolTip(btnDeleteImage, "Delete Image");
            btnDeleteImage.UseVisualStyleBackColor = true;
            btnDeleteImage.Click += btnDeleteImage_Click;
            // 
            // btnAddImage
            // 
            btnAddImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddImage.BackgroundImage = Properties.Resources.PlusSignGreen;
            btnAddImage.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddImage.Location = new Point(317, 485);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(25, 25);
            btnAddImage.TabIndex = 23;
            toolTip1.SetToolTip(btnAddImage, "Add Image from disk");
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 518);
            Controls.Add(btnDeleteImage);
            Controls.Add(btnAddImage);
            Controls.Add(grpbxDetail);
            Controls.Add(btnDeleteGame);
            Controls.Add(btnAddGame);
            Controls.Add(picBoxGameImage);
            Controls.Add(gameList);
            Controls.Add(btnDebug);
            MinimumSize = new Size(1005, 557);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Video Game Catalog";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxGameImage).EndInit();
            grpbxDetail.ResumeLayout(false);
            grpbxDetail.PerformLayout();
            ResumeLayout(false);
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
        private Button btnAddGame;
        private Button btnDeleteGame;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox grpbxDetail;
        private Button btnDeleteImage;
        private Button btnAddImage;
        private ToolTip toolTip1;
    }
}
