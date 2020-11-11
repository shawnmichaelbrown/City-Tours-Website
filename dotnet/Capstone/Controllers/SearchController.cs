using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Capstone.Models;
using Capstone.DAO;
using RestSharp;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly RestClient client = new RestClient();
        private string URL = @"https://maps.googleapis.com/maps/api/distancematrix/";
        private string API_KEY = "";
        private readonly ILandmarkDAO landmarkDAO;

        public SearchController(ILandmarkDAO _landmarkDAO, IConfiguration configuration)
        {
            API_KEY = configuration["googleAPIKey"];
            landmarkDAO = _landmarkDAO;
        }

        [HttpGet]
        public IActionResult SearchAll()
        {
            List<Landmark> landmarks = landmarkDAO.RetrieveLandmarks();

            try
            { return Ok(landmarks); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in RetrieveLandmarks - " + ex.Message });
            }
        }

        [HttpPost("distanceCalculator")]
        public IActionResult DistanceBetween(AddressDetails add)
        {
            List<Landmark> landmarks = landmarkDAO.RetrieveLandmarks();

            if(add.Address.Length == 0)
            {
                return Ok(landmarks);
            }


            if (add == null)
            {
                return NoContent();
            }
            string param = @"json?origins=";

            string destinations = @"&destinations=";

            string mode = @"&mode=walking&language=en-US";

            string address = ToGoogleFormat(add.Address);

            string bigURL = ToUrl(landmarks);

            List<string> distances = new List<string>();

            RestRequest request = new RestRequest(URL + param + address + destinations + bigURL + mode + "&key=" + API_KEY);

            IRestResponse<JsonResult> response = client.Get<JsonResult>(request);

            JObject jSON = JObject.Parse(response.Content);

            distances = parseJ(jSON);

            if (landmarks.Count != 0)
            {


                for (int i = 0; i < landmarks.Count; i++)
                {
                    decimal meters = Convert.ToDecimal(distances[i]);

                    decimal m = meters / 1609.34M;

                    decimal miles = decimal.Round(m, 2);

                    landmarks[i].Distance = miles;
                }
            }
            

            return Ok(landmarks);

        }


        public List<string> parseJ(JObject item)
        {
            List<string> distances = new List<string>();
            foreach (var row in item["rows"])
            {
                foreach (var element in row["elements"])
                {
                    string variable = (string)element["distance"]["value"];

                    distances.Add(variable);
                }
            }
            return distances;
        }

        public string ToUrl(List<Landmark> landmarks)
        {
            List<string> listOfAddresses = new List<string>();

            for (int i = 0; i < landmarks.Count; i++)
            {
                string address = landmarks[i].Address;
                string newAddress = address.Replace(" ", "+");
                listOfAddresses.Add(newAddress);
            }

            string bigURL = string.Join("|", listOfAddresses);

            return bigURL;
        }

        public string ToGoogleFormat(string add)
        {
            string address = add.Replace(" ", "+");
            return address;
        }

    }
}