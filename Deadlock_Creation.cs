using System;
using System.Threading;

class Deadlock_Creation
{
    // Shared account balances
    private static int accountA = 1000;
    private static int accountB = 1000;

    // Mutexes for protecting accounts
    private static Mutex mutexA = new Mutex();
    private static Mutex mutexB = new Mutex();

    // Function for transferring money from account A to account B
    private static void TransferAToB(object customerIdObj)
    {
        int customerId = (int)customerIdObj;
        Random rand = new Random();
        int amount = rand.Next(100);

        // Lock account A, then account B
        mutexA.WaitOne();
        mutexB.WaitOne();

        // Transfer money
        accountA -= amount;
        accountB += amount;
        Console.WriteLine($"Customer {customerId} transferred ${amount} from A to B. Balances: A=${accountA}, B=${accountB}");

        // Unlock accounts
        mutexB.ReleaseMutex();
        mutexA.ReleaseMutex();
    }

    // Function for transferring money from account B to account A
    private static void TransferBToA(object customerIdObj)
    {
        int customerId = (int)customerIdObj;
        Random rand = new Random();
        int amount = rand.Next(100);

        // Lock account B, then account A
        mutexB.WaitOne();
        mutexA.WaitOne();

        // Transfer money
        accountB -= amount;
        accountA += amount;
        Console.WriteLine($"Customer {customerId} transferred ${amount} from B to A. Balances: A=${accountA}, B=${accountB}");

        // Unlock accounts
        mutexA.ReleaseMutex();
        mutexB.ReleaseMutex();
    }

    static void Main(string[] args)
    {
        Thread[] threads = new Thread[10];
        Random rand = new Random();

        // Create 10 customer threads
        for (int i = 0; i < 10; i++)
        {
            if (rand.Next(2) == 0)
            {
                threads[i] = new Thread(TransferAToB);
            }
            else
            {
                threads[i] = new Thread(TransferBToA);
            }
            threads[i].Start(i);  // Pass customer ID as argument
        }

        // Wait for all threads to finish
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine($"All transactions completed. Final balances: A=${accountA}, B=${accountB}");
    }
}