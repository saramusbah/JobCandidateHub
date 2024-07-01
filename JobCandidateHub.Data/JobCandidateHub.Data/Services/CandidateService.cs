using JobCandidateHub.Domain.Contracts;
using JobCandidateHub.Domain.Entities;
using JobCandidateHub.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<CandidateOutputModel>> List(int page, int pageSize)
        {
            return await _dbContext.Candidates.Select(c =>
            new CandidateOutputModel
            {
                FullName = c.FirstName + " " + c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                PreferredCallTime = c.PreferredCallTime,
                LinkedInProfileUrl = c.LinkedInProfileUrl,
                GitHubProfileUrl = c.GitHubProfileUrl,
                FreeTextComment = c.FreeTextComment
            }).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
