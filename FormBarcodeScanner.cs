using System.Media;
using VideoGameCollection_WinForms.Models;
using VideoGameCollection_WinForms.Repositories;
using VideoGameCollection_WinForms.WebScrapers.PriceCharting;

namespace VideoGameCollection_WinForms
{
    public partial class FormBarcodeScanner : Form
    {
        private string scannedUPC = string.Empty;
        private string coverImageURL = string.Empty;
        private PriceChartingGameData? scrapedGameData = null;
        private Game? scrapedGame = null;

        public FormBarcodeScanner()
        {
            InitializeComponent();

            // Allows capturing key presses at form level before sending to controls
            KeyPreview = true;
        }

        private void btnStopScanning_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormBarcodeScanner_KeyDown(object sender, KeyEventArgs e)
        {
            KeysConverter converter = new KeysConverter();
            var scannedChar = converter.ConvertToString(e.KeyCode);

            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(scannedUPC))
                {
                    ProcessScannedUPC();
                }
                else
                {
                    ShowStatusMessage(success: false, failedToScan: true);
                    ClearStoredData();
                }
            }
            else
            {
                scannedUPC += scannedChar;
            }
        }

        private void ProcessScannedUPC()
        {
            try
            {
                btnStopScanning.Enabled = false;

                ScrapeGameData();

                if (ValidateScrapedData())
                {
                    if (AddScrapedGame())
                    {
                        ShowStatusMessage(success: true);
                    }
                    else
                    {
                        ShowStatusMessage(success: false, declinedToAdd: true);
                    }
                }
                else
                {
                    ShowStatusMessage(success: false);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"There was an error attempting to scrape data for UPC {scannedUPC}. Exception:{Environment.NewLine}{ex.Message}");
            }
            finally
            {
                ClearStoredData();
                btnStopScanning.Enabled = true;
            }
        }

        private void ScrapeGameData()
        {
            var oldCursor = Cursor;

            try
            {
                var gameDataScraper = new PriceChartingScraper();

                Cursor = Cursors.WaitCursor;
                scrapedGameData = gameDataScraper.GetGameDataByUPC(scannedUPC.Trim());
                Cursor = oldCursor;

                if (scrapedGameData != null)
                {
                    scrapedGame = new Game(isNew:true)
                    {
                        Title = scrapedGameData.Title.Trim(),
                        Platform = scrapedGameData.Platform.Trim(),
                        Genre = scrapedGameData.Genre.Trim(),
                        ReleaseYear = scrapedGameData.ReleaseYear.Trim(),
                        Developer = scrapedGameData.Developer.Trim(),
                        Publisher = scrapedGameData.Publisher.Trim(),
                        ScannedUPC = scannedUPC.Trim(),
                        Physical = true
                    };

                    coverImageURL = scrapedGameData.CoverImageURL;
                }
            }
            finally
            {
                Cursor = oldCursor;
            }
        }

        private bool ValidateScrapedData()
        {
            return scrapedGame != null &&
                               !string.IsNullOrWhiteSpace(scrapedGame.Title) &&
                               !string.IsNullOrWhiteSpace(scrapedGame.Platform) &&
                               ValidReleaseYear(scrapedGame.ReleaseYear);
        }

        private bool AddScrapedGame()
        {
            if (!chkbxAutoAdd.Checked)
            {
                string details = Environment.NewLine;
            
                details += $"Game Title: {scrapedGame?.Title}{Environment.NewLine}";
                details += $"Platform: {scrapedGame?.Platform}{Environment.NewLine}";
                details += $"Genre: {(string.IsNullOrWhiteSpace(scrapedGame?.Genre) ? "[No Data]" : scrapedGame?.Genre)}{Environment.NewLine}";
                details += $"Release Year: {(string.IsNullOrWhiteSpace(scrapedGame?.ReleaseYear) ? "[No Data]" : scrapedGame?.ReleaseYear)}{Environment.NewLine}";
                details += $"Developer: {(string.IsNullOrWhiteSpace(scrapedGame?.Developer) ? "[No Data]" : scrapedGame?.Developer)}{Environment.NewLine}";
                details += $"Publisher: {(string.IsNullOrWhiteSpace(scrapedGame?.Publisher) ? "[No Data]" : scrapedGame?.Publisher)}{Environment.NewLine}";
                
                var result = MessageBox.Show($"Game data found! Add to database?{Environment.NewLine}{details}",
                                             "Game Data Found",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Information);
                
                if (result != DialogResult.Yes) return false;
            }

            var oldCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            GamesSqlRepo.AddOrUpdateGame(scrapedGame!);

            if (chkbxGetCoverImage.Checked)
            {
                GetCoverImage();
            }

            Cursor = oldCursor;
            return true;
        }

        private async void GetCoverImage()
        {
            byte[] imageBytes;

            using (var client = new HttpClient())
            {
                imageBytes = await client.GetByteArrayAsync(coverImageURL);
                //TODO: Can't finish below without getting ID of game I just INSERTED (see notes for a plan)
                //ImagesSqlRepo.InsertImage(ugh, imageBytes);
            }
        }

        private void ShowStatusMessage(bool success, bool declinedToAdd = false, bool failedToScan = false)
        {
            if (failedToScan)
            {
                lblStatus.Text = $"Failed to scan barcode. Please try again.";
                lblStatus.ForeColor = Color.Red;
                SystemSounds.Exclamation.Play();
                return;
            }

            if (success)
            {
                lblStatus.Text = $"{scrapedGame?.Title} successfully added to database.";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                if (declinedToAdd)
                {
                    lblStatus.Text = $"Did not add {scrapedGame?.Title} to database.";
                    lblStatus.ForeColor = Color.Black;
                }
                else
                {
                    lblStatus.Text = $"Could not retrieve data for UPC: {scannedUPC}.";
                    lblStatus.ForeColor = Color.Red;
                    SystemSounds.Exclamation.Play();
                }
            }
        }

        private bool ValidReleaseYear(string yearString)
        {
            return string.IsNullOrWhiteSpace(yearString) || (yearString.Length == 4 && Int16.TryParse(yearString, out _));
        }

        private void ClearStoredData()
        {
            scannedUPC = string.Empty;
            scrapedGameData = null;
            scrapedGame = null;
        }

    }
}
