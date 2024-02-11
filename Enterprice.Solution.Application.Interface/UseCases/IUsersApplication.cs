using Enterprice.Solution.Application.DTO;
using Enterprice.Solution.Transversal.Common;

namespace Enterprice.Solution.Application.Interface.UseCases
{
    public interface IUsersApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
