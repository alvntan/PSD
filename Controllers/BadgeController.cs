using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Habit_Tracker.Models;

namespace Habit_Tracker.Controllers
{
   
    public class BadgeController : ApiController
    {
        MyDBEntities1 mydb = new MyDBEntities1();

        [HttpGet]
        [Route("api/v1/users/{userID}/badges")]
        public HttpResponseMessage GET(Guid userid)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(mydb.Badges.Single(u => u.user_id == userid)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
