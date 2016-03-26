using System;
using System.ComponentModel.DataAnnotations;

namespace NHLScheduleEvalSvc.Models
{
    public class B2BComparison
    {
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        public DateTime GameOneDate { get; set; }
        public DateTime GameTwoDate { get; set; }
        public bool GameOneHome { get; set; }
        public bool GameTwoHome { get; set; }
        public string GameOneFinal { get; set; }
        public string GameTwoFinal { get; set; }
        public bool OppPlayedDayBefore { get; set; }

        // foreign key
        public int TeamId { get; set; }
        // navigation property
        public Team Team { get; set; }
    }
}