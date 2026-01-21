# MVC Movies

This is a refactored application from Microsoft tutorial designed to demonstrate a full stack .NET application using MVC web app in ASP.NET Framework.

It allows users to create, update, delete and track movies.

## Table of contents

- [MVC Movies](#mvc-movies)
  - [Table of contents](#table-of-contents)
  - [Technologies](#technologies)
  - [Features](#features)
    - [Movie management](#movie-management)
    - [Input validation](#input-validation)
    - [Error display](#error-display)
    - [Database initialization](#database-initialization)
    - [Database seeding](#database-seeding)
  - [Installation](#installation)
    - [Prerequisites](#prerequisites)
    - [Running the application](#running-the-application)
  - [Contributing](#contributing)
  - [License](#license)
  - [Contact](#contact)

## Technologies

- [ASP.NET Core 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Entity Framework Core](https://github.com/dotnet/efcore)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Bootstrap](https://getbootstrap.com/)

## Features

### Movie management

- Create, update and delete operations
- Paginated view
  - **Active page** indicator
  - **Page navigation** buttons
    - **Previous** page
    - **Next** page
  - **Sorting** in ascending or descending order
    - **Title** column
    - **Release Date** column
    - **Genre** column
    - **Price** column
    - **Rating** column
  - **Filtering**
    - **Genre** dropdown options
    - **Search** by movie title

### Input validation

- Client side validation
  - built-in JQuery form validation with data annotation attributes on input models
- Server side validation
  - `ModelState` checks with data annotation attributes on input models
  - `Result` pattern with strongly typed `Errors` for business rules

### Error display

- Form validation errors appear under input fields
- Server side validation errors are used for conditional rendering of pages

### Database initialization

- Connection string can be changed in `appsettings.json`
  - `ConnectionStrings` - `MvcMovieContext`
- SQL Server database with the name `MvcMovieDb` is created on startup if it doesn't already exist
- Database is initialized with `Movie` table

### Database seeding

- Database is seeded on startup with 25 sample movies if no records exist

## Installation

### Prerequisites

- .NET 10 SDK ([download link](https://dotnet.microsoft.com/en-us/download/dotnet/10.0))
- SQL Server ([download link](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))

### Running the application

1. Clone the repository
   - using **HTTPS**
     - `https://github.com/nwdorian/MvcMovie.git`
   - using **SSH**
     - `git@github.com:nwdorian/MvcMovie.git`
   - using **GitHub CLI**
     - `gh repo clone nwdorian/MvcMovie`

2. Configure `appsettings.json` options if needed
   - replace the connection string
     - details in [Database Initialization](#database-initialization) section

3. Navigate to the project directory and run the project
    - `dotnet run`

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

## Contact

For any questions or feedback, please open an issue.