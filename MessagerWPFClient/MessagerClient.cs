using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagerWPFClient
{
    public class MessagerClient
    {
        public HubConnection HubConnection { get; set; }

        public MessagerClient(string URL)
        {
            HubConnection = new HubConnectionBuilder().WithUrl(URL).WithAutomaticReconnect().Build();
        }

        public async Task Send(string message)
        {
            await HubConnection.SendAsync(ActionName.GroupMessage.ToString(), message);
        }

        public async Task ReceiveHandler()
        {
            HubConnection.On<string>(ActionName.Send.ToString(), m => Console.WriteLine(m));
        }
    }
}