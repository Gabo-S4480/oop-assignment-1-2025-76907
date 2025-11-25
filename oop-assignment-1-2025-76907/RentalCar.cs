using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace oop_assignment_1_2025_76907
{
    
    // 1. Interface
    
    public interface IRentalCar
    {
        void borrow();
        void returnRentalCar();
        void changePrice(double price);
        double checkPrice();
        bool checkBorrowed();
        void display();
    }

    
    // 2. Class
   
    public abstract class RentalItem
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public double Price { get; set; } = 0.0;
        public bool Borrowed { get; protected set; } = false;

        protected RentalItem(string manufacturer, string model, double price)
        {
            if (string.IsNullOrWhiteSpace(manufacturer) ||
                string.IsNullOrWhiteSpace(model) ||
                price <= 0)
            {
                throw new ArgumentException(
                    "The Manufacturer and Model fields cannot be empty, and the Price must be greater than zero.");
            }

            Manufacturer = manufacturer;
            Model = model;
            Price = price;
        }

        public abstract void display();
    }

    
    // 3. Class
    
    public class RentalCar : RentalItem, IRentalCar
    {
        public string BodyType { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;

        // Validation 
        private void ValidateCar(string registrationNumber, string bodyType)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber) ||
                string.IsNullOrWhiteSpace(bodyType))
            {
                throw new ArgumentException("The registration number and body type cannot be left blank.");
            }
        }

        
        // Constructor 1 (Full)
        
        public RentalCar(string manufacturer, string model, string bodyType,
                         string registrationNumber, double price, bool borrowed)
            : base(manufacturer, model, price)
        {
            ValidateCar(registrationNumber, bodyType);
            BodyType = bodyType;
            RegistrationNumber = registrationNumber;
            Borrowed = borrowed;
        }

        // =====================
        // Constructor 2
        // =====================
        public RentalCar(string manufacturer, string model, string bodyType,
                         string registrationNumber, double price)
            : this(manufacturer, model, bodyType, registrationNumber, price, false)
        {
        }

        // =====================
        // Constructor 3
        // =====================
        public RentalCar(string manufacturer, string model, string bodyType)
            : this(manufacturer, model, bodyType, "PENDING", 50.0, false)
        {
        }

        // =====================
        // Display Method
        // =====================
        public override void display()
        {
            Console.WriteLine("\n****************************************************");
            Console.WriteLine($"RENTAL CAR INFORMATION: {Manufacturer} {Model}");
            Console.WriteLine("****************************************************");
            Console.WriteLine($"  Manufacturer:       {Manufacturer}");
            Console.WriteLine($"  Model:              {Model}");
            Console.WriteLine($"  Type:               {BodyType}");
            Console.WriteLine($"  Registration:       {RegistrationNumber}");
            Console.WriteLine($"  Price per day:      {Price:C}");
            Console.WriteLine($"  Status:             {(Borrowed ? "BORROWED" : "AVAILABLE")}");
            Console.WriteLine("****************************************************\n");
        }

       
        // INTERFACE METHODS
       

        public void borrow()
        {
            if (Borrowed)
            {
                Console.WriteLine($"\n[ERROR]: {Manufacturer} {Model} (Reg: {RegistrationNumber}) is already borrowed.");
            }
            else
            {
                Borrowed = true;
                Console.WriteLine($"\n[SUCCESS]: {Manufacturer} {Model} (Reg: {RegistrationNumber}) has been borrowed.");
            }
        }

        public void returnRentalCar()
        {
            if (!Borrowed)
            {
                Console.WriteLine($"\n[ERROR]: {Manufacturer} {Model} (Reg: {RegistrationNumber}) was not borrowed.");
            }
            else
            {
                Borrowed = false;
                Console.WriteLine($"\n[SUCCESS]: {Manufacturer} {Model} (Reg: {RegistrationNumber}) has been returned.");
            }
        }

        public bool checkBorrowed() => Borrowed;

        public double checkPrice() => Price;

        public void changePrice(double newPrice)
        {
            if (newPrice > 0)
            {
                Console.WriteLine($"\n[UPDATE]: Changing price of {Manufacturer} {Model} from {Price:C} to {newPrice:C}.");
                Price = newPrice;
            }
            else
            {
                Console.WriteLine("[ERROR]: The new price must be a positive value.");
            }
        }
    }
}





