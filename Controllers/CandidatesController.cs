using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresidentialElection.Data;
using PresidentialElection.Models;
using PresidentialElection.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PresidentialElection.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<StoreUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CandidatesController(ApplicationContext context, UserManager<StoreUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> VoteCandidate(int? candidateID)
        {
            if (candidateID == null)
            {
                return View();
            }
            var votedCandidate = await _context.Candidates.FirstOrDefaultAsync(result => result.CanditateID == candidateID);

            if (votedCandidate == null)
            {
                return View();
            }
            // Getting the current logged user 
            var userID = _userManager.GetUserId(HttpContext.User);
            var loggedUser = await _userManager.FindByIdAsync(userID);

            var vote = new Vote
            {
                CandidateID = (int)candidateID,
                Id = loggedUser.Id,
            };
            votedCandidate.NumberOFVotes++;
            _context.Candidates.Update(votedCandidate);
            await _context.AddAsync(vote);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EnrollCandidacy()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EnrollCandidacy(CandidateCreateViewModel model)
        {
            if (ModelState.IsValid)
            {   
                // Getting the current logged user 
                var userID = _userManager.GetUserId(HttpContext.User);
                var loggedUser = await _userManager.FindByIdAsync(userID);

                //Save the image in the wwwroot/Images directory
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.PhotoFile.FileName);
                string extension = Path.GetExtension(model.PhotoFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(fileStream);
                }

                //Create the new candidate
                var currentCandidate = new Candidate()
                {
                    PhotoFileName = fileName,
                    Party = model.Party,
                    Id = userID,
                    Name = loggedUser.FullName,

                };
                // Save the candidate in the Database
                await _context.Candidates.AddAsync(currentCandidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

     }
}
