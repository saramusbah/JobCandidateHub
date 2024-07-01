# Candidate Management API
 
This project is a .NET Core application that provides a REST API for managing candidate information. It allows you to add or update candidate profiles using their email as a unique identifier.
 
## Features
 
- **Add or Update Candidate**: POST endpoint `/api/candidates` allows adding or updating candidate information. Email is used as the unique identifier.
- **Validation**: FluentValidation is used for input validation to ensure required fields are provided and email format is correct.
- **Persistence**: Data is stored in a SQL database (configured for SQL Server in this example).
