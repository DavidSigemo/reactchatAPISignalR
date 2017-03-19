using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using reactchatAPI.Models;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace reactchatAPI.App_Start
{
    [Authorize]
    [HubName("messageHub")]
    public class MessageHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        /// <summary>
        /// Broadcasts the chat message to all the clients
        /// </summary>
        /// <param name="chatItem"></param>
        public void SendMessage(string who, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("messageHub");
            context.Clients.All.pushNewMessage(who, message);
        }

        /// <summary>
        /// Broadcasts the user list to the clients
        /// </summary>
        public void SendUserList(List<String> userList)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("messageHub");
            context.Clients.All.pushUserList(userList);
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " joined.");
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }

        [HubMethodName("Test")]
        public void Test(string test)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("messageHub");

            //This runs the method Test in the React code for all clients
            context.Clients.All.Test(test);
        }

        [HubMethodName("TestChatServer")]
        public void TestChatServer(string test)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("messageHub");

            //This runs the method Test in the React code for all clients
            context.Clients.All.TestChatClient("ASDF: " + test);
        }

        [HubMethodName("TestMetod")]
        public void Con()
        {
            Test("Hej klient");
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}