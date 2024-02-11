using Enterprice.Solution.Application.DTO;
using Enterprice.Solution.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprice.Solution.Application.Interface.UseCases
{
    public interface ICategoriesApplication
    {
        Task<Response<IEnumerable<CategoryDto>>> GetAll();
    }
}
