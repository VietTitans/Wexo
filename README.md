This is a Razor Pages web application that allows users to browse movies and view detailed information such as title, description, release date, genres, actors, and directors. It uses data fetched from the TMDb (The Movie Database) API.


Features:
- View a list of movies
- Click into a movie to see full details
- View poster and backdrop images
- See genre, description, release year top 5 actors and directors  
- Fully responsive layout with styled UI

Technologies:
- ASP.NET Core MVP with Razor Pages
- C#
- TMDb API
- HTML/CSS (with custom styling)
- Newtonsoft.Json for JSON parsing
- RestSharp for API requests


Getting Started:
1. Clone the repository to your local machine
2. Add a valid TMDb API key your environment variables.
   - One way to do it is to open the downloaded solution.
   - Right-click on the "webapplication" project (Note: Ensure it's the project and not the entire solution)
   - Navigate to button and click "Properties"
   - Find and select "Debug"
   - Under "Genereal" click "Open debug launch profiles UI"
   - In the table "Enviroment variables", under the "Name" column write "ConnectionString". Under "value" write your API key.
   - Exit
3. Run the application

Project structure:
- /Models: Data models like Media, Cast, Crew, etc.
- /Pages: Razor Pages including Index and Details
- /wwwroot: Static files like CSS, JS, Img
- Program.cs: App config and service setup

Demo:

Front page
![image](https://github.com/user-attachments/assets/fb75eb87-632b-46c5-b531-1f3959103357)

Movie details page
![image](https://github.com/user-attachments/assets/70e008ec-db3b-4547-bb7c-d67b5fe1a916)


