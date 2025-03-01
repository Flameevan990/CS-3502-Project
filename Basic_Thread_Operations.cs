using System;
using System.Threading;

class Basic_Thread_Operations
{
    // Shared account balance
    private static int accountBalance = 1000;

    // Function for customer transactions
    private static void CustomerTransaction(object customerIdObj)
    {
        int customerId = (int)customerIdObj;
        Random rand = new Random();
        int amount = rand.Next(100);  // Random transaction amount between 0 and 99

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