﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using reactchatAPI.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace reactchatAPI.App_Start
{
    [HubName("messageHub")]
    public class MessageHub : Hub
    {
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

        [HubMethodName("Test")]
        public void Test(string test)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext("messageHub");
            context.Clients.All.Test(test);
        }

        [HubMethodName("TestMetod")]
        public void Con()
        {
            Test("Hej klient");
        }
    }
}