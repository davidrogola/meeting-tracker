using MeetingTrackManagement.BusinessProcess.Domain;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Services
{
    public class TrackInformationOutputBuilder : ITrackInfomationOutputBuilder
    {

        public List<string> BuildTrackInfoOutput(List<Track> tracks)
        {
            List<string> formatedTrackInfomation = new List<string>();

            foreach (Track track in tracks)
            {
                formatedTrackInfomation.Add($"{track.Name}:");
                string morningTalkStartTime = track.MorningSession.FormatStartTime();
                var morningSessionTimeSpan = track.MorningSession.GetStartTimeSpanMinutes();

                for (int talkCounter = 0; talkCounter < track.MorningSession.Talks.Count; talkCounter++)
                {
                    int talkDuration = track.MorningSession.Talks[talkCounter].Duration;
                    formatedTrackInfomation.Add($" {morningTalkStartTime} AM { track.MorningSession.Talks[talkCounter].Title} {talkDuration}min");
                    morningSessionTimeSpan =
                        TimeSpan.FromMinutes(morningSessionTimeSpan.TotalMinutes + talkDuration );
                    morningTalkStartTime = morningSessionTimeSpan.ToString("hh':'mm");

                }
                formatedTrackInfomation.Add("12:00PM Lunch");


                string afternoonTalkStartTime = track.AfternoonSession.FormatStartTime();
                var afternoonSessionTimeSpan = track.AfternoonSession.GetStartTimeSpanMinutes();

                for (int talkCounter = 0; talkCounter < track.AfternoonSession.Talks.Count; talkCounter++)
                {
                    int talkDuration = track.AfternoonSession.Talks[talkCounter].Duration;

                    formatedTrackInfomation.Add($"{afternoonTalkStartTime} PM  {track.AfternoonSession.Talks[talkCounter].Title} {talkDuration}min");
                    afternoonSessionTimeSpan = TimeSpan.FromMinutes(afternoonSessionTimeSpan.TotalMinutes + talkDuration);
                    afternoonTalkStartTime = afternoonSessionTimeSpan.ToString("hh':'mm");

                }

                //setting up the networking event
                afternoonSessionTimeSpan = afternoonSessionTimeSpan < TimeSpan.FromMinutes(TimeSpan.FromHours(4).TotalMinutes) ? afternoonSessionTimeSpan = TimeSpan.FromMinutes(TimeSpan.FromHours(4).TotalMinutes) :
                    TimeSpan.FromMinutes(TimeSpan.FromHours(5).TotalMinutes);         
                
                afternoonTalkStartTime = afternoonSessionTimeSpan.ToString("hh':'mm");
                formatedTrackInfomation.Add(afternoonTalkStartTime + "PM Networking Event");
            }
            return formatedTrackInfomation;
        }
    }
}

