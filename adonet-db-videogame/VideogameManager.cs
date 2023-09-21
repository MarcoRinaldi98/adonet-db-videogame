using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=videogames;Integrated Security=True";

        public static bool InsertVideogame(Videogame videogameToAdd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@Name, @Overview, @ReleaseDate, @SoftwareHouseId);";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Name", videogameToAdd.Name));
                    cmd.Parameters.Add(new SqlParameter("@Overview", videogameToAdd.Overview));
                    cmd.Parameters.Add(new SqlParameter("@ReleaseDate", videogameToAdd.ReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@SoftwareHouseId", videogameToAdd.SoftwareHouseId));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
}
