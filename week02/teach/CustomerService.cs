/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a CustomerService queue with a max size of 0, which means the default value is 10.
        // Expected Result: 10
        Console.WriteLine("Test 1");
        CustomerService cs = new CustomerService(0);
        Console.WriteLine(cs.GetMaxSize());

        // Defect(s) Found: No defects found.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create a CustomerService queue with a max size of 5, and add one customer to the queue.
        // Expected Result: [size=1 max_size=5 => Diego (123)  : Dunno]
        Console.WriteLine("Test 2");
        CustomerService cs2 = new CustomerService(5);
        cs2.AddNewCustomer();
        Console.WriteLine(cs2.ToString());

        // Defect(s) Found: No defects found.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Create a CustomerService queue with a max size of 1, and add two customers to the queue.
        // Expected Result: Maximum Number of Customers in Queue.
        Console.WriteLine("Test 3");
        CustomerService cs3 = new CustomerService(1);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();

        // Defect(s) Found: The AddNewCustomer method did not take into account if the size of the queue was already at the max size. After corrections have been made, the tests are successful.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Create a CustomerService queue with a max size of 5, add one customer to the queue, and then serve the customer.
        // Expected Result: Diego (123)  : Dunno
        Console.WriteLine("Test 4");
        CustomerService cs4 = new CustomerService(5);
        cs4.AddNewCustomer();
        cs4.ServeCustomer();

        // Defect(s) Found: The serve customer method did not take into account if the queue was empty and the deletion of the customer it was not in the correct order. After corrections have been made, the tests are successful.

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a CustomerService queue with a max size of 5, and try to server a customer from an empty queue.
        // Expected Result: No customers in the queue.
        Console.WriteLine("Test 5");
        CustomerService cs5 = new CustomerService(5);
        cs5.ServeCustomer();

        // Defect(s) Found: The message was not being displayed when the queue was empty.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count != 0)
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("No customers in the queue.");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }

    public int GetMaxSize()
    {
        return _maxSize;
    }
}