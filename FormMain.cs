using System.Data;
using VideoGameCollection_WinForms.Repositories;
using VideoGameCollection_WinForms.Utilities;

namespace VideoGameCollection_WinForms
{
    public partial class FormMain : Form
    {
        private DataTable games = new();
        private Image? gameImage;
        private string loadedGameID = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
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
            if (gameList.SelectedItem != null)
            {
                DataRowView selectedGame = (DataRowView)gameList.SelectedItem;

                if (selectedGame != null)
                {
                    var selectedGameID = selectedGame.Row["VGID"].ToString();

                    if (selectedGameID != null && !string.Equals(selectedGameID, loadedGameID))
                    {
                        BindGameDetail(selectedGameID);
                        loadedGameID = selectedGameID;
                    }
                }
            }
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            ClearBindings();
            ShowSaveAndCancel(true);
            EnableAddAndDeleteGame(false);
            txtbxTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Either INSERT or UPDATE
            ShowSaveAndCancel(false);
            EnableAddAndDeleteGame(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //TODO: Either clear form or un-do changes
            
            //TODO: When Adding, just ClearBindings(). That's probably all.
            //TODO: When Editing, probably need to re-bind everything and select this game from the
            //      listBox somehow. Need a way to "un-do" changes and go back to how it started.
            ShowSaveAndCancel(false);
            EnableAddAndDeleteGame(true);
        }

        private void txtbxRequiredField_KeyUp(object sender, KeyEventArgs e)
        {
            btnSave.Enabled = btnSave.Visible && ValidateInput();
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
            ClearBindings();

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

        private bool ValidateInput()
        {
            return !String.IsNullOrWhiteSpace(txtbxTitle.Text.Trim()) &&
                   !String.IsNullOrWhiteSpace(txtbxPlatform.Text.Trim());
        }

        private void ClearBindings()
        {
            picBoxGameImage.Image = null;

            txtbxTitle.Text = string.Empty;
            txtbxGenre.Text = string.Empty;
            txtbxPlatform.Text = string.Empty;
            txtbxReleaseYear.Text = string.Empty;
            txtbxDeveloper.Text = string.Empty;
            txtbxPublisher.Text = string.Empty;
            txtbxDescription.Text = string.Empty;
        }

        private void ShowSaveAndCancel(bool show)
        {
            btnSave.Visible = show;
            btnCancel.Visible = show;

            btnSave.Enabled = show && ValidateInput();
            btnCancel.Enabled = show;
        }

        private void EnableAddAndDeleteGame(bool enable)
        {
            btnAddGame.Enabled = enable;
            btnDeleteGame.Enabled = enable && gameList.Items.Count > 0;

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

    }
}
