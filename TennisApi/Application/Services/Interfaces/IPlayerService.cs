using TennisApi.Models;

namespace TennisApi.Application.Services.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetAllSorted();
        Player GetById(int id);
        void Add(Player player);
    }
}
