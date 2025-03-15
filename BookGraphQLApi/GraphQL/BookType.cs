using BookGraphQLApi.Models;
using GraphQL.Types;

namespace BookGraphQLApi.GraphQL;

public class BookType : ObjectGraphType<Book>
{
    public BookType()
    {
        Field(x => x.Id);
        Field(x => x.Title);
        Field(x => x.Author);
    }
}