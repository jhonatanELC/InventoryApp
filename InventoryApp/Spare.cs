namespace InventoryApp
{
    internal class Spare
    {
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string OemCode { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public Group Group { get; set; }

        public List<Spare> Spares { get; set; } = new List<Spare>();

        public Spare(string? description, string brand, string oemCode, string vehicleBrand, string vehicleModel, Group group)
        {
            Description = description ?? "";
            Brand = brand;
            OemCode = oemCode;
            VehicleBrand = vehicleBrand;
            VehicleModel = vehicleModel;
            Group = group;

        }
        public Spare()
        {
            //Sku = GenerateSku();
        }

        public Spare AddSpare(string? description, string brand, string oemCode, string vehicleBrand, string vehicleModel, Group group)
        {
            Spare newSpare = new Spare(description,brand,oemCode,vehicleBrand,vehicleModel,group);

            Spares.Add(newSpare);
            return newSpare;
        }

        public List<Spare> GetAllSpare()
        {

            return Spares;
        }

        public void GetSpareInfo(string sku)
        {
            Spare getSpare =  Spares.Find(s => s.Sku == sku);

            getSpare.ToString();
        }



        public override string ToString()
        {
            return $"OEM: {OemCode}\nDescripción: {Description}\n Marca: {Brand}\n Tipo de Vehiculo: {VehicleBrand}, modelo {VehicleModel}\n SKU: {Sku}";
        }

        private string GenerateSku()
        {
             
            return OemCode + Brand; ;
        }

    }
}
