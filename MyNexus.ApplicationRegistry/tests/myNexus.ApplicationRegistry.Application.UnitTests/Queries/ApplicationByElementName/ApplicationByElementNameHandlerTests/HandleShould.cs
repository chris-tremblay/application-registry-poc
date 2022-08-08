using FluentAssertions;
using MyNexus.ApplicationRegistry.Application.Queries.ApplicationByElementName;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MyNexus.ApplicationRegistry.Application.UnitTests.Queries.ApplicationByElementName.ApplicationByElementNameHandlerTests
{
    /// <summary>
    ///   Tests for the <see cref="ApplicationByElementNameQueryHandler.Handle(ApplicationByElementNameQuery,
    ///   CancellationToken)"/> method.
    /// </summary>
    public class HandleShould
    {
        /// <summary>
        ///   A test to ensure that a <see cref="MicroApplication"/> is returned.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ReturnMicroApplication()
        {
            // Arrange
            var query = new ApplicationByElementNameQuery("Mnc", new CorrelationId(Guid.NewGuid()))
            {
                ElementName = "app-element"
            };

            var repository = new Moq.Mock<IMicroApplicationRepository>();

            repository.Setup(m => m.GetMicroApplicationByElementName("Mnc", query.ElementName)).Returns(Task.FromResult(new MicroApplication()
            {
                AppElementName = query.ElementName
            } as IMicroApplication));

            var handler = new ApplicationByElementNameQueryHandler(repository.Object);

            // Act
            var result = await handler.Handle(query, new CancellationToken());

            // Assert
            result.Should().NotBeNull();
        }

        /// <summary>
        ///   A test to ensure that a <see cref="ResourceNotFoundException"/> is thrown when an element is not found.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ThrowResourceNotFoundException()
        {
            // Arrange
            var query = new ApplicationByElementNameQuery("Mnc", new CorrelationId(Guid.NewGuid()))
            {
                ElementName = "app-not-found-element"
            };
            var repository = new Moq.Mock<IMicroApplicationRepository>();

            repository.Setup(m => m.GetMicroApplicationByElementName("Mnc", query.ElementName)).Returns(Task.FromResult(null as IMicroApplication));

            var handler = new ApplicationByElementNameQueryHandler(repository.Object);

            // Act

            // Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await handler.Handle(query, new CancellationToken()));
        }
    }
}