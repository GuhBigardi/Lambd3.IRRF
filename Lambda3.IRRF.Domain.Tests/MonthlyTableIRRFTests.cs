using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lambda3.IRRF.Domain.Entities;

namespace Lambda3.IRRF.Domain.Tests
{
    [TestClass]
    public class MonthlyTableIRRFTests
    {
        [TestMethod]
        [TestCategory("MonthlyTableIRRFTests")]
        public void GivenACalculateBasisInicialGreaterThanCalculateBasisEndItShouldReturnAnError()
        {
            var table = new MonthlyTableIRRF(2000, 1000, 0, 0);
            Assert.IsFalse(table.IsValid());
        }

        [TestMethod]
        [TestCategory("MonthlyTableIRRFTests")]
        public void GivenACalculateBasisInicialLowerThanCalculateBasisEndItShouldBeValid()
        {
            var table = new MonthlyTableIRRF(1000, 2000, 0, 0);
            Assert.IsTrue(table.IsValid());
        }

        [TestMethod]
        [TestCategory("MonthlyTableIRRFTests")]
        public void GivenAnAliquotLowerThanZeroItShouldReturnAnError()
        {
            var table = new MonthlyTableIRRF(1000, 2000, -1, 0);
            Assert.IsFalse(table.IsValid());
        }
        [TestMethod]
        [TestCategory("MonthlyTableIRRFTests")]
        public void GivenAnAliquotGreaterThanZeroItShouldBeValid()
        {
            var table = new MonthlyTableIRRF(1000, 2000, 1, 0);
            Assert.IsTrue(table.IsValid());
        }

        [TestMethod]
        [TestCategory("MonthlyTableIRRFTests")]
        public void GivenAPortionToReduceLowerThanZeroItShouldReturnAnError()
        {
            var table = new MonthlyTableIRRF(1000, 2000, 1, -1);
            Assert.IsFalse(table.IsValid());
        }
        [TestMethod]
        [TestCategory("MonthlyTableIRRFTests")]
        public void GivenAportionToReduceGreaterThanZeroItShouldBeValid()
        {
            var table = new MonthlyTableIRRF(1000, 2000, 1, 10);
            Assert.IsTrue(table.IsValid());
        }

    }
}
