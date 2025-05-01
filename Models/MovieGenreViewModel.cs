using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Movies.NathanJenner.Models;

public class MovieGenreViewModel
{
    public List<MovieModel>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
}
