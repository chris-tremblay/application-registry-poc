using FluentAssertions;
using MyNexus.ApplicationRegistry.Application.Commands.PutApplication;
using MyNexus.ApplicationRegistry.Domain.Models;
using System;
using Xunit;

namespace MyNexus.ApplicationRegistry.Application.UnitTests.Commands.PutApplication.PutApplicationCommandValidatorTests
{
    /// <summary>
    ///   Tests for the <see cref="PutApplicationCommandValidator"/> class.
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
            var query = new PutApplicationCommand("TestTenant", null)
            {
                Application = new MicroApplication
                {
                    AppElementName = "app-element",
                    Fqan = "some.app",
                    ScriptUrls = new[] { "https://www.example.com" }
                }
            };

            // Act
            var result = new PutApplicationCommandValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        /// <summary>
        ///   A test to ensure that validation fails when the CorrelationId is empty.
        /// </summary>
        [Fact]
        public void FailWhenElementNameIsEmpty()
        {
            // Arrange
            var query = new PutApplicationCommand("TestTenant", new CorrelationId(Guid.NewGuid()))
            {
                Application = new MicroApplication
                {
                    AppElementName = "",
                    Fqan = "some.app",
                    ScriptUrls = new[] { "https://www.example.com" }
                }
            };

            // Act
            var result = new PutApplicationCommandValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        /// <summary>
        ///   A test to ensure that validation fails when the CorrelationId is empty.
        /// </summary>
        [Fact]
        public void FailWhenFqanIsEmpty()
        {
            // Arrange
            var query = new PutApplicationCommand("TestTenant", new CorrelationId(Guid.NewGuid()))
            {
                Application = new MicroApplication
                {
                    AppElementName = "app-element",
                    Fqan = "",
                    ScriptUrls = new[] { "https://www.example.com" }
                }
            };

            // Act
            var result = new PutApplicationCommandValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        /// <summary>
        ///   A test to ensure that validation fails when the CorrelationId is empty.
        /// </summary>
        [Fact]
        public void FailWhenScriptUrlsIsEmpty()
        {
            // Arrange
            var query = new PutApplicationCommand("TestTenant", new CorrelationId(Guid.NewGuid()))
            {
                Application = new MicroApplication
                {
                    AppElementName = "app-element",
                    Fqan = "some.app",
                }
            };

            // Act
            var result = new PutApplicationCommandValidator().Validate(query);

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
            var query = new PutApplicationCommand(tenantId, new CorrelationId(Guid.NewGuid()))
            {
                Application = new MicroApplication
                {
                    AppElementName = "app-element",
                    Fqan = "some.app",
                    ScriptUrls = new[] { "https://www.example.com" }
                }
            };

            // Act
            var result = new PutApplicationCommandValidator().Validate(query);

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
            var query = new PutApplicationCommand("TestTenant", new CorrelationId(Guid.NewGuid()))
            {
                Application = new MicroApplication
                {
                    AppElementName = "app-element",
                    Fqan = "some.app",
                    ScriptUrls = new[] { "https://www.example.com" }
                }
            };

            // Act
            var result = new PutApplicationCommandValidator().Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}