using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order : IPersistable
    {
        private int id;
        private DateTime deliveryDate;
        private DateTime rentDate;
        private Rentee rentee;
        private Bike bike;

        public Order(Bike bike, Rentee rentee, DateTime rentDate, DateTime deliveryDate, int id)
        {
            Bike = bike;
            Rentee = rentee;
            RentDate = rentDate;
            DeliveryDate = deliveryDate;
            ID = id;
        }

        public Bike Bike
        {
            get { return bike; }
            set { bike = value; }
        }

        public Rentee Rentee
        {
            get { return rentee; }
            set { rentee = value; }
        }

        public DateTime RentDate
        {
            get { return rentDate; }
            set { rentDate = value; }
        }

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Gets the price of the bike in the order
        /// </summary>
        /// <returns>Returns the price of the bike</returns>
        public decimal GetPrice()
        {
            return bike.PricePerDay; 
        }

        public override string ToString()
        {
            return $"Order ID: {id}, Rentee: {rentee.ToString()}";
        }
    }
}
