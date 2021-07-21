using collaborators.Models;
using collaborators.Repositories;

namespace collaborators.Services
{
    public class ProfileProjectService
    {
        private readonly ProjectRepository _prepo;
        private readonly ProfileProjectRepository _jrepo;

        public ProfileProjectService(ProjectRepository prepo, ProfileProjectRepository jrepo)
        {
            _prepo = prepo;
            _jrepo = jrepo;
        }

        internal ProfileProject Create(ProfileProject newProfProj){
            Project p = _prepo.getById(newProfProj.projectId);
            newProfProj.Id = _jrepo.createProfileProject(newProfProj);
            return newProfProj;
        }

        internal ProfileProject getById(int id){
            var data = _jrepo.getById(id);
            if(data == null){
                throw new System.Exception("Invalid ID!");
            }
            return data;
        }
    }
}