using System.Collections.Generic;
using System.Data;
using sharp;



namespace sharp {

    class Program {
        private static bool MainMenu() {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Bike");
            Console.WriteLine("2) List Bikes");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
 
            switch (Console.ReadLine())
            {
                case "1":
                    AddBike();
                    return true;
                case "2":
                    ListBikes();
                    Console.ReadKey();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        static void AddBike() {
            using var db = new BikeContext();
            string Manufacturer = Console.ReadLine();
            string Model = Console.ReadLine();
            string Type = Console.ReadLine();
            
            db.Add(new Bike { Manufacturer = Manufacturer, Model = Model, Type = Type});
            db.SaveChanges();
        }

        static void ListBikes() {
            using var db = new BikeContext();
            var bikes = db.Bikes;
            foreach( var bike in bikes) {
                Console.WriteLine($"|ID: {bike.BikeId}|Manufactuer: {bike.Manufacturer}|Model: {bike.Model}|Type: {bike.Type}|");
            }

        }
        

        static void Main(string[] args) {
            bool showMenu = true;
            while (showMenu) {
                showMenu = MainMenu();
            }
        }
    }
}
