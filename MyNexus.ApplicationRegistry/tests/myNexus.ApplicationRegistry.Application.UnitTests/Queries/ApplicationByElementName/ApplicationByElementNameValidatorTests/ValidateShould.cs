using FluentAssertions;
using MyNexus.ApplicationRegistry.Application.Queries.ApplicationByElementName;
using System;
using Xunit;

namespace MyNexus.ApplicationRegistry.Application.UnitTests.Queries.ApplicationByElementName.ApplicationByElementNameValidatorTests
{
    /// <summary>
    ///   Tests for the <see cref="ApplicationByElementNameQueryValidator"/> class.
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
            var query = new ApplicationByElementNameQuery("TestTenant", null)
            {
                ElementName = "app-element"
            };

            // Act
            var result = new ApplicationByElementNameQueryValidator().Validate(query);

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
            var query = new ApplicationByElementNameQuery("TestTenant", new CorrelationId(Guid.NewGuid()));

            // Act
            var result = new ApplicationByElementNameQueryValidator().Validate(query);

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
            var query = new ApplicationByElementNameQuery(tenantId, new CorrelationId(Guid.NewGuid()));

            // Act
            var result = new ApplicationByElementNameQueryValidator().Validate(query);

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
            var query = new ApplicationByElementNameQuery("TestTenant", new CorrelationId(Guid.NewGuid()))
            {
                ElementName = "app-element"
            };

            // Act
            var result = new ApplicationByElementNameQueryValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}