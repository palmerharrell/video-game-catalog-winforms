using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameCollection_WinForms.Utilities;

namespace VideoGameCollection_WinForms.Repositories
{
    public class ImagesSqlRepo : SqlRepository
    {
        public ImagesSqlRepo() { }

        public static DataTable GetImagesByGame(int gameId)
        {
            var dataTable = new DataTable();
            var selectString = @$" SELECT VGID
                                         ,Image
                                         ,ImageType
                                   FROM IMAGES
                                   WHERE VGID = @VGID ";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                using SqlDataAdapter adapter = new SqlDataAdapter(selectString, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@VGID", gameId);
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
                    command.Parameters.AddWithValue("@VGID", gameId);
                    command.Parameters.AddWithValue("@Image", bytes);
                    command.Parameters.AddWithValue("@ImageType", imageType);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }

    }
}
