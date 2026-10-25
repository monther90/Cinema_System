using Microsoft.EntityFrameworkCore;

namespace Cinema_System.Models
{
    [PrimaryKey(nameof(MovieId),nameof(ActorId))]
    public class MovieActor
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

    }
}
