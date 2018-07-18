using System;
using System.Collections.Generic;
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
        /// Constructor that takes connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to connect to DB.</param>
        public SurveyDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
