﻿using System.ComponentModel.DataAnnotations;

namespace movie_store_backend.DTOs
{
    public class MovieRequestBody
    {
        [Required]
        [StringLength(96, MinimumLength = 2)]
        public required string Title { get; set; }

        [Required]
        [StringLength(512, MinimumLength = 2)]
        public required string Synopsis { get; set; }

        [Required]
        [StringLength(96, MinimumLength = 2)]
        public required string Director { get; set; }

        [Required]
        [Range(1888, int.MaxValue)]
        public int Year { get; set; }
    }
}
