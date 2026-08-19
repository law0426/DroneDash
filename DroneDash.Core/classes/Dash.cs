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

    public static void ThreadRace()
    {
        //I could set up a method to set up multiple drones and threads with random values. 
        //But that's not the point of the test.

        //Entrants take the field.
        var drone1 = new DroneModel("SeaBiscuit", 5, 300);
        
        DroneModel drone2 = new ("Equinox", 3, 500);
        //DroneModel[] droneModels = [drone1,drone2];
        //The referees get ready:
        //so threads don't like non-object arguments?
        //Since I'm not using object? as the argument type.
        //I'm using lambda expression instead:
        Thread track1 = new (() => SendDrone(drone1));
        Thread track2 = new (() => SendDrone(drone2));
        //And GO!
        Console.WriteLine("The drones are ready at the starting line!");
        track1.Start();
        track2.Start();

        track1.Join();
        track2.Join();

        Console.WriteLine("Both drones have finished their race!");
        //Readline?

        //MAKE A VERSION WITHOUT JOIN?
        //5) Noter klumpete/ikke-deterministisk utskrift og hva det sier om delte ressurser (Console).
    }

    // -  its weird to take a flexible object only to immediatle assume it's a specific one.
    // I knew it! It's because the thread variable won't accept the function otherwise!

    private static void SendDrone(DroneModel drone)
    {
        Console.WriteLine($"And {drone.Name} is off to the races!");
        //Ok, so this function just gets sent to a thread, but otherwise just behaves like a funksjon would?
        //It does contain thread behavior, though.
        //I could set up an actual stopwatch for fun?
        int timePassed = 0;
        for (int i = 0; i < drone.MaxCheckpoints; i++)
        {
            Thread.Sleep(drone.DelayMs);
            timePassed += drone.DelayMs;
            Console.WriteLine($"{drone.Name} has just passed checkpoint {i+1} after {timePassed} ms!");
        }
        Console.WriteLine($"{drone.Name}Has finished the race after {timePassed}!");
    }

    public async static Task AsyncOrchestration()
    {
        //Achieve the same results using tasks instead.
        //Meaning use async/await
        //Await task.delay. for every step
        //Do I even know how to set up a task? Nope. Back to the video.

        //I would like to just hold the function, but it's so fidgety.
        DroneModel drone1 = new("SeaBiscuit", 5, -333);
        Task? task1 = null;
        try
        {
            task1 = Task.Run(()=> AsyncSendDrone(drone1));
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex);//Shouldn't this still write?
        }
        
        DroneModel drone2 = new ("Equinox", 3, 500);
        Task task2 = Task.Run(()=> AsyncSendDrone(drone2));

        // await task1;
        // await task2;
        await Task.WhenAll(task1, task2);

        Console.WriteLine("Both drones have finished their ASYNC race!");

    }

    private async static Task AsyncSendDrone(DroneModel drone)
    {
        if(drone.DelayMs <0 ) throw new ArgumentOutOfRangeException($"DelayMS cannot be negative: {drone.DelayMs}");

        Console.WriteLine($"And {drone.Name} is off to the races!");
        int timePassed = 0;
        for (int i = 0; i < drone.MaxCheckpoints; i++)
        {
            // Kept for posterity:
            // try
            // {
            //     await Task.Delay(drone.DelayMs);
            // }
            // catch (ArgumentOutOfRangeException)
            // {
            //     Console.WriteLine($"DelayMS set to inappropriate value: {drone.DelayMs}");
            // }
            
            await Task.Delay(drone.DelayMs);

            timePassed += drone.DelayMs;
            Console.WriteLine($"{drone.Name} has just passed checkpoint {i+1} after {timePassed} ms!");
        }
        Console.WriteLine($"{drone.Name}Has finished the race after {timePassed}!");
    }

}







public class DroneModel(string name, int maxCheckpoints, int delay)
{
    public string Name { get; set; } = name;
    public int MaxCheckpoints { get; set; } = maxCheckpoints;
    public int DelayMs { get; set; } = delay;
}