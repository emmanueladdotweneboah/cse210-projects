using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - USA customer
        Address address1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Keyboard", "KB101", 30.0, 1));
        order1.AddProduct(new Product("Mouse", "MS202", 15.0, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        // Order 2 - International customer
        Address address2 = new Address("456 Pine Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Alice Chen", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "MN303", 120.0, 1));
        order2.AddProduct(new Product("HDMI Cable", "HD404", 10.0, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}
