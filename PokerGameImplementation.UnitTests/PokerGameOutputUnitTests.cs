using Moq;
using PokerGame.Interfaces.Enums;
using PokerGameImplementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class PokerGameOutputUnitTests
    {
        public static IEnumerable<object[]> GameResults
        {
            get
            {
                foreach(GameResult result in Enum.GetValues(typeof(GameResult)))
                {
                    yield return new object[] { result };
                }
            }
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PokerGameOutput(null));
        }

        [Theory]
        [MemberData(nameof(GameResults))]
        public void Output_SendsAnOutput_ToUserOutput(GameResult result)
        {
            var output = new Mock<IUserOutput>();

            var pokerGameOutput = new PokerGameOutput(output.Object);

            pokerGameOutput.Output(result);

            output.Verify(m => m.Output(It.IsAny<string>()));
        }
    }
}
