using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingManagementController : Controller
    {
        ITrackInfomationOutputBuilder trackInfomationOutputBuilder;
        ITalkScheduler talkScheduler;
        public MeetingManagementController(ITrackInfomationOutputBuilder _trackInfomationOutputBuilder,
        ITalkScheduler _talkScheduler)
        {
            trackInfomationOutputBuilder = _trackInfomationOutputBuilder;
            talkScheduler = _talkScheduler;
        }


        [HttpPost, DisableRequestSizeLimit]
        public IEnumerable<string> UploadScheduleFile()
        {
            var file = Request.Form.Files[0];
            if (file.Length < 0)
                return new List<string>();

            var talkDetails = string.Empty;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                talkDetails = reader.ReadToEnd();
            }

            string[] fileContents = talkDetails.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var scheduledTracks = talkScheduler.ScheduleTalks(fileContents);

            var formatedScheduleOutput = trackInfomationOutputBuilder.BuildTrackInfoOutput(scheduledTracks);
            return formatedScheduleOutput;

        }

    }
}