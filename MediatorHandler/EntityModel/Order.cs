namespace DataAccessLayer.EntityModel
{
    public class Order : ModelBase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public double Price { get; set; }

        public IList<Item> Items { get; set; }
    }
}
