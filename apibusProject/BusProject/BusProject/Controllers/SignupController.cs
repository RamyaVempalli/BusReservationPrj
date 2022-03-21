using BusProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        [Key]
        private readonly BusReservationProjectContext db;

        public SignupController(BusReservationProjectContext context)
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
