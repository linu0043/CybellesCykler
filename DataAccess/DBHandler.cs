using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DBHandler : CommonDB
    {
        /// <summary>
        /// Creates a connection to the database
        /// </summary>
        /// <param name="constring">Connection string to connect to</param>
        public DBHandler(string constring) : base(constring)
        {
        }

        
    }
}
