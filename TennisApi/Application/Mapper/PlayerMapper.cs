using TennisApi.Application.DTO;
using TennisApi.Models;

namespace TennisApi.Application.Mapper
{
    public class PlayerMapper
    {
        public static PlayerDto ToDto(Player p)
        {
            return new PlayerDto
            {
                Id = p.Id,
                Fullname = $"{p.Firstname} {p.Lastname}",
                CountryCode = p.Country.Code,
                Rank = p.Data.Rank
            };
        }
    }
}
