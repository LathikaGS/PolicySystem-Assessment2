# PolicyNoteService

PolicyNoteService is a simple ASP.NET Core Web API for managing policy notes.  
It allows creating and retrieving notes linked to insurance policies and includes unit and integration tests.

## Features
- Create a note for a policy
- Retrieve all notes
- Retrieve a note by ID
- Handles 404 for missing notes
- Uses In-Memory Database for testing

## API Endpoints

| Method | Endpoint         | Description                     |
|--------|------------------|----------------------------------|
| POST   | /notes           | Create a new policy note         |
| GET    | /notes           | Get all policy notes             |
| GET    | /notes/{id}      | Get specific note by ID          |

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- xUnit
- InMemory Database
- GitHub


## Packages Added

### Main Project
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.InMemory
- Swashbuckle.AspNetCore

### Test Project
- xUnit
- Microsoft.AspNetCore.Mvc.Testing
- Microsoft.EntityFrameworkCore.InMemory
## Running the Project

```bash
dotnet run
dotnet test
```
