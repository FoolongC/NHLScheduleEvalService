using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NHLScheduleEvalSvc.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        public int Count { get; set; }
    }
}