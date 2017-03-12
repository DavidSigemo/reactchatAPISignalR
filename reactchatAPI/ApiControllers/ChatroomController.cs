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
using reactchatAPI.ViewModels;

namespace reactchatAPI.ApiControllers
{
    public class ChatroomController : ApiController
    {
        private AzureDBConnection db = new AzureDBConnection();

        // GET: api/Chatroom
        public IQueryable<ChatroomViewModel> GetChatrooms()

        {
            var chatrooms = db.Chatrooms.Select(x => new ChatroomViewModel { Id = x.ChatroomId, RoomName = x.RoomName, Locked = x.Locked, Password = x.Password });
            return chatrooms;
        }

        // GET: api/Chatroom/5
        [ResponseType(typeof(ChatroomViewModel))]
        public async Task<IHttpActionResult> GetChatroom(int id)
        {
            Chatroom chatroom = await db.Chatrooms.FindAsync(id);
            if (chatroom == null)
            {
                return NotFound();
            }
            ChatroomViewModel chatroomViewModel = new ChatroomViewModel { Id = chatroom.ChatroomId, RoomName = chatroom.RoomName, Locked = chatroom.Locked, Password = chatroom.Password };
            return Ok(chatroomViewModel);
        }

        // PUT: api/Chatroom/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChatroom(int id, Chatroom chatroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatroom.ChatroomId)
            {
                return BadRequest();
            }

            db.Entry(chatroom).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatroomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Chatroom
        [ResponseType(typeof(Chatroom))]
        public async Task<IHttpActionResult> PostChatroom(Chatroom chatroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chatrooms.Add(chatroom);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chatroom.ChatroomId }, chatroom);
        }

        // DELETE: api/Chatroom/5
        [ResponseType(typeof(Chatroom))]
        public async Task<IHttpActionResult> DeleteChatroom(int id)
        {
            Chatroom chatroom = await db.Chatrooms.FindAsync(id);
            if (chatroom == null)
            {
                return NotFound();
            }

            db.Chatrooms.Remove(chatroom);
            await db.SaveChangesAsync();

            return Ok(chatroom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatroomExists(int id)
        {
            return db.Chatrooms.Count(e => e.ChatroomId == id) > 0;
        }
    }
}