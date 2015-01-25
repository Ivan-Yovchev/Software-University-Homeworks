using System;

class Laptop
{
    private string model;
    private string manufacturer;
    private string processor;
    private string ram;
    private string graphicsCard;
    private string hdd;
    private string screen;
    private Battery battery;
    private string batteryLife;
    private string price;

    public Laptop (string model, string manufacturer, string processor, string ram, string graphicsCard,
        string hdd, string screen, Battery battery, string batteryLife, string price)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.RAM = ram;
        this.GraphicsCard = graphicsCard;
        this.hdd = HDD;
        this.Screen = screen;
        this.Battery = battery;
        this.BatteryLife = batteryLife;
        this.Price = price;
    }

    public Laptop (string model, string manufacturer, string processor, string ram, string graphicsCard,
        string hdd, string screen, Battery battery, string price)
        : this(model, manufacturer, processor, ram, graphicsCard, hdd, screen, battery, null, price)
    {
    }

    public Laptop(string model, string manufacturer, string processor, string ram, string graphicsCard,
        string hdd, string screen, string price)
        : this(model, manufacturer, processor, ram, graphicsCard, hdd, screen, null, null, price)
    {
    }

    public Laptop(string model, string manufacturer, string processor, string ram, string graphicsCard,
        string hdd, string price)
        : this(model, manufacturer, processor, ram, graphicsCard, hdd, null, null, null, price)
    {
    }

    public Laptop(string model, string manufacturer, string processor, string ram, string graphicsCard,
        string price)
        : this(model, manufacturer, processor, ram, graphicsCard, null, null, null, null, price)
    {
    }

    public Laptop(string model, string manufacturer, string processor, string ram, string price)
        : this(model, manufacturer, processor, ram, null, null, null, null, null, price)
    {
    }

    public Laptop(string model, string manufacturer, string processor, string price)
        : this(model, manufacturer, processor, null, null, null, null, null, null, price)
    {
    }

    public Laptop(string model, string manufacturer, string price)
        : this(model, manufacturer, null, null, null, null, null, null, null, price)
    {
    }

    public Laptop(string model, string price)
        : this(model, null, null, null, null, null, null, null, null, price)
    {
    }

    public string Model
    {
        get { return this.model; }
        set 
        {
            if (value == "")
            {
                throw new Exception("The model cannot be empty");
            }
            this.model = value; 
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (value == "")
            {
                throw new Exception("The manufacturer cannot be empty");
            }
            this.manufacturer = value;
        }
    }

    public string Processor
    {
        get { return this.processor; }
        set
        {
            if (value == "")
            {
                throw new Exception("The processor cannot be empty");
            }
            this.processor = value;
        }
    }

    public string RAM
    {
        get { return this.ram; }
        set
        {
            if (value == "")
            {
                throw new Exception("The RAM cannot be empty");
            }
            this.ram = value;
        }
    }

    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set
        {
            if (value == "")
            {
                throw new Exception("The Graphics Card cannot be empty");
            }
            this.graphicsCard = value;
        }
    }

    public string HDD
    {
        get { return this.hdd; }
        set
        {
            if (value == "")
            {
                throw new Exception("The HDD cannot be empty");
            }
            this.hdd = value;
        }
    }

    public string Screen
    {
        get { return this.screen; }
        set
        {
            if (value == "")
            {
                throw new Exception("The Screen cannot be empty");
            }
            this.screen = value;
        }
    }

    public Battery Battery
    {
        get { return this.battery; }
        set { this.battery = value; }
    }

    public string BatteryLife
    {
        get { return this.batteryLife; }
        set 
        {
            if (value == "")
            {
                throw new Exception("The Battery Life cannot be empty");
            }
            this.batteryLife = value; 
        }
    }

    public string Price
    {
        get { return this.price; }
        set
        {
            if (value == "")
            {
                throw new Exception("The Price cannot be empty");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        string result = "Model: " + this.model;
        if (this.manufacturer != null)
        {
            result += "\nManufacturer: " + this.manufacturer;
        }
        if (this.processor != null)
        {
            result += "\nProcessor: " + this.processor;
        }
        if (this.ram != null)
        {
            result += "\nRAM: " + this.ram;
        }
        if (this.graphicsCard != null)
        {
            result += "\nGraphics Card: " + this.graphicsCard;
        }
        if (this.hdd != null)
        {
            result += "\nHDD: " + this.hdd;
        }
        if (this.screen != null)
        {
            result += "\nScreen: " + this.screen;
        }
        if (this.battery != null)
        {
            result += "\nBattery: " + this.battery;
        }
        if (this.batteryLife != null)
        {
            result += "\nBAttery Life: " + this.batteryLife;
        }

        result += "\nPrice: " + this.price;

        return result;
    }

}

class Battery
{
    private string type;
    private string cells;
    private string amps;

    public Battery (string type, string cells, string amps)
    {
        this.Amps = amps;
        this.Cells = cells;
        this.Type = type;
    }

    public Battery (string type, string cells) 
        : this (type, cells, null)
    {
    }

    public Battery(string type)
        : this(type, null, null)
    {
    }

    public string Type 
    {
        get { return this.type; } 
        set 
        {
            if (value == "")
            {
                throw new Exception("Type must not be empty");
            }
            this.type = value;
        } 
    }

    public string Cells
    {
        get { return this.cells; }
        set
        {
            if (value == "")
            {
                throw new Exception("Cells must not be empty");
            }
            this.cells = value;
        }
    }

    public string Amps
    {
        get { return this.amps; }
        set
        {
            if (value == "")
            {
                throw new Exception("Amps must not be empty");
            }
            this.amps = value;
        }
    }

    public override string ToString()
    {
        string result = this.type;
        if(this.cells != null)
        {
            result += ", " + this.cells;
        }
        if (this.amps != null)
        {
            result += ", " + this.amps;
        }

        return result;

    }

}

class LaptopShop
{
    static void Main(string[] args)
    {
        Laptop notFullLaptop = new Laptop("HP 250 G2", "699.00 lv.");
        Console.WriteLine(notFullLaptop);

        Console.WriteLine();

        Laptop fullLaptop = new Laptop("Lenovo Yoga 2 Pro", "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
            "8 GB", "Intel HD Graphics 4400", "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
            new Battery("Li-lon", "4-cells", "2550 mAh"), "4.5 hours", "2259.00 lv");
        Console.WriteLine(fullLaptop);
    }
}
