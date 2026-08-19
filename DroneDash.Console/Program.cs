using DroneDash.Core.Classes.Dash;

Console.WriteLine("Hello, World!");





//Dash.CountTwoThreads();
// Dash.ThreadRace();
try
{
    await Dash.AsyncOrchestration();
}
catch
{
    Console.WriteLine("WHOOPS?");
}