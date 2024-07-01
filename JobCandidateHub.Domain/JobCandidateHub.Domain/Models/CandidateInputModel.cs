namespace JobCandidateHub.Domain.Models
{
    public class CandidateInputModel
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PreferredCallTime { get; set; }

        public string LinkedInProfileUrl { get; set; }

        public string GitHubProfileUrl { get; set; }

        public required string FreeTextComment { get; set; }
    }
}
