using BookGraphQLApi.GraphQL;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Vite's default dev server port
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add GraphQL services
builder.Services.AddGraphQL(b => b
    .AddSchema<BookSchema>()
    .AddSystemTextJson());

// Register schema dependencies
builder.Services.AddSingleton<BookQuery>();
builder.Services.AddSingleton<BookType>();
builder.Services.AddSingleton<BookSchema>();

var app = builder.Build();
app.UseCors("AllowViteFrontend");

// Add GraphQL middleware
app.UseGraphQL<BookSchema>("/graphql");
app.UseGraphQLPlayground("/ui/playground"); // Playground for testing

app.Run();