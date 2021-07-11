# Cards and columns

Cards and columns is a simple Single Page Application (SPA) of a sprint board using VueJS and .NET Core Web API. You can make boards, cards and columns, edit them and delete them.

![board](https://raw.githubusercontent.com/eddiegieze/caco/main/images/board.png)

## Initial setup

To run card and columns on your own machine, follow these steps:

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