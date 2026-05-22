using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TennisApi.Application.Services;
using TennisApi.Application.Services.Interfaces;
using TennisApi.Models;

namespace TestTennisApi
{
    public class StatsServiceTests
    {
        private readonly Mock<IPlayerService> _serviceMock;
        private readonly StatsService _service;

        public StatsServiceTests()
        {
            _serviceMock = new Mock<IPlayerService>();
            //_service = new StatsService(_serviceMock.Object);
        }

        [Fact]
        public void BestCountryByWinRatio_ShouldReturnCountryWithBestRatio()
        {
            // Arrange
            var players = new List<Player>
            {
                new Player
                {
                    Country = new Country { Code = "FRA" },
                    Data = new PlayerStats { Last = new List<int> { 1, 1, 1, 1, 1 } }
                },
                new Player
                {
                    Country = new Country { Code = "USA" },
                    Data = new PlayerStats { Last = new List<int> { 0, 0, 0, 0, 0 } }
                }
            };

            _serviceMock.Setup(s => s.GetAllSorted())
             .Returns(players);

            var service = new StatsService(_serviceMock.Object);

            // Act
            var result = service.BestCountryByWinRatio();

            // Assert
            Assert.Equal("FRA", result);
        }

        [Fact]
        public void AverageBMI_ShouldReturnPositiveValue()
        {
            // Arrange
            var players = new List<Player>
                 {
                     new Player
                     {
                         Data = new PlayerStats
                         {
                             Weight = 80000,
                             Height = 180
                         }
                     }
                 };

            _serviceMock.Setup(s => s.GetAllSorted())
                        .Returns(players);

            var service = new StatsService(_serviceMock.Object);

            // Act
            var result = service.AverageBMI();

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void MedianHeight_ShouldReturnCorrectValue()
        {
            // Arrange
            var players = new List<Player>
                 {
                     new Player { Data = new PlayerStats { Height = 170 } },
                     new Player { Data = new PlayerStats { Height = 180 } },
                     new Player { Data = new PlayerStats { Height = 190 } }
                 };

            _serviceMock.Setup(s => s.GetAllSorted())
                        .Returns(players);

            var service = new StatsService(_serviceMock.Object);

            // Act
            var result = service.MedianHeight();

            // Assert
            Assert.Equal(180, result);
        }
    }
}
