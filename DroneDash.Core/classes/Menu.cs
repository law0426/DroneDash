using System.Collections;

namespace DroneDash.Core.Classes.Menu;
using DroneDash.Core.Classes.Dash;

public class Menu()
{
    public static async void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine ("welcome to the main menu. Type 'exit' to exit the program at any time.");
            Console.WriteLine ("Select your options with the correct number:");
            Console.WriteLine ("1) Race Drones threaded!");
            Console.WriteLine ("2) Race Drones Asynced (Now extra broken!)");
            Console.WriteLine ("3) Add drone (Feature not yet added)");
            Console.WriteLine ("4) exit.");
            //Play drone dash.
            //insert values?
            //Randomize values?
            //Betting game?
            //exit.
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Dash.ThreadRace();
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    try
                    {
                        await Dash.AsyncOrchestration();
                    }
                    catch
                    {
                        Console.WriteLine("WHOOPS?");
                    }
                    //TODO: Make this return an error message, but not break the program?
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Which part of feature not implemented do you not uderstand?");
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Now shutting down. Press enter to exit.");
                    Console.ReadLine();
                    break;
                case "exit":
                    running = false;
                    Console.WriteLine("Now shutting down. Press enter to exit.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid input. press enter to return to main menu.");
                    Console.ReadLine();
                    break;
            }
                
        }

    }

    // void Selector()
    // {
        
    // }

    
}


