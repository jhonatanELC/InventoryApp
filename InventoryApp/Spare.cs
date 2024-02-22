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


        public Spare(string? description, string brand, string oemCode, string vehicleBrand, string vehicleModel, Group group)
        {
            Description = description ?? "";
            Brand = brand;
            OemCode = oemCode;
            VehicleBrand = vehicleBrand;
            VehicleModel = vehicleModel;
            Group = group;
            Sku = OemCode + Brand;
        }




        public override string ToString()
        {
            return $"OEM: {OemCode}\nDescripción: {Description}\nMarca: {Brand}\nTipo de Vehiculo: {VehicleBrand}, modelo {VehicleModel}\nSKU: {Sku}";
        }


    }
}
