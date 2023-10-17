namespace ASP.NET_WebAPI6.Entities
{
    public class StudentResult
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ResultId { get; set; }
        public Result Result { get; set; }

        public int Score { get; set; }

    }
}
