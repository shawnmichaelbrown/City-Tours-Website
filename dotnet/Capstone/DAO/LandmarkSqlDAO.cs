using System;
using System.Collections.Generic;
using System.Linq;
using Capstone.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class LandmarkSqlDAO : ILandmarkDAO
    {
        private readonly string connectionString;

        private string sqlGetLandmarks = "SELECT * from landmarks";

        string sqlAddLandmark = "INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES (@name, @address, @description);";

        public LandmarkSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Landmark> RetrieveLandmarks()
        {
            List<Landmark> list = new List<Landmark>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetLandmarks, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Landmark landmark = new Landmark();
                    landmark.Address = Convert.ToString(reader["landmark_address"]);
                    landmark.Description = Convert.ToString(reader["landmark_description"]);
                    landmark.ID = Convert.ToInt32(reader["landmark_id"]);
                    landmark.Name = Convert.ToString(reader["landmark_name"]);
                    list.Add(landmark);
                }
            }
                return list;
        }
        public bool AddLandmark(Landmark landmark)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddLandmark, conn);
                    cmd.Parameters.AddWithValue("@name", landmark.Name);
                    cmd.Parameters.AddWithValue("@address", landmark.Address);
                    cmd.Parameters.AddWithValue("@description", landmark.Description);
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
