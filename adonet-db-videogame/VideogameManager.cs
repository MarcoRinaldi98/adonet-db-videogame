using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static Videogame GetVideogameById(long idToSearch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id = @Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", idToSearch));
                    using SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        return new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public static List<Videogame> GetVideogamesWithString(string stringToSearch)
        {
            List<Videogame> videogamesSearched = new List<Videogame>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name LIKE @Name;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Name", $"%{stringToSearch}%"));
                        using (SqlDataReader data = cmd.ExecuteReader())
                        {
                            while (data.Read())
                            {
                                Videogame newFoundedVideogame = new Videogame(data.GetInt64(0), data.GetString(1), data.GetString(2), data.GetDateTime(3), data.GetInt64(4));
                                videogamesSearched.Add(newFoundedVideogame);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return videogamesSearched;
            }
        }

        public static bool DeleteVideogame(long idToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM videogames WHERE id=@Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", idToDelete));

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
