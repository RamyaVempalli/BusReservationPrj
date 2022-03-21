using BusReservation1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusReservation1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusSearchController : ControllerBase
    {
        private readonly BusReservationContext db;
        public BusSearchController(BusReservationContext context)
        {
            db = context;
        }

          [HttpGet]

          public IActionResult Get()
          {

            var bus = db.buses.ToList();


            if (bus != null)
            {

                return Ok(bus);
            }
            else
            {
                return NotFound("data not found");
            }

        }

        /* public Bu GetBus(int id)*/
        [HttpPost]

        public IActionResult SearchBus(Bu bus)
        {
            //Query syntax
            var bus1 = (from b in db.buses
                            where b.Departure == bus.Departure && b.Destination== bus.Destination 
                            select b).ToList();
               if (bus1 != null)
               {
                   return Ok(bus1);
               }
               else
               {
                   return Ok("No bus Available");
               }
            

        }

        

       /* public IActionResult GetBusDetails (Bu businfo)
        {
            var searchbus = db.buses.where(b => b.Departure == businfo.From && b.Destination == businfo.To
            && b.StartDate == businfo.DateofJourney).select(x => new { x.BusName ,x.BusNo ,x.NoOfSeatsAvailable }).ToList();

            if(searchbus!=null)
            {
                return Ok(searchbus);
            }
            else
            {
                return BadRequest("No Buses Available");
            }
        }
       */

        }
}
