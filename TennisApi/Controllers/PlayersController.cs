using Microsoft.AspNetCore.Mvc;
using TennisApi.Application.Mapper;
using TennisApi.Application.Services;
using TennisApi.Application.Services.Interfaces;
using TennisApi.Models;

namespace TennisApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _service;

        public PlayersController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllSorted()
                .Select(PlayerMapper.ToDto);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var player = _service.GetById(id);
                return Ok(PlayerMapper.ToDto(player));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Player not found" });
            }
        }

        [HttpPost]
        public IActionResult Add(Player player)
        {
            _service.Add(player);
            return Created("", player);
        }
    }
}
