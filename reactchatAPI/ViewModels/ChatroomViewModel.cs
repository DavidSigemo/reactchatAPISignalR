using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using reactchatAPI.Models;

namespace reactchatAPI.ViewModels
{
    public class ChatroomViewModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public bool Locked { get; set; }
        public string Password { get; set; }
    }
}