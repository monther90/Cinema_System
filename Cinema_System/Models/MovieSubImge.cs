using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_System.Models
{
    public class MovieSubImge
    {
        [Key]
        public int Id { get; set; }
        public int MovieId {  get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }

        [Required]
        public string Img { get; set; }


    }
}
