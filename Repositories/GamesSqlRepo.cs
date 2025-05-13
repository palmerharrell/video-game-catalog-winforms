using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using VideoGameCollection_WinForms.Models;

namespace VideoGameCollection_WinForms.Repositories
{
    public class GamesSqlRepo : SqlRepository
    {   
        public static DataTable GetGames()
        {
            var dataTable = new DataTable();
            var selectString = $" SELECT * FROM GAMES ";

            try
            {
                using SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[server.ToString()].ToString());
                using SqlDataAdapter adapter = new SqlDataAdapter(selectString, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        public static void AddOrUpdateGame(Game game)
        {
            if (game.IsNew)
            {
                AddGame(game);
            }
            else
            {
                UpdateGame(game);
            }
        }

        private static void AddGame(Game game)
        {
            var insertString = @$" INSERT INTO GAMES
                                        (
                                            Title
                                           ,Description
                                           ,Genre
                                           ,Platform
                                           ,Physical
                                           ,ReleaseYear
                                           ,Developer
                                           ,Publisher
                                           ,ScannedUPC
                                        )
                                   VALUES
                                        (
                                             @Title
                                            ,@Description
                                            ,@Genre
                                            ,@Platform
                                            ,@Physical
                                            ,@ReleaseYear
                                            ,@Developer
                                            ,@Publisher
                                            ,@ScannedUPC
                                        ) ";

            using SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[server.ToString()].ToString());
            {
                using SqlCommand command = new SqlCommand(insertString, connection);
                {
                    SetCommonParameters(command, game);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private static void UpdateGame(Game game)
        {
            var updateString = @$" UPDATE GAMES
                                   SET
                                        Title = @Title
                                       ,Description = @Description
                                       ,Genre = @Genre
                                       ,Platform = @Platform
                                       ,Physical = @Physical
                                       ,ReleaseYear = @ReleaseYear
                                       ,Developer = @Developer
                                       ,Publisher = @Publisher
                                       ,ScannedUPC = @ScannedUPC
                                   WHERE
                                       VGID = @VGID ";

            using SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[server.ToString()].ToString());
            {
                using SqlCommand command = new SqlCommand(updateString, connection);
                {
                    SetCommonParameters(command, game);
                    command.Parameters.Add(new SqlParameter("@VGID", SqlDbType.Int) { Value = game.VGID });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void DeleteGame(int gameId)
        {
            var deleteString = $" DELETE FROM GAMES WHERE VGID = @VGID ";

            using SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[server.ToString()].ToString());
            {
                using SqlCommand command = new SqlCommand(deleteString, connection);
                {
                    command.Parameters.Add(new SqlParameter("@VGID", SqlDbType.Int) { Value = gameId });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private static void SetCommonParameters(SqlCommand command, Game game)
        {
            command.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar) { Value = game.Title.Trim() });
            command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar) { Value = game.Description.Trim() });
            command.Parameters.Add(new SqlParameter("@Genre", SqlDbType.VarChar) { Value = game.Genre.Trim() });
            command.Parameters.Add(new SqlParameter("@Platform", SqlDbType.VarChar) { Value = game.Platform.Trim() });
            command.Parameters.Add(new SqlParameter("@Physical", SqlDbType.Bit) { Value = game.Physical ? 1 : 0 });
            command.Parameters.Add(new SqlParameter("@ReleaseYear", SqlDbType.SmallInt) { Value = string.IsNullOrWhiteSpace(game.ReleaseYear.Trim()) ? DBNull.Value : game.ReleaseYear.Trim() });
            command.Parameters.Add(new SqlParameter("@Developer", SqlDbType.VarChar) { Value = game.Developer.Trim() });
            command.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.VarChar) { Value = game.Publisher.Trim() });
            command.Parameters.Add(new SqlParameter("@ScannedUPC", SqlDbType.VarChar) { Value = game.ScannedUPC.Trim() });
        }
        
    }
}
