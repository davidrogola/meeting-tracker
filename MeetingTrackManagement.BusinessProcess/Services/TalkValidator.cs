using MeetingTrackManagement.BusinessProcess.Domain;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MeetingTrackManagement.BusinessProcess.Services
{
    public class TalkValidator : ITalkValidator
    {

        public ValidationInfo ValidateTalk(Talk talk)
        {
            int minimumTalkDurationInMinutes = 5;

            var errors = new List<ValidationError>();
            string digit = Regex.Match(talk.Title, @"\d+").Value;

            if (!string.IsNullOrEmpty(digit))
                errors.Add(new ValidationError
                {
                    ErrorMessage = "Talk title should not contain numbers"
                });

            if(talk.Duration < minimumTalkDurationInMinutes)
                errors.Add(new ValidationError
                {
                    ErrorMessage = "Minimum talk duration is 5 minutes"
                });

            return new ValidationInfo
            {
                IsValid = !errors.Any(),
                Title = talk.Title,
                VaildationErrors = errors
            };
        }
    }
}
