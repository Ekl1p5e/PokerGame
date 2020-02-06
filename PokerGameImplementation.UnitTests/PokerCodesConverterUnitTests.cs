using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class PokerCodesConverterUnitTests
    {
        private static readonly char[] suits = { 'H', 'D', 'S', 'C', };
        private static readonly char[] values = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A', };

        public static IEnumerable<object[]> ValidCodes
        {
            get
            {
                foreach(var suit in suits)
                {
                    foreach (var value in values)
                    {
                        yield return new object[] { $"{value}{suit}" };
                    }
                }
            }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t")]
        [InlineData("\n")]
        public void GetCard_ThrowsArgumentException_CodeNullOrWhitespace(string code)
        {
            var converter = new PokerCodesConverter();

            Assert.Throws<ArgumentException>(() => converter.GetCard(code));
        }

        [Theory]
        [InlineData("H")]
        [InlineData("X")]
        [InlineData(" H")]
        [InlineData("X ")]
        [InlineData(" X")]
        [InlineData("H ")]
        [InlineData("2X")]
        [InlineData("YH ")]
        [InlineData("YZ")]
        [InlineData("HHH")]
        [InlineData("XXX")]
        public void GetCard_ThrowsArgumentException_CodeInvalid(string code)
        {
            var converter = new PokerCodesConverter();

            Assert.Throws<ArgumentException>(() => converter.GetCard(code));
        }

        [Theory]
        [MemberData(nameof(ValidCodes))]
        public void GetCard_ReturnsCard_CodeValid(string code)
        {
            var converter = new PokerCodesConverter();

            Assert.IsType<Card>(converter.GetCard(code));
        }

        [Theory]
        [MemberData(nameof(ValidCodes))]
        public void GetCard_ReturnsSameCard_ForEachCode(string code)
        {
            var converter = new PokerCodesConverter();

            var first = converter.GetCard(code);
            Assert.IsType<Card>(first);

            var second = converter.GetCard(code);
            Assert.IsType<Card>(first);

            Assert.Same(first, second);
        }
    }
}
