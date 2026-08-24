using System.ComponentModel.Design;
using DroneDash.Core.Classes.Menu;
using DroneDash.Core.Classes.Server;
using DroneDash.Core.Classes.WebServer;



Console.WriteLine("Hello, World!");

// using var server = new SimpleHttpServer();

// var response = await client.GetStringAsync("http://localhost:9001/MyFirstServer/hello-world.txt");

// Console.WriteLine(response);

int gateWay = 8080;
string mainURL = $"http://localhost:{gateWay}/";
HttpClient client = new HttpClient(); //establish client.

Task main = WebServer.Run(gateWay);

await main;

//Now takes main URL as argument and uses it to communicate. Also takes webserver? can we double await?
//FML.
Menu.Start(client, mainURL);


//Dash.CountTwoThreads();
// Dash.ThreadRace();
//Menu.Start();
