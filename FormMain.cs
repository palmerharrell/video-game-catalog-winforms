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
        private DataTable images = new();
        private Image? loadedImage;
        private int? loadedImageId;
        private Game? loadedGame;
        private Game? editedGame;
        private int lastSelectedGameIndex = -1;
        private FormMode mode;

        public FormMain()
        {
            InitializeComponent();

            // Debug button for running test code in MainDebugger.MainDebug()
            btnDebug.Enabled = false;
            btnDebug.Visible = false;

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
                EnableAddAndDeleteGame(true);
                EnableAddAndDeleteImage(false);
                EnableDetailControls(false);

                if (games.Rows.Count > 0)
                {
                    gameList.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}", "Error loading games", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gameList_SelectedIndexChanged(object? sender, EventArgs e)
        {
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

            EnableAddAndDeleteGame(true);
            EnableAddAndDeleteImage(true);
            EnableDetailControls(true);
        }

        private void gameList_Leave(object sender, EventArgs e)
        {
            lastSelectedGameIndex = gameList.SelectedIndex;
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            mode = FormMode.Add;

            ClearBindings();
            EnableGameList(false);
            EnableAddAndDeleteGame(false);
            EnableAddAndDeleteImage(false);
            ShowSaveAndCancel(true);
            EnableDetailControls(true);
            txtbxTitle.Focus();
            HighlightRequiredFields(false);
        }

        private void btnDeleteGame_Click(Object sender, EventArgs e)
        {
            if (loadedGame != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {loadedGame.Title.Trim()} and all associated images?",
                                             "Delete Game",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    GamesSqlRepo.DeleteGame(loadedGame.VGID);
                    ImagesSqlRepo.DeleteAllImagesForOneGame(loadedGame.VGID);

                    ClearBindings();
                    LoadGames();
                    BindGameList();
                    EnableAddAndDeleteGame(true);
                    EnableAddAndDeleteImage(false);
                    ShowSaveAndCancel(false);
                    EnableDetailControls(false);

                    gameList.Focus();
                }
            }
            else
            {
                MessageBox.Show("Unable to delete game. Re-select it, and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                        loadedImage = ImageUtilities.ConvertByteArrayToImage(imageBytes);
                        picBoxGameImage.Image = loadedImage;
                        ImagesSqlRepo.InsertImage(loadedGame.VGID, imageBytes);
                        LoadImages(loadedGame.VGID);

                        EnableAddAndDeleteImage(true);

                        Cursor = oldCursor;
                    }
                }
            }
        }

        private void btnDeleteImage_Click(Object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this image?",
                                         "Delete Image",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (loadedGame != null && loadedImageId != null)
                {
                    ImagesSqlRepo.DeleteImage((int)loadedImageId);
                    LoadImages(loadedGame.VGID);
                    EnableAddAndDeleteImage(true);
                }
                else
                {
                    MessageBox.Show("Unable to delete image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var editedGameId = loadedGame?.VGID;

            if (ValidateReleaseYearInput())
            {
                AddOrUpdateGame();

                EnableGameList(true);
                EnableAddAndDeleteGame(true);
                EnableAddAndDeleteImage(true);
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
                        gameList.SelectedIndex = lastSelectedGameIndex;
                    }
                }
            }
            else
            {
                MessageBox.Show("Release Year must be a 4-digit number.", "Release Year Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbxReleaseYear.Focus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableGameList(true);
            EnableAddAndDeleteGame(true);
            ShowSaveAndCancel(false);

            if (mode.Equals(FormMode.Add))
            {
                mode = FormMode.View;
                ClearBindings();
                EnableAddAndDeleteImage(false);
                EnableDetailControls(false);
                gameList.Focus();
            }
            else
            {
                mode = FormMode.View;
                gameList.SelectedIndex = lastSelectedGameIndex;
                EnableAddAndDeleteImage(true);
            }

            HighlightRequiredFields(false);
        }

        private void txtbxAnyField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey ||
                e.KeyCode == Keys.Control ||
                e.KeyCode == Keys.Alt ||
                e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Home ||
                e.KeyCode == Keys.End ||
                e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                return;
            }

            HighlightRequiredFields(false);

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

                ShowSaveAndCancel(true);

                if (comparer.Equals(editedGame, loadedGame))
                {
                    // Changes were undone, so go back to View mode and hide Save & Cancel
                    editedGame = null;
                    EnableGameList(true);
                    EnableAddAndDeleteGame(true);
                    EnableAddAndDeleteImage(true);
                    ShowSaveAndCancel(false);
                    mode = FormMode.View;

                    if (loadedGame != null)
                    {
                        gameList.Focus();
                        gameList.SelectedIndex = lastSelectedGameIndex;
                        EnableAddAndDeleteImage(true);
                    }

                    return;
                }
            }

            if (loadedGame != null && mode.Equals(FormMode.View))
            {
                EnableGameList(false);
                EnableAddAndDeleteGame(false);
                EnableAddAndDeleteImage(false);
                ShowSaveAndCancel(true);
                mode = FormMode.Edit;
                HighlightRequiredFields(false);

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
            var oldCursor = Cursor;

            Cursor = Cursors.WaitCursor;
            games = GamesSqlRepo.GetGames();
            Cursor = oldCursor;
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

            lblAddAGame.Visible = games.Rows.Count == 0;

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

                    EnableDetailControls(true);
                    LoadImages(id);
                }
            }
        }

        private void LoadImages(int id)
        {
            //TODO: LoadImages only loads the first image for now
            var oldCursor = Cursor;

            loadedImage = null;
            loadedImageId = null;
            picBoxGameImage.Image = null;

            Cursor = Cursors.WaitCursor;

            images = ImagesSqlRepo.GetImagesByGame(id);

            if (images != null && images.Rows.Count > 0)
            {
                var firstImage = images.AsEnumerable().First()["Image"] as byte[];

                if (firstImage != null)
                {
                    loadedImage = ImageUtilities.ConvertByteArrayToImage(firstImage);
                    loadedImageId = images.AsEnumerable().First()["ImageID"] as int?;
                    picBoxGameImage.Image = loadedImage;
                }
            }

            lblAddAnImage.Visible = loadedImage == null;
            Cursor = oldCursor;
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

        private bool ValidateRequiredInput()
        {
            return !String.IsNullOrWhiteSpace(txtbxTitle.Text.Trim()) &&
                   !String.IsNullOrWhiteSpace(txtbxPlatform.Text.Trim());
        }

        private bool ValidateReleaseYearInput()
        {
            var yearInput = txtbxReleaseYear.Text.Trim();

            return string.IsNullOrWhiteSpace(yearInput) || (yearInput.Length == 4 && Int16.TryParse(yearInput, out _));
        }

        private void HighlightRequiredFields(bool setFocus)
        {

            //TODO: Currently the Save button is hidden if any required fields are missing, so 
            //      setFocus is never used. If I decide to show the Save button, call this from 
            //      btnSave_Click() with setFocus=true.

            if (mode == FormMode.View)
            {
                txtbxTitle.BackColor = txtbxTitle.Enabled ? Color.White : SystemColors.Control;
                txtbxPlatform.BackColor = txtbxPlatform.Enabled ? Color.White : SystemColors.Control;
                return;
            }

            var focused = false;

            if (string.IsNullOrWhiteSpace(txtbxTitle.Text))
            {
                txtbxTitle.BackColor = Color.LightPink;

                if (setFocus)
                {
                    txtbxTitle.Focus();
                    focused = true;
                }
            }
            else
            {
                txtbxTitle.BackColor = txtbxTitle.Enabled ? Color.White : SystemColors.Control;
            }

            if (string.IsNullOrWhiteSpace(txtbxPlatform.Text))
            {
                txtbxPlatform.BackColor = Color.LightPink;

                if (setFocus && !focused)
                {
                    txtbxPlatform.Focus();
                    focused = true;
                }
            }
            else
            {
                txtbxPlatform.BackColor = txtbxPlatform.Enabled ? Color.White : SystemColors.Control;
            }
        }

        private void ClearBindings()
        {
            loadedGame = null;
            lblAddAGame.Visible = mode == FormMode.View && 
                                  games.Rows.Count == 0;

            loadedImage = null;
            loadedImageId = null;
            picBoxGameImage.Image = null;
            lblAddAnImage.Visible = false;

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
                btnDeleteGame.BackgroundImage = Properties.Resources.MinusSignRedDisabled;
            }
        }

        private void EnableAddAndDeleteImage(bool enable)
        {
            btnAddImage.Enabled = enable &&
                                  loadedGame != null &&
                                  mode == FormMode.View &&
                                  loadedImage == null;

            btnDeleteImage.Enabled = enable &&
                                     loadedGame != null &&
                                     mode == FormMode.View &&
                                     loadedImage != null;

            if (btnAddImage.Enabled)
            {
                btnAddImage.BackgroundImage = Properties.Resources.PlusSignGreen;
            }
            else
            {
                btnAddImage.BackgroundImage = Properties.Resources.PlusSignGreenDisabled;
            }

            if (btnDeleteImage.Enabled)
            {
                btnDeleteImage.BackgroundImage = Properties.Resources.MinusSignRed;
            }
            else
            {
                btnDeleteImage.BackgroundImage = Properties.Resources.MinusSignRedDisabled;
            }
        }

        private void ShowSaveAndCancel(bool show)
        {
            btnSave.Visible = show;
            btnCancel.Visible = show;

            btnSave.Enabled = show && ValidateRequiredInput();
            btnCancel.Enabled = show;
        }

        private void EnableDetailControls(bool enable)
        {
            HighlightRequiredFields(false);
            enable = enable && (loadedGame != null || mode == FormMode.Add);

            txtbxTitle.Enabled = enable;
            txtbxGenre.Enabled = enable;
            txtbxPlatform.Enabled = enable;
            txtbxReleaseYear.Enabled = enable;
            txtbxDeveloper.Enabled = enable;
            txtbxPublisher.Enabled = enable;
            txtbxDescription.Enabled = enable;
        }
    }
}
