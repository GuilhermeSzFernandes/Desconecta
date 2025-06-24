using Microsoft.AspNetCore.SignalR.Client;
const string url = "http://localhost:5281/controle";

await using var connection = new HubConnectionBuilder().WithUrl(url).Build();
await connection.StartAsync();

Console.WriteLine("Hello, World!");


await foreach (var status in connection.StreamAsync<bool>("Streaming"))
{
    Console.WriteLine(status);
}
;