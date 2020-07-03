using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaruant> restaruants;

        public InMemoryRestaurantData()
        {
            restaruants = new List<Restaruant>()
            {
                new Restaruant {Id = 1 , Name ="SCott's Pizza" , Cuisine = CuisineType.Italian},
                new Restaruant {Id = 2 , Name ="Tersiguels" , Cuisine = CuisineType.French},
                new Restaruant {Id = 3 , Name ="Mango Grove" , Cuisine = CuisineType.Indian}

            };
        }

        public void Add(Restaruant restaruant)
        {
            restaruants.Add(restaruant);
            restaruant.Id = restaruants.Max(r => r.Id) + 1;
        }

       

        public Restaruant Get (int id)
        {
            return restaruants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaruant> GetAll()
        {
            return restaruants.OrderBy(r => r.Name);   
        }

        public void Update(Restaruant restaruant)
        {


            var existing = Get(restaruant.Id);

            if (existing != null)
            {
                existing.Name = restaruant.Name;
                existing.Cuisine = restaruant.Cuisine;
            }
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);

            if (restaurant != null)
                restaruants.Remove(restaurant);
        }
    }
}
