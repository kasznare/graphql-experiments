using BookGraphQLApi.Models;
using GraphQL.Types;

namespace BookGraphQLApi.GraphQL;

public class BookQuery : ObjectGraphType
{
    public BookQuery()
    {
        Field<ListGraphType<BookType>>(
            "books",
            resolve: context => new List<Book>
            {
                new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien" },
                new Book { Id = 2, Title = "1984", Author = "George Orwell" }
            });
    }
}