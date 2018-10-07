using MeetingTrackManagement.BusinessProcess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Interfaces
{
    public interface ITalkValidator
    {
        ValidationInfo ValidateTalk(Talk talk);
    }

    public class ValidationInfo
    {
        public bool IsValid { get; set; }
        public string Title { get; set; }
        public List<ValidationError> VaildationErrors { get; set; }       
    }

    public class ValidationError
    {
        public string ErrorMessage { get; set; }
    }

}
