using System.Data;
using VideoGameCollection_WinForms.Models;
using VideoGameCollection_WinForms.Repositories;
using VideoGameCollection_WinForms.Utilities;

namespace VideoGameCollection_WinForms
{
    public partial class FormMain : Form
    {
        private enum FormMode
        {
            View,
            Add,
            Edit
        }

        private DataTable games = new();
        private Image? gameImage;
        private Game? loadedGame;
        private Game? editedGame;
        private FormMode mode;

        public FormMain()
        {
            InitializeComponent();

            // Prevents visual artifacts when resizing window
            ResizeRedraw = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                mode = FormMode.View;
                ClearBindings();
                LoadGames();
                BindGameList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Error loading games", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gameList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            EnableAddAndDeleteGame(true);

            if (mode.Equals(FormMode.View) && gameList.SelectedItem != null)
            {
                DataRowView selectedGame = (DataRowView)gameList.SelectedItem;

                if (selectedGame != null)
                {
                    var selectedGameID = selectedGame.Row["VGID"].ToString();

                    if (selectedGameID != null && !string.Equals(selectedGameID, loadedGame?.VGID))
                    {
                        BindGameDetail(selectedGameID);
                    }
                }
            }
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            mode = FormMode.Add;

            ClearBindings();
            EnableGameList(false);
            EnableAddAndDeleteGame(false);
            ShowSaveAndCancel(true);
            txtbxTitle.Focus();
        }

        private void btnDeleteGame_Click(Object sender, EventArgs e)
        {
            // TODO: Prompt for confirmation, then delete game row from database as well as all associated images 
            MessageBox.Show("Delete Game not yet implemented");
        }

        private void btnAddImage_Click(Object sender, EventArgs e)
        {
            byte[]? imageBytes = null;

            if (mode.Equals(FormMode.View) && loadedGame != null)
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Title = "Import Game Image";
                    dialog.InitialDirectory = "c:\\";
                    dialog.Filter = ImageUtilities.ImageFileFormats;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        imageBytes = File.ReadAllBytes(dialog.FileName);
                    }

                    if (imageBytes != null)
                    {
                        var oldCursor = Cursor;
                        Cursor = Cursors.WaitCursor;

                        gameImage = ImageUtilities.ConvertByteArrayToImage(imageBytes);
                        picBoxGameImage.Image = gameImage;
                        ImagesSqlRepo.InsertImage(loadedGame.VGID, imageBytes);

                        Cursor = oldCursor;
                    }
                }
            }
        }

        private void btnDeleteImage_Click(Object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("Delete Image not yet implemented");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var editedGameId = loadedGame?.VGID;

            AddOrUpdateGame();

            EnableGameList(true);
            EnableAddAndDeleteGame(true);
            ShowSaveAndCancel(false);

            ClearBindings();
            LoadGames();
            BindGameList();

            if (mode.Equals(FormMode.Add))
            {
                mode = FormMode.View;
                gameList.SelectedIndex = gameList.Items.Count - 1;
            }
            else
            {
                mode = FormMode.View;

                if (editedGameId != null)
                {
                    gameList.SelectedIndex = (int)(editedGameId - 1);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var editedGameId = loadedGame?.VGID;

            EnableGameList(true);
            EnableAddAndDeleteGame(true);
            ShowSaveAndCancel(false);

            if (mode.Equals(FormMode.Add))
            {
                mode = FormMode.View;
                ClearBindings();
            }
            else
            {
                mode = FormMode.View;

                if (editedGameId != null)
                {
                    gameList.SelectedIndex = (int)(editedGameId - 1);
                }
            }
        }

        private void txtbxAnyField_KeyUp(object sender, KeyEventArgs e)
        {
            if (mode.Equals(FormMode.Edit))
            {
                var comparer = new GameComparer();

                if (editedGame != null)
                {
                    editedGame.Title = txtbxTitle.Text.Trim();
                    editedGame.Platform = txtbxPlatform.Text.Trim();
                    editedGame.Description = txtbxDescription.Text.Trim();
                    editedGame.Genre = txtbxGenre.Text.Trim();
                    editedGame.ReleaseYear = txtbxReleaseYear.Text.Trim();
                    editedGame.Developer = txtbxDeveloper.Text.Trim();
                    editedGame.Publisher = txtbxPublisher.Text.Trim();
                }

                if (comparer.Equals(editedGame, loadedGame))
                {
                    // Changes were undone, so go back to View mode and hide Save & Cancel
                    editedGame = null;
                    EnableGameList(true);
                    EnableAddAndDeleteGame(true);
                    ShowSaveAndCancel(false);
                    mode = FormMode.View;

                    if (loadedGame != null)
                    {
                        gameList.Focus();
                        gameList.SelectedIndex = (loadedGame.VGID - 1);
                    }

                    return;
                }
            }

            if (loadedGame != null && mode.Equals(FormMode.View))
            {
                EnableGameList(false);
                EnableAddAndDeleteGame(false);
                ShowSaveAndCancel(true);
                mode = FormMode.Edit;

                editedGame = new Game(false)
                {
                    VGID = loadedGame.VGID,
                    Title = txtbxTitle.Text.Trim(),
                    Platform = txtbxPlatform.Text.Trim(),
                    Description = txtbxDescription.Text.Trim(),
                    Genre = txtbxGenre.Text.Trim(),
                    ReleaseYear = txtbxReleaseYear.Text.Trim(),
                    Developer = txtbxDeveloper.Text.Trim(),
                    Publisher = txtbxPublisher.Text.Trim(),
                    Physical = true
                };
            }
            else if (loadedGame == null && !mode.Equals(FormMode.View))
            {
                ShowSaveAndCancel(true);
            }
        }

        private void BtnDebug_Click(object sender, EventArgs e)
        {
            MainDebugger.MainDebug();
        }

        private void LoadGames()
        {
            games = GamesSqlRepo.GetGames();
        }

        private void BindGameList()
        {
            gameList.SelectedIndexChanged -= gameList_SelectedIndexChanged;
            gameList.DataSource = null;
            gameList.DisplayMember = string.Empty;
            gameList.Items.Clear();

            if (games.Rows.Count > 0)
            {
                gameList.DataSource = games;
                gameList.DisplayMember = "Title";
                gameList.ClearSelected();
            }

            gameList.SelectedIndexChanged += gameList_SelectedIndexChanged;
        }

        private void BindGameDetail(string gameID)
        {
            var gameRow = games.AsEnumerable().Where(x => x["VGID"].ToString() == gameID).FirstOrDefault();

            if (gameRow != null)
            {
                txtbxTitle.Text = gameRow["Title"].ToString();
                txtbxGenre.Text = gameRow["Genre"].ToString();
                txtbxPlatform.Text = gameRow["Platform"].ToString();
                txtbxReleaseYear.Text = gameRow["ReleaseYear"].ToString();
                txtbxDeveloper.Text = gameRow["Developer"].ToString();
                txtbxPublisher.Text = gameRow["Publisher"].ToString();
                txtbxDescription.Text = gameRow["Description"].ToString();

                if (int.TryParse(gameID.Trim(), out int id))
                {
                    loadedGame = new Game(false)
                    {
                        VGID = id,
                        Title = txtbxTitle.Text.Trim(),
                        Platform = txtbxPlatform.Text.Trim(),
                        Description = txtbxDescription.Text.Trim(),
                        Genre = txtbxGenre.Text.Trim(),
                        ReleaseYear = txtbxReleaseYear.Text.Trim(),
                        Developer = txtbxDeveloper.Text.Trim(),
                        Publisher = txtbxPublisher.Text.Trim(),
                        Physical = true
                    };

                    picBoxGameImage.Image = null;

                    var images = ImagesSqlRepo.GetImagesByGame(id);

                    if (images != null && images.Rows.Count > 0)
                    {
                        var firstImage = images.AsEnumerable().First()["Image"] as byte[];

                        if (firstImage != null)
                        {
                            gameImage = ImageUtilities.ConvertByteArrayToImage(firstImage);
                            picBoxGameImage.Image = gameImage;
                        }
                    }
                }
            }

            //TODO: Maybe get image dimensions and change dimensions of PictureBox to match, if under a certain size 
            //TODO: Otherwise, probably have to stick with Zoom, since image will be too big for Form
        }

        private void AddOrUpdateGame()
        {
            var comparer = new GameComparer();
            var isNewGame = mode.Equals(FormMode.Add);
            var oldCursor = Cursor;

            var newOrUpdatedGame = new Game(isNew: isNewGame)
            {
                VGID = loadedGame?.VGID ?? 0,
                Title = txtbxTitle.Text.Trim(),
                Platform = txtbxPlatform.Text.Trim(),
                Description = txtbxDescription.Text.Trim(),
                Genre = txtbxGenre.Text.Trim(),
                ReleaseYear = txtbxReleaseYear.Text.Trim(),
                Developer = txtbxDeveloper.Text.Trim(),
                Publisher = txtbxPublisher.Text.Trim(),
                Physical = true
            };

            if (!isNewGame && comparer.Equals(newOrUpdatedGame, loadedGame))
            {
                // Nothing changed. Don't update database.
                return;
            }
            
            Cursor = Cursors.WaitCursor;
            GamesSqlRepo.AddOrUpdateGame(newOrUpdatedGame);
            Cursor = oldCursor;
        }

        private bool ValidateInput()
        {
            return !String.IsNullOrWhiteSpace(txtbxTitle.Text.Trim()) &&
                   !String.IsNullOrWhiteSpace(txtbxPlatform.Text.Trim());
        }

        private void ClearBindings()
        {
            loadedGame = null;

            picBoxGameImage.Image = null;

            txtbxTitle.Text = string.Empty;
            txtbxGenre.Text = string.Empty;
            txtbxPlatform.Text = string.Empty;
            txtbxReleaseYear.Text = string.Empty;
            txtbxDeveloper.Text = string.Empty;
            txtbxPublisher.Text = string.Empty;
            txtbxDescription.Text = string.Empty;
        }

        private void EnableGameList(bool enable)
        {
            if (!enable)
            {
                gameList.SelectedItem = null;
            }
            gameList.Enabled = enable;
        }

        private void EnableAddAndDeleteGame(bool enable)
        {
            btnAddGame.Enabled = enable;
            btnDeleteGame.Enabled = enable && 
                                    gameList.Items.Count > 0 && 
                                    gameList.SelectedItem != null;

            if (btnAddGame.Enabled)
            {
                btnAddGame.BackgroundImage = Properties.Resources.PlusSignGreen;
            }
            else
            {
                btnAddGame.BackgroundImage = Properties.Resources.PlusSignGreenDisabled;
            }

            if (btnDeleteGame.Enabled)
            {
                btnDeleteGame.BackgroundImage = Properties.Resources.MinusSignRed;
            }
            else
            {
                btnDeleteGame.BackgroundImage= Properties.Resources.MinusSignRedDisabled;
            }
        }
        private void ShowSaveAndCancel(bool show)
        {
            btnSave.Visible = show;
            btnCancel.Visible = show;

            btnSave.Enabled = show && ValidateInput();
            btnCancel.Enabled = show;
        }

    }
}
