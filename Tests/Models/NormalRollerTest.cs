using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Olirator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olirator.Tests.Models
{
    [TestClass]
    class NormalRollerTest
    {
        private Mock<Random> RandomMock = new Mock<Random>();
        private Mock<List<Die>> DiceMocks { get; } = new Mock<List<Die>>();

        [TestMethod]
        public void NormalRoller_Roll3DiceWithoutModifier_ResultShouldBe13()
        {
            List<Die> dice = new List<Die>()
            {

            };
        }
    }
}
