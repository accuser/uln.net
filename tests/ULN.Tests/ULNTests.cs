using System;
using Xunit;

namespace ULN.Tests
{
    public class ULNTests
    {
        [Fact]
        public void ULN_FromString_ValidULN_CreatesULNObject()
        {
            var uln = ULN.FromString("0000000042");
            Assert.NotNull(uln);
            Assert.Equal("ULN(0000000042)", uln.ToString());
        }

        [Fact]
        public void ULN_FromString_InvalidULN_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ULN.FromString("0000000000"));
        }

        [Fact]
        public void ULN_Equals_SameULN_ReturnsTrue()
        {
            var uln1 = ULN.FromString("0000000042");
            var uln2 = ULN.FromString("0000000042");
            Assert.Equal(uln1, uln2);
        }

        [Fact]
        public void ULN_Equals_DifferentULN_ReturnsFalse()
        {
            var uln1 = ULN.FromString("0000000042");
            var uln2 = ULN.FromString("0000000050");
            Assert.NotEqual(uln1, uln2);
        }

        [Fact]
        public void ULN_CompareTo_SmallerULN_ReturnsPositive()
        {
            var uln1 = ULN.FromString("0000000050");
            var uln2 = ULN.FromString("0000000042");
            Assert.True(uln1.CompareTo(uln2) > 0);
        }
    }
}