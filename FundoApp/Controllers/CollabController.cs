using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace FundoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        private readonly ICollabBussiness collabBussiness;

        public CollabController(ICollabBussiness labelBussiness)
        {
            this.collabBussiness = collabBussiness;

        }
        [HttpPut("Add")]
        public IActionResult AddCollab(long noteId,  string email)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = collabBussiness.AddCollab(noteId,userId, email);
                if (result != null)
                {

                    return this.Ok(new { success = true, message = "AddCollabration is Successful" });
                }
                else
                {

                    return this.BadRequest(new { success = false, message = "Unable to AddCollabration" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Get")]
        public IActionResult GetAllCollab(string email)

        {
            try
            {
                long collablId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "CollabId").Value);
                var result = collabBussiness.GetAllCollab(email);
                if (result != null)
                {

                    return this.Ok(new { success = true, message = "Get collab Successfull" });
                }
                else
                {

                    return this.BadRequest(new { success = false, message = "Unable to get Collab" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteCollaborator(string email)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = collabBussiness.DeleteCollaborator(email);

                if (result != false)
                    return Ok(new { success = true, message = "Collab Deleted" });
                else
                    return BadRequest(new { success = false, message = "something went wrong" });
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
