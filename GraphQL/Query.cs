public class Query
{
    // Will return all of our todo list items
    // We are injecting the context of our dbConext to access the db
    // public IQueryable<ItemData> GetItems([Service] ApiDbContext context)
    // {
    //     return context.Items;
    // }

    // So basically this attribute is pulling a db context from a pool
    // using the db context 
    // returning the db context to the pool
    [UseDbContext(typeof(ApiDbContext))]
    public IQueryable<ItemData> GetItems(ApiDbContext context)
    {
        return context.Items;
    }
}