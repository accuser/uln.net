using System;
using Xunit;

namespace ULN.Tests
{
    public class ULNValidatorTests
    {
        [Theory]
        [InlineData("0000000042")]
        public void IsValidULN_ValidULN_ReturnsTrue(string value)
        {
            Assert.True(ULNValidator.IsValidULN(value));
        }

        [Theory]
        [InlineData("0000000000")]
        [InlineData("1111111111")]
        [InlineData("invalid")]
        public void IsValidULN_InvalidULN_ReturnsFalse(string value)
        {
            Assert.False(ULNValidator.IsValidULN(value));
        }

        [Fact]
        public void RequireValidULN_ValidULN_ReturnsULN()
        {
            var result = ULNValidator.RequireValidULN("0000000042");
            Assert.Equal("0000000042", result);
        }

        [Fact]
        public void RequireValidULN_InvalidULN_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ULNValidator.RequireValidULN("0000000000"));
        }
    }
}