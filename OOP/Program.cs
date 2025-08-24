namespace OOP
{
    abstract class Vehicle
    {
        public string brand="abc";
        public virtual void honk()
        {
            Console.WriteLine("Tuut,Tuut!");
        }
        public abstract void start();
    }
    class Car : Vehicle
    {
        public string modelName = "Lambo";
        public override void honk()
        {
            Console.WriteLine("Lambo....................!");
        }
        public override void start()
        {
            Console.WriteLine("Car started.");
        }
    }
    class Truck : Vehicle
    {
        public string modelName = "Ford";
        public override void honk()
        {
            Console.WriteLine("Ford......................!");
        }
        public override void start()
        {
            Console.WriteLine("Truck started.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Vehicle truck = new Truck();
            car.honk();
            car.start();
            truck.honk();
            truck.start();

            Vehicle myVehicle;
            myVehicle = car;
            myVehicle.honk();
            myVehicle.start();

            Car mycar = (Car) myVehicle;
            Console.WriteLine(mycar.modelName);

        }
    }
}
