using TennisApi.Models;

namespace TennisApi.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAll();
        Player? GetById(int id);
        void Add(Player player);
    }
}
