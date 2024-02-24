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
                Console.WriteLine("Agregar cantidades: 4");
                Console.WriteLine("Salir: 0");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddSpareMenu();
                        break;
                    case "2":
                        GetOneSpareInfoMenu(showAllSpares);
                        break;
                    case "3":
                        showAllSpares = true;
                        GetOneSpareInfoMenu(showAllSpares);
                        showAllSpares = false;
                        break;
                    case "4":
                        AddQuantitiesMenu();
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
            int Quantity = 0 ;

            bool HasConvertedGroupLanguage;


            Console.WriteLine("Ingrese los siguientes datos: ");

            // Set OEM
            do
            {
                Console.WriteLine("Codigo del repuesto: ");
                OemCode = Console.ReadLine()?.Trim(); 
            } while (string.IsNullOrWhiteSpace(OemCode));

            // Set Brand
            do
            {
                Console.WriteLine("Marca del repuesto: ");
                Brand = Console.ReadLine()?.Trim(); 
            } while (string.IsNullOrWhiteSpace(Brand));

            // Set Description
            do
            {
                Console.WriteLine("Descripción: ");
                Description = Console.ReadLine()?.Trim() ; 
            } while (string.IsNullOrWhiteSpace(Description));

            // Set Vehicle Brand
            do
            {
                Console.WriteLine("Marca del vehiculo:  ");
                VehicleBrand = Console.ReadLine()?.Trim(); 
            } while (string.IsNullOrWhiteSpace(VehicleBrand));

            // Set Vehicle Model
            Console.WriteLine("Modelo del vehiculo: ");
            VehicleModel = Console.ReadLine();

            // Set Quantity
            bool HasParsed;
            do
            {
                Console.WriteLine("Ingrese la cantidad: ");
                string value = Console.ReadLine();

                HasParsed = int.TryParse(value, out Quantity);

            } while (!HasParsed || Quantity < 0);
            HasParsed = false;

            // Set Group
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




            Spare newSpare = new Spare(Description, Brand,OemCode,VehicleBrand,VehicleModel,group);
            Inventory.Add(newSpare);
            HasConvertedGroupLanguage = false;

        }

        public static void GetOneSpareInfoMenu(bool showAllSpares)
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

        public static void AddQuantitiesMenu()
        {
            string getSku;
            int amountToAdd;

            Console.WriteLine("Ingrese el SKU del respuesto a buscar: ");
            getSku = Console.ReadLine();

            Spare findSpare = Inventory.Find(s => s.Sku == getSku);

            if(findSpare == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"SKU {getSku} invalido!");
                Console.ResetColor();
                Thread.Sleep(2000); ;
                return;
            }
            string message = findSpare.ToString();
            Console.WriteLine(message);

            Console.WriteLine("\nIngrese la cantidad a agregar: ");
            int.TryParse(Console.ReadLine(), out amountToAdd);

            findSpare.IncreaseStock(amountToAdd);

        }




    }
}
