using FluentAssertions;
using MyNexus.ApplicationRegistry.Application.Queries.ApplicationByFqan;
using MyNexus.ApplicationRegistry.Data.Exceptions;
using MyNexus.ApplicationRegistry.Domain.Models;
using MyNexus.ApplicationRegistry.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MyNexus.ApplicationRegistry.Application.UnitTests.Queries.ApplicationByFqan.ApplicationByFqanHandlerTests
{
    /// <summary>
    ///   Tests for the <see cref="ApplicationByFqanQueryHandler.Handle(ApplicationByFqanQuery, CancellationToken)"/> method.
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
            var query = new ApplicationByFqanQuery("Tenant 1", new CorrelationId(Guid.NewGuid()))
            {
                Fqan = "some.app.name"
            };

            var repository = new Moq.Mock<IMicroApplicationRepository>();

            repository.Setup(m => m.GetMicroApplicationByFqan("Tenant 1", query.Fqan)).Returns(Task.FromResult(new MicroApplication()
            {
                Fqan = query.Fqan
            } as IMicroApplication));

            var handler = new ApplicationByFqanQueryHandler(repository.Object);

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
            var query = new ApplicationByFqanQuery("Tenant 1", new CorrelationId(Guid.NewGuid()))
            {
                Fqan = "some.unfound.app"
            };
            var repository = new Moq.Mock<IMicroApplicationRepository>();

            repository.Setup(m => m.GetMicroApplicationByFqan("Tenant 1", query.Fqan)).Returns(Task.FromResult(null as IMicroApplication));

            var handler = new ApplicationByFqanQueryHandler(repository.Object);

            // Act

            // Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await handler.Handle(query, new CancellationToken()));
        }
    }
}