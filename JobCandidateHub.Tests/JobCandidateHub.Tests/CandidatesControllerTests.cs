using JobCandidateHub.API.Controllers;
using JobCandidateHub.Domain.Contracts;
using JobCandidateHub.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace JobCandidateHub.Tests
{
    public class CandidatesControllerTests
    {
        private readonly Mock<ICandidateService> _candidateServiceMock;
        private readonly CandidatesController _candidatesController;
        private CandidateInputModel _candidateInputModel;
        public CandidatesControllerTests()
        {
            _candidateServiceMock = new Mock<ICandidateService>();
            _candidateInputModel = new CandidateInputModel
            {
                Email = "test@test.vom",
                FirstName = "test first name",
                LastName = "test last name",
                FreeTextComment = "test free comment",
            };

            _candidatesController = new CandidatesController(_candidateServiceMock.Object);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnOK_WhenCandidateIsValid()
        {
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenEmailIsNotValid()
        {
            _candidateInputModel.Email = "notValidEmail";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenFreeTextIsEmpty()
        {
            _candidateInputModel.FreeTextComment = "";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenFirstNameIsEmpty()
        {
            _candidateInputModel.FirstName = "";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenLastNameIsEmpty()
        {
            _candidateInputModel.LastName = "";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenEmailIsEmpty()
        {
            _candidateInputModel.Email = "";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenFirstNameIsBiggerThan50()
        {
            _candidateInputModel.FirstName = "Aequeosalinocalcalinoceraceoaluminosocupreovitriolic";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WhenLastNameIsBiggerThan50()
        {
            _candidateInputModel.LastName = "Aequeosalinocalcalinoceraceoaluminosocupreovitriolic";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task AddCandidate_ShouldReturnBadRequest_WheFreeTextIsBiggerThan500()
        {
            _candidateInputModel.FreeTextComment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id ligula non odio suscipit placerat. Nulla facilisi. Donec nec mi in felis eleifend luctus.  Curabitur aliquam felis ac neque consectetur, eu vehicula urna dictum. Maecenas tempus posuere justo, vel tincidunt libero vehicula et. Proin fermentum imperdiet urna sit amet lacinia. Duis at rutrum leo. Ut eget tellus quis metus lobortis feugiat. Suspendisse potenti. Integer quis augue id felis commodo ultricies. Mauris in mi ut risus eleifend pretium at at ipsum. Nullam eleifend turpis sed justo molestie, id hendrerit libero mollis.";
            var result = await _candidatesController.AddOrUpdate(_candidateInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}