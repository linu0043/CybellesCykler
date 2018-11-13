using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace Business
{
    public class DataController
    {
        private DBHandler handler;

        private DBHandler Handler
        {
            get { return handler; }
            set { handler = value; }
        }

        public DataController(string conString)
        {
            handler = new DBHandler(conString);
        }
        /// <summary>
        /// Gets all entities from the database that is the same as entity
        /// </summary>
        /// <param name="entity">The object to get. Can be either "rentee", "order", or "bike"</param>
        /// <returns></returns>
        public List<IPersistable> GetEntities(string entity)
        {
            List<IPersistable> entities = new List<IPersistable>();



            return entities;
        }
        /// <summary>
        /// Gets an entity from the database with an id
        /// </summary>
        /// <param name="entity">The object to get. Can be either "rentee", "order", or "bike"</param>
        /// <param name="id">The id of the specific object</param>
        /// <returns></returns>
        public IPersistable GetEntity(string entity, int id)
        {
            List<IPersistable> entities = new List<IPersistable>();

            switch (entity)
            {
                case "rentee":
                    entities.Add(handler.GetRentee(id));
                    break;
                case "bike":
                    entities.Add(handler.GetBike(id));
                    break;
                case "order":
                    entities.Add(handler.GetOrder(id));
                    break;
                default:
                    break;
            }

            return entities[0];
        }

        public bool NewEntity(IPersistable entity)
        {
            bool result = false;

            if (entity is Bike)
            {
                result = handler.NewBike(entity as Bike);
            }
            else if (entity is Order)
            {
                result = handler.NewOrder(entity as Order);
            }
            else if (entity is Rentee)
            {
                result = handler.NewRentee(entity as Rentee);
            }

            return result;
        }

        //public bool UpdateEntity(IPersistable entity)
        //{

        //}
    }
}
