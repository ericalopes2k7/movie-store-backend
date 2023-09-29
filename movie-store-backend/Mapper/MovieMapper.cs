using movie_store_backend.Domain;
using movie_store_backend.DTOs;

namespace movie_store_backend.Mapper
{
    public class MovieMapper
    {
        public static MovieDTO ToDTO(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id.ToString(),
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                Director = movie.Director,
                Year = movie.Year
            };
        }
    }
}
