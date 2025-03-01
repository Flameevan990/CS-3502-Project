using System;
using System.Threading;

class Resource_Protection
{
    // Shared account balance
    private static int accountBalance = 1000;

    // Mutex for protecting accountBalance
    private static Mutex mutex = new Mutex();

    // Function for customer transactions
    private static void CustomerTransaction(object customerIdObj)
    {
        int customerId = (int)customerIdObj;
        Random rand = new Random();
        int amount = rand.Next(100);  // Random transaction amount between 0 and 99

        // Lock the mutex before accessing the shared resource
        mutex.WaitOne();

        // Simulate a deposit or withdrawal
        if (rand.Next(2) == 0)
        {
            accountBalance += amount;  // Deposit
            Console.WriteLine($"Customer {customerId} deposited ${amount}. New balance: ${accountBalance}");
        }
        else
        {
            accountBalance -= amount;  // Withdrawal
            Console.WriteLine($"Customer {customerId} withdrew ${amount}. New balance: ${accountBalance}");
        }

        // Unlock the mutex after accessing the shared resource
        mutex.ReleaseMutex();
    }

    static void Main(string[] args)
    {
        Thread[] threads = new Thread[10];

        // Create 10 customer threads
        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(CustomerTransaction);
            threads[i].Start(i);  // Pass customer ID as argument
        }

        // Wait for all threads to finish
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine($"All transactions completed. Final balance: ${accountBalance}");
    }
}
