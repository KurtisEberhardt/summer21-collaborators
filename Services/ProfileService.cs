using System;
using collaborators.Models;
using collaborators.Repositories;

namespace collaborators.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _prepo;

        public ProfileService(ProfileRepository prepo)
        {
            _prepo = prepo;
        }

        internal Profile Create(Profile newProfile)
        {
            newProfile.Id = _prepo.createProfile(newProfile);
            return newProfile;
        }
        internal Profile getById(int id){
            var data = _prepo.getById(id);
            if(data == null){
                throw new Exception("Invalid Id");
            } return data;
        }
    }
}