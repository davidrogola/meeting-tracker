using MeetingTrackManagement.BusinessProcess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Interfaces
{
    public interface ITrackInfomationOutputBuilder
    {
        List<string> BuildTrackInfoOutput(List<Track> tracks);
    }
}
