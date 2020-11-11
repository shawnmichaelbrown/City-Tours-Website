using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ItineraryController: ControllerBase
    {
        private readonly IItineraryDAO itineraryDAO;

        public ItineraryController(IItineraryDAO _itineraryDAO)
        {
            itineraryDAO = _itineraryDAO;
        }

        [HttpPost("add")]
        public IActionResult AddItinerary(Itinerary itinerary)
        {
            bool result = itineraryDAO.AddItinerary(itinerary);
            if (result == true)
            {
                return Ok("itinerary added successfully");
            }
            else
            {
                return BadRequest("OOPS, there was a problem. Try that again, boss");
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteItinerary(int id)
        {
            bool result = itineraryDAO.DeleteItinerary(id);
            if (result == true)
            {
                return Ok("itinerary deleted successfully");
            }
            else
            {
                return BadRequest("OOPS, there was a problem. Try that again, boss");
            }
        }

        [HttpPut("edit")]
        public IActionResult EditItinerary(Itinerary itinerary)
        {
            bool result = itineraryDAO.EditItinerary(itinerary);
            if (result == true)
            {
                return Ok("itinerary edited successfully");
            }
            else
            {
                return BadRequest("OOPS, there was a problem. Try that again, boss");
            }
        }
        [HttpGet("fetch/{id}")]
        public IActionResult GetItineraries(int id)
        {
            List<Itinerary> result = itineraryDAO.RetrieveItineraries(id);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
            }
        }
    }
}
