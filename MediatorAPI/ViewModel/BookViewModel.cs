namespace MediatorAPI.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

        public IList<ItemViewModel> Items { get; set; }
    }

    public class CreatedBookViewModel
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

    }
}
