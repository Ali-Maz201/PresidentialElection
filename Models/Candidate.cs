using PresidentialElection.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PresidentialElection.Models
{
    public class Candidate
    {
        [Key]
        public int CanditateID { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public string PhotoFileName { get; set; }
        public int NumberOFVotes { get; set; } = 0;
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;


        //Navigation Properties
        public ICollection<Vote> Votes { get; set; }
        public string Id { get; set; }
        public StoreUser User { get; set; }
    }
}
