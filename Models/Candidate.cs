using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresidentialElection.Models
{
    public class Candidate
    {
        [Key]
        public int CanditateID { get; set; }
        public string Name { get; set; }
        public string Party { get; set; } = "Unfilieted";

        
        public ICollection<Vote> Votes { get; set; }
    }
}
