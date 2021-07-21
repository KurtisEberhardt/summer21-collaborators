using collaborators.Models;
using collaborators.Repositories;

namespace collaborators.Services
{
    public class ProjectService
    {
        private readonly ProjectRepository _prepo;
        private readonly ProfileProjectRepository _repo;

        public ProjectService(ProjectRepository prepo, ProfileProjectRepository repo)
        {
            _prepo = prepo;
            _repo = repo;
        }

        public Project Create(Project newProject){
            newProject.Id = _prepo.Create(newProject);
            return newProject;
        }
        internal Project getById(int id){
            var data = _prepo.getById(id);
            if(data == null){
                throw new System.Exception("Invalid Id");
            }return data;
        }
    }
}