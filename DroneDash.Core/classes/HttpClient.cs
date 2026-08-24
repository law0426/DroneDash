using System.Net.Http;



HttpClient client = new HttpClient(); //establish client.

var content = new StringContent("Hello from client"); //create Content, which is a string.

HttpResponseMessage response = await client.PostAsync( //Return a response. PostAsync to the address, with content.
    "http://localhost:8080/hello",
    content
);

string result = await response.Content.ReadAsStringAsync(); //The result is always just a string?


Console.WriteLine(result);

// I need to segment this logic into separate methods that can be called by the console.

//Where should the client live? Probably in the main program?
//So then we receive the client as data?
//I don't think a separate class is necessary for this after all.

//Lets start at the end.



