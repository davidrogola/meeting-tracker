using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetingTracker.Web.Models;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MeetingTracker.Web.Controllers
{
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

        public IActionResult UploadTalkScheduleFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadTalkScheduleFile(UploadTalkScheduleFile model)
        {
            if (model.TalkScheduleFile == null)
                return View();
            var talkDetails = string.Empty;
            using (var reader = new StreamReader(model.TalkScheduleFile.OpenReadStream()))
            {
                talkDetails = reader.ReadToEnd();
            }

            string [] fileContents  = talkDetails.Split( new[] { Environment.NewLine }, StringSplitOptions.None);

            var scheduledTracks = talkScheduler.ScheduleTalks(fileContents);

            var formatedScheduleOutput = trackInfomationOutputBuilder.BuildTrackInfoOutput(scheduledTracks);

            return View(nameof(TalkScheduleResult),formatedScheduleOutput);
        }

        public IActionResult TalkScheduleResult(List<string> talkSchedules)
        {
            return View(talkSchedules);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
