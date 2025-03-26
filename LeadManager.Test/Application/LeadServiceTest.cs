using LeadManager.Application.ApplicationService;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces;
using Moq;

namespace LeadManager.Tests.Application
{
    public class LeadServiceTests
    {
        private readonly Mock<ILeadRepository> _leadRepositoryMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly LeadService _leadService;

        public LeadServiceTests()
        {
            _leadRepositoryMock = new Mock<ILeadRepository>();
            _emailServiceMock = new Mock<IEmailService>();
            _leadService = new LeadService(_leadRepositoryMock.Object, _emailServiceMock.Object);
        }

        [Fact]
        public async Task AcceptLeadAsync_ShouldApplyDiscount_WhenPriceIsGreaterThan500()
        {
            // Arrange
            var lead = new Lead { Id = 1, Price = 600m };

            _leadRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Lead>()))
                .Returns(Task.CompletedTask);

            _emailServiceMock.Setup(email => email.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _leadService.AcceptLeadAsync(lead);

            // Assert
            Assert.Equal(540m, result.Price);
            _leadRepositoryMock.Verify(repo => repo.UpdateAsync(lead), Times.Once);
            _emailServiceMock.Verify(email => email.SendEmailAsync(It.IsAny<string>(), "Lead Accepted", "Hello"), Times.Once);
        }

        [Fact]
        public async Task AcceptLeadAsync_ShouldNotApplyDiscount_WhenPriceIsLessThanOrEqualTo500()
        {
            // Arrange
            var lead = new Lead { Id = 2, Price = 500m };

            _leadRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Lead>()))
                .Returns(Task.CompletedTask);

            _emailServiceMock.Setup(email => email.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _leadService.AcceptLeadAsync(lead);

            // Assert
            Assert.Equal(500m, result.Price);
            _leadRepositoryMock.Verify(repo => repo.UpdateAsync(lead), Times.Once);
            _emailServiceMock.Verify(email => email.SendEmailAsync(It.IsAny<string>(), "Lead Accepted", "Hello"), Times.Once);
        }

        [Fact]
        public async Task RejectLeadAsync_ShouldUpdateLead()
        {
            // Arrange
            var lead = new Lead { Id = 3, Price = 400m };

            _leadRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Lead>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _leadService.RejectLeadAsync(lead);

            // Assert
            _leadRepositoryMock.Verify(repo => repo.UpdateAsync(lead), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(lead.Id, result.Id);
        }
    }
}