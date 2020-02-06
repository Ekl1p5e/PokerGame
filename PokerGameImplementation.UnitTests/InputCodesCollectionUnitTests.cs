using Moq;
using PokerGame.Interfaces;
using PokerGameImplementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace PokerGameImplementation.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class InputCodesCollectionUnitTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_NullConverterArgument()
        {
            var userInput = new Mock<IUserInput>();

            Assert.Throws<ArgumentNullException>(() => new InputCodesCollection(null, userInput.Object, default));
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_NullUserInputArgument()
        {
            var converter = new Mock<ICodeConverter>();

            Assert.Throws<ArgumentNullException>(() => new InputCodesCollection(converter.Object, null, default));
        }

        [Fact]
        public void Constructor_ThrowsFormatException_IndistinctCodes()
        {
            var inputString = "OH OH";
            var constructorCount = inputString.Split().Length;

            var userInput = new Mock<IUserInput>();
            userInput.Setup(m => m.GetInput()).Returns(inputString);

            var converter = new Mock<ICodeConverter>();

            Assert.Throws<FormatException>(() => new InputCodesCollection(converter.Object, userInput.Object, constructorCount));
        }

        [Fact]
        public void GetEnumerator_ReturnsEnumerator_ProperConstructionInput()
        {
            var inputString = "OH HO";
            var constructorCount = inputString.Split().Length;

            var userInput = new Mock<IUserInput>();
            userInput.Setup(m => m.GetInput()).Returns(inputString);

            var converter = new Mock<ICodeConverter>();

            var collection = new InputCodesCollection(converter.Object, userInput.Object, constructorCount);

            Assert.IsAssignableFrom<IEnumerator<ICard>>(collection.GetEnumerator());
        }
    }
}
