namespace movie_store_backend.Domain
{
    public class Movie
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movie(string _title, string _synopsis, string _director, int _year)
        {
            Title = _title;
            Synopsis = _synopsis;
            Director = _director;
            Year = _year;
        }
    }
}
