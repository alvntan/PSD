using Habit_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace Habit_Tracker.Controllers
{
    public class HabitController : ApiController
    {
        MyDBEntities1 mydb = new MyDBEntities1();

        [HttpGet]
        [Route("api/v1/users/{userID}/habits")]
        public HttpResponseMessage GET(Guid userid)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(mydb.Habits.Single(u => u.user_id == userid)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("api/v1/users/{userID}/habits/{id}")]
        public HttpResponseMessage GET(Guid userid , Guid habitid)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(mydb.Habits.Single(u => u.user_id == userid && u.habitid == habitid)));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("api/v1/users/{userID}/habits")]
        public HttpResponseMessage POST(Habit habit)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                mydb.Habits.Add(habit);
                mydb.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("api/v1/users/{user_id}/habits/{id}")]
        public HttpResponseMessage PUT(Habit habit)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                var newUser = mydb.Habits.Single(u => u.habitid == habit.habitid);
                mydb.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


        [HttpDelete]
        [Route("api/v1/users/{user_id}/habits/{id}")]
        public HttpResponseMessage Delete(Guid userid , Guid habitid)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                mydb.Habits.Remove(mydb.Habits.Single(u => u.user_id == userid && u.habitid == habitid));
                mydb.SaveChanges();
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }



    }
}
