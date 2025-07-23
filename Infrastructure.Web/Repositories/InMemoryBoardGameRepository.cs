using Demant.Interview.Infrastructure.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demant.Interview.Infrastructure.Web.Repositories
{
    public class InMemoryBoardGameRepository : IBoardGamesRepository
    {
        private static readonly IList<Boardgame> _boardGames = new List<Boardgame>();

        public Task Create(Boardgame boardGame)
        {
            if (_boardGames.Any(b => b.Name == boardGame.Name))
            {
                throw new InvalidOperationException("Game already exists");
            }

            _boardGames.Add(boardGame);
            return Task.CompletedTask;
        }

        public Task Delete(string name)
        {
            var boardGame = _boardGames.FirstOrDefault(b => b.Name == name);

            if (boardGame == null)
            {
                throw new InvalidOperationException("Game not found");
            }

            _boardGames.Remove(boardGame);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Boardgame>> List()
        {
            IReadOnlyCollection<Boardgame> games = _boardGames.AsReadOnly();
            return Task.FromResult(games);
        }

        public Task Borrow(string name, string loaner, int days)
        {
            Boardgame boardGame = _boardGames.FirstOrDefault(b => b.Name == name);

            if (boardGame == null)
            {
                throw new InvalidOperationException("Game not found");
            }

            boardGame.BorrowedBy = loaner;
            boardGame.BorrowedUntil = DateTime.Now.AddDays(days);

            return Task.CompletedTask;
        }

        public Task Return(string name)
        {
            Boardgame boardGame = _boardGames.FirstOrDefault(b => b.Name == name);

            if (boardGame == null)
            {
                throw new InvalidOperationException("Game not found");
            }

            boardGame.BorrowedBy = null;
            boardGame.BorrowedUntil = null;

            return Task.CompletedTask;
        }
    }
}