namespace DroneDash.Core.Classes.WebServer;

using System.Net;
using System.Net.Sockets;
using System.Text;

public class WebServer{
    //En webserver er ikke magi. Den er en socket som lytter på en port,
    //leser tekst fra en TCP-forbindelse, og skriver tekst tilbake.
    //Alt ASP.NET Core gjør, er dette pluss veldig mange lag med bekvemmelighet.
    //
    //To lag er i sving her, og det er verdt å holde dem fra hverandre:
    //      TCP  -> transporten. Sørger for at bytes kommer frem, i riktig rekkefølge.
    //              TCP vet ingenting om "GET" eller "200 OK", det er bare en byte-strøm.
    //      HTTP -> avtalen om hva bytene BETYR. Ren tekst, med et fast format
    //              vi begge har blitt enige om på forhånd.

    //TcpListener er "resepsjonisten". Den tar imot innkommende forbindelser på en port.
    //IPAddress.Any betyr "lytt på alle nettverkskortene på maskinen", ikke bare localhost.
    //Vil du kun slippe til trafikk fra din egen maskin, bruker du IPAddress.Loopback.
    public static async Task Run()
    {
        var listener = new TcpListener(IPAddress.Any, 8080);
        listener.Start();
        Console.WriteLine("Listening on localhost:8080");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _= HandleClient(client);
        }

        static async Task HandleClient(TcpClient client)
        {
            using (client)

            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[1024];

                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine(request);

                string requestLine = request.Split("\r\n")[0];
                string [] parts = request.Split("\r\n");

                string method = requestLine.Split(" ")[0];
                string rawUrl = requestLine.Split(" ")[1];

                // string response = method == "GET"
                //     ? BuildResponse("200 OK", "Hello from my dumb webserver!")
                //     : BuildResponse("405 Method Not Allowed", "Get the heck away!");
                string response;

                if (method == "GET" && rawUrl == "/hello")
                {
                    response = BuildResponse("200 OK", "Hello!");
                }
                else if (method == "GET" && rawUrl == "/goodbye")
                {
                    response = BuildResponse("200 OK", "Goodbye!");
                }
                else
                {
                    response = BuildResponse("404 Not Found", "Endpoint not found");
                }

                ///route?drone=Navn => (antall checkpoints, basert på dronenavn)
                //weather. => clear, wind, storm, der storm øker DelayMs
                ///register?drone=name&checkpoints&delay
                //what's the syntax for the above? post? 
                //Race?



                //Variable response time?
                Random random = new();
                int min = 0;
                int max = 10000;
                int responseTime = random.Next(min,max);
                await Task.Delay(responseTime); 
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes, 0, responseBytes.Length);

            }
        }

    }
    //This just displays the information / response.
    static string BuildResponse(string status, string body) => $"""
    HTTP/1.1 {status}
    Content-Type: text/plain
    Content-Length: {body.Length}
    Connection: close

    {body}
    """;
}

