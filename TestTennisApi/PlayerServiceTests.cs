using Moq;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Timers;
using TennisApi.Application.Services;
using TennisApi.Models;
using TennisApi.Repositories.Interfaces;

namespace TestTennisApi
{
    public class PlayerServiceTests
    {
        private readonly Mock<IPlayerRepository> _repoMock;
        private readonly PlayerService _service;

        public PlayerServiceTests()
        {
            _repoMock = new Mock<IPlayerRepository>();
            _service = new PlayerService(_repoMock.Object);
        }

        [Fact]
        public void GetById_ShouldReturnPlayer_WhenExists()
        {
            // Arrange
            var player = new Player
            {
                Id = 1,
                Firstname = "Novak",
                Data = new PlayerStats
                {
                    Rank = 2
                }
            };

            _repoMock.Setup(r => r.GetById(1))
                     .Returns(player);

            // Act
            var result = _service.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Novak", result.Firstname);
        }

        [Fact]
        public void GetById_ShouldThrowKeyNotFoundException_WhenPlayerNotFound()
        {
            // Arrange
            _repoMock.Setup(r => r.GetById(1))
                     .Returns((Player)null);

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() =>
                _service.GetById(1));
        }

        [Fact]
        public void GetAllSorted_ShouldReturnPlayersOrderedByRank()
        {
            // Arrange
            var players = new List<Player>
            {
                new Player { Id = 1, Data = new PlayerStats { Rank = 5 } },
                new Player { Id = 2, Data = new PlayerStats { Rank = 1 } },
                new Player { Id = 3, Data = new PlayerStats { Rank = 3 } }
            };

            _repoMock.Setup(r => r.GetAll())
                     .Returns(players);

            // Act
            var result = _service.GetAllSorted();

            // Assert
            Assert.Equal(1, result.First().Data.Rank);
            Assert.Equal(5, result.Last().Data.Rank);
        }

        [Fact]
        public void Add_ShouldCallRepositoryAdd()
        {
            // Arrange
            var player = new Player
            {
                Id = 1,
                Firstname = "Rafael"
            };

            // Act
            _service.Add(player);

            // Assert
            _repoMock.Verify(r => r.Add(player), Times.Once);
        }
    }
}
