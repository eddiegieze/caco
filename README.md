# Cards and columns

Cards and columns is a simple Single Page Application (SPA) of a sprint board using VueJS and .NET Core Web API. You can make boards, cards and columns, edit them and delete them.

![board](https://raw.githubusercontent.com/eddiegieze/caco/main/images/board.png)

## Initial setup

To run cards and columns on your own machine, follow these steps:

### Download and install Visual Studio Code

<https://code.visualstudio.com/>

### Clone the repository

git clone <https://github.com/eddiegieze/caco.git>

### Start VS Code

code .

### Extensions for VS Code

When browsing through the code files, you can install these VS Code extensions when prompted and desired:

- Vetur for .vue files
- C# for Visual Studio Code for .cs files

### Run the API

1. Install the dotnet SDK: <https://dotnet.microsoft.com/download/dotnet/sdk-for-vs-code>
2. cd caco/api
3. dotnet restore
4. dotnet watch run (serve and support hot-reload)
5. View the OpenAPI specification: <http://localhost:5000/swagger/index.html>

### Run the UI

1. cd caco/ui (in a new terminal)
2. npm install
3. npm run serve (serve and support hot-reload)
4. View the UI by visiting <http://localhost:8080/>

## Code structure API

### Controllers

- House the API endpoints
- Call mappers
- Connect to services to handle requests

### Mapping

- Map between public resources and private model objects

### Model

- The basic domain model classes
- Interfaces for repositories containing those classes

### Persistence

- Implementation of the repository interfaces in entity framework
- The database context (including a sample in-memory database)

### Resources

- Public classes to communicate through the API without exposing all the properties of the domain model objects, or polluting domain model objects with API-specific functionality

### Services

- Layer between the repository and the API, to link together repository functionality in comprehensive methods, keeping the controllers and repository simple

### Miscellaneous

- Extensions, helper methods for 3rd party classes
- Properties, settings for visual studio code
- Program.cs & Startup.cs for configuration and to wire together the different classes and dependencies
