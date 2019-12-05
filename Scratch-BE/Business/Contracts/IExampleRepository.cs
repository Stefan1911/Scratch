using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IExampleRepository
    {
        Task<Example> AddAsync(Example instance);
        Task<Example> GetAsync(int id);
        Task<IEnumerable<Example>> GetCollecionAsync();
    }
}
