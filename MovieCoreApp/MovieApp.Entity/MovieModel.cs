using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Entity
{
    public class MovieModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        public string Moviename { get; set; }

        public string Movietype { get; set; }

        public string MovieDescription { get; set; }

        public string Movielangauge { get; set; }


    }
}
