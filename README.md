# No-Test-Application

A C# ASP.NET Core REST API with CRUD functionality for managing objects with name and date properties.

## Overview

This is a simple ASP.NET Core Web API that demonstrates basic CRUD (Create, Read, Update, Delete) operations. The API manages objects with the following properties:
- **Name**: String identifier for the object
- **Date**: DateTime associated with the object

Data is stored in-memory and does not persist between application restarts.

## Features

- ✅ Create new objects
- ✅ Read all objects or a specific object by ID
- ✅ Update existing objects
- ✅ Delete objects
- ✅ In-memory data storage
- ✅ Swagger/OpenAPI documentation
- ✅ Proper HTTP status codes and error handling
- ✅ Built with .NET 8

## Prerequisites

- .NET 8 SDK or later
- Visual Studio, Visual Studio Code, or any C# IDE

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Bremmmmmmm/No-Test-application.git
cd No-Test-application
```

### 2. Build the Project

```bash
dotnet build
```

### 3. Run the Application

```bash
dotnet run
```

The API will start on `https://localhost:5001` (or the configured port).

## API Endpoints

### Base URL
```
https://localhost:5001/api/objects
```

### 1. Get All Objects
**GET** `/api/objects`

```bash
curl -X GET https://localhost:5001/api/objects
```

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "name": "Sample Object",
    "date": "2024-01-15T10:30:00"
  }
]
```

---

### 2. Get Object by ID
**GET** `/api/objects/{id}`

```bash
curl -X GET https://localhost:5001/api/objects/1
```

**Response (200 OK):**
```json
{
  "id": 1,
  "name": "Sample Object",
  "date": "2024-01-15T10:30:00"
}
```

**Response (404 Not Found):**
```json
{
  "message": "Object with ID 1 not found."
}
```

---

### 3. Create Object
**POST** `/api/objects`

```bash
curl -X POST https://localhost:5001/api/objects \
  -H "Content-Type: application/json" \
  -d '{"name": "New Object", "date": "2024-01-15T10:30:00"}'
```

**Request Body:**
```json
{
  "name": "New Object",
  "date": "2024-01-15T10:30:00"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "name": "New Object",
  "date": "2024-01-15T10:30:00"
}
```

---

### 4. Update Object
**PUT** `/api/objects/{id}`

```bash
curl -X PUT https://localhost:5001/api/objects/1 \
  -H "Content-Type: application/json" \
  -d '{"name": "Updated Object", "date": "2024-01-16T15:45:00"}'
```

**Request Body:**
```json
{
  "name": "Updated Object",
  "date": "2024-01-16T15:45:00"
}
```

**Response (204 No Content):**
No body, just status code.

**Response (404 Not Found):**
```json
{
  "message": "Object with ID 1 not found."
}
```

---

### 5. Delete Object
**DELETE** `/api/objects/{id}`

```bash
curl -X DELETE https://localhost:5001/api/objects/1
```

**Response (204 No Content):**
No body, just status code.

**Response (404 Not Found):**
```json
{
  "message": "Object with ID 1 not found."
}
```

---

## Project Structure

```
No-Test-Application/
├── Controllers/
│   └── ObjectsController.cs          # REST API endpoints
├── Models/
│   ├── ObjectModel.cs                # Object data model
│   ├── CreateObjectRequest.cs        # Create request DTO
│   └── UpdateObjectRequest.cs        # Update request DTO
├── Services/
│   ├── IObjectService.cs             # Service interface
│   └── ObjectService.cs              # Service implementation
├── Program.cs                        # Application configuration
├── appsettings.json                  # Configuration file
├── appsettings.Development.json      # Development configuration
├── No-Test-Application.csproj        # Project file
├── .gitignore                        # Git ignore rules
└── README.md                         # This file
```

## Architecture

### Layers

1. **Controllers** - Handle HTTP requests and responses
2. **Services** - Contain business logic and data management
3. **Models** - Define data structures

### Data Storage

Data is stored in-memory using a static dictionary in the `ObjectService` class. This means:
- ✅ No database setup required
- ❌ Data is lost when the application restarts
- ❌ Not suitable for production

## Swagger Documentation

When running in development, you can access the Swagger UI at:
```
https://localhost:5001/swagger
```

This provides an interactive API documentation where you can test all endpoints.

## Example Usage

### Create Multiple Objects

```bash
# Create first object
curl -X POST https://localhost:5001/api/objects \
  -H "Content-Type: application/json" \
  -d '{"name": "Object 1", "date": "2024-01-01T00:00:00"}'

# Create second object
curl -X POST https://localhost:5001/api/objects \
  -H "Content-Type: application/json" \
  -d '{"name": "Object 2", "date": "2024-01-02T00:00:00"}'

# Get all objects
curl -X GET https://localhost:5001/api/objects

# Update first object
curl -X PUT https://localhost:5001/api/objects/1 \
  -H "Content-Type: application/json" \
  -d '{"name": "Updated Object 1", "date": "2024-06-01T00:00:00"}'

# Delete second object
curl -X DELETE https://localhost:5001/api/objects/2
```

## Future Enhancements

- Add database persistence (SQL Server, PostgreSQL, etc.)
- Add authentication and authorization
- Add input validation and error handling
- Add logging and monitoring
- Add unit and integration tests
- Add Docker support

## License

MIT License

## Support

For issues or questions, please create an issue on the GitHub repository. new test
