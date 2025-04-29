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
                lblTitleValue.Text = gameRow["Title"].ToString();
                lblGenreValue.Text = gameRow["Genre"].ToString();
                lblPlatformValue.Text = gameRow["Platform"].ToString();
                lblReleaseYearValue.Text = gameRow["ReleaseYear"].ToString();
                lblDeveloperValue.Text = gameRow["Developer"].ToString();
                lblPublisherValue.Text = gameRow["Publisher"].ToString();
                lblDescriptionValue.Text = gameRow["Description"].ToString();

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

        private void ClearBindings()
        {
            picBoxGameImage.Image = null;
            lblTitleValue.Text = string.Empty;
            lblGenreValue.Text = string.Empty;
            lblPlatformValue.Text = string.Empty;
            lblReleaseYearValue.Text = string.Empty;
            lblDeveloperValue.Text = string.Empty;
            lblPublisherValue.Text = string.Empty;
            lblDescriptionValue.Text = string.Empty;
        }

    }
}
