using System.ComponentModel.Design;
using DroneDash.Core.Classes.Menu;
using DroneDash.Core.Classes.Server;
using DroneDash.Core.Classes.WebServer;



Console.WriteLine("Hello, World!");

// using var server = new SimpleHttpServer();

// var response = await client.GetStringAsync("http://localhost:9001/MyFirstServer/hello-world.txt");

// Console.WriteLine(response);

Task main = WebServer.Run();

await main;



//Dash.CountTwoThreads();
// Dash.ThreadRace();
//Menu.Start();
