using MeetingTrackManagement.BusinessProcess.Interfaces;
using MeetingTrackManagement.BusinessProcess.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Installers
{
    public static class TrackerManagementServicesInstaller
    {
        public static void AddMeetingTrackerServices(this IServiceCollection services)
        {
            services.AddSingleton<ITalkInfoExtractor, TalkInfoExtractor>();
            services.AddSingleton<ITalkManager, TalkManagerService>();
            services.AddSingleton<ITrackManager, TrackManagerService>();
            services.AddSingleton<ITalkScheduler, TalkSchedulerService>();
            services.AddSingleton<ITrackInfomationOutputBuilder, TrackInformationOutputBuilder>();
            services.AddSingleton<ITalkValidator, TalkValidator>();
        }
    }
}
