using TennisApi.Application.Services.Interfaces;
using TennisApi.Models;
using TennisApi.Repositories;
using TennisApi.Repositories.Interfaces;

namespace TennisApi.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;
        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public List<Player> GetAllSorted()
        {
            return _repository.GetAll()
                .OrderBy(p => p.Data.Rank)
                .ToList();
        }

        public Player GetById(int id)
        {
            var player = _repository.GetById(id);

            if (player == null)
                throw new KeyNotFoundException("Player not found");

            return player;
        }

        public void Add(Player player)
        {
            _repository.Add(player);
        }
    }
}
