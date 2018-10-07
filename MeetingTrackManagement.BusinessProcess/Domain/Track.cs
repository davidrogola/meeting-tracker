using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Domain
{
    public class Track
    {
        public Track(int id, string name)
        {
            Id = id;
            Name = name;
            MorningSession = new Session("Morning Session", 3,9);
            AfternoonSession = new Session("Afternoon Session", 4,1);
            LunchBreak = new SessionBreak("Lunch", 1);
            Networking = new SessionBreak("Networking", 1); // tentative newtworking period. could be less
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Session MorningSession { get; set; }
        public Session AfternoonSession { get; set; }
        public SessionBreak LunchBreak { get; set; }
        public SessionBreak Networking { get; set; }

    }

}
