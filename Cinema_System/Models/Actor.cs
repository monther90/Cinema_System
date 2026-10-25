using System.ComponentModel.DataAnnotations;

namespace Cinema_System.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Img { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
