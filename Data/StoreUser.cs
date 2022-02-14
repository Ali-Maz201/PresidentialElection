using Microsoft.AspNetCore.Identity;
using System;

namespace PresidentialElection.Data
{
    public class StoreUser : IdentityUser
    {
        public string GovernmentID { get; set; }
        public string FullName { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public bool CanVote { get; set; } = false;
        public bool Enrolled { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAccount { get; set; } = DateTime.Now;
        
    }
}
