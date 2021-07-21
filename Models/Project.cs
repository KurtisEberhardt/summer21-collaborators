namespace collaborators.Models
{
    public class Project
    {
        public int Id {get; set; }
        public string Name {get; set;}
    }
    public class ProfileProjectViewModel : Project
    {
        public int profileProjectId {get; set;}
    }
}