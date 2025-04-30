using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
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
                using SqlConnection connection = new SqlConnection(_connectionString);
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
            //TODO: This replace method isn't necessary. I guess parameters take care of apostrophes.
            //ReplaceSpecialCharactersInStringProperties(game); 

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
                                        ) ";

            using SqlConnection connection = new SqlConnection(_connectionString);
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
            var updateString = @$"  UPDATE GAMES
                                    SET
                                         Title = @Title
                                        ,Description = @Description
                                        ,Genre = @Genre
                                        ,Platform = @Platform
                                        ,Physical = @Physical
                                        ,ReleaseYear = @ReleaseYear
                                        ,Developer = @Developer
                                        ,Publisher = @Publisher
                                    WHERE
                                        VGID = @VGID ";

            using SqlConnection connection = new SqlConnection(_connectionString);
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

            var waitasec = true;
        }

        private static void SetCommonParameters(SqlCommand command, Game game)
        {
            command.Parameters.Add(new SqlParameter("@Title", SqlDbType.VarChar) { Value = game.Title.Trim() });
            command.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar) { Value = game.Description.Trim() });
            command.Parameters.Add(new SqlParameter("@Genre", SqlDbType.VarChar) { Value = game.Genre.Trim() });
            command.Parameters.Add(new SqlParameter("@Platform", SqlDbType.VarChar) { Value = game.Platform.Trim() });
            command.Parameters.Add(new SqlParameter("@Physical", SqlDbType.Bit) { Value = game.Physical ? 1 : 0 });
            command.Parameters.Add(new SqlParameter("@ReleaseYear", SqlDbType.SmallInt) { Value = game.ReleaseYear });
            command.Parameters.Add(new SqlParameter("@Developer", SqlDbType.VarChar) { Value = game.Developer.Trim() });
            command.Parameters.Add(new SqlParameter("@Publisher", SqlDbType.VarChar) { Value = game.Publisher.Trim() });
        }

        // TODO: Use these again, if I find problems with any other characters, but apostrophes aren't a problem.
        //private static void ReplaceSpecialCharactersInStringProperties(Game game)
        //{
        //    game.Title = ReplaceSpecialCharacters(game.Title);
        //    game.Description = ReplaceSpecialCharacters(game.Description);
        //    game.Genre = ReplaceSpecialCharacters(game.Genre);
        //    game.Platform = ReplaceSpecialCharacters(game.Platform);
        //    game.Developer = ReplaceSpecialCharacters(game.Developer);
        //    game.Publisher = ReplaceSpecialCharacters(game.Publisher);
        //}

        //private static string ReplaceSpecialCharacters(string str)
        //{
        //    return str.Replace("'", "''");
        //}

    }
}
