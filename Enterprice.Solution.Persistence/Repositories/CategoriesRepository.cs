using Dapper;
using Enterprice.Solution.Persistence.Contexts;
using Enterprice.Solution.Application.Interface.Persistence;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Enterprice.Solution.Domain.Entities;

namespace Enterprice.Solution.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var query = "Select * From Categories";

            var categories = await connection.QueryAsync<Category>(query, commandType: CommandType.Text);
            return categories;
        }
    }
}
