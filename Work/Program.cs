namespace IndependentWork;

public class Sixth
{
    static void Main(string[] args)
    {
        Transport transport = new Transport("Generic Transport", 100);
        transport.DisplayInfo();
        Console.WriteLine();

        Auto auto = new Auto("Generic Auto", 200, 4);
        auto.DisplayInfo();
        Console.WriteLine();

        Car car = new Car("Generic Car", 180, 5, "Sedan");
        car.DisplayInfo();
        Console.WriteLine();

        Truck truck = new Truck("Generic Truck", 150, 2, 5000);
        truck.DisplayInfo();
        Console.WriteLine();

        Airplane airplane = new Airplane("Generic Airplane", 900, 10000);
        airplane.DisplayInfo();
        Console.WriteLine();

        CargoPlane cargoPlane = new CargoPlane("Generic Cargo Plane", 800, 12000, 5000);
        cargoPlane.DisplayInfo();
        Console.WriteLine();

        PassengerPlane passengerPlane = new PassengerPlane("Generic Passenger Plane", 900, 10000, 200);
        passengerPlane.DisplayInfo();
        Console.WriteLine();

        Train train = new Train("Generic Train", 120, 10);
        train.DisplayInfo();
        Console.WriteLine();
    }
}