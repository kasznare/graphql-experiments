# BookGraphQL Project
This project demonstrates a simple full-stack application using GraphQL with a .NET 8 backend and a Vite-powered React frontend. The backend exposes a GraphQL API to manage a list of books, while the frontend fetches and displays the data using Apollo Client.
## Features
- Backend: ASP.NET Core with GraphQL.NET, serving a list of books via a /graphql endpoint.
- Frontend: React with TypeScript, built with Vite, using Apollo Client to query the GraphQL API.
- CORS: Configured to allow cross-origin requests from the frontend.
- Playground: GraphQL Playground available for testing queries.
## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18+ recommended)
- A terminal (e.g., Bash, PowerShell, or Command Prompt)
## Project Structure
```
BookGraphQLProject/
├── BookGraphQLApi/    # .NET backend
│   ├── Models/        # Data models (e.g., Book.cs)
│   ├── GraphQL/       # GraphQL schema (types, queries, schema)
│   └── Program.cs     # Main app configuration
└── book-client/       # Vite React frontend
    ├── src/           # React components and Apollo setup
    └── vite.config.ts # Vite configuration
```
## Setup Instructions
### 1. Backend (BookGraphQLApi)
1. Create the Project:
   ```
   dotnet new web -n BookGraphQLApi
   cd BookGraphQLApi
   ```
2. Install Dependencies:
   ```
   dotnet add package GraphQL.Server.All
   dotnet add package GraphQL.Server.Ui.Playground
   dotnet add package Microsoft.EntityFrameworkCore.InMemory
   ```
3. Configure Files:
   - Add Models/Book.cs, GraphQL/BookType.cs, GraphQL/BookQuery.cs, and GraphQL/BookSchema.cs as per the code in [this guide](#).
   - Update Program.cs with CORS and GraphQL middleware (see [Backend Code](#)).
4. Run the Backend:
   ```
   dotnet run
   ```
   - Note the port (e.g., http://localhost:5069) from the terminal output.
   - Test at http://localhost:5069/ui/playground.
### 2. Frontend (book-client)
1. Create the Project:
   ```
   npm create vite@latest book-client -- --template react-ts
   cd book-client
   ```
2. Install Dependencies:
   ```
   npm install @apollo/client graphql
   ```
3. Configure Apollo Client:
   - Update src/main.tsx with the Apollo setup, pointing to your backend URL (e.g., http://localhost:5069/graphql).
   - Replace src/App.tsx with the book list component (see [Frontend Code](#)).
4. Run the Frontend:
   ```
   npm run dev
   ```
   - Open http://localhost:5173 to view the app.
### 3. Verify
- Backend: Run a query in the Playground:
  ```
  query {
    books {
      id
      title
      author
    }
  }
  ```
- Frontend: Ensure the book list displays at http://localhost:5173.
## Example Query
```
query GetBooks {
  books {
    id
    title
    author
  }
}
```
## Troubleshooting
- CORS Issues: Ensure app.UseCors precedes app.UseGraphQL in Program.cs and the frontend origin (http://localhost:5173) is allowed.
- Port Mismatch: Check the backend port in the terminal and update the frontend’s Apollo uri if needed.
- Errors: Inspect the browser’s Network tab or backend logs for details.
## Future Enhancements
- Add mutations to create/edit books.
- Replace in-memory data with a database (e.g., SQLite or SQL Server).
- Deploy to a hosting service.
## License
This project is unlicensed—feel free to use and modify it as you see fit!

