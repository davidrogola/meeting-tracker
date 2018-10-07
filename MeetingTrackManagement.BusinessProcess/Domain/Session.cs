using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Domain
{
    public class Session
    {
        public Session(string name, int hours, int startTime)
        {
            Name = name;
            Duration = new TimeSpan(hours, 0, 0);
            Talks = new List<Talk>();
            StartTime = TimeSpan.FromHours(startTime);

        }
        public string Name;
        public TimeSpan Duration;
        public TimeSpan StartTime { get; set; }
        public List<Talk> Talks;
        public bool FullyAllocated { get; set; }

        public string FormatStartTime()
        {
            return TimeSpan.FromMinutes(StartTime.TotalMinutes).ToString("hh':'mm");
        }

        public TimeSpan GetStartTimeSpanMinutes()
        {
            return TimeSpan.FromMinutes(StartTime.TotalMinutes);
        }
    }
}
