using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;

namespace Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected DataAccess.DatabaseContext context;

        public ProjectRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public Task<ProjectModel> AddAsync(ProjectModel instance)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectModel>> GetCollecionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
