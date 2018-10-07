using MeetingTrackManagement.BusinessProcess.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Interfaces
{
    public interface ITalkInfoExtractor
    {
        Tuple<string, int> ExtractTalkTitleAndDuration(string title);
    }
}
