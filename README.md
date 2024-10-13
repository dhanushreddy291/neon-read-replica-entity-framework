# Todo API with Neon Read Replica Support

This project demonstrates how to build a simple Todo API using .NET and Entity Framework Core, with support for Neon read replicas. It showcases how to separate read and write operations to optimize database performance and scalability.

## Features

- CRUD operations for Todo items
- Separate database contexts for read and write operations
- Integration with Neon database and read replica support
- Swagger UI for easy API testing

## Prerequisites

- .NET 6.0 SDK or later
- A Neon database account with read replica set up

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/dhanushreddy291/neon-read-replica-entity-framework
   cd neon-read-replica-entity-framework
   ```

2. Update the connection strings in `appsettings.json` / `appsettings.Development.json` with your Neon database credentials:
   ```json
   {
     "ConnectionStrings": {
       "TodoDbConnectionWrite": "Host=your-neon-primary-host;Database=your-db;Username=your-username;Password=your-password",
       "TodoDbConnectionRead": "Host=your-neon-read-replica-host;Database=your-db;Username=your-username;Password=your-password"
     }
   }
   ```

3. Run the migrations to set up your database:
   ```
   dotnet ef database update
   ```

4. Run the application:
   ```
   dotnet run
   ```

5. Open a web browser and navigate to `https://localhost:5001/swagger` to view the Swagger UI and test the API.

## Project Structure

- `Controllers/TodoController.cs`: Contains the API endpoints for CRUD operations on Todo items.
- `Data/TodoDbContext.cs`: Defines the database contexts for read and write operations.
- `Models/Todo.cs`: Defines the Todo item model.
- `Program.cs`: Configures the application, including database contexts and dependency injection.

## How It Works

This API uses separate database contexts for read and write operations:

- `TodoDbReadContext`: Used for all read operations (GET requests). Connects to the Neon read replica.
- `TodoDbWriteContext`: Used for all write operations (POST, PUT, DELETE requests). Connects to the primary Neon database.

This separation allows for better performance and scalability by offloading read operations to the read replica.

## API Endpoints

- GET `/api/todo`: Retrieve all Todo items
- GET `/api/todo/{id}`: Retrieve a specific Todo item
- POST `/api/todo`: Create a new Todo item
- PUT `/api/todo/{id}`: Update an existing Todo item
- DELETE `/api/todo/{id}`: Delete a Todo item

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
