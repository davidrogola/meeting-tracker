using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingTracker.Web.Models
{
    public class UploadTalkScheduleFile
    {
        public IFormFile TalkScheduleFile { get; set; }

    }
}
