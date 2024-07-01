using JobCandidateHub.Domain.Contracts;
using JobCandidateHub.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ILogger<CandidatesController> _logger;
        private readonly ICandidateService _candidateService;
        public CandidatesController(ILogger<CandidatesController> logger, ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CandidateInputModel candidate)
        {
            await _candidateService.Add(candidate);

            return Ok(ResponseResult.Succeeded());
        }
    }
}
