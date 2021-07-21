using System;
using System.Collections.Generic;
using System.Data;
using collaborators.Models;
using Dapper;

namespace collaborators.Repositories
{
    public class ProfileProjectRepository
    {
        private readonly IDbConnection _db;

        public ProfileProjectRepository(IDbConnection db)
        {
            _db = db;
        }

        internal int createProfileProject(ProfileProject newProfProj)
        {
            string sql = @"
            INSERT INTO profileproject
            (projectId, profileId)
            VALUES
            (@projectId, @profileId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newProfProj);
        }
        internal IEnumerable<ProfileProjectViewModel> getProfilesbyProjectId(int id){
            string sql =@"
            SELECT prof.*,
            proj.id AS profileProjectId
            FROM profileproject profproj
            JOIN profile prof ON prof.id = profproj.id
            WHERE projectId = @id;";
            return _db.Query<ProfileProjectViewModel>(sql, new {id});
        }

        internal ProfileProject getById(int id)
        {
            string sql = @"SELECT profproj.* FROM profileproject profproj WHERE profproj.Id = @id;";
            return _db.QueryFirstOrDefault<ProfileProject>(sql, new {id});
        }
    }
}