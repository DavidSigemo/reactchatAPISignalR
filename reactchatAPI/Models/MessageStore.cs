using reactchatAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactChat.Models
{
    public class ChatStore
    {
        public Dictionary<string, string> ChatList { get; set; }
        public List<String> UserList { get; set; }

        public ChatStore()
        {
            ChatList = new Dictionary<string, string>();
            UserList = new List<String>();
        }
    }
}