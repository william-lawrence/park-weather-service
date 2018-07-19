using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
        /// <summary>
        /// Connection string used to connect to DB.
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// Dictionary that is used to determine the name of the park given the park code.
        /// The park name is not included in the database. 
        /// </summary>
        private readonly Dictionary<string, string> CodeToParkName = new Dictionary<string, string>()
        {
            {"CVNP", "Cuyahoga Valley National Park" },
            {"ENP", "Everglades National Park" },
            {"GCNP", "Grand Canyon National Park" },
            {"GNP", "Glacier National Park" },
            {"GSMNP", "Great Smoky Mountains National Park" },
            {"GTNP", "Grand Teton National Park" },
            {"MRNP", "Mount Rainier National Park" },
            {"RMNP", "Rocky Mountain National Park" },
            {"YNP", "Yellowstone National Park" },
            {"YNP2", "Yosemite National Park" }
        };
          
        /// <summary>
        /// Constructor that takes connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to connect to DB.</param>
        public SurveyDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Adds a survey to the database
        /// </summary>
        /// <param name="survey">survey object to be added to the database.</param>
        public void AddNewSurvey(SurveyResult survey)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO survey_result (parkCode, emailAddress, activityLevel, state) VALUES (@parkCode, @emailAddress, @activityLevel, @state)";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    command.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    command.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);
                    command.Parameters.AddWithValue("@state", survey.State);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates a list of parks ordered by number of appearances in survey results (most to least).
        /// </summary>
        /// <returns>A list of parks order by number of appearances in the database (Most to least)</returns>
        public Park GetBestPark()
        {
            Park bestPark = new Park();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL that gets all the park codes by rank of popularity.
                    string sql = "SELECT TOP (1) parkCode FROM survey_result GROUP BY parkCode ORDER BY COUNT(survey_result.parkCode) DESC;";

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    bestPark.Code = reader.GetString(0);
                    bestPark.Name = CodeToParkName[bestPark.Code];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return bestPark;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            Park park = new Park
            {
                Code = Convert.ToString(reader["parkCode"]),
                Name = CodeToParkName[Convert.ToString(reader["parkCode"])] // Getting the park name using the CodeToParkName dictionary.
            };

            return park;
        }
    }
}
