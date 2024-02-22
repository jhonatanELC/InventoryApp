namespace InventoryApp
{
    internal class Price
    {
        public Currency Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public int Igv { get; set; }
        public int ProfitMargen { get; set; }

        protected decimal SalePrice = 0;

    }
}
