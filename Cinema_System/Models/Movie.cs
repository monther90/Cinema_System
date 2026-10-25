using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_System.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)]")]
        public decimal Price { get; set; }
        public string MainImg { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey (nameof(CategoryId))]
        public Category Category { get; set; }
        public int CinmaId { get; set; }
        [ForeignKey(nameof(CinmaId))]
        public Cinema Cinema{ get; set; }
        public ICollection<MovieSubImge> MovieSubImges {  get; set; }
        public ICollection<MovieActor> movieActors { get; set; }


    }
}
