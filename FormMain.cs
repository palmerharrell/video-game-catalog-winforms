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
        private FormMode mode;

        public FormMain()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddOrUpdateGame();
            EnableGameList(true);
            EnableAddAndDeleteGame(true);
            ShowSaveAndCancel(false);
            mode = FormMode.View;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //TODO: Either clear form or un-do changes

            //TODO: When Adding, just ClearBindings(). That's probably all.
            //TODO: When Editing, probably need to re-bind everything and select this game from the
            //      listBox somehow. Need a way to "un-do" changes and go back to how it started.
            EnableGameList(true);
            EnableAddAndDeleteGame(true);
            ShowSaveAndCancel(false);

            mode = FormMode.View;
        }

        private void txtbxAnyField_KeyUp(object sender, KeyEventArgs e)
        {
            if (loadedGame != null && mode.Equals(FormMode.View))
            {
                EnableGameList(false);
                EnableAddAndDeleteGame(false);
                ShowSaveAndCancel(true);
                mode = FormMode.Edit;
            }
            else if (loadedGame == null && !mode.Equals(FormMode.View))
            {
                ShowSaveAndCancel(true);
            }
        }

        //TODO: Testing handling all of this with txtbxAnyField_KeyUp() instead
        //private void txtbxRequiredField_KeyUp(object sender, KeyEventArgs e)
        //{
        //    btnSave.Enabled = btnSave.Visible && ValidateInput();
        //}

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
            //ClearBindings();

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
            var isNewGame = mode.Equals(FormMode.Add);

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

            GamesSqlRepo.AddOrUpdateGame(newOrUpdatedGame);
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
