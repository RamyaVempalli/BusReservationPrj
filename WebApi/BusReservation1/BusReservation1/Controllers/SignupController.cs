using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BusReservation1.Models;

namespace BusReservation1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly BusReservationContext db;

        public SignupController(BusReservationContext context)
        {
            db = context;
        }

        [HttpGet]

        public IActionResult Result()
        {
            var user = db.UserProfiles.ToList();
            try
            {

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return Ok("No user found");
                }
            }
            catch (Exception e)
            {
                return Ok("");
            }
        }



        [HttpPost]

        public IActionResult Result(UserProfile userProfile)
        {
            if (userProfile == null)
            {
                return Ok("Data Not Inserted");


            }
            else
            {
                db.UserProfiles.Add(userProfile);
                db.SaveChanges();

                return Ok("Data Inserted");
            }
        }

    }
}