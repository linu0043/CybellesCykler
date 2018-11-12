using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;

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

        public Rentee GetRentee(int id)
        {
            string query = $"select * from Renters where id={id}";
            Rentee rentee;
            DataSet data = SelectDataFromDB(query);
            DataRow row = data.Tables[0].Rows[0];

            rentee = new Rentee((string)row["name"], (string)row["address"], (string)row["phoneNumber"], (DateTime)row["registerDate"], (int)row["id"]);

            return rentee;
        }
        public Bike GetBike(int id)
        {
            string query = $"select * from Bikes where id={id}";
            Bike bike;
            DataSet data = SelectDataFromDB(query);
            DataRow row = data.Tables[0].Rows[0];

            bike = new Bike((decimal)row["pricePerDay"], (string)row["bikeDescription"], (BikeKind)row["bikeType"], (int)row["id"]);

            return bike;
        }
        //public Order GetOrder(int id)
        //{
        //    string query = $"select * from Orders where id={id}";
        //    DataSet data = SelectDataFromDB(query);
        //    string queryTwo = $"select * from Bikes where id=Orders";
        //    Order order;
        //    DataRow row = data.Tables[0].Rows[0];

        //    order = new Order();

        //    return order;
        //}
    }
}
