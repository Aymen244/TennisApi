using Microsoft.AspNetCore.Mvc;
using TennisApi.Application.Services;
using TennisApi.Application.Services.Interfaces;

namespace TennisApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        private readonly IStatsService _stats;

        public StatsController(IStatsService stats)
        {
            _stats = stats;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                countryWithHighestWinRatio = _stats.BestCountryByWinRatio(),
                averageBMI = _stats.AverageBMI(),
                medianHeight = _stats.MedianHeight()
            });
        }
    }
}
