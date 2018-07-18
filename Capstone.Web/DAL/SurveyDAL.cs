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
        /// Dictionary that is used to determine the state where a park resides. 
        /// This needs to be updated when a park is added or removed from the database.
        /// </summary>
        private readonly Dictionary<string, string> CodeToState = new Dictionary<string, string>()
        {
            {"CVNP", "Ohio" },
            {"ENP", "Florida" },
            {"GCNP", "Arizona" },
            {"GNP", "Montana" },
            {"GSMNP", "Tennessee" },
            {"GTNP", "Wyoming" },
            {"MRNP", "Washington" },
            {"RMNP", "Colorado" },
            {"YNP", "Wyoming" },
            {"YNP2", "California" }
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
                    command.Parameters.AddWithValue("@state", CodeToState[survey.ParkCode]);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
