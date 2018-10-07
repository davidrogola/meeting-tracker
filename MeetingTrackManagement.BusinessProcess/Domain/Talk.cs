using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MeetingTrackManagement.BusinessProcess.Domain
{
    public class Talk
    {
        public Talk(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }
        public string Title { get; set; }
        public int Duration { get; set; }
       
    }


}
