using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace FundoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LabelController:ControllerBase
    {
        private readonly ILabelBussiness labelBussiness;

        public LabelController(ILabelBussiness labelBussiness)
        {
            this.labelBussiness = labelBussiness;

        }

        [HttpPut("Add")]
         //[Route("Add")]
        public IActionResult AddLabel(string labelName,long noteId)

        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBussiness.AddLabel(labelName,noteId,userId);
                if (result != null)
                {

                    return this.Ok(new { success = true, message = "AddLabel is Successful" });
                }
                else
                {

                    return this.BadRequest(new { success = false, message = "Unable to AddLabel" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("Get")]
        // [Route("Get")]
        public IActionResult GetAllLabel()

        {
            try
            {
                long labelId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "LabelId").Value);
                var result = labelBussiness.GetAllLabel(labelId);
                if (result != null)
                {

                    return this.Ok(new { success = true, message = "Get user Label Successfully" });
                }
                else
                {

                    return this.BadRequest(new { success = false, message = "Unable to get Label" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeletLabel(long noteId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBussiness.DeleteLabel(userID, noteId);

                if (result != false)
                    return Ok(new { success = true, message = "Label Deleted" });
                else
                    return BadRequest(new { success = false, message = "something went wrong" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("UpdateLabel")]
        public IActionResult UpdateLabel(string newLabelName, long labelId)
        {
            try
            {
                var userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = labelBussiness.UpdateLabel( newLabelName,  labelId);

                if (result != null)
                    return Ok(new { success = true, message = "Updated Label" });
                else
                    return BadRequest(new { success = false, message = "Unable to update Label" });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
