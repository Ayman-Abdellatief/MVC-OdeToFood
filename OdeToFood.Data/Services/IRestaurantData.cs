using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaruant> GetAll();
        Restaruant Get(int id);

        void Add(Restaruant restaruant);
        void Update(Restaruant restaruant);

        void Delete(int id);
    }
}
