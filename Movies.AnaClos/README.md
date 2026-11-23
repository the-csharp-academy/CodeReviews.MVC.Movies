# Movies.AnaClos

Web application to manage a movie collection, built with ASP.NET Core MVC as a project for The C# Academy.

## What it does

- Lets you create, view, edit and delete movies.
- Searches by title and filters by genre.
- Stores the movie data in a database.
- Exports the list to Excel, respecting the search and genre currently applied.

## How to run it

**Requirements:** Visual Studio with the ASP.NET workload and SQL Server Express LocalDB (installed from the Visual Studio installer).

Tested on Windows with Visual Studio and LocalDB.

1. Clone the repository and open the solution in Visual Studio.
2. Open *Tools > NuGet Package Manager > Package Manager Console* and run `Update-Database`. This creates the database.
3. Run the application. The browser opens and, if the database is empty, sample movies are loaded.

There is no need to modify the connection string in `appsettings.json`.

## How it works

The application uses the MVC pattern. `MoviesController` receives the requests, queries the database with Entity Framework and displays the results in Razor views.
The database context is registered in `Program.cs` and injected into the controller.

## Architecture decisions

- LocalDB, a lightweight version of SQL Server, is used instead of a full server, for its simplicity.
- The search and filter are in a single private method used by both the list and the export, so both apply the same rules.
- The culture is fixed to `en-US` so that prices with decimals work the same in any country.

## Resources used

- Microsoft tutorial on ASP.NET Core MVC and Entity Framework.
- Bootstrap video tutorial.
- Claude.ai: I used it to understand concepts (dependency injection, Entity Framework, migrations) and as a guide for the Excel export and the styling.

## Reflection

- Although the Microsoft tutorial was followed, using MVC for the first time was a challenge.
- Exporting to Excel was chosen because I had already done it in other projects, but adapting it from a console application to the web was hard, especially exporting what is already filtered.
- Since Argentina uses the comma as the decimal separator, a solution was needed that would work regardless of region. For that reason the `en-US` culture was chosen.