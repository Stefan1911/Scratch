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

        public async Task<ProjectModel> AddAsync(ProjectModel instance)
        {
            await context.Projects.InsertOneAsync(instance);
            return instance;

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
