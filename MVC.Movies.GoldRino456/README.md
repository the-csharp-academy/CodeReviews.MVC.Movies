# Movie App

A web app that interfaces with a locally hosted SQL Server to read and store movie information including their titles, genres, and price. The user can add, remove, or update movies stored in the database as well as filter the database's entries by a search query or genre from a dropdown menu.
## Tech Stack

**Runtime & Framework:** .NET 9, ASP.NET Core

**Database ORM:** Entity Framework

**Database:** SQL Server

## Lessons Learned

- With how in depth Bootstrap is, I tried to focus more on learning what it had to offer in this project and what it's classes did when added to a given element. Sure you can change the color of something from red to blue, but that doesn't really make it feel like a modern web app these days. Bootstrap's buttons are the most obvious leap in improving the base look of HTML, but I did also spend some time customizing the table, playing with icons, and seeing what all I could add "rounded" to take hard edges off elements. I feel like I have a bit of a better understanding of how to use Bootstrap, but there's so many parts and pieces to it that continuing to explore it will be the only way to really see what all it can do! 
- I ran into an interesting issue with the icon I have embedded in my navbar. The movie reel icon I found on pixabay is stored locally with the web page's files, but I found it displaying as a broken link on everything except the home page. The issue was with the path that the img element was trying to follow. Adding a path like "/img/my_image.png" to the src of an img tag will use the current URL as the path. So on the home page this would lead to the correct path folder, "domain.com/img/my_image.png". But any other page like "domain.com/create" would throw an error. It was a rather simple fix, but adding "~" to point the element to the root folder first solved the problem.
## Acknowledgements

 - [The C# Academy](https://www.thecsharpacademy.com/)
 - [README Editor](https://readme.so/editor)
 - [Pixabay](https://pixabay.com)
