namespace ASP.NET_WebAPI6.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public string Exam { get; set; }
        public ICollection<StudentResult> StudentResults { get; set; }

    }
}
