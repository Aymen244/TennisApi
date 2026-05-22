using System.Text.Json;
using TennisApi.Models;
using TennisApi.Repositories.Interfaces;

namespace TennisApi.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players;

        public PlayerRepository()
        {
            _players = Load();
        }

        private List<Player> Load()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Infrastructure", "headtohead.json");
            var json = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var root = JsonSerializer.Deserialize<Root>(json, options);
            return root?.Players ?? new List<Player>();
        }

        public List<Player> GetAll() => _players;

        public Player GetById(int id) =>
            _players.FirstOrDefault(x => x.Id == id);

        public void Add(Player player)
        {
            player.Id = _players.Max(x => x.Id) + 1;
            _players.Add(player);
        }
    }
    public class Root
    {
        public List<Player> Players { get; set; }
    }
}
