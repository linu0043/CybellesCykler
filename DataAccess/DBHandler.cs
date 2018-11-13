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
        #region Get database
        /// <summary>
        /// Gets a rentee from the database
        /// </summary>
        /// <param name="id">The id of the rentee in the database</param>
        /// <returns>Returns a rentee</returns>
        public Rentee GetRentee(int id)
        {
            string query = $"select * from Renters where id={id}";
            Rentee rentee;
            DataSet data = SelectDataFromDB(query);
            DataRow row = data.Tables[0].Rows[0];

            rentee = new Rentee((string)row["name"], (string)row["address"], (string)row["phoneNumber"], (DateTime)row["registerDate"], (int)row["id"]);

            return rentee;
        }
        /// <summary>
        /// Gets a bike from the database
        /// </summary>
        /// <param name="id">The id of the bike in the database</param>
        /// <returns>Returns a bike</returns>
        public Bike GetBike(int id)
        {
            string query = $"select * from Bikes where id={id}";
            Bike bike;
            DataSet data = SelectDataFromDB(query);
            DataRow row = data.Tables[0].Rows[0];

            bike = new Bike((decimal)row["pricePerDay"], (string)row["bikeDescription"], (BikeKind)Enum.Parse(typeof(BikeKind), (string)row["bikeType"]), (int)row["id"]);

            return bike;
        }
        /// <summary>
        /// Gets an order from the database
        /// </summary>
        /// <param name="id">The id of the order in the database</param>
        /// <returns>Returns an order</returns>
        public Order GetOrder(int id)
        {
            string query = $"select * from Orders where id={id}";
            DataSet data = SelectDataFromDB(query);
            DataRow row = data.Tables[0].Rows[0];

            Bike orderBike = GetBike((int)row["bikeID"]);
            Rentee orderRentee = GetRentee((int)row["renteeID"]);
            Order order = new Order(orderBike, orderRentee, (DateTime)row["orderDate"], (DateTime)row["deliveryDate"], (int)row["id"]);

            return order;
        }
        #endregion

        #region Get all from database
        /// <summary>
        /// Gets a list of all rentees from the database
        /// </summary>
        /// <returns>A list of all rentees from the database</returns>
        public List<Rentee> GetAllRentees()
        {
            string query = $"select * from Renters";
            DataSet data = SelectDataFromDB(query);
            var rows = data.Tables[0].Rows;
            List<Rentee> rentees = new List<Rentee>();

            foreach (DataRow row in rows)
            {
                rentees.Add( new Rentee(
                    (string)row["name"],
                    (string)row["address"],
                    (string)row["phoneNumber"],
                    (DateTime)row["registerDate"],
                    (int)row["id"]
                ));
            }   

            return rentees;
        }
        /// <summary>
        /// Gets a list of all bikes from the database
        /// </summary>
        /// <returns>A list of all bikes from the database</returns>
        public List<Bike> GetAllBikes()
        {
            string query = $"select * from Bikes";
            DataSet data = SelectDataFromDB(query);
            var rows = data.Tables[0].Rows;
            List<Bike> bikes = new List<Bike>();

            foreach (DataRow row in rows)
            {
                bikes.Add( new Bike(
                    (decimal)row["pricePerDay"],
                    (string)row["bikeDescription"],
                    (BikeKind)Enum.Parse(typeof(BikeKind),
                    (string)row["bikeType"]),
                    (int)row["id"]
                ));
            }

            return bikes;
        }
        /// <summary>
        /// Gets a list of all orders from the database
        /// </summary>
        /// <returns>A list of all orders from the database</returns>
        public List<Order> GetAllOrders()
        {
            string query = $"select * from Orders";
            DataSet data = SelectDataFromDB(query);
            var rows = data.Tables[0].Rows;
            List<Order> orders = new List<Order>();

            foreach (DataRow row in rows)
            {
                orders.Add( new Order(
                    GetBike((int)row["bikeID"]),
                    GetRentee((int)row["renteeID"]),
                    (DateTime)row["orderDate"],
                    (DateTime)row["deliveryDate"],
                    (int)row["id"]
                ));
            }

            return orders;
        }
#endregion

        #region Create database
        /// <summary>
        /// Creates a new rentee in the database
        /// </summary>
        /// <param name="rentee">The rentee to add to the database</param>
        /// <returns>Returns true if the object has been inserted into the database, otherwise it returns false</returns>
        public bool NewRentee(Rentee rentee)
        {
            string query = $"insert into Renters(name, phoneNumber, address, registerDate) values ('{rentee.Name}', '{rentee.PhoneNumber}', '{rentee.Address}', '{rentee.RegisterDate}')";
            bool result;

            if (InsertDataToDB(query) > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        /// <summary>
        /// Creates a new bike in the database
        /// </summary>
        /// <param name="bike">The bike to add to the database</param>
        /// <returns>Returns true if the object has been inserted into the database, otherwise it returns false</returns>
        public bool NewBike(Bike bike)
        {
            string query = $"insert into Bikes(bikeDescription, pricePerDay, bikeType) values ('{bike.BikeDesc}', '{bike.PricePerDay}', '{bike.Kind}')";
            bool result;

            if (InsertDataToDB(query) > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        /// <summary>
        /// Creates a new order in the database
        /// </summary>
        /// <param name="order">The order to add to the database</param>
        /// <returns>Returns true if the object has been inserted into the database, otherwise it returns false</returns>
        public bool NewOrder(Order order)
        {
            string query = $"insert into Orders(deliveryDate, orderDate, bikeID, renteeID) values ('{order.DeliveryDate}', '{order.RentDate}', '{order.Bike.ID}', '{order.Rentee.ID}')";
            bool result;

            if (InsertDataToDB(query) > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        #endregion

        #region Update Database
        /// <summary>
        /// Updates a rentee in the database depending on the id of the object 
        /// </summary>
        /// <param name="rentee">The rentee to update using the id</param>
        /// <returns>Returns true if the object has been updated, otherwise it returns false</returns>
        public bool UpdateRentee(Rentee rentee)
        {
            string query = $"update Renters set name = '{rentee.Name}', phoneNumber = '{rentee.PhoneNumber}', address = '{rentee.Address}', registerDate = '{rentee.RegisterDate}')";
            bool result;

            if (InsertDataToDB(query) >= 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        /// <summary>
        /// Updates a bike in the database depending on the id of the object 
        /// </summary>
        /// <param name="bike">The bike to update using the id</param>
        /// <returns>Returns true if the object has been updated, otherwise it returns false</returns>
        public bool UpdateBike(Bike bike)
        {
            string query = $"update Bikes set bikeDescription = '{bike.BikeDesc}', pricePerDay = '{bike.PricePerDay}', bikeType = '{bike.Kind}')";
            bool result;

            if (InsertDataToDB(query) >= 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        /// <summary>
        /// Updates an order in the database depending on the id of the object 
        /// </summary>
        /// <param name="order">The order to update using the id</param>
        /// <returns>Returns true if the object has been updated, otherwise it returns false</returns>
        public bool UpdateOrder(Order order)
        {
            string query = $"update Orders set deliveryDate = '{order.DeliveryDate}', orderDate = '{order.RentDate}', bikeID = '{order.Bike.ID}', renteeID = '{order.Rentee.ID}')";
            bool result;

            if (InsertDataToDB(query) >= 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
#endregion
    }
}
