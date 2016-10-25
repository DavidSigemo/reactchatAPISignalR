using ReactChat.Models;
using reactchatAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reactchatAPI.App_Start
{
    public class MessageManager
    {
        private ChatStore _chatStore;
        public MessageManager(ChatStore chatStore)
        {
            _chatStore = chatStore;
        }

        public void AddChat(string who,string message)
        {
            _chatStore.ChatList.Add(who, message);
        }

        public void AddUser(String userName)
        {
            _chatStore.UserList.Add(userName);
        }

        public List<String> GetAllUsers()
        {
            return _chatStore.UserList;
        }

        public Dictionary<string, string> GetAllChat()
        {
            return _chatStore.ChatList;
        }
    }
}