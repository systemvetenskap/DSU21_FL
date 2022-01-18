using DSU21.Models;
using System.Threading.Tasks;

namespace DSU21.Repositories
{
    public interface IDbRepository
    {
        Task<Ship> AddShipAsync(string name);
        Pirate GetPirateById(int id);
        Ship GetShip(int id);
    }
}