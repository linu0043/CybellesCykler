using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rentee
    {
        private int id;
        private DateTime registerDate;
        private string phoneNumber;
        private string address;
        private string name;

        public Rentee(string name, string address, string phoneNumber, DateTime registerDate, int id)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            RegisterDate = registerDate;
            ID = id;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public DateTime RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return $"{name}, {phoneNumber}";
        }
    }
}
