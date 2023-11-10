# Task Manager API

## Task Objective

Develop a simple ASP.NET Core Web API application that provides a RESTful service for managing a list of "Tasks" to be done.

## How It Works

This project is a basic ASP.NET Core Web API application using Entity Framework Core. It allows you to perform CRUD operations on tasks, enabling you to create, read, update, and delete tasks.

## Installation

### Clone Repository

```bash
git clone https://github.com/Arturs322/ASP.NET-Core-Web-API.git
```

### Install packages
```cs
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

### Build, clean, and run the project to test the API endpoints:
```cs
dotnet build
dotnet clean
dotnet run
```

Your API should be accessible at [https://localhost:5065](https://localhost:5065). If not check the launchSettings.json for correct applicationUrl.
## API Endpoints

The following are the main endpoints provided by the API:

- **Create Task**: 
  - Method: `POST`
  - URL: `/CreateTask`
  - Instructions: To create a new task, send a `POST` request to `/CreateTask` with the task details in the request body.

- **Get All Tasks**: 
  - Method: `GET`
  - URL: `/GetTasks`
  - Instructions: Retrieve all tasks by sending a `GET` request to `/GetTasks`.

- **Update Task**: 
  - Method: `PUT`
  - URL: `/UpdateTask/{id}`
  - Instructions: Update a task by sending a `PUT` request to `/UpdateTask/{id}` with the task ID in the URL and the updated task details in the request body.

- **Delete Task**: 
  - Method: `DELETE`
  - URL: `/DeleteTask/{id}`
  - Instructions: Delete a task by sending a `DELETE` request to `/DeleteTask/{id}` with the task ID in the URL.

For a more interactive experience and detailed API documentation, explore the Swagger UI at [https://localhost:5065/swagger/index.html](https://localhost:5065/swagger/index.html).


## Technologies Used

- ASP.NET Core
- Entity Framework Core
