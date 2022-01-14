using Microsoft.AspNetCore.Identity;
using System;

namespace PresidentialElection.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string CitizenID { get; set; }

        [PersonalData]
        public string StreetAddress { get; set; }

        [PersonalData]
        public string State { get; set; }

        [PersonalData]
        public string CanVote { get; set; } = "No";

        [PersonalData]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAccount { get; set; } = DateTime.Now;

    }
}
