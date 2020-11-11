using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.DAO;
using Microsoft.AspNetCore.Authorization;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LandmarkController : ControllerBase
    {
        private readonly ILandmarkDAO landmarkDAO;
        private readonly RestClient client = new RestClient();

        public LandmarkController(ILandmarkDAO _landmarkDAO)
        {
            landmarkDAO = _landmarkDAO;
        }

        string wikipediaTextURL = @"https://en.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&exintro&explaintext&titles=";

        string wikipediaImageURL = @"https://en.wikipedia.org/w/api.php?action=query&prop=pageimages&format=json&pithumbsize=500&titles=";


        //[Authorize(Roles="admin")]
        [HttpPost("add")]
        public IActionResult AddLandmark(Landmark landmark)
        {
            bool result = landmarkDAO.AddLandmark(landmark);
            if (result == true)
            {
                return Ok("landmark added successfully");
            }
            else
            {
                return BadRequest("OOPS, there was a problem. Try that again, boss");
            }
        }
        [AllowAnonymous]
        [HttpPost("getDescription")]
        public IActionResult RetrieveDescription(WikiPage page)
        {
            string formattedName = ToWikipediaFormat(page.Text);
            string queryURL = wikipediaTextURL + formattedName;

            RestRequest request = new RestRequest(queryURL);
            IRestResponse<JsonResult> response = client.Get<JsonResult>(request);

            try
            {
                JObject jSON = JObject.Parse(response.Content);

                JToken token = jSON.SelectToken("extract");

                string textWithN = parseJSON(jSON);
                string textToReturn = NoMoreNs(textWithN);

                return Ok(textToReturn);
            }
            catch
            {
                return Ok("The requested page does not exist.");
            }
        }
        [AllowAnonymous]
        [HttpPost("getImage")]
        public IActionResult RetrieveImage(WikiPage page)
        {
            string formattedName = ToWikipediaFormat(page.Text);
            string queryURL = wikipediaImageURL + formattedName;


            RestRequest request = new RestRequest(queryURL);
            IRestResponse<JsonResult> response = client.Get<JsonResult>(request);

            try
            {
                JObject jSON = JObject.Parse(response.Content);
                string ImageURL = parseJSONImage(jSON);

                return Ok(ImageURL);
            }
            catch
            {
                return Ok("The requested image does not exist.");
            }
        }

        public string parseJSON(JObject item)
        {
            string wikiText = "";

            IJEnumerable<JToken> list = item["query"]["pages"].Children();
            foreach(var row in list)
            {
                wikiText = (string)row.Last.Last;
            }
            return wikiText;
        }
        public string parseJSONImage(JObject item)
        {
            string wikiImageURL = "";

            IJEnumerable<JToken> list = item["query"]["pages"].Children();

            foreach (var row in list)
            {
                wikiImageURL = (string)row.Last["thumbnail"].First;
            }
            return wikiImageURL;
        }

        public string ToWikipediaFormat(string add)
        {
            string address = add.Replace(" ", "_");
            return address;
        }
        public string NoMoreNs (string text)
        {
            string result = text.Replace("\n", " ");
            return result;
        }
    }

}