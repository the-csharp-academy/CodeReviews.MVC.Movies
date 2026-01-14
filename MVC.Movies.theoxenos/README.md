# Movie Collection App

## Features
- **Full CRUD**: Create, Read, Update, and Delete movies.
- **Search**: Filter movies by title.
- **Filter**: Filter movies by genre.
- **Sorting**: Sort movies by Title, Release Date, Genre, Price, and Rating.

## Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SQL Server (or LocalDB)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Getting Started

1.  **Clone the repository**
2.  **Update the Database**
    The application uses Entity Framework Core. Run the following command to apply migrations and seed the initial data:
    ```bash
    dotnet ef database update --project MvcMovie
    ```
    *Note: Ensure your connection string in `MvcMovie/appsettings.json` is correctly configured for your environment.*

3.  **Run the application**
    ```bash
    dotnet run --project MvcMovie
    ```

## Technology Stack
- **Backend**: ASP.NET Core 10 MVC
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: Razor Views, Bootstrap 5, Bootstrap Icons
