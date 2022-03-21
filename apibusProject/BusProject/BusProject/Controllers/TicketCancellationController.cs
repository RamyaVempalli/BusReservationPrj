using BusProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCancellationController : ControllerBase
    {
        private readonly BusReservationProjectContext db;
        public TicketCancellationController(BusReservationProjectContext context)
        {
            db = context;
        }

        [HttpDelete]
        [Route("TicketCancellation")]
        public IActionResult TicketCancellation(int Booking_Id)
        {
            
            var data = db.TicketCancellations.Find(Booking_Id);
            if (data == null)
            {
                return NotFound("Invalid bid");
            }
            else
            {
                db.TicketCancellations.Remove(data);
                db.SaveChanges();
                return Ok("Record Deleted");
            }
           

        }
      /*  [HttpPost] // To Save the data
        [Route("Refund")]
        public IActionResult PostRefundAmount([FromBody] TicketCancellation ticketCancellation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.TicketCancellations.Add(ticketCancellation);  //to call the data
                    db.SaveChanges(); // save the data in table
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Created("Amount Refunded Successfully", ticketCancellation);
        }*/
    }
}