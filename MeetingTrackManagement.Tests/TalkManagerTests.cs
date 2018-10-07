using MeetingTrackManagement.BusinessProcess.Interfaces;
using MeetingTrackManagement.BusinessProcess.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static MeetingTrackManagement.Tests.TalkInputsHelper;

namespace MeetingTrackManagement.Tests
{
    public class TalkManagerTests
    {
       

        ITalkManager talkManager;

        [SetUp]
        public void SetUp()
        {
            var talkInfoExtractor = new TalkInfoExtractor();
            var talkvalidator = new TalkValidator();

            talkManager = new TalkManagerService(talkInfoExtractor, talkvalidator);
        }

        [Test]
        public void Talk_Generation_Should_Return_A_valid_Talk_List()
        {
            var expectedTalkCount = GetTalkInputs().Length;
            var generatedTalks = talkManager.GenerateTalksFromInput(GetTalkInputs());
            Assert.AreEqual(expectedTalkCount, generatedTalks.Count);
        }


    }
}
