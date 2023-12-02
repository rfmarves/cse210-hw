using System;

class Program
{
    static void Main(string[] args)
    {
        // Load product master list
        ProductList masterProducts = new ProductList();
        masterProducts.LoadFromFile("products.txt");
        // masterProducts.Print();

        //Load customer master list
        CustomerList masterCustomers = new CustomerList();
        masterCustomers.LoadFromFile("customers.txt");
        // masterCustomers.Print();

        // Load orders from file
        string ordersFile = "orders.txt";
        List<Order> orders = new List<Order>();
        using StreamReader sr = new StreamReader(ordersFile);
        while (sr.Peek() >= 0)
        {
            string line = sr.ReadLine();
            string[] parts = line.Split("|");
            // Creates a base order based on the custoer id in file and master customer list
            Order newOrder = new Order(masterCustomers.CustomerByID(parts[0]));
            // iterate over the other items in the list, adding products with quantities
            for (int i = 1; i < parts.Length; i++)
            {
                string[] subparts = parts[i].Split(",");
                newOrder.AddProduct(masterProducts.ProductByID(subparts[0]),float.Parse(subparts[1]));
            }
            orders.Add(newOrder);
        }

        // Menu function
        static int  Menu()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4", "5" };
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");
                Console.WriteLine(" 1. Display ALL Packing Labels");
                Console.WriteLine(" 2. Display ALL Shipping Labels");
                Console.WriteLine(" 3. Display ALL Shipping labels with packing labels");
                Console.WriteLine(" 4. Display ONE Shipping and packing label");
                Console.WriteLine(" 5. Quit");               
                choice = Console.ReadLine();
                Console.WriteLine();
            }
            return int.Parse(choice);
        }

        static void ItemBreak()
        {
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
        }
        // Runs main program options
        int selectedItem = 0;
        while (selectedItem != 5)
        {
            selectedItem = Menu();
            if (selectedItem == 1)
            {
                foreach (Order o in orders)
                {
                    Console.WriteLine(o.PackingLabel());
                    ItemBreak();
                }
            } else if (selectedItem == 2)
            {
                foreach (Order o in orders)
                {
                    Console.WriteLine(o.ShippingLabel());
                    ItemBreak();
                }
            } else if (selectedItem == 3)
            {
                foreach (Order o in orders)
                {
                    Console.WriteLine(o.ShippingLabel());
                    Console.WriteLine();
                    Console.WriteLine(o.PackingLabel());
                    ItemBreak();
                }
            } else if (selectedItem == 4)
            {
                Console.WriteLine("Select order to display:");
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"{String.Format("{0,3}",i+1)}. {orders[i].ShortDescription()}");
                }
                Console.Write("Item number: ");
                Boolean inputSuccess = int.TryParse(Console.ReadLine(), out int orderIndex);
                if (!inputSuccess)
                    {Console.WriteLine("Invalid number.");}
                else
                {
                    Console.WriteLine(orders[orderIndex-1].ShippingLabel());
                    ItemBreak();
                    Console.WriteLine(orders[orderIndex-1].PackingLabel());
                    ItemBreak();
                }

            }
        }

    }
}