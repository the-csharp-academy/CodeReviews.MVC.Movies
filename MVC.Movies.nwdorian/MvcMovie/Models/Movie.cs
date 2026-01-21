using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public DateTime ReleaseDate { get; set; }

    public required string Genre { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public required string Rating { get; set; }
}
