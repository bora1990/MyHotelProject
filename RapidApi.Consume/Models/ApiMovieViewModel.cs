namespace RapidApi.Consume.Models
{
    public class ApiMovieViewModel  //isimler Api isimleriyle aynı olmalıdır.
    {
        public int rank { get; set; } //rank id gibi düşünebiliriz.
        public string title { get; set; }
        public string rating { get; set; }
        public string trailer { get; set; }

    }
}
