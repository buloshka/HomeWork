public class Transport
{
    protected string _model;
    protected int _maxSpeed;

    public Transport(string model, int maxSpeed)
    {
        this._model = model;
        this._maxSpeed = maxSpeed;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Transport Type: {GetType().Name}");
        Console.WriteLine($"Model: {_model}");
        Console.WriteLine($"Max Speed: {_maxSpeed} km/h");
    }
}

public class Auto : Transport
{
    protected int _numberOfSeats;

    public Auto(string model, int maxSpeed, int numberOfSeats)
         : base(model, maxSpeed)
    {
        this._numberOfSeats = numberOfSeats;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Number of Seats: {_numberOfSeats}");
    }
}

public class Car : Auto
{
    private string _bodyType;

    public Car(string model, int maxSpeed, int numberOfSeats, string bodyType)
        : base(model, maxSpeed, numberOfSeats)
    {
        this._bodyType = bodyType;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Body Type: {_bodyType}");
    }
}

public class Truck : Auto
{
    private int _maxLoad;

    public Truck(string model, int maxSpeed, int numberOfSeats, int maxLoad)
          : base(model, maxSpeed, numberOfSeats)
    {
        this._maxLoad = maxLoad;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Max Load: {_maxLoad} kg");
    }
}

public class Airplane : Transport
{
    protected int _flightAltitude;

    public Airplane(string model, int maxSpeed, int flightAltitude)
             : base(model, maxSpeed)
    {
        this._flightAltitude = flightAltitude;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Flight Altitude: {_flightAltitude} meters");
    }
}

public class CargoPlane : Airplane
{
    private int _maxCargoWeight;

    public CargoPlane(string model, int maxSpeed, int flightAltitude, int maxCargoWeight)
               : base(model, maxSpeed, flightAltitude)
    {
        this._maxCargoWeight = maxCargoWeight;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Max Cargo Weight: {_maxCargoWeight} kg");
    }
}

public class PassengerPlane : Airplane
{
    private int _maxPassengerCount;

    public PassengerPlane(string model, int maxSpeed, int flightAltitude, int maxPassengerCount)
                   : base(model, maxSpeed, flightAltitude)
    {
        this._maxPassengerCount = maxPassengerCount;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Max Passenger Count: {_maxPassengerCount}");
    }
}

public class Train : Transport
{
    private int _carriageCount;

    public Train(string model, int maxSpeed, int carriageCount)
          : base(model, maxSpeed)
    {
        this._carriageCount = carriageCount;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Carriage Count: {_carriageCount}");
    }
}