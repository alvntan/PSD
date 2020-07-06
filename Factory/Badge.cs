using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habit_Tracker.Factory
{
    public class Badge
    {
        public Guid badgeid { get; set; }
        public String badgename { get; set; }
        public String description { get; set; }
        public Guid badgeuser_id { get; set; }
        public DateTime badgecreated_at { get; set; }
    }
    
}