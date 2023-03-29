public class ListType : ObjectType<ItemList>
{
    // since we are inheriting from objectType we need to override the functionality
    protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
    {
        descriptor.Description("Used to group the do list item into groups");
        
        //descriptor.Field(x => x.ItemDatas).Ignore();

        descriptor.Field(x => x.ItemDatas)
                    .ResolveWith<Resolvers>(p => p.GetItems(default!, default!))
                    .UseDbContext<ApiDbContext>()
                    .Description("This is the list of to do item available for this list");
    }

    private class Resolvers
    {
        public IQueryable<ItemData> GetItems([Parent] ItemList list, ApiDbContext context)
        {
            return context.Items.Where(x => x.ListId == list.Id);
        }
    }
}