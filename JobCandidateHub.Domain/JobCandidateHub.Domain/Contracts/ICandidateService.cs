using JobCandidateHub.Domain.Models;

namespace JobCandidateHub.Domain.Contracts
{
    public interface ICandidateService
    {
        Task Add(CandidateInputModel candidate);
    }
}
