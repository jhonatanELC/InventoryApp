namespace InventoryApp
{
    public class Utilities
    {

        private static List<Spare> inventory = new List<Spare>();
        public static void MainMenu()
        {
            string option;
            bool showAllSpares = false;

            do
            {
                Console.WriteLine("Inventario");
                Console.WriteLine("Que desea hacer?");
                Console.WriteLine("Agregar un repuesto: 1");
                Console.WriteLine("Obtener informacion de un repuesto:  2");
                Console.WriteLine("Ver todos los repuestos: 3");
                Console.WriteLine("Salir: 0");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddSpareMenu();
                        break;
                    case "2":
                        GetInfoMenu(showAllSpares);
                        break;
                    case "3":
                        showAllSpares = true;
                        GetInfoMenu(showAllSpares);
                        showAllSpares = false;
                        break;
                    case "0":
                        Console.WriteLine("Presione enter para salir");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opción invalida!");
                        break;
                }
                Console.Clear();

            } while (option != "0");

        }

        public static void AddSpareMenu()
        {
            string OemCode;
            string Brand;
            string Description;
            string VehicleBrand;
            string VehicleModel;
            Group Group;

            Console.WriteLine("Ingrese los siguientes datos: ");
            Console.WriteLine("Codigo del repuesto: ");
            OemCode = Console.ReadLine();

            Console.WriteLine("Marca del repuesto: ");
            Brand = Console.ReadLine();

            Console.WriteLine("Descripción: ");
            Description = Console.ReadLine();

            Console.WriteLine("Marca del vehiculo:  ");
            VehicleBrand = Console.ReadLine();

            Console.WriteLine("Modelo del vehiculo: ");
            VehicleModel = Console.ReadLine();

            Console.WriteLine("En que grupo quiere agruparlo, por ejm caja, corona: ");
            Enum.TryParse(Console.ReadLine(), true, out Group);


            Spare newSpare = new Spare(Description, Brand,OemCode,VehicleBrand,VehicleModel,Group);

            inventory.Add(newSpare);

        }

        public static void GetInfoMenu(bool showAllSpares)
        {
            if (!showAllSpares)
            {
                string getSku;

                Console.WriteLine("Ingrese el SKU del respuesto a buscar: ");
                getSku = Console.ReadLine();

                Spare findSpare = inventory.Find(s => s.Sku == getSku);

                string message = findSpare.ToString();
                Console.WriteLine(message);

                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
            else
            {
                foreach (var store in inventory)
                {
                    Console.WriteLine(store.ToString());

                }
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }


        }




    }
}
