namespace FactoryPattern_Car
{
    public enum VehicleCategory
    {
        Bike,
        Scooter,
        Car,
        Truck
    }
    public interface IVehicle
    {
        public string Model { get; set; }
        public int Wheels { get; set; }
        public double Mileage { get; set; }
        void Drive(double distance);
        void ShowInfo();
    }
    public abstract class TwoWheeler : IVehicle
    {
        public string Model { get; set; }
        public int Wheels { get; set; } = 2;
        public double Mileage { get; set; }
        protected TwoWheeler(string model,double mileage)
        {
            Model = model;
            Mileage = mileage; // default mileage for two wheelers
        }
        public virtual void Drive(double distance)
        {
            Mileage += distance; // assuming 20 km/l efficiency
            Console.WriteLine($"Driving {Model} for {distance} km. Total Mileage : {Mileage} km.");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Model: {Model}, Wheels: {Wheels}");
        }
    }
    public class Bike : TwoWheeler
    {
        public Bike(string model,double mileage) : base(model, mileage) { }
    }
    public class Scooter : TwoWheeler
    {
        public Scooter(string model,double mileage) : base(model, mileage) { }
    }

    public abstract class FourWheeler : IVehicle
    {
        public string Model { get; set; }
        public int Wheels { get; set; } = 4;
        public double Mileage { get; set; }
        protected FourWheeler(string model,double mileage)
        {
            Model = model;
            Mileage = mileage;
        }
        public virtual void Drive(double distance)
        {
            Mileage += distance;
            Console.WriteLine($"Driving {Model} for {distance} km. Total Mileage : {Mileage} km.");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Model: {Model}, Wheels: {Wheels}");
        }
    }
    public class Car : FourWheeler
    {
        public Car(string model,double mileage) : base(model, mileage) { }
    }
    public class Truck : FourWheeler
    {
        public Truck(string model,double mileage) : base(model, mileage) { }
    }

    public static class VehicleFactory
    {
        public static IVehicle CreateVehicle(VehicleCategory category, string model,double mileage)
        {
            return category switch
            {
                VehicleCategory.Bike => new Bike(model,mileage),
                VehicleCategory.Scooter => new Scooter(model,mileage),
                VehicleCategory.Car => new Car(model,mileage),
                VehicleCategory.Truck => new Truck(model,mileage),
                _ => throw new ArgumentException("Invalid vehicle category")
            };
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle myBike = VehicleFactory.CreateVehicle(VehicleCategory.Bike, "Yamaha FZ", 30);
            IVehicle myScooter = VehicleFactory.CreateVehicle(VehicleCategory.Scooter, "Honda Activa", 40); 
            IVehicle myCar = VehicleFactory.CreateVehicle(VehicleCategory.Car, "Toyota Camry", 15);
            IVehicle myTruck = VehicleFactory.CreateVehicle(VehicleCategory.Truck, "Ford F-150", 10);
            myBike.ShowInfo();
            myBike.Drive(100);
            myScooter.ShowInfo();
            myScooter.Drive(50);
            myCar.ShowInfo();
            myCar.Drive(200);
            myTruck.ShowInfo();
            myTruck.Drive(300);
            
        }
    }
}
