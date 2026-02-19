## Library Management System

## Project Overview
This project is an enhanced ASP.NET Core MVC application. It manages library data using a persistent SQLite database and Entity Framework Core.

## Technical Stack
Framework: ASP .NET CORE
SDK: .NET 10
ORM: Entity FrameWork Core
Database: SQLite

## How To Run Application
## 1. Prerequities
Ensure .NET10 SDK is installed in a machine and tools required for Entity Framework Core.

## 2. Setup and Execution
1. Navigate to the root folder through terminal
2. Restore Dependencies
    **dotnet restore** command in terminal
3. Apply Migration
    **dotnet ef database update** to update/intialize database, AppDbContext and migration available in codebase.
4. Running Application
    **dotnet run** to run application