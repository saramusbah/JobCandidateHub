using JobCandidateHub.Domain.Models;

namespace JobCandidateHub.Domain.Contracts
{
    public interface ICandidateService
    {
        Task AddOrUpdate(CandidateInputModel candidate);
        Task<List<CandidateOutputModel>> List(int page, int pageSize);
    }
}
