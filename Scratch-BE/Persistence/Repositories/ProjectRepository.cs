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
            project.DrawingBoards[0].Id = ObjectId.GenerateNewId().ToString();
            project.DrawingBoards[0].Chat.Id = ObjectId.GenerateNewId().ToString();
            await context.Projects.InsertOneAsync(project);
            return project;

        }
        public async Task<ProjectModel> DeleteAsync(string id,string userId)
        {
            var deleteFilter = Builders<ProjectModel>.Filter.Where(_project => _project.Id.Equals(id));
            var update = Builders<ProjectModel>.Update.Pull(_project => _project.UserIDs, userId);
            await context.Projects.UpdateManyAsync(deleteFilter, update);

            ProjectModel project = await GetAsync(id);
            if (project.UserIDs.Count == 0)
                await context.Projects.DeleteOneAsync(_project=>_project.Id.Equals(id));
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
        public async Task JoinProjectAsync(string userId, string projectId)
        {
            var filter = Builders<ProjectModel>.Filter.Eq(project => project.Id, projectId);
            var update = Builders<ProjectModel>.Update.Push(project => project.UserIDs, userId);
            await context.Projects.UpdateOneAsync(filter, update);
        }
    }
}
