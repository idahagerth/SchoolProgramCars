using System;

class Vehicle
{
    private static int lastId = 0;
    private int Id { get; } = GenerateId();
    private string Make { get; set; }
    private string Model { get; set; }
    private int Year { get; set; }
    private string Color { get; set; }

    public Vehicle(string make, string model, string color)
    {
        Make = make;
        Model = model;
        Color = color;
    }
    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }
    private static List<Vehicle> VehicleList = new List<Vehicle>();

    private static int GenerateId()
    {
        return ++lastId;
    }
    public static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Enter '+' to add vehicle, Enter '-' to remove vehicle, Enter '0' to exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "+":
                    Console.Write("Enter Make: ");
                    string make = Console.ReadLine();

                    Console.Write("Enter Model: ");
                    string model = Console.ReadLine();

                    string Respons;
                    do
                    {
                        Console.Write("Do you want to enter the year? (y/n)");
                        Respons = Console.ReadLine().ToLower();
                    } while (Respons != "y" && Respons != "n");

                    if (Respons.ToLower() == "y")
                    {
                        int year = 0;
                        bool errors = false;
                        while (!errors)
                        {
                            Console.Write("Enter year: ");
                            errors = int.TryParse(Console.ReadLine(), out year);

                            if (!errors)
                            {
                                Console.WriteLine("Please enter numbers!");
                            }
                        }

                        Vehicle newCar = new Vehicle(make, model, year);

                        VehicleList.Add(newCar);
                    }
                    else
                    {
                        Console.Write("Enter color: ");
                        int color = int.Parse(Console.ReadLine());

                        Vehicle newCar = new Vehicle(make, model, color);

                        VehicleList.Add(newCar);
                    }
                    Console.WriteLine("vehicle added!");
                    break;

                case "-":
                    Console.Write("Enter vehicle id to remove: ");
                    int remove = int.Parse(Console.ReadLine());

                    Vehicle carToRemove = VehicleList.Find(v => v.Id == remove);

                    if (carToRemove != null)
                    {
                        VehicleList.Remove(carToRemove);
                        Console.WriteLine("vehicle deleted!");
                    }
                    else
                    {
                        Console.WriteLine("vehicle not found!");
                    }
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
            for (int i = 0; i < VehicleList.Count; i++)
            {
                Console.WriteLine($"Id: {VehicleList[i].Id} Make: {VehicleList[i].Make} Model: {VehicleList[i].Model} Year: {VehicleList[i].Year} Color: {VehicleList[i].Color}");

            }
        }
    }
}

