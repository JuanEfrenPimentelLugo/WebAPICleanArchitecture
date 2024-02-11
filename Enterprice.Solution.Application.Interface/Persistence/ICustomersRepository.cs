using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Enterprice.Solution.Domain.Entities;

namespace Enterprice.Solution.Application.Interface.Persistence
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        
    }
}
