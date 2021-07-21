using System.Data;
using collaborators.Models;
using Dapper;

namespace collaborators.Repositories
{
    public class ProfileRepository
    {
        private readonly IDbConnection _db;

        public ProfileRepository(IDbConnection db)
        {
            _db = db;
        }

        public int createProfile(Profile newProfile){
            string sql=@"
            INSERT INTO profile
            (name, Id)
            VALUES
            (@name, @Id);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newProfile);
        }

        public Profile getById(int id){
            string sql = "SELECT * FROM profile WHERE id = @id;";
            return _db.QueryFirstOrDefault<Profile>(sql, new {id});
        }
    }
}