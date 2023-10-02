using movie_store_backend.Core;

namespace movie_store_backend.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movie(string title, string synopsis, string director, int year)
        {
            Title = title;
            Synopsis = synopsis;
            Director = director;
            Year = year;
        }
    }
}
