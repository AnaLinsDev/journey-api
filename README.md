# Journey Manager API 

A RESTful Web API built with **C# and ASP.NET Core** for managing trips and activities.

This project was developed **primarily to understand the structure and implementation of layered architecture in ASP.NET Core Web API**, while also exploring concepts such as business rules, input validation, exception handling, and dependency injection.

## Technologies

- C#
- .NET
- ASP.NET Core Web API
- Swagger / OpenAPI
- Visual Studio

## Features

- List all trips
- Get a trip by ID
- Create trip
- Update a trip
- Delete a trip
- Business rule validation
- Status and Priority validation
- HTTP status code handling

## Layered Architecture

For this project, the following layered architecture was adopted:

1. Journey.API — The entry point of the application, responsible for handling HTTP requests through the controllers.
2. Journey.Application — The application/service layer, responsible for implementing the application's use cases and business rules.
3. Journey.Communication — The DTO layer, responsible for defining and organizing the request and response objects used to communicate between the API and the application layer.
3. Journey.Exception — The Exception layer, responsible for defining and organizing the aplication errors and saving the resourse message errors.
3. Journey.Infrastructure — The Infrastructure layer, responsible for defining and organizing the database communication and migrations.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/trips` | Get all trips |
| GET | `/api/trips/{id}` | Get a trip by ID |
| POST | `/api/trips` | Create a trip |
| PUT | `/api/trips/{id}` | Update a trip |
| DELETE | `/api/trips/{id}` | Delete a trip |

## What I Practiced

Through this project, I practiced:

- Layered architecture in .NET
- ASP.NET Core Web API
- RESTful API design
- HTTP methods and status codes
- Business rule implementation
- Input validation
- Exception handling
- Debugging with Visual Studio

## How to Run

### Prerequisites

Make sure you have installed:

- .NET SDK
- Visual Studio 2022 or another C#/.NET IDE

### 1. Clone the repository

```bash
git clone https://github.com/AnaLinsDev/journey-api.git
```

### 2. Navigate to the project

```bash
cd journey-api
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Build the project

```bash
dotnet build
```

### 5. Run the API

```bash
dotnet run --project src/Journey.API
```

The terminal will display the URL where the API is running.

### 6. Open Swagger

Open the Swagger URL displayed by the application in your browser.

Swagger can be used to test the available API endpoints without requiring Postman or another API client.
