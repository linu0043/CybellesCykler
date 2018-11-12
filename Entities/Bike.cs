using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bike
    {
        private int id;
        private BikeKind kind;
        private string bikeDesc;
        private decimal pricePerDay;

        public Bike(decimal pricePerDay, string bikeDesc, BikeKind kind, int id)
        {
            PricePerDay = pricePerDay;
            BikeDesc = bikeDesc;
            Kind = kind;
            ID = id;
        }

        public decimal PricePerDay
        {
            get { return pricePerDay; }
            set { pricePerDay = value; }
        }

        public string BikeDesc
        {
            get { return bikeDesc; }
            set { bikeDesc = value; }
        }

        public BikeKind Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
