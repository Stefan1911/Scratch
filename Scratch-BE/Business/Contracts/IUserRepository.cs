using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserRepository
    {
        Task<UserModel> AddAsync(UserModel instance);
        Task<UserModel> GetAsync(int id);
        Task<IEnumerable<UserModel>> GetCollecionAsync();
    }
}
