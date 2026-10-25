using System.ComponentModel.DataAnnotations;

namespace Cinema_System.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public ICollection<Movie> movies { get; set; }
    }
}
