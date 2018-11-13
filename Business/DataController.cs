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
        /// <returns>Returns a list of all entities based on entity</returns>
        public List<IPersistable> GetEntities(string entity)
        {
            List<IPersistable> entities = new List<IPersistable>();

            
            switch (entity)
            {
                case "rentee":
                    foreach (Rentee rentee in handler.GetAllRentees())
                    {
                        entities.Add(rentee);
                    }
                    break;
                case "bike":
                    foreach (Bike bike in handler.GetAllBikes())
                    {
                        entities.Add(bike);
                    }
                    break;
                case "order":
                    foreach (Order order in handler.GetAllOrders())
                    {
                        entities.Add(order);
                    }
                    break;
                default:
                    entities = null;
                    break;
            }
            
            return entities;
        }
        /// <summary>
        /// Gets an entity from the database with an id
        /// </summary>
        /// <param name="entity">The object to get. Can be either "rentee", "order", or "bike"</param>
        /// <param name="id">The id of the specific object</param>
        /// <returns>Returne one entity based on the parameters</returns>
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
        /// <summary>
        /// Creates a new entity from the object given
        /// </summary>
        /// <param name="entity">The object to save in the database</param>
        /// <returns>Returns true if the object was successfully added, otherwise it returns false</returns>
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

        /// <summary>
        /// Updates an entity from the object given using its id
        /// </summary>
        /// <param name="entity">The object to update in the database</param>
        /// <returns>Returns true if the object was successfully updated, otherwise it returns false</returns>
        public bool UpdateEntity(IPersistable entity)
        {
            bool result = false;

            if (entity is Bike)
            {
                result = handler.UpdateBike(entity as Bike);
            }
            else if (entity is Order)
            {
                result = handler.UpdateOrder(entity as Order);
            }
            else if (entity is Rentee)
            {
                result = handler.UpdateRentee(entity as Rentee);
            }

            return result;
        }

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="entity">The object to delete in the database</param>
        /// <returns>Returns true if the object was successfully deleted, otherwise it returns false</returns>
        public bool DeleteEntity(IPersistable entity)
        {
            bool result = false;

            if (entity is Bike)
            {
                result = handler.DeleteBike(entity as Bike);
            }
            else if (entity is Order)
            {
                result = handler.DeleteOrder(entity as Order);
            }
            else if (entity is Rentee)
            {
                result = handler.DeleteRentee(entity as Rentee);
            }

            return result;
        }
    }
}
