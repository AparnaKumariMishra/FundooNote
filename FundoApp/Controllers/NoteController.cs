using System.Drawing;
using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;

namespace FundoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class NoteController : ControllerBase

    {
        private INoteBussiness NoteBussiness;
        private FundoContext fundoContext;
        private readonly ILogger<NoteController> _logger;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        
        private readonly INoteBussiness noteBussiness;
       
        public NoteController(INoteBussiness noteBussiness,FundoContext fundoContext,ILogger<NoteController>logger,IMemoryCache memoryCache,IDistributedCache distributedCache )
        {
            this.noteBussiness = noteBussiness;
            this.fundoContext = fundoContext;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this._logger = logger;
            _logger.LogDebug(1, "NLog injected into NoteController");
           
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult AddNote(NoteModel noteModel)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.AddNote(noteModel, userID);

                if (result != null)
                    return Ok(new { success = true, message = "Note Added", data = result });
                else
                    return BadRequest(new { success = false, message = "something went wrong" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("Get")]
       // [Route("Get")]
        public IActionResult GetNote()

        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.GetAllNote(userId);
                if (result != null)
                {
                   
                    return this.Ok(new { success = true, message = "Get user Notes Successfully" });
                }
                else
                {
                   
                    return this.BadRequest(new { success = false, message = "Unable to get note" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Update")]
       // [Route("Update")]
        public IActionResult UpdateNote()

        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.GetAllNote(userId);
                if (result != null)
                {
                   
                    return this.Ok(new { success = true, message = " user Notes Updated Successfully" });
                }
                else
                {
                   
                    return this.BadRequest(new { success = false, message = "Unable to Update note" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.DeleteNote(userID, noteId);

                if (result != false)
                    return Ok(new { success = true, message = "Note Deleted" });
                else
                    return BadRequest(new { success = false, message = "something went wrong" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("pin")]
        public IActionResult IsPinNote(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.IsPinNote(noteId);

                if (result != false)
                    return Ok(new { success = true, message = "Pin" });
                else
                    return BadRequest(new { success = false, message = "Unpin" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Archive")]
        public IActionResult IsArchive(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.IsArchive(noteId);

                if (result != false)
                    return Ok(new { success = true, message = "Archive" });
                else
                    return BadRequest(new { success = false, message = "UnArchive" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Trash")]
        public IActionResult Istrash(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.Istrash(noteId);

                if (result != false)
                    return Ok(new { success = true, message = "Trash" });
                else
                    return BadRequest(new { success = false, message = "UnTrash" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Updatecolor")]
        public IActionResult Updatecolor(long noteId, string color)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.Updatecolor(noteId,color);

                if (result != null)
                    return Ok(new { success = true, message = "Updated color" });
                else
                    return BadRequest(new { success = false, message = "Unable to update color" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("RemoveTrashForever")]
        public IActionResult RemoveTrashForever(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.RemoveTrashForever(noteId);

                if (result != true)
                    return Ok(new { success = true, message = "RemoveTrashForever" });
                else
                    return BadRequest(new { success = false, message = "Unable to RemoveTrashForever" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("DisplayNotes")]
        public IActionResult DisplayNotes(long userId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.DisplayNotes(userId);

                if (result != null)
                    return Ok(new { success = true, message = "Displying Notes" });
                else
                    return BadRequest(new { success = false, message = "Unable to display Note" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("DisplayIsTrash")]
        public IActionResult DisplayIsTrash(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.DisplayIsTrash(noteId);

                if (result != null)
                    return Ok(new { success = true, message = "Displying in Trash" });
                else
                    return BadRequest(new { success = false, message = "Unable to display in Trash " });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut(" Reminder")]
        public IActionResult Reminder(long noteId, DateTime reminder)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = noteBussiness.Reminder(noteId,reminder);

                if (result != null)
                    return Ok(new { success = true, message = "Displying Reminder" });
                else
                    return BadRequest(new { success = false, message = "Unable to display Reminder " });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
