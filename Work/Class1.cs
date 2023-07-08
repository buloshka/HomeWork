public abstract class Transport
{
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }

    /// <summary> Количество энергии в баке/батарее в КВт*Ч </summary>
    public double EnergyStorage { get; private set; }
    public double Weight { get; private set; }
    public double Speed { get; private set; }
    public double Price { get; private set; }
    public int PassangerAmount { get; private set; }

    public Transport(string name, string manufacturer, double energyStorage, double weight, double speed, double price, int passangerAmount = 4)
    {
        Name = name;
        Manufacturer = manufacturer;
        PassangerAmount = passangerAmount;
        EnergyStorage = energyStorage;
        Weight = weight;
        Speed = speed;
        Price = price;
    }

    public virtual string GetInfo()
    {
        return $"Название - {Name};\nПроизводитель - {Manufacturer};\nКоличество пассажиров - {PassangerAmount};\nВместимось энергии - {EnergyStorage}КВт*ч;\nВес - {Weight}Кг;\nСкорость - {Speed}Км/Ч;\nЦена - {Price} Рублей;";
    }
}
public class Engine
{
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }

    /// <summary> Мощность в КВт </summary>
    public double Power { get; private set; }

    /// <summary> Энергопотребление в КВт*Ч/100Км </summary>
    public double EnergyConsumption { get; private set; }

    public Engine(string manufacturer, string name, double power, double energyConsumption)
    {
        Manufacturer = manufacturer;
        Name = name;
        Power = power;
        EnergyConsumption = energyConsumption;
    }

    public override string ToString()
    {
        return $"Название - {Name};\nМощность - {Power}КВт;\nЭнергопотребление - {EnergyConsumption}КВт*Ч/100Км";
    }
}

public abstract class Automobile : Transport
{
    public Engine Engine { get; private set; }

    protected Automobile(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, int passangerAmount) : base(name, manufacturer, energyStorage, weight, speed, price, passangerAmount)
    {
        Engine = engine;
    }

    public new string GetInfo()
    {
        return base.GetInfo() + $"\nДвигатель\n{Engine}\n";
    }
    public void Drive(double distance)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака");
        }
    }
}

public sealed class PassangerCar : Automobile
{
    /// <summary> В кубических метрах </summary>
    public double TrunkVolume { get; private set; }
    public PassangerCar(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double trunkVolume, int passangerAmount) : base(name, manufacturer, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        TrunkVolume = trunkVolume;
    }
    public new string GetInfo()
    {
        return base.GetInfo() + $"Объём багажника - {TrunkVolume} метров кубических;";
    }

    public void TrunkFill(double volume)
    {
        if (volume < TrunkVolume)
        {
            Console.WriteLine("Поместилось");
        }
        else
        {
            Console.WriteLine("Не поместилось");
        }
    }
}

public sealed class Lorry : Automobile
{
    /// <summary> В Кг </summary>
    public double CarryWeight { get; private set; }

    public Lorry(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double carryWeight, int passangerAmount) : base(name, manufacturer, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        CarryWeight = carryWeight;
    }
    public new string GetInfo()
    {
        return base.GetInfo() + $"Грузоподъёмность - {CarryWeight}Кг;";
    }

    public void CargoVeightMeasure(double weight)
    {
        if (weight < CarryWeight)
        {
            Console.WriteLine("Хватает грузоподъёмности");
        }
        else
        {
            Console.WriteLine("Не хватает грузоподъёмности");
        }
    }
}

public abstract class Plane : Transport
{
    public Engine Engine { get; private set; }

    /// <summary> В метрах </summary>
    public double WingSpan { get; private set; }

    protected Plane(string name, string manufacturer, double wingSpan, Engine engine, double energyStorage, double weight, double speed, double price, int passangerAmount) : base(name, manufacturer, energyStorage, weight, speed, price, passangerAmount)
    {
        WingSpan = wingSpan;
        Engine = engine;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"\nДвигатель\n{Engine}\nРазмах крыльев - {WingSpan};";
    }

    public virtual void Flight(double distance)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака");
        }
    }
}

public sealed class PassangerPlane : Plane
{
    public bool International { get; private set; }
    public PassangerPlane(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double wingSpan, int passangerAmount, bool international = false) : base(name, manufacturer, wingSpan, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        International = international;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nМежду стран - {(International ? "Да" : "Нет")};";
    }

    public void Flight(double distance, int passangersAmount)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100 && passangersAmount <= PassangerAmount)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака или количества мест");
        }
    }

}

public sealed class CargoPlane : Plane
{
    public bool International { get; private set; }

    /// <summary> В Кг </summary>
    public double CarryWeight { get; private set; }
    public CargoPlane(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, double carryWeight, double wingSpan, int passangerAmount, bool international = false) : base(name, manufacturer, wingSpan, engine, energyStorage, weight, speed, price, passangerAmount)
    {
        International = international;
        CarryWeight = carryWeight;
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $"\nМежду стран - {(International ? "Да" : "Нет")};\nГрузоподъёмность - {CarryWeight}Кг";
    }

    public void Flight(double distance, double weight)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100 && weight <= CarryWeight)
        {
            Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        }
        else
        {
            Console.WriteLine("Не хватает объёма бака или грузоподъёмности");
        }
    }
}

public class Train : Transport
{
    public Engine Engine { get; private set; }
    public int TrainCars { get; private set; }

    public Train(string name, string manufacturer, Engine engine, double energyStorage, double weight, double speed, double price, int passangerAmount, int trainCars = 10) : base(name, manufacturer, energyStorage, weight, speed, price, passangerAmount)
    {
        TrainCars = trainCars;
        Engine = engine;
    }

    public new string GetInfo()
    {
        return base.GetInfo() + $"\nДвигатель\n{Engine}\nКоличество вагонов - {TrainCars};";
    }
    public void Route(double distance)
    {
        if (EnergyStorage >= Engine.EnergyConsumption * distance / 100) Console.WriteLine("Затрачено энергии - " + Engine.EnergyConsumption * distance + "КВт*Ч");
        else Console.WriteLine("Не хватает объёма бака");
    }
}