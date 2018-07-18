using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParksDAL : IParksDAL
    {
        /// <summary>
        /// Connection string used to connect to DB.
        /// </summary>
        private readonly string ConnectionString;

        /// <summary>
        /// Constructor that takes connection string.
        /// </summary>
        /// <param name="connectionString">Connection string used to connect to DB.</param>
        public ParksDAL(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
