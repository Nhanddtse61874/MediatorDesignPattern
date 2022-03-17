namespace MediatorAPI.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public double Price { get; set; }

        public List<ItemViewModel> Items { get; set; }
    }
}
