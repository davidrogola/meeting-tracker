using MeetingTrackManagement.BusinessProcess.Domain;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Services
{
    public class TalkSchedulerService : ITalkScheduler
    {
        ITalkManager talkManager;
        ITrackManager trackManager;
        TimeSpan totalTrackDuration = new TimeSpan(7, 0, 0); // allowable presentation time minus the breaks
        public TalkSchedulerService(ITalkManager _talkManager, ITrackManager _trackManager)
        {
            talkManager = _talkManager;
            trackManager = _trackManager;
        }

        public List<Track> ScheduleTalks(string [] talkInputs)
        {
            var talks = talkManager.GenerateTalksFromInput(talkInputs);
            var totalTalkDuration = talks.Sum(x => x.Duration);

            var minimumNoOfTracksRequired = trackManager.CalculateMinimumTracksRequired(totalTrackDuration, totalTalkDuration);

            var tracks = trackManager.GenerateTracks(minimumNoOfTracksRequired);

            foreach (var track in tracks)
            {
                bool morningSessionFullyAllocated = false;

                int morningSessionDurationInMinutes = (int)track.MorningSession.Duration.TotalMinutes;
                for (int talkCounter = talks.Count - 1; talkCounter >= 0; talkCounter--)
                {
                    int talkDuration = talks[talkCounter].Duration;
                    if (morningSessionDurationInMinutes >= talkDuration && !morningSessionFullyAllocated)
                    {
                        track.MorningSession.Talks.Add(talks[talkCounter]);
                        morningSessionDurationInMinutes = morningSessionDurationInMinutes - talkDuration;
                        talks.RemoveAt(talkCounter);
                        if (morningSessionDurationInMinutes == 0)
                        {
                            morningSessionFullyAllocated = true;
                            track.MorningSession.FullyAllocated = morningSessionFullyAllocated;
                            break;
                        }

                    }
                }

                bool afternoonSessionFullyAllocated = false;
                int afternoonSessionDurationInMinutes = (int)track.AfternoonSession.Duration.TotalMinutes;
                for (int talkCounter = talks.Count - 1; talkCounter >= 0; talkCounter--)
                {
                    int talkDuration = talks[talkCounter].Duration;
                    if (afternoonSessionDurationInMinutes >= talkDuration && !afternoonSessionFullyAllocated)
                    {
                        track.AfternoonSession.Talks.Add(talks[talkCounter]);
                        afternoonSessionDurationInMinutes = afternoonSessionDurationInMinutes - talkDuration;
                        talks.RemoveAt(talkCounter);
                        if (afternoonSessionDurationInMinutes == 0 || talks.Count == 0)
                        {
                            afternoonSessionFullyAllocated = true;
                            track.AfternoonSession.FullyAllocated = afternoonSessionFullyAllocated;
                            break;
                        }

                    }
                }

            }

            return tracks;

        }
    }
}
