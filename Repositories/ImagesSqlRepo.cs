using Microsoft.Data.SqlClient;
using System.Data;
using VideoGameCollection_WinForms.Models;
using VideoGameCollection_WinForms.Utilities;

namespace VideoGameCollection_WinForms.Repositories
{
    public class ImagesSqlRepo : SqlRepository
    {
        public ImagesSqlRepo() { }

        public static DataTable GetImagesByGame(int gameId)
        {
            var dataTable = new DataTable();
            var selectString = @$" SELECT ImageID
                                         ,VGID
                                         ,Image
                                         ,ImageType
                                   FROM IMAGES
                                   WHERE VGID = @VGID ";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlDataAdapter adapter = new SqlDataAdapter(selectString, connection);
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@VGID", SqlDbType.Int) { Value = gameId });
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        //TODO: This method may not have been tested yet
        public static void InsertImage(int gameId, Image image, string imageType = "Photo - Game Case")
        {
            InsertImage(gameId, ImageUtilities.ConvertImageToByteArray(image), imageType);
        }

        public static void InsertImage(int gameId, byte[] bytes, string imageType = "Photo - Game Case")
        {
            var insertString = $" INSERT INTO IMAGES VALUES(@VGID, @Image, @ImageType) ";

            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                using SqlCommand command = new SqlCommand(insertString, connection);
                {
                    command.Parameters.Add(new SqlParameter("@VGID", SqlDbType.Int) { Value = gameId });
                    command.Parameters.Add(new SqlParameter("@Image", SqlDbType.VarBinary) { Value = bytes });
                    command.Parameters.Add(new SqlParameter("@ImageType", SqlDbType.VarChar) { Value = imageType });
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void DeleteImage(int imageId)
        {
            var deleteString = $" DELETE FROM IMAGES WHERE ImageID = @ImageID ";

            using SqlConnection connection = new SqlConnection(_connectionString);
            {
                using SqlCommand command = new SqlCommand(deleteString, connection);
                {
                    command.Parameters.Add(new SqlParameter("@ImageID", SqlDbType.Int) { Value = imageId });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void DeleteAllImagesForOneGame(int gameId)
        {
            var deleteString = $" DELETE FROM IMAGES WHERE VGID = @VGID ";

            using SqlConnection connection = new SqlConnection(_connectionString);
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

    }
}
