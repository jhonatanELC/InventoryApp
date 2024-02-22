namespace InventoryApp
{
    public class Utilities
    {
        static Spare newSpare = new Spare();
        public static void MainMenu()
        {
            Console.WriteLine("Inventario");
            Console.WriteLine("Que desea hacer    ?");
            Console.WriteLine("Agregar un repuesto: 1");
            Console.WriteLine("Obtener informacion de un repuesto:  2");


            AddSpareMenu();
            GetInfoMenu();
        }   

        public static void AddSpareMenu()
        {
            string Code;
            string SpareBrand;
            string Description;
            string VehicleBrand;
            string VehicleModel;
            Group Group;

            Console.WriteLine("Ingrese los siguientes datos: ");
            Console.WriteLine("Codigo del repuesto: ");
            Code = Console.ReadLine();
            Console.WriteLine("Marca del repuesto: ");
            SpareBrand = Console.ReadLine();
            Console.WriteLine("Descripción: ");
            Description = Console.ReadLine();
            Console.WriteLine("Marca del vehiculo:  ");
            VehicleBrand = Console.ReadLine();
            Console.WriteLine("Modelo del vehiculo: ");
            VehicleModel = Console.ReadLine();
            Console.WriteLine("En que grupo quiere agruparlo, por ejm caja, corona: ");
            Enum.TryParse(Console.ReadLine(),true, out Group );


            
            newSpare.AddSpare(Description,SpareBrand,Code,VehicleBrand,VehicleModel,Group);

        }

        public static void GetInfoMenu()
        {
            string getSku; 

            Console.WriteLine("Ingrese el SKU del respuesto a buscar: ");
            getSku = Console.ReadLine();

            newSpare.GetSpareInfo(getSku);

        }




    }
}
