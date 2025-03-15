using GraphQL.Types;
using GraphQL;

namespace BookGraphQLApi.GraphQL;

public class BookSchema : Schema
{
    public BookSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<BookQuery>();
    }
}