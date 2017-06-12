using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lambda3.IRRF.Domain.Entities;

namespace Lambda3.IRRF.Domain.Tests
{
    [TestClass]
    public class IRRFTests
    {

        [TestMethod]
        [TestCategory("IRRFTests")]
        public void GivenASalary1000ItShouldReturnTheCorrectIRRF()
        {
            Entities.IRRF IRRF = new Entities.IRRF();
            var Table = IRRF.GetMonthlyTableIRRF(1000);

            Assert.AreEqual(Table.Aliquot, 0);
        }

        [TestMethod]
        [TestCategory("IRRFTests")]
        public void GivenASalary2000ItShouldReturnTheCorrectIRRF()
        {
            Entities.IRRF IRRF = new Entities.IRRF();
            var Table = IRRF.GetMonthlyTableIRRF(2000);

            Assert.AreEqual(Table.Aliquot, 0.075);
        }

        [TestMethod]
        [TestCategory("IRRFTests")]
        public void GivenASalary3000ItShouldReturnTheCorrectIRRF()
        {
            Entities.IRRF IRRF = new Entities.IRRF();
            var Table = IRRF.GetMonthlyTableIRRF(3000);

            Assert.AreEqual(Table.Aliquot, 0.15);
        }

        [TestMethod]
        [TestCategory("IRRFTests")]
        public void GivenASalary4000ItShouldReturnTheCorrectIRRF()
        {
            Entities.IRRF IRRF = new Entities.IRRF();
            var Table = IRRF.GetMonthlyTableIRRF(4000);

            Assert.AreEqual(Table.Aliquot, 0.225);
        }

        [TestMethod]
        [TestCategory("IRRFTests")]
        public void GivenASalary5000ItShouldReturnTheCorrectIRRF()
        {
            Entities.IRRF IRRF = new Entities.IRRF();
            var Table = IRRF.GetMonthlyTableIRRF(5000);

            Assert.AreEqual(Table.Aliquot, 0.275);
        }

        [TestMethod]
        [TestCategory("IRRFTests")]
        public void GivenASalaryAndAnIRRFItShouldReturnTheCorrectTax()
        {
            Entities.IRRF IRRF = new Entities.IRRF();
            var Table = IRRF.GetMonthlyTableIRRF(5000);
            var Tax = IRRF.Calculate(Table, 5000);
            Assert.AreEqual(Tax, 505.64);
        }
    }
}
