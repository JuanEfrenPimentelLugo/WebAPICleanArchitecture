﻿using Dapper;
using Enterprice.Solution.Persistence.Contexts;
using Enterprice.Solution.Application.Interface.Persistence;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Enterprice.Solution.Domain.Entities;

namespace Enterprice.Solution.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;
        public UsersRepository(DapperContext context)
        {
            _context = context;
        }
        public User Authenticate(string userName, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                //var query = "UsersGetByUserAndPassword";
                var query = "select public.fn_users_get_by_user_and_password(@UserName,@Password)";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.Text);
                return user;
            }
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public User Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
