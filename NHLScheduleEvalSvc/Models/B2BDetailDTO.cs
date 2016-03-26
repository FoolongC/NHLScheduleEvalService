using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHLScheduleEvalSvc.Models
{
    public class B2BDetailDTO
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public DateTime GameOneDate { get; set; }
        public DateTime GameTwoDate { get; set; }
        public string GameOneHome { get; set; }
        public string GameTwoHome { get; set; }
        public string GameOneFinal { get; set; }
        public string GameTwoFinal { get; set; }
        public string OppPlayedDayBefore { get; set; }
        public string TeamId { get; set; }
    }
}