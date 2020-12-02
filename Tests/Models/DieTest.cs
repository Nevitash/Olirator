using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Olirator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using static Olirator.Constants.ExceptionConstants;

namespace Olirator.Tests.Models
{
    [TestClass]
    public class DieTest
    {
        public Mock<Random> RandomMock { get; } = new Mock<Random>();

        [TestMethod]
        public void CtorDie_NonZeroSideDie_DoesNotThrowException()
        {
            new Die(20, RandomMock.Object);
        }

        [TestMethod]
        public void CtorDie_ZeroSideDie_ThrowsArgumentException()
        {
            Action action = () => new Die(0, RandomMock.Object);

            action.Should().Throw<ArgumentException>().WithMessage(ERROR_MESSAGE_INVALID_SIDES_FOR_DIE);
        }

        [TestMethod]
        public void Die_Roll_RandomValueShouldBe4()
        {
            RandomMock.Setup(x => x.Next(1, 20)).Returns(4);
            var sut = new Die(20, RandomMock.Object);

            sut.Roll().Should().Be(4);
        }

        [TestMethod]
        public void Die_MultiRoll_ThrowsInvalidOperationException()
        {
            var sut = new Die(20, RandomMock.Object);

            sut.Roll();

            Action action = () => sut.Roll();
            action.Should().Throw<InvalidOperationException>().WithMessage(ERROR_MESSAGE_DIE_WAS_ALREADY_ROLLED);
        }

        [TestMethod]
        public void Die_RerollWithoutRoll_ThrowsInvalidOperationException()
        {
            var sut = new Die(20, RandomMock.Object);

            Action action = () => sut.Reroll();

            action.Should().Throw<InvalidOperationException>().WithMessage(ERROR_MESSAGE_REROLL_BEFORE_ROLL);
        }

        [TestMethod]
        public void Die_RerollDie_ShouldBe6()
        {
            var returnValueForRandom = 4;
            RandomMock.Setup(x => x.Next(1, 20)).Returns(() =>
            {
                return returnValueForRandom;
            }
            );

            var sut = new Die(20, RandomMock.Object);
            sut.Roll();
            returnValueForRandom = 6;

            sut.Reroll().Should().Be(6);
        }

        [TestMethod]
        public void Die_CheckIfRolledBeforeRoll_ReturnsFalse()
        {
            var sut = new Die(20, RandomMock.Object);

            sut.Rolled.Should().BeFalse();
        }

        [TestMethod]
        public void Die_CheckIfRolledAfterRoll_ReturnsTrue()
        {
            var sut = new Die(20, RandomMock.Object);
            sut.Roll();

            sut.Rolled.Should().BeTrue();
        }

        [TestMethod]
        public void Die_CheckIfRolledAfterReroll_ReturnsTrue()
        {
            var sut = new Die(20, RandomMock.Object);
            sut.Roll();
            sut.Reroll();

            sut.Rolled.Should().BeTrue();
        }
    }
}
