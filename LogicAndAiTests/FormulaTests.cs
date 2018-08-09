using FluentAssertions;
using LogicAndAi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicAndAiTests
{
    [TestClass]
    public class FormulaTests
    {
        [TestMethod, TestCategory("Unit")]
        public void GivenNotPOrQAndBothAreFalse_WhenAskingToEvaluate_ThenItShouldReturnTrue()
        {
            // arrange
            Variable p = new Variable(false);
            Variable q = new Variable(false);

            Or formula = new Or(new Not(p), q);

            // act
            bool actual = formula.Evaluate();

            // assert
            actual.Should().Be(true);
        }

        [TestMethod, TestCategory("Unit")]
        public void GivenNotPOrQWherePIsTrueAndQIsFalse_WhenAskingToEvaluate_ThenItShouldReturnFalse()
        {
            // arrange
            Variable p = new Variable(true);
            Variable q = new Variable(false);

            Or formula = new Or(new Not(p), q);

            // act
            bool actual = formula.Evaluate();

            // assert
            actual.Should().Be(false);
        }
    }
}
