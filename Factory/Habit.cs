using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Habit_Tracker.Factory
{
    public class Habit
    {
        public Guid habitid { get; set; }
        public String habitname { get; set; }
        public String[] days_off { get; set; }
        public Int16 current_streak { get; set; }
        public Int16 longest_streak { get; set; }
        public Int16 log_count { get; set; }
        public IEnumerable<DateTime> logs { get; set; }
        public Guid habituser_id { get; set; }
        public DateTime habitcreated_at { get; set; }
    }

    public class RequestHabit
    {
        public String habitname { get; set; }
        public String[] habitdays_off { get; set; }
    }
}