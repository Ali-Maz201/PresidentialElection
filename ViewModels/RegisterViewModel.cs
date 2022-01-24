using System;
using System.ComponentModel.DataAnnotations;

namespace PresidentialElection.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The CitizenID is required.")]
        [Display(Name = "Government ID")]
        public string GovernmentID { get; set; }

        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Select your birth date.")]
        [Display(Name = "Birth date")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
