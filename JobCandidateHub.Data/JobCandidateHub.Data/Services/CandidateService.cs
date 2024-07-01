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

        public async Task AddOrUpdate(CandidateInputModel candidate)
        {
            Candidate newCandidate = Candidate.CreateFromInputModel(candidate);

            var existingEmail = await _dbContext.Candidates.Where(c => c.Email == candidate.Email).FirstOrDefaultAsync();
            if (existingEmail != null)
            {
                UpdateExistingCandidate(candidate, existingEmail);
            }
            else
            {
                await _dbContext.Candidates.AddAsync(newCandidate);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CandidateOutputModel>> List(int page, int pageSize)
        {
            return await _dbContext.Candidates.AsNoTracking().Select(c =>
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

        private void UpdateExistingCandidate(CandidateInputModel candidate, Candidate existingEmail)
        {
            existingEmail.FirstName = candidate.FirstName;
            existingEmail.LastName = candidate.LastName;
            existingEmail.Email = candidate.Email;
            existingEmail.PhoneNumber = candidate.PhoneNumber;
            existingEmail.PreferredCallTime = candidate.PreferredCallTime;
            existingEmail.FreeTextComment = candidate.FreeTextComment;
            existingEmail.GitHubProfileUrl = candidate.GitHubProfileUrl;
            existingEmail.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
        }
    }
}
