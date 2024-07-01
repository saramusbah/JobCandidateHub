using FluentValidation;

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

    public class CandidateInputModelValidator: AbstractValidator<CandidateInputModel>
    {
        public CandidateInputModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FreeTextComment).NotEmpty().MaximumLength(500);
        }
    }
}
