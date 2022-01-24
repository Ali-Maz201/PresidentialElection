using PresidentialElection.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace PresidentialElection.Models
{
    public class Vote
    {
        [Key]
        public int VoteID { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.Now;


        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        public int Id { get; set; }
        public StoreUser User { get; set; }
    }
}
