using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class DataController
    {
        private DBHandler handler;

        public DBHandler Handler
        {
            get { return handler; }
            set { handler = value; }
        }

        public DataController(string conString)
        {
            Handler.ConnectionString = conString;
        }
    }
}
