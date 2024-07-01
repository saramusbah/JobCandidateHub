using JobCandidateHub.Domain.Contracts;
using JobCandidateHub.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateHub.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(CandidateInputModel candidate)
        {
            var validator = new CandidateInputModelValidator();

            var validate = validator.Validate(candidate);
            if (!validate.IsValid)
            {
                return BadRequest(ResponseResult.Failed(ErrorCode.ValidationError, validate.Errors.Select(x => x.ErrorMessage).ToArray()));
            }
            await _candidateService.AddOrUpdate(candidate);

            return Ok(ResponseResult.Succeeded());
        }

        [HttpGet]
        public async Task<IActionResult> List(int page = 1, int pageSize = 10)
        {
            var result = await _candidateService.List(page, pageSize);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
