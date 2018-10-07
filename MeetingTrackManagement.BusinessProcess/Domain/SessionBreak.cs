using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Domain
{
    public class SessionBreak
    {
        public SessionBreak(string name, int hours)
        {
            Name = name;
            Duration = new TimeSpan(hours, 0, 0);
        }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
