using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PresidentialElection.ViewModels
{
    public class CandidateCreateViewModel
    {
        public string Party { get; set; }

        [Required(ErrorMessage = "Photo is required!")]
        public IFormFile PhotoFile { get; set; }
        
    }
}
