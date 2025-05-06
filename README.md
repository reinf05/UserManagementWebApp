# UserManagementWebApp

## Features
- List every user existing in database
- Search for a user by its ID
- Create new users
- Edit existing users
- Delete existing users
- Update in real time without page reload
- Store user in a given type

## Technologies used
- **Frontend**
  - ASP.MVC with Razor pages
  - Bootstrap 5
  - JavaScript
- **Backend**
  - ASP.NET Core 8
  - Entity Framework Core 9
  - SQL Server database
 
  ## Getting Started
1. Update the connection string for database in `appSettings.json`
  - Basic connaction string contains:
     - Data Source: ´localhost´
     - Database name: `usermanagement_db`
     - Authentication: Windows authentication
  - To update this, edit `ConnectionStrings/Default` connection in the file.
2. **Run the Application:**

   ```bash
   dotnet run
   ```
3. Access the website
   - Open your webbrowser
   - Go to http://localhost:5202

## Project structure
- `wwwroot`: Static files for websites (JavaScript, CSS, Bootstrap)
- `Controllers`: API and MVC controllers
- `Data`: Entity Framework Core Database Context
- `Interfaces`: Interfaces for UserRepository
- `Models`: Data models
- `Repositories`: Repository layer for accessing data
- `Views`: Razor pages for the website

## API Endpoints
- `GET/Users`: List all users
- `/GET/Users/id`: List only the user with the given ID
- `POST/Users`: Create a new user
- `PUT/Users/id`: Edit a user with given ID
- `DELETE/Users/id`: Delete a user with given ID

## Known issues and future improvements
- Add unit/integration tests
- Add authorization and authentication
- Add more complex search for names and emails
- Improve data validation
- API calls are not secured
