using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lambda3.IRRF.Domain.Entities;

namespace Lambda3.IRRF.Domain.Tests
{
    [TestClass]
    public class SalaryTests
    {
        [TestMethod]
        [TestCategory("SalaryTests")]
        public void GivenAGrossSalaryLowerZeroItShouldAnError()
        {
            Salary salary = new Salary(0);
            Assert.IsFalse(salary.IsValid());
        }

        [TestMethod]
        [TestCategory("SalaryTests")]
        public void GivenAGrossSalaryGreaterThanZeroItShouldBeValid()
        {
            Salary salary = new Salary(1000);
            Assert.IsTrue(salary.IsValid());
        }
    }
}
