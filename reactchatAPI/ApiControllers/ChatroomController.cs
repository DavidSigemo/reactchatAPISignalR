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

namespace reactchatAPI.ApiControllers
{
    public class ChatroomController : ApiController
    {
        private AzureDBConnection db = new AzureDBConnection();

        // GET: api/Chatroom
        public IQueryable<Chatroom> GetChatrooms()
        {
            return db.Chatrooms;
        }

        // GET: api/Chatroom/5
        [ResponseType(typeof(Chatroom))]
        public async Task<IHttpActionResult> GetChatroom(int id)
        {
            Chatroom chatroom = await db.Chatrooms.FindAsync(id);
            if (chatroom == null)
            {
                return NotFound();
            }

            return Ok(chatroom);
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