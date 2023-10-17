namespace ASP.NET_WebAPI6.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public ICollection<StudentResult> StudentResults { get; set; }

    }
}
