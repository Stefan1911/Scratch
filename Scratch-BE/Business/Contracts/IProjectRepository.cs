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
        Task<ProjectModel> GetAsync(string id);
        Task<IEnumerable<ProjectModel>> GetProjectOfUserAsync(string id);
        Task<IEnumerable<ProjectModel>> GetCollecionAsync();
        Task<IEnumerable<string>> DeleteAsync(string id);
        Task JoinProjectAsync(string userId, string projectId);
    }
}
