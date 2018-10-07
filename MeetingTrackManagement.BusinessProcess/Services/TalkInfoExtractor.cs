using MeetingTrackManagement.BusinessProcess.Domain;
using MeetingTrackManagement.BusinessProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MeetingTrackManagement.BusinessProcess.Services
{
    public class TalkInfoExtractor : ITalkInfoExtractor
    {
        
        public Tuple<string, int> ExtractTalkTitleAndDuration(string title)
        {
            int duration = 0;
            string topic = string.Empty;
            if (string.IsNullOrEmpty(title))
                return new Tuple<string, int>(string.Empty, 0);

            string strDuration = Regex.Match(title, @"\d+").Value;
            if(!string.IsNullOrEmpty(strDuration))
            {
                topic = title.Replace(strDuration, "").Replace("min", "");
                duration = int.Parse(strDuration);
            }
            else if(title.Contains("lightning",StringComparison.InvariantCultureIgnoreCase))
            {
                duration = 5; // lightning presentation duration
                topic = title;
            }          
            return new Tuple<string, int>(topic, duration);
        }
    }
}
