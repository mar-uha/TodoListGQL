public class Query
{
    // Will return all of our todo list items
    // We are injecting the context of our dbConext to access the db
    // this is called a resolver

    // So basically this attribute is pulling a db context from a pool
    // using the db context 
    // returning the db context to the pool
    [UseDbContext(typeof(ApiDbContext))]
    [UseProjection] //=> we have remove it since we have used explicit resolvers
    [UseFiltering]
    [UseSorting]
    public IQueryable<ItemData> GetItems(ApiDbContext context)
    {
        return context.Items;
    }

    [UseDbContext(typeof(ApiDbContext))]
    [UseProjection] //=> we have remove it since we have used explicit resolvers
    [UseFiltering]
    [UseSorting]
    public IQueryable<ItemList> GetLists(ApiDbContext context)
    {
        return context.Lists;
    }
}