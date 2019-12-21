using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IProjectRepository
    {
        Task<ProjectModel> AddAsync(ProjectModel instance);
        Task<ProjectModel> GetAsync(int id);
        Task<IEnumerable<ProjectModel>> GetCollecionAsync();
    }
}
