using JobCandidateHub.Domain.Models;

namespace JobCandidateHub.Domain.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PreferredCallTime { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string GitHubProfileUrl { get; set; }

        public required string FreeTextComment { get; set; }

        public static Candidate CreateFromInputModel(CandidateInputModel inputModel)
        {
            Candidate candidate = new()
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Email = inputModel.Email,
                PhoneNumber = inputModel.PhoneNumber,
                PreferredCallTime = inputModel.PreferredCallTime,
                LinkedInProfileUrl = inputModel.LinkedInProfileUrl,
                GitHubProfileUrl = inputModel.GitHubProfileUrl,
                FreeTextComment = inputModel.FreeTextComment,
            };

            return candidate;
        }
    }
}
