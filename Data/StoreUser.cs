using Microsoft.AspNetCore.Identity;
using PresidentialElection.Models;
using System;

namespace PresidentialElection.Data
{
    public class StoreUser : IdentityUser
    {
        public string GovernmentID { get; set; }
        public string FullName { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string CanVote { get; set; } = "No";
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAccount { get; set; } = DateTime.Now;
    }
}
