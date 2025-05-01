using MVC.Movies.NathanJenner.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Movies.NathanJenner.Models;

public class MovieModel
{
    [Key]
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime ReleaseDate { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    [Required]
    public decimal Price { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public MovieGenre? MovieGenre { get; set; }

    [Required]
    [Display(Name = "Rating")]
    public MovieRating? MovieRating { get; set; }
}
