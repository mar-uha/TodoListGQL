public class Subscription
{
    [Subscribe]
    public ItemList OnListAdded([EventMessage] ItemList list) => list;
}
