public class Mutation
{
    // this attribute will help us utilise the multi threaded api db context
    [UseDbContext(typeof(ApiDbContext))]
    public async Task<AddListPayload> AddListAsync(AddListInput input, [ScopedService] ApiDbContext context)
    {
        var list = new ItemList
        {
            Name = input.name
        };

        context.Lists.Add(list);
        await context.SaveChangesAsync();

        return new AddListPayload(list);
    }
}