namespace RepoDbDemo.WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public Student()
        {
            Name = string.Empty;
            Subject = string.Empty;
        }
    }
}
