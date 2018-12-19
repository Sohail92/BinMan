using System;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;

namespace BinMan.Controllers
{
    [Route("api/[controller]")]
    public class AlexaController : Controller
    {
        [HttpPost]
        [Route("HandleResponse")]
        public SkillResponse HandleResponse([FromBody] SkillRequest input)
        {
            var requestType = input.GetRequestType();

            string url = string.Empty;

            // return a welcome message
            if (requestType == typeof(LaunchRequest))
                return ResponseBuilder.Ask("Welcome to Bin Man. I will help you find which bin to put out!", null);

            if (requestType == typeof(IntentRequest))
            {
                // do some intent-based stuff
                var intentRequest = input.Request as IntentRequest;
                // check the name to determine what you should do
                if (intentRequest.Intent.Name.Equals("WhichBin"))
                {
                    try { return ResponseBuilder.Tell("This week you need to take out the Black bin and the Blue bin.");}
                    catch (Exception ex) { return ResponseBuilder.Ask($"ERROR!" + ex.InnerException, null); }
                }
            }
            return ResponseBuilder.Ask("I didn't understand that.. sorry.", null);
        }
    }
}