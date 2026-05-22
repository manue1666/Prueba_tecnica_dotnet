# PruebaTecnica - ASP.NET Core MVC Posts Application

## Project Overview

PruebaTecnica is an ASP.NET Core MVC web application that demonstrates how to consume a public REST API (JSONPlaceholder) and perform CRUD operations on Posts. This project serves as a learning resource for understanding the fundamentals of ASP.NET Core MVC, API consumption, and web application development.

## Features

- View a list of all posts from JSONPlaceholder API
- Display detailed information about a specific post
- Create new posts (simulated)
- Edit existing posts (simulated)
- Delete posts (simulated)
- Input validation and error handling
- Success/confirmation messages
- Responsive user interface using Bootstrap

## Technical Requirements

- .NET 8.0 or higher
- Visual Studio Code or Visual Studio
- HttpClient for API consumption
- Async/await patterns
- MVC architectural pattern

## Project Structure

```
PruebaTecnica/
├── Controllers/
│   ├── HomeController.cs          # Redirects to Posts
│   └── PostController.cs          # Handles Post operations
├── Models/
│   ├── Post.cs                    # Post data model
│   └── ErrorViewModel.cs          # Error handling model
├── Services/
│   └── PostService.cs             # API consumption logic
├── Views/
│   ├── Post/
│   │   ├── Index.cshtml           # List all posts
│   │   ├── Details.cshtml         # Display single post
│   │   ├── Create.cshtml          # Create post form
│   │   ├── Edit.cshtml            # Edit post form
│   │   └── Delete.cshtml          # Delete confirmation
│   ├── Shared/
│   │   └── _Layout.cshtml         # Master layout template
│   └── Home/
├── wwwroot/                       # Static files (CSS, JS)
├── Program.cs                     # Application configuration
└── PruebaTecnica.csproj          # Project file
```

## Installation and Setup

### 1. Prerequisites
Ensure you have .NET 8.0 or higher installed on your system.

### 2. Clone the Repository
```bash
git clone <repository-url>
cd PruebaTecnica
```

### 3. Restore Dependencies
```bash
dotnet restore
```

## Running the Application

### Development Mode
```bash
dotnet run
```

The application will start at: http://localhost:5026

### Building the Project
```bash
dotnet build
```

## Application Architecture

### Models
- **Post.cs**: Represents a post with properties: UserId, Id, Title, Body

### Services
- **PostService.cs**: Handles all communication with JSONPlaceholder API
  - GetAllPosts(): Retrieves all posts
  - GetPost(id): Retrieves a specific post by ID
  - CreatePost(post): Creates a new post
  - UpdatePost(id, post): Updates an existing post
  - DeletePost(id): Deletes a post
  - Includes error handling with try-catch blocks

### Controllers
- **PostController.cs**: Main controller handling all HTTP requests
  - Index: Displays all posts
  - Details: Shows post details
  - Create (GET/POST): Post creation workflow
  - Edit (GET/POST): Post editing workflow
  - Delete (GET/POST): Post deletion workflow
  - Includes form validation and error management

### Views
- **Index.cshtml**: Displays all posts in a table format with action buttons
- **Details.cshtml**: Shows complete post information with edit/back buttons
- **Create.cshtml**: Form for creating new posts
- **Edit.cshtml**: Pre-filled form for editing posts
- **Delete.cshtml**: Confirmation page before deletion

## Key Technologies and Concepts

### ASP.NET Core MVC
- Model-View-Controller architectural pattern
- Dependency injection for service management
- Tag helpers for HTML generation

### HttpClient Configuration
- Registered as a named client in Program.cs
- Base address configured for JSONPlaceholder API
- Supports GET, POST, PUT, DELETE operations

### Async/Await Pattern
- All service methods are asynchronous
- Non-blocking API calls improve application responsiveness
- Proper exception handling in async contexts

### Model Validation
- Form validation using ModelState
- Validation error messages displayed to users
- Anti-forgery token protection on POST requests

## Important Note: JSONPlaceholder API

This application uses JSONPlaceholder (https://jsonplaceholder.typicode.com/), which is a fake JSON API designed for testing and learning purposes.

Important limitations:
- Create, Edit, and Delete operations return successful responses but DO NOT persist data on the server
- All data shown is static and predefined
- The API always returns the same data on subsequent requests
- This is intentional for learning purposes and safe experimentation

This approach allows developers to practice API consumption patterns without affecting a real database.

## Usage Guide

### Viewing Posts
1. Launch the application
2. You will be automatically redirected to the Posts list
3. Browse all available posts in the table format

### Viewing Post Details
1. From the Posts list, click the "Details" button on any post
2. View complete post information
3. Use "Edit" button to modify or "Back to List" to return

### Creating a Post
1. Click "Create New Post" button
2. Fill in the form (UserId, Title, Body)
3. Click "Create" to submit
4. Confirmation message will appear
5. You will be redirected to the posts list

### Editing a Post
1. From the Posts list, click "Edit" on the desired post
2. Modify the post information
3. Click "Save" to submit changes
4. Confirmation message will appear

### Deleting a Post
1. From the Posts list, click "Delete" on the desired post
2. Review the post information on the confirmation page
3. Click "Delete" to confirm
4. Confirmation message will appear

## Troubleshooting

### Application won't start
- Ensure port 5026 is not in use
- Verify .NET 8.0 or higher is installed
- Run: dotnet restore

### Posts not loading
- Check internet connection for JSONPlaceholder API access
- Verify the API is accessible at https://jsonplaceholder.typicode.com/posts
- Check application logs for error details

### Form validation errors
- Ensure all required fields are filled
- Check form validation messages
- Verify input format matches field requirements

## Development Notes

- The application redirects the root URL (/) to the Posts controller
- TempData is used to pass success messages between requests
- Bootstrap classes provide styling and responsive layout
- All API calls include comprehensive error handling
- The service layer abstracts API logic from controller logic


