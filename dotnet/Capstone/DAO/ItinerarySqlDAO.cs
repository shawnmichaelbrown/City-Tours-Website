using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ItinerarySqlDAO : IItineraryDAO
    {
        private readonly string connectionString;

        public ItinerarySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public string sqlGetItineraries = "SELECT * FROM itineraries WHERE user_id = @userId";//tie this to token

        public string sqlAddItinerary = "INSERT INTO itineraries (user_id, itinerary_name, starting_address, locations) VALUES (@userId, @itineraryName, @address, @locations)";

        public string sqlDeleteItinerary = "DELETE FROM itineraries WHERE id = @id";

        public string sqlEditItinerary = "UPDATE itineraries SET itinerary_name = @name, starting_address = @address, locations = @locations WHERE id = @id";

        public List<Itinerary> RetrieveItineraries(int userId)
        {
            List<Itinerary> list = new List<Itinerary>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetItineraries, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Itinerary itinerary = new Itinerary();
                    itinerary.Id = Convert.ToInt32(reader["id"]);
                    itinerary.UserId = Convert.ToInt32(reader["user_id"]);
                    itinerary.Name = Convert.ToString(reader["itinerary_name"]);
                    itinerary.Address = Convert.ToString(reader["starting_address"]);
                    itinerary.Locations = Convert.ToString(reader["locations"]);
                    list.Add(itinerary);
                }
            }
            return list;
        }

        public bool AddItinerary(Itinerary itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddItinerary, conn);
                    cmd.Parameters.AddWithValue("@userId", itinerary.UserId);
                    cmd.Parameters.AddWithValue("@itineraryName", itinerary.Name);
                    cmd.Parameters.AddWithValue("@address", itinerary.Address);
                    cmd.Parameters.AddWithValue("@locations", itinerary.Locations);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteItinerary(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteItinerary, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool EditItinerary(Itinerary itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlEditItinerary, conn);
                    cmd.Parameters.AddWithValue("@id", itinerary.Id);
                    cmd.Parameters.AddWithValue("@name", itinerary.Name);
                    cmd.Parameters.AddWithValue("@address", itinerary.Address);
                    cmd.Parameters.AddWithValue("@locations", itinerary.Locations);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
