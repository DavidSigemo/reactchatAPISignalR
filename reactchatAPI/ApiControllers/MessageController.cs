using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using reactchatAPI.Models;
using reactchatAPI.App_Start;

namespace reactchatAPI.ApiControllers
{
    public class MessageController : ApiController
    {
        private MessageManager _manager;
        private MessageHub _chatHub;

        public MessageController(MessageManager chatManager)
        {
            _manager = chatManager;
            _chatHub = new MessageHub();
        }

        // GET api/<controller>
        public String GetNewUserId(String userName)
        {
            _manager.AddUser(userName);

            //broadcast the user list to all the clients
            _chatHub.SendUserList(_manager.GetAllUsers());
            return Guid.NewGuid().ToString();
        }

        // GET api/<controller>/5
        public Dictionary<string, string> Get()
        {
            return _manager.GetAllChat();
        }

        // POST api/<controller>
        public void PostChat(string who, string message)
        {
            who = Guid.NewGuid().ToString();           
            _manager.AddChat(who, message);

            //broadcast the chat to all the clients
            _chatHub.SendMessage(who, message);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}