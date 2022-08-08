using FluentAssertions;
using MyNexus.ApplicationRegistry.Application.Queries.ApplicationByFqan;
using System;
using Xunit;

namespace MyNexus.ApplicationRegistry.Application.UnitTests.Queries.ApplicationByElementName.ApplicationByFqanValidatorTests
{
    /// <summary>
    ///   Tests for the <see cref="ApplicationByFqanQueryValidator"/> class.
    /// </summary>
    public class ValidateShould
    {
        /// <summary>
        ///   A test to ensure that validation fails when the CorrelationId is empty.
        /// </summary>
        [Fact]
        public void FailWhenCorrelationIdIsEmpty()
        {
            // Arrange
            var query = new ApplicationByFqanQuery("TestTenant", null)
            {
                Fqan = "some.app.name"
            };

            // Act
            var result = new ApplicationByFqanQueryValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        /// <summary>
        ///   A test to ensure that validation fails when the element name is empty.
        /// </summary>
        [Fact]
        public void FailWhenElementNameIsEmpty()
        {
            // Arrange
            var query = new ApplicationByFqanQuery("TestTenant", new CorrelationId(Guid.NewGuid()));

            // Act
            var result = new ApplicationByFqanQueryValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        /// <summary>
        ///   A test to ensure that validation fails when the tenant id is empty.
        /// </summary>
        /// <param name="tenantId">The tenantId to test.</param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void FailWhenTenantIdIsEmpty(string tenantId)
        {
            // Arrange
            var query = new ApplicationByFqanQuery(tenantId, new CorrelationId(Guid.NewGuid()));

            // Act
            var result = new ApplicationByFqanQueryValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        /// <summary>
        ///   A test to ensure that validation succeeds when all parameters are valid.
        /// </summary>
        [Fact]
        public void Succeed()
        {
            // Arrange
            var query = new ApplicationByFqanQuery("TestTenant", new CorrelationId(Guid.NewGuid()))
            {
                Fqan = "some.app.name"
            };

            // Act
            var result = new ApplicationByFqanQueryValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}