using InventoryApp.Helpers;

namespace InventoryApp
{
    public class Utilities
    {

        private static List<Spare> Inventory = new List<Spare>();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción invalida!");
                        Console.ResetColor();
                        Thread.Sleep(1000);
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
            Group group;
            bool HasConvertedGroupLanguage;


            Console.WriteLine("Ingrese los siguientes datos: ");

            do
            {
                Console.WriteLine("Codigo del repuesto: ");
                OemCode = Console.ReadLine()?.Trim(); 
            } while (string.IsNullOrWhiteSpace(OemCode));

            do
            {
                Console.WriteLine("Marca del repuesto: ");
                Brand = Console.ReadLine()?.Trim(); 
            } while (string.IsNullOrWhiteSpace(Brand));
            do
            {
                Console.WriteLine("Descripción: ");
                Description = Console.ReadLine()?.Trim() ; 
            } while (string.IsNullOrWhiteSpace(Description));

            do
            {
                Console.WriteLine("Marca del vehiculo:  ");
                VehicleBrand = Console.ReadLine()?.Trim(); 
            } while (string.IsNullOrWhiteSpace(VehicleBrand));

            Console.WriteLine("Modelo del vehiculo: ");
            VehicleModel = Console.ReadLine();

            do
            {
                Console.WriteLine("En que grupo quiere agruparlo, por ejm caja, corona: ");
                string groupInput = Console.ReadLine()?.Trim().ToLower();


                HasConvertedGroupLanguage =  GroupConverter.TryConvertFromSpanish(groupInput, out group); 
                if (HasConvertedGroupLanguage)
                {
                    // Use the English enum value
                    Console.WriteLine($"Grupo seleccionado: {group}");
                }
                else
                {
                    Console.WriteLine("Grupo no válido. Inténtelo de nuevo.");
                }


                //isValidImput = Enum.TryParse(groupImput, true, out group) && Enum.IsDefined(typeof(Group),group  );

                //if (!isValidImput)
                //{
                //    Console.WriteLine("Entrada no valida. Intente nuevamente.");
                //}

            } while (!HasConvertedGroupLanguage);
            HasConvertedGroupLanguage = false;


            Spare newSpare = new Spare(Description, Brand,OemCode,VehicleBrand,VehicleModel,group);

            Inventory.Add(newSpare);

        }

        public static void GetInfoMenu(bool showAllSpares)
        {
            if (!showAllSpares)
            {
                string getSku;

                Console.WriteLine("Ingrese el SKU del respuesto a buscar: ");
                getSku = Console.ReadLine();

                Spare findSpare = Inventory.Find(s => s.Sku == getSku);

                string message = findSpare.ToString();
                Console.WriteLine(message);

                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }
            else
            {
                foreach (var store in Inventory)
                {
                    Console.WriteLine(store.ToString());

                }
                Console.WriteLine("Presione enter para continuar");
                Console.ReadLine();
            }


        }

        protected void DisplayGroup()
        {

        }




    }
}
