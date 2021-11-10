using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(3000);
            //Set connection
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:44329/testHub"))
                .WithAutomaticReconnect(new RandomRetryPolicy())
                .Build();
            //Make proxy to hub based on hub name on server
            
            await connection.StartAsync();
            Console.WriteLine($"Connection Started");

            //Start connection
            connection.On<string, string>("SendMessage",
            (string message1, string message2) =>
            {
                Console.WriteLine($"Message received: {message1}, {message2}");
            });
            Console.ReadKey();
        }
    }
    public class RandomRetryPolicy : IRetryPolicy
    {
        private readonly Random _random = new Random();

        public TimeSpan? NextRetryDelay(RetryContext retryContext)
        {
            // If we've been reconnecting for less than 60 seconds so far,
            // wait between 0 and 10 seconds before the next reconnect attempt.
            if (retryContext.ElapsedTime < TimeSpan.FromSeconds(60))
            {
                return TimeSpan.FromSeconds(_random.NextDouble() * 10);
            }
            else
            {
                // If we've been reconnecting for more than 60 seconds so far, stop reconnecting.
                return null;
            }
        }
    }
}
