using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda3.IRRF.Domain.Entities
{
    public class Salary : Notifiable
    {
        public Salary(double grossSalary)
        {
            GrossSalary = grossSalary;
            IRRF IRRF = new IRRF();
            new ValidationContract<Salary>(this)
                .IsGreaterThan(x => x.GrossSalary, 1, "O Salário Bruto informado deve ser maior que 0");
            if (IRRF.IsValid())
            {
                MonthlyTableIRRF = IRRF.GetMonthlyTableIRRF(GrossSalary);
                Tax = IRRF.Calculate(MonthlyTableIRRF, GrossSalary);
            }
            this.AddNotifications(IRRF.Notifications);
        }

        public double GrossSalary { get; private set; }
        public double NetSalary
        {
            get { return GrossSalary - Tax; }
        }
        public double Tax { get; private set; }
        public MonthlyTableIRRF MonthlyTableIRRF { get; private set; }


    }
}
