using System;
using System.Collections.Generic;
using System.Linq;

class Component
{
    private string name;
    private string details;
    private double price;

    public Component(string name, double price, string details = null)
    {
        this.Name = name;
        this.Price = price;
        this.Details = details;
    }

    public string Name 
    {
        get { return this.name; }
        set
        {
            if (value == "")
            {
                throw new ArgumentOutOfRangeException("The Name must not be empty");
            }
            this.name = value;
        }
    }

    public string Details 
    {
        get { return this.details; }
        set
        {
            if (value == "")
            {
                throw new ArgumentException("The Details must not be empty");
            }
            this.details = value;
        }
    }

    public double Price 
    {
        get { return this.price; }
        set 
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The Price must be a positive non-zero number");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        string result = "Name: " + this.name + ", Price: " + this.price;
        if (this.details != null)
        {
            result += ", Details: " + this.details;
        }

        return result;
    }

}

class Computer
{
    private string name;
    private Component processor;
    private Component motherboard;
    private Component graphicsCard;

    public Computer(string name, Component processor, Component motherboard, Component graphicsCard)
    {
        this.Name = name;
        this.Processor = processor;
        this.MotherBoard = motherboard;
        this.GraphicsCard = graphicsCard;
    }

    public string Name 
    {
        get { return this.name; }
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name must be a non-empty string");
            }
            this.name = value;
        }
    }

    public Component Processor
    {
        get { return this.processor; }
        set { this.processor = value; }
    }

    public Component MotherBoard
    {
        get { return this.motherboard; }
        set { this.motherboard = value; }
    }

    public Component GraphicsCard
    {
        get { return this.graphicsCard; }
        set { this.graphicsCard = value; }
    }

    public double Price
    {
        get { return (double)(this.Processor.Price + this.MotherBoard.Price + this.GraphicsCard.Price); }
    }

    public override string ToString()
    {
        double price = this.Processor.Price + this.MotherBoard.Price + this.GraphicsCard.Price;

        string result = "Computer name: " + this.Name + "\n";
        result += "Processor: " + this.Processor.Name + ", " + this.Processor.Price + "lv., " + this.Processor.Details + "\n";
        result += "MotherBoard: " + this.MotherBoard.Name + ", " + this.MotherBoard.Price + "lv., " + this.MotherBoard.Details + "\n";
        result += "Graphics Card: " + this.GraphicsCard.Name + ", " + this.GraphicsCard.Price + "lv., " + this.GraphicsCard.Details + "\n";
        result += "Total Price: " + (price.ToString("0.00")) + "lv.\n";
        
        return result;
    }

}

class PCCatalog
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        List<Computer> computers = new List<Computer>();

        Computer PC1 = new Computer(
            name: "ASUS",
            motherboard: new Component("Asus AK-47", 334.14, "mini form factor"),
            processor: new Component("i7 2345", 234.65, "64 cores"),
            graphicsCard: new Component("NVIDIA", 200.21, "G-Force"));

        Computer PC2 = new Computer(
            name: "GigaBUUUG",
            motherboard: new Component("Gigabyte AZ32", 144.12, "mini form factor"),
            processor: new Component("i5 2345", 134.98, "32 cores"),
            graphicsCard: new Component("AMD", 100.12, "Radeon"));

        Computer PC3 = new Computer(
            name: "Handmade",
            motherboard: new Component("Marmalad duno", 112.6),
            processor: new Component("i3 2200", 104.12),
            graphicsCard: new Component("NVIDIA", 80.88));

        computers.Add(PC1);
        computers.Add(PC2);
        computers.Add(PC3);

        computers = computers.OrderBy(x => x.Price).ToList();
        foreach (var computer in computers)
        {
            Console.WriteLine(computer);
        }

    }
}

