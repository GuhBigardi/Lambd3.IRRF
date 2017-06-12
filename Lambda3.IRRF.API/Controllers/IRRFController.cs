using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lambda3.IRRF.Domain.Entities;

namespace Lambda3.IRRF.API.Controllers
{
    public class IRRFController : BaseController
    {
        [HttpGet]
        [Route("v1/IRRF/{SalaryValue}")]
        public async Task<IActionResult> Get(double SalaryValue)
        {
            Salary Salary = new Salary(SalaryValue);

            return await Response(Salary, Salary.Notifications);
        }
    }
}
