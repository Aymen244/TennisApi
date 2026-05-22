using TennisApi.Application.Services.Interfaces;
using TennisApi.Models;

namespace TennisApi.Application.Services
{
    public class StatsService : IStatsService
    {
        private readonly List<Player> _players;

        public StatsService(IPlayerService service)
        {
            _players = service.GetAllSorted();
        }

        public string BestCountryByWinRatio()
        {
            return _players
                .Where(p => p.Data?.Last != null && p.Data.Last.Count > 0)
                .GroupBy(p => p.Country.Code)
                .Select(g => new
                {
                    Country = g.Key,
                    Ratio = g.Average(p =>
                        (double)p.Data.Last.Count(x => x == 1) /
                        p.Data.Last.Count)
                })
                .OrderByDescending(x => x.Ratio)
                .First()
                .Country;
        }

        public double AverageBMI()
        {
            return _players.Average(p =>
            {
                var weightKg = p.Data.Weight / 1000.0;
                var heightM = p.Data.Height / 100.0;

                return weightKg / (heightM * heightM);
            });
        }

        public double MedianHeight()
        {
            var heights = _players.Select(p => p.Data.Height).OrderBy(x => x).ToList();

            int n = heights.Count;

            return n % 2 == 0
                ? (heights[n / 2 - 1] + heights[n / 2]) / 2.0
                : heights[n / 2];
        }
    }
}
