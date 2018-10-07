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
    public class TalkInfoExtratorTests
    {
        ITalkInfoExtractor talkInfoExtrator;

        [SetUp]
        public void SetUp()
        {
            talkInfoExtrator = new Mock<TalkInfoExtractor>().Object;
        }

        [Test]
        public void Talk_Info_Extractor_Should_Return_Tuple_With_Valid_Title_And_Duration()
        {
            var talkInfoTuple = new Tuple<string, int>("Overdoing it in Python: ", 45);
            string title = "Overdoing it in Python: 45min";
            var talkInfo = talkInfoExtrator.ExtractTalkTitleAndDuration(title);

            Assert.AreEqual(talkInfoTuple, talkInfo);          
        }

        [Test]
        public void Lightning_Talk_Duration_Should_Be_Five_Minutes()
        {
            var lightningTalkDuration = 5;
            string lightningTitle = "Rails for Python Developers lightning";

            var talkInfo = talkInfoExtrator.ExtractTalkTitleAndDuration(lightningTitle);
            Assert.AreEqual(lightningTalkDuration, talkInfo.Item2);
        }
    }
}
