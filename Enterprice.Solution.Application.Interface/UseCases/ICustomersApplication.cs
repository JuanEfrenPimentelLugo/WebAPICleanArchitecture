﻿using System;
using System.Collections.Generic;
using System.Text;
using Enterprice.Solution.Application.DTO;
using Enterprice.Solution.Transversal.Common;
using System.Threading.Tasks;

namespace Enterprice.Solution.Application.Interface.UseCases
{
    public interface ICustomersApplication
    {
        #region Métodos Síncronos

        Response<bool> Insert(CustomerDto customersDto);
        Response<bool> Update(CustomerDto customersDto);
        Response<bool> Delete(string customerId);

        Response<CustomerDto> Get(string customerId);
        Response<IEnumerable<CustomerDto>> GetAll();
        ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(CustomerDto customersDto);
        Task<Response<bool>> UpdateAsync(CustomerDto customersDto);
        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomerDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
