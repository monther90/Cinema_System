using System.ComponentModel.DataAnnotations;

namespace Cinema_System.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public string Img { get; set; }
        [Required]
        public string Address { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
