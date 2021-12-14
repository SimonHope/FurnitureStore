namespace FurnitureStore.Models
{
    public class BasketModel
    {
        public string Id { get; set; }
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}
