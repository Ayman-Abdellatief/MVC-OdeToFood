using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDBContext db;

        public SqlRestaurantData(OdeToFoodDBContext db)
        {
            this.db = db;
        }
        public void Add(Restaruant restaruant)
        {
            db.Restaurants.Add(restaruant);
            db.SaveChanges();
        }


        public Restaruant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaruant> GetAll()     
        {
            return db.Restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaruant restaruant)
        {

            var entery = db.Entry(restaruant);
            entery.State =  EntityState.Modified;
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }
    }
}
