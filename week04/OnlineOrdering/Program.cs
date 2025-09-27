using System;
using System.Collections.Generic;

/// <summary>
/// Online Ordering Program - Foundation #2: Encapsulation
/// CSE 210 - Week 04 Assignment
/// 
/// This program demonstrates encapsulation by creating Product, Customer, Address, and Order classes
/// to manage an online ordering system with proper information hiding.
/// </summary>
partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("======================\n");

        // Example usage (replace with your actual order logic)
        // Create some products
        Product product1 = new Product("Laptop", "P001", 1200.00, 1);
        Product product2 = new Product("Mouse", "P002", 25.00, 2);

        // Create an address
        Address address = new Address("123 Main St", "Apt 4B", "New York", "NY", "USA");

        // Create a customer
        Customer customer = new Customer("John Doe", address);

        // Create an order
        Order order = new Order(customer);
        order.AddProduct(product1);
        order.AddProduct(product2);

        int orderNumber = 1;

        Console.WriteLine($"ORDER #{orderNumber}");
        Console.WriteLine(new string('=', 50));

        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine(new string('-', 20));
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine(new string('-', 20));
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTOTAL COST: ${order.GetTotalCost():F2}");

        Console.WriteLine();
        Console.WriteLine(new string('*', 60));
        Console.WriteLine();

        Console.WriteLine("Order processing completed successfully!");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    public class Product
    {
        private string _name;
        private string _productId;
        private double _price;
        private int _quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public double GetTotalPrice()
        {
            return _price * _quantity;
        }

        public string GetPackingLabel()
        {
            return $"{_name} (ID: {_productId}) x{_quantity}";
        }
    }

    public class Address
    {
        private string _street;
        private string _apartment;
        private string _city;
        private string _state;
        private string _country;

        public Address(string street, string apartment, string city, string state, string country)
        {
            _street = street;
            _apartment = apartment;
            _city = city;
            _state = state;
            _country = country;
        }

        public string GetFullAddress()
        {
            return $"{_street}, {_apartment}, {_city}, {_state}, {_country}";
        }

        public bool IsUSA()
        {
            return _country.Trim().ToUpper() == "USA";
        }
    }

    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public Address GetAddress()
        {
            return _address;
        }
    }

    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;
            foreach (var product in _products)
            {
                total += product.GetTotalPrice();
            }
            // Add shipping cost
            if (_customer.GetAddress().IsUSA())
                total += 5;
            else
                total += 35;
            return total;
        }

        public string GetPackingLabel()
        {
            List<string> labels = new List<string>();
            foreach (var product in _products)
            {
                labels.Add(product.GetPackingLabel());
            }
            return string.Join("\n", labels);
        }

        public string GetShippingLabel()
        {
            return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
        }
    }
}