using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ConsoleSignalRClient
{
    public class MessageClient
    {
        private HubConnection _connection;
        private HubConnectionBuilder _connectionBuilder;
        private bool isCompleted = false;

        public void CreateConncetion()
        {
            _connectionBuilder = new HubConnectionBuilder();
            _connection = _connectionBuilder.WithUrl("http://localhost:5000/messageHub").WithAutomaticReconnect().Build();

            if(_connection.State == HubConnectionState.Disconnected)
            {
                _connection.On<string>("ReceiveMessage", (string messageContent) => 
                {
                    Console.WriteLine(messageContent);
                    isCompleted = true;
                });

                _connection.StartAsync().GetAwaiter().GetResult();

                while(!isCompleted)
                {
                    Task.Delay(10).GetAwaiter().GetResult();
                }
            }
        }
    }
}
