using Demant.Interview.Infrastructure.Web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demant.Interview.Infrastructure.Web.Repositories
{
    public interface IBoardGamesRepository
    {
        Task Create(Boardgame boardGame);
        Task Delete(string name);
        Task<IReadOnlyCollection<Boardgame>> List();
        Task Borrow(string name, string loaner, int days);
        Task Return(string name);
    }
}