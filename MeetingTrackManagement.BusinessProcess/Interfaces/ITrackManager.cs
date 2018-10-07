using MeetingTrackManagement.BusinessProcess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Interfaces
{
    public interface ITrackManager
    {
        int CalculateMinimumTracksRequired(TimeSpan trackDuration, int totalTalkDuration);
        List<Track> GenerateTracks(int lowerBound); // lowerbound is the value of minimum tracks required to accomodate all talks
    }
}
