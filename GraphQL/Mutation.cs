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

    [UseDbContext(typeof(ApiDbContext))]
    public async Task<bool> RemoveItemAsync(int itemId, ApiDbContext context)
    {
        var item = context.Items.SingleOrDefault(x => x.Id == itemId);

        // TODO: check if item exist and return false
        context.Items.Remove(item);
        await context.SaveChangesAsync();

        return true;
    }
}