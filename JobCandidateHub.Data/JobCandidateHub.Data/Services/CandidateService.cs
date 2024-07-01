using JobCandidateHub.Domain.Contracts;
using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Domain.Models;

namespace JobCandidateHub.Data.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly JobCandidateHubDBContext _dbContext;

        public CandidateService(JobCandidateHubDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Add(CandidateInputModel candidate)
        {
            Candidate newCandidate = new()
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Email = candidate.Email,
                PhoneNumber = candidate.PhoneNumber,
                PreferredCallTime = candidate.PreferredCallTime,
                LinkedInProfileUrl = candidate.LinkedInProfileUrl,
                GitHubProfileUrl = candidate.GitHubProfileUrl,
                FreeTextComment = candidate.FreeTextComment,
            };

            await _dbContext.Candidates.AddAsync(newCandidate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
