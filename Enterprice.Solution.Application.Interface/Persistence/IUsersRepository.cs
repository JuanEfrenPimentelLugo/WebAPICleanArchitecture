using Enterprice.Solution.Domain.Entities;

namespace Enterprice.Solution.Application.Interface.Persistence
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User Authenticate(string username, string password);

    }
}
