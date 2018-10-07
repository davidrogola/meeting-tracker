using MeetingTrackManagement.BusinessProcess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetingTrackManagement.BusinessProcess.Interfaces
{
    public interface ITalkManager
    {
        List<Talk> GenerateTalksFromInput(string[] fileContents);
        List<Talk> GetTalkList();

    }

    public class TalkManagerService : ITalkManager
    {
        ITalkInfoExtractor talkInfoExtractor;
        readonly List<Talk> talkList = new List<Talk>();
        ITalkValidator talkValidator;
        public TalkManagerService(ITalkInfoExtractor _talkInfoExtractor, ITalkValidator _talkValidator)
        {
            talkInfoExtractor = _talkInfoExtractor;
            talkValidator = _talkValidator;
        }

        public List<Talk> GenerateTalksFromInput(string[] fileContents)
        {
            List<Talk> talkList = new List<Talk>();

            foreach (var fileContent in fileContents)
            {
                if (string.IsNullOrEmpty(fileContent))
                    continue;
                var titleAndTalkDurationTuple = talkInfoExtractor.ExtractTalkTitleAndDuration(fileContent);
                if (string.IsNullOrEmpty(titleAndTalkDurationTuple.Item1))
                    continue;
                var talk = new Talk(titleAndTalkDurationTuple.Item1, titleAndTalkDurationTuple.Item2);
                var validationResult = talkValidator.ValidateTalk(talk);

                if (validationResult.IsValid)
                    talkList.Add(talk);
            }
            return talkList.OrderBy(x=>x.Duration).ToList();
        }

        public List<Talk> GetTalkList()
        {
            return talkList;
        }
    }
}
