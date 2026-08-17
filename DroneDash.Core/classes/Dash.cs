namespace DroneDash.Core.Classes.Dash;


// // Oppretter en ny thread med en metode den skal kjøre
// var newThread = new Thread(WriteNewThread);
// newThread.Start();

// // Main thread fortsetter å kjøre uavhengig
// for (int i = 0; i < 1000; i++) Console.WriteLine(i);

// // Metode som kjøres på den nye threaden
// static void WriteNewThread()
// {
//     for (int i = 1000; i > 0; i--) Console.WriteLine(i);
// }

public class Dash{

    public static void CountTwoThreads()
    {
        Console.WriteLine("Counting with regular Threads...");

        // Setter opp første counter og thread
        var counter1 = new DroneModel("Counter 1", 5, 250);
        var thread1 = new Thread(ThreadCounter);
        thread1.Start(counter1);

        // Setter opp andre counter og thread
        var counter2 = new DroneModel("Counter 2", 3, 500);
        var thread2 = new Thread(ThreadCounter);
        thread2.Start(counter2);

        // Main thread blokkeres her til begge threadene er ferdige
        thread1.Join();
        thread2.Join();

        Console.WriteLine("Both Threads have finished operating!");
    }

    private static void ThreadCounter(object? state)
    {
        var counter = (DroneModel)state!;
        Console.WriteLine($"Thread {counter.Name}: Started...");

        for (int i = 0; i <= counter.MaxCheckpoints; i++)
        {
            Thread.Sleep(counter.DelayMs); // Simulerer arbeid
            Console.WriteLine($"{counter.Name} has counted {i} of {counter.MaxCheckpoints}...");
        }

        Console.WriteLine($"Thread {counter.Name}: Finished");
    }

}







public class DroneModel(string name, int maxCount, int delay)
{
    public string Name { get; set; } = name;
    public int MaxCheckpoints { get; set; } = maxCount;
    public int DelayMs { get; set; } = delay;
}