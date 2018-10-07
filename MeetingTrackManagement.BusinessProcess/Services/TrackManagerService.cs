using MeetingTrackManagement.BusinessProcess.Domain;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Services
{
    public class TrackManagerService : ITrackManager
    {
        public TrackManagerService()
        {

        }
        public int CalculateMinimumTracksRequired(TimeSpan trackDuration, int totalTalkDuration)
        {
            var lowerBound = (int)Math.Round(totalTalkDuration / trackDuration.TotalMinutes);
            return lowerBound;
        }

        public List<Track> GenerateTracks(int lowerBound)
        {
            var tracks = new List<Track>();
            for (int counter = 1; counter <= lowerBound; counter++)
            {
                var track = new Track(counter, $"Track {counter}");
                tracks.Add(track);
            }
            return tracks;
        }
    }
}
