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
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public string Password { get; set; }
    }
}