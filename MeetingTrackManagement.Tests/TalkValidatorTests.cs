using MeetingTrackManagement.BusinessProcess.Domain;
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
    public class TalkValidatorTests
    {
        ITalkValidator talkValidator;

        [SetUp]
        public void SetUp()
        {
            talkValidator = new Mock<TalkValidator>().Object;
        }

        [Test]
        public void Talk_Title_Should_Not_Contain_Numbers()
        {
            var talk = new Talk("Test Talk Title 5", 10);
            var validationResult = talkValidator.ValidateTalk(talk);
            Assert.False(validationResult.IsValid);
        }

        [Test]
        public void Talk_Duration_Should_Not_Be_Less_Than_Five_Minutes()
        {
            var talk = new Talk("Test Talk Title", 3);
            var validationResult = talkValidator.ValidateTalk(talk);
            Assert.False(validationResult.IsValid);
        }
    }
}
