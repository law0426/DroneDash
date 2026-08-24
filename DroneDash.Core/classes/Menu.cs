using System.Collections;

namespace DroneDash.Core.Classes.Menu;
using DroneDash.Core.Classes.Dash;

public class Menu()
{
    // HttpClient client;
    // string mainURL;
    public static async void Start(HttpClient client, string mainURL)
    {
        // client = newClient;
        // mainur
        bool running = true;
        while (running)
        {
            Console.WriteLine ("welcome to the main menu. Type 'exit' to exit the program at any time.");
            Console.WriteLine ("Select your options with the correct number:");
            Console.WriteLine ("1) Race Drones threaded!");
            Console.WriteLine ("2) Race Drones Asynced (Now extra broken!)");
            Console.WriteLine ("3) get drone");
            
            Console.WriteLine ("4) exit.");
            /*
            Console.WriteLine ("3) get drone");
            opens submenu where the names are returned, and you need to select with name?

            Console.WriteLine ("3) Add drone (Feature not yet added)");


            */

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
                    //call server? No, we can just race server side.
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
                    Console.WriteLine("Which part of feature not implemented do you not understand?");
                    //
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
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

    async Task GetDroneMenu(HttpClient client, string mainURL)
    {
        //Get Drones from the server.
        var content = new StringContent("Requesting drone names."); //create Content, which is a string.
        string command = "/";
        HttpResponseMessage response = await client.GetAsync( //Return a response. PostAsync to the address, with content.
            mainURL + command
        );

        string result = await response.Content.ReadAsStringAsync(); //The result is always just a string?
        Console.WriteLine(result);
        Console.WriteLine("press enter to return to main menu.");
        Console.ReadLine();
        //if readline matches...
        
    }

    // void Selector()
    // {
        
    // }

    
}


