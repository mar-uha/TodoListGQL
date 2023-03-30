public class Mutation
{
    // this attribute will help us utilise the multi threaded api db context
    [UseDbContext(typeof(ApiDbContext))]
    public async Task<AddListPayload> AddListAsync(AddListInput input, ApiDbContext context)
    {
        var list = new ItemList
        {
            Name = input.name
        };

        context.Lists.Add(list);
        await context.SaveChangesAsync();

        return new AddListPayload(list);
    }

    [UseDbContext(typeof(ApiDbContext))]
    public async Task<AddItemPayload> AddItemAsync(AddItemInput input, ApiDbContext context)
    {
        var item = new ItemData
        {
            Description = input.description,
            Done = input.done,
            Title = input.title,
            ListId = input.listId
        };

        context.Items.Add(item);
        await context.SaveChangesAsync();

        return new AddItemPayload(item);
    }
}