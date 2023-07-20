# ASP.NETCoreWebAPI_WithJWT_UsingBogus
Two Project: Using bogus for fake data, using JWT for Authentication

## ASP.NET Core Web API With JWT
This project is a sample ASP.NET Core Web API application with JWT (JSON Web Tokens) authentication implemented using Bogus for generating fake data. It provides a basic setup for user registration, login, and accessing secure endpoints.

NuGet Packages
Microsoft.AspNetCore.Authentication.JwtBearer: Provides JWT authentication for the API endpoints.
Microsoft.AspNetCore.Identity.EntityFrameworkCore: Allows integration with Identity for user management.
Microsoft.AspNetCore.OpenApi: Enables API documentation with Swagger.
Microsoft.EntityFrameworkCore.Sqlite: Provides support for SQLite as the database (used for development in this project).
Microsoft.EntityFrameworkCore.Tools: Adds EF Core CLI tools for database migration.
Swashbuckle.AspNetCore: Implements Swagger UI to visualize and interact with the API resources.
System.IdentityModel.Tokens.Jwt: Supports JWT creation and validation.
Requirements
Before running the application, ensure you have the following:

.NET Core SDK (version XYZ or later)
Installation
Clone the repository or download the source code.

Navigate to the project root folder.

Run the application using the following command:

bash
Copy code
dotnet run
Configuration
The application's configuration can be found in the appsettings.json file. Update the following settings as required:

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=JWT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  },
  "JWT": {
    "Issuer": "your_issuer_here",
    "Audience": "your_audience_here",
    "ExpiredTime": "00:20:00",
    "Secret": "your_secret_key_here"
  }
}
Replace your_issuer_here, your_audience_here, and your_secret_key_here with your desired values for JWT configuration.

Models
User Model
The User.cs class in the Models folder represents the user entity. It inherits from IdentityUser and includes additional properties for custom user information.

DTOs
The RegistryDto.cs and LoginDto.cs classes in the Models folder represent the data transfer objects for user registration and login processes, respectively.

Services
IJwtService and JwtService
The IJwtService.cs interface defines the contract for generating JWT tokens, and the JwtService.cs class implements this interface to handle JWT token generation. The JwtService class is injected into the UserController to issue tokens upon successful registration and login.

Extensions
DependencyInjection
The DependencyInjection.cs static class in the Extensions folder contains the AddApiServices() static method. This method is used to configure and inject necessary services, including database context, authentication, and JWT options.

Controllers
UserController
The UserController.cs class in the Controllers folder handles user registration and login. It includes two endpoints:

POST /api/auth/register: Register a new user. Required parameters: Email, Password.
POST /api/auth/login: Authenticate a user and receive a JWT token. Required parameters: Email, Password.
ValuesController
The ValuesController.cs class in the Controllers folder includes sample API endpoints for testing purposes. To access these endpoints, users must be authenticated with a valid JWT token.

Usage
Register a new user using the /api/auth/register endpoint.

Authenticate the user using the /api/auth/login endpoint to receive a JWT token.

Use the obtained JWT token in the Authorization header to access secure endpoints, such as those in the ValuesController.

Authentication
JWT authentication is implemented using the Microsoft.AspNetCore.Authentication.JwtBearer package. The AddApiServices() method in the DependencyInjection.cs class sets up the necessary authentication middleware.

Swagger Documentation
API documentation is provided using Swagger. You can access the Swagger UI by running the application and navigating to https://localhost:7149/swagger/index.html (the port may vary based on your configuration). The Swagger UI allows you to explore and interact with the API endpoints.

Additional Notes
To test JWT tokens, you can use jwt.io for decoding and validating the tokens.

When testing via Swagger or Postman, ensure that the email includes the "@" character, and the password has a minimum of 6 characters, including at least one uppercase letter, one lowercase letter, one number, and one symbol.

The project uses SQLite as the database for development purposes. Ensure that the DefaultConnection in the appsettings.json file points to the correct database connection string.

The expiration time for the JWT token is set to 20 minutes by default. You can adjust this value in the appsettings.json file.

## Web API Using Bogus
NuGet Packages:
	- Microsoft.AspNetCore.OpenApi
	- Swashbuckle.AspNetCore
	- Bogus

PROCESS STEPS:
	- Create User.cs class and Models folder in project
	- Create BogusFakeData.cs class and Fakes folder in project for using fake datas
	- Add HomeController.cs API controller for Controllers folder. Do action methods (Get, Select, Create, Update and Delete)
	- Create GlobalUsings.cs class in project for using code blocks

POSTMAN QUERY
	if swagger run (so application is runing):
	- https://localhost:12345/api/Home		-> for example -> paste this link to Postman -> [HttpGet]		-> Get
	- https://localhost:12345/api/Home/1	-> for example -> argument 1 for id value -> [HttpGet("{id}")]	-> Select
	- https://localhost:12345/api/Home?id=1 -> for example -> argument 1 for id value -> [HttpDelete]		-> Delete
	else -> solution folder location copy -> open cmd console and write: cd  -> paste location and enter -> write >dotnet run and enter -> copy localhost number
	use new local host number for postman
	- http://localhost:5000/api/Home/1 -> for example -> argument 1 for id value -> [HttpGet("{id}")]
	- http://localhost:5000/api/Home?id=1 -> for example -> argument 1 for id value -> [HttpDelete]
