using MeetingTrackManagement.BusinessProcess.Interfaces;
using MeetingTrackManagement.BusinessProcess.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.Tests
{
    [TestFixture]
    public class TrackManagerTests
    {
        ITrackManager trackManager;
        [SetUp]
        public void SetUp()
        {
            trackManager = new Mock<TrackManagerService>().Object;
        }

        [Test]
        public void Track_Generator_Returns_Valid_Track_List_With_the_Specified_Count()
        {
            int trackCount = 2;
            var tracks = trackManager.GenerateTracks(trackCount);
            Assert.AreEqual(trackCount, tracks.Count);
        }

        [Test]
        public void Minimum_Tracks_Required_Calculation_Returns_Valid_Track_Count_Required_To_Fill_All_Talks()
        {
            var lowerBound = 2;
            var trackDuration = TimeSpan.FromHours(7); // 7 is he valid presentation duration minus the breaks
            var totalTalkTime = 840; // the total talk presentation time

            var minimumTracks = trackManager.CalculateMinimumTracksRequired(trackDuration, totalTalkTime);
            Assert.AreEqual(lowerBound, minimumTracks);
        }
    }
}
