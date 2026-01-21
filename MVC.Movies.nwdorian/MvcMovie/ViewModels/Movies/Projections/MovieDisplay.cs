using System.ComponentModel.DataAnnotations;

namespace MvcMovie.ViewModels.Movies.Projections;

public class MovieDisplay(
    int id,
    string title,
    DateTime releaseDate,
    string genre,
    decimal price,
    string rating
)
{
    public int Id { get; set; } = id;

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Title { get; set; } = title;

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; } = releaseDate;

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string Genre { get; set; } = genre;

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; } = price;

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [StringLength(5)]
    [Required]
    public string Rating { get; set; } = rating;
}
