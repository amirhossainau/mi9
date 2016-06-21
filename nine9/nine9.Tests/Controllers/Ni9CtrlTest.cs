using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nine9;
using nine9.Controllers;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using nine9.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
namespace nine9.Tests.Controllers
{
    [TestClass]
    public class Ni9CtrlTest
    {
        [TestMethod]
        public void Ni9_call_with_null_value()
        {
            // Arrange
            Ni9Controller controller = new Ni9Controller();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            controller.Request.Method = HttpMethod.Post;

            // Act
            var callapi = controller.Post(null);
            var output = callapi.Content.ReadAsAsync<CustomError>().Result;

            // Assert            
            Assert.IsNotNull(callapi.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, callapi.StatusCode);
            Assert.IsTrue(output.error.Contains("decode request"));
        }

        [TestMethod]
        public void Ni9_call_with_value()
        {
            // Arrange
            Ni9Controller controller = new Ni9Controller();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            controller.Request.Method = HttpMethod.Post;

            // Act
            var callapi = controller.Post(jsoninput());
            var output = callapi.Content.ReadAsAsync<ResponseResult>().Result;

            // Assert            
            Assert.IsNotNull(callapi.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, callapi.StatusCode);
            // validate the json response as well
            Assert.AreEqual(1, output.response.Count);

            Debug.WriteLine( JsonConvert.SerializeObject(output, formatting: Formatting.Indented));
        }

        [TestMethod]
        public void Ni9_call_with_wrong_value()
        {
            // Arrange
            Ni9Controller controller = new Ni9Controller();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            controller.Request.Method = HttpMethod.Post;

            // Act
            var callapi = controller.Post(jsonwronginput());
            var output = callapi.Content.ReadAsAsync<CustomError>().Result;

            // Assert            
            Assert.IsNotNull(callapi.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, callapi.StatusCode);
            
            
        }

        private Programs jsoninput()
        {
            return new Programs()
            {
                payload = new List<Payload>()
                {
                    new Payload{
                        country = "UK",
                        description = "What's life like when you have enough children to field your own football team?",
                        drm=true,
                        episodeCount = 3,
                        genre="reality",
                        image = new Image(){
                                    showImage = "http://mybeautifulcatchupservice.com/img/shows/16KidsandCounting1280.jpg"
                                            },
                       language="English",
                       nextEpisode = null,
                       primaryColour = "#99388",
                       seasons = new List<Season>()
                       {
                           new Season
                           {
                               slug = "show/thunderbirds/season/1"
                           },
                           new Season
                           {
                               slug = "show/thunderbirds/season/3"
                           },
                           new Season
                           {
                               slug = "show/thunderbirds/season/5"
                           }
                       },
                       slug = "show/separtor",
                       title = "Sea Patrol",
                       tvChannel = "Channel 9"
                        },
                    new Payload{
                        country = "USA",
                        description = "The Taste puts 16 culinary competitors in the kitchen, where four of the World's most notable culinary masters of the food world judges their creations based on a blind taste. Join judges Anthony Bourdain, Nigella Lawson, Ludovic Lefebvre and Brian Malarkey in this pressure-packed contest where a single spoonful can catapult a contender to the top or send them packing.",
                        drm=true,
                        episodeCount = 0,
                        genre="reality",
                        image = new Image(){
                                    showImage = "http://mybeautifulcatchupservice.com/img/shows/16KidsandCounting1280.jpg"
                                            },
                       language="English",
                       nextEpisode = null,
                       primaryColour = "#99388",
                       seasons = null,
                       slug = "show/Thunderbirds",
                       title = "Thunderbirds",
                       tvChannel = "Channel 9"
}
                },
                skip = 0,
                take = 10,
                totalRecords = 75
            };
            
        }
        private Programs jsonwronginput()
        {
            return new Programs()
            {
               totalRecords = 0
            };

        }
    }
}
