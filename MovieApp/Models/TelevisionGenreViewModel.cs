using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieApp.Models;

public class TelevisionGenreViewModel
{
    public List<TelevisionShow>? Shows { get; set; }

    public SelectList? Genres { get; set; }

    public string? ShowGenre { get; set; }

    public string? SearchString { get; set; }
}
