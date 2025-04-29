using System.Data;
using VideoGameCollection_WinForms.Repositories;

namespace VideoGameCollection_WinForms
{
    public partial class FormMain : Form
    {
        private DataTable games = new();
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
            //TODO: Get game details from games DataTable
            //TODO: Get game image(s) from database
            //TODO: Bind details/images to detail controls
        }

        private void ClearBindings()
        {
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
