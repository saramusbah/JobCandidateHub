using JobCandidateHub.Domain.Models;

namespace JobCandidateHub.Domain.Contracts
{
    public interface ICandidateService
    {
        Task Add(CandidateInputModel candidate);
        Task<List<CandidateOutputModel>> List(int page, int pageSize);
    }
}
