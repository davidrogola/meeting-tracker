using MeetingTrackManagement.BusinessProcess.Domain;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using MeetingTrackManagement.BusinessProcess.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MeetingTrackManagement.Tests.TalkInputsHelper;

namespace MeetingTrackManagement.Tests
{
    public class TalkSchedulerTests
    {
        ITalkScheduler taskScheduler;
        List<Track> tracks;

        [SetUp]
        public void SetUp()
        {
            var talkManager = new TalkManagerService(new TalkInfoExtractor(),new TalkValidator());
            var trackManager = new TrackManagerService();

            taskScheduler = new TalkSchedulerService(talkManager, trackManager);
            tracks = taskScheduler.ScheduleTalks(GetTalkInputs());
        }
        [Test]
        public void Talk_Scheduler_Generates_Tracks_And_Allocates_Time_For_All_Sessions()
        {
            foreach (var track in tracks)
            {
                Assert.True(track.MorningSession.FullyAllocated);
                Assert.True(track.AfternoonSession.FullyAllocated);
            }
        }
        [Test]
        public void Morning_Session_Event_Should_Start_At_9_AM()
        {
            var morningSessionStartTime = "09:00 AM";
            var track = tracks.FirstOrDefault();
            var actualStartTime =$"{track.MorningSession.FormatStartTime()} AM";
            Assert.AreEqual(morningSessionStartTime, actualStartTime);

        }
        [Test]
        public void Morning_Session_Event_Shoud_End_At_12()
        {
            var morningSessionEndTime = "12:00 PM";
            var track = tracks.FirstOrDefault();
            var actualEndTime = track.MorningSession.StartTime.Add(track.MorningSession.Duration).ToString("hh':'mm");
            Assert.AreEqual(morningSessionEndTime,$"{ actualEndTime} PM");
        }

        [Test]
        public void Afternoon_Session_Event_Should_Start_At_1PM()
        {
            var afternoonSessionStartTime = "01:00 PM";
            var track = tracks.FirstOrDefault();
            var actualStartTime = $"{track.AfternoonSession.FormatStartTime()} PM";
            Assert.AreEqual(afternoonSessionStartTime, actualStartTime);
        }

    }
}
