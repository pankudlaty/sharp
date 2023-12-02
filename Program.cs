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
            Console.WriteLine("3) Delete Bike");
            Console.WriteLine("4) Exit");
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
                    DeleteBike();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        static void AddBike() {
            using var db = new BikeContext();
            Console.WriteLine("Manufacturer:");
            string Manufacturer = Console.ReadLine();
            Console.WriteLine("Model:");
            string Model = Console.ReadLine();
            Console.WriteLine("Type:");
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
        static void DeleteBike() {
            using var db = new BikeContext();
            ListBikes();
            Console.WriteLine("Bike ID:");
            int BikeId = int.Parse(Console.ReadLine());
            var bike = db.Bikes.Find(BikeId);
            db.Remove(bike);
            db.SaveChanges();

        }
        

        static void Main(string[] args) {
            bool showMenu = true;
            while (showMenu) {
                showMenu = MainMenu();
            }
        }
    }
}
