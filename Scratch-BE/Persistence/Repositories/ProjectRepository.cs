using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected DataAccess.DatabaseContext context;

        public ProjectRepository(DataAccess.DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<ProjectModel> AddAsync(ProjectModel project)
        {
            await context.Projects.InsertOneAsync(project);
            return project;

        }

        public async Task<ProjectModel> GetAsync(string id)
        {
            var project = await context.Projects.FindAsync(i => i.Id.Equals(id));
            return await project.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProjectModel>> GetCollecionAsync()
        {
            var projects = await context.Projects.FindAsync(x => true);
            return projects.ToList();
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectOfUserAsync(string id)
        {
            var projects = await context.Projects.FindAsync(x => x.UserIDs.Contains(id));
            return projects.ToList();
        }
    }
}
