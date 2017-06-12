using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda3.IRRF.Domain.Entities
{
    public class IRRF : Notifiable
    {
        public IRRF()
        {
            Id = Guid.NewGuid();
            MonthlyTableIRRF = new List<MonthlyTableIRRF>
            {
                new MonthlyTableIRRF(0,1903.38,0,0),
                new MonthlyTableIRRF(1903.38,2806.65,0.075,142.80),
                new MonthlyTableIRRF(2806.65,3751.05,0.15,354.80),
                new MonthlyTableIRRF(3751.05,4664.68,0.225,636.13),
                new MonthlyTableIRRF(4664.68,double.MaxValue,0.275,869.36)

            };

            new ValidationContract<IRRF>(this)
                .IsGreaterThan(x => x.MonthlyTableIRRF.Count, 0, "A tabela mensal de IRRF não foi configurada");

            foreach (var item in MonthlyTableIRRF.Where(p => p.Notifications.Any()))
            {
                this.AddNotifications(item.Notifications);
            }
        }
        public Guid Id { get; private set; }
        public IList<MonthlyTableIRRF> MonthlyTableIRRF { get; private set; }

        public MonthlyTableIRRF GetMonthlyTableIRRF(double salary)
        {
            return MonthlyTableIRRF.Where(p => p.CalculationBasisInitial <= salary && p.CalculationBasisEnd >= salary).FirstOrDefault();
        }
        public double Calculate(MonthlyTableIRRF Table, double salary)
        {
            return salary * Table.Aliquot - Table.PortionToDeducted;
        }

    }
}
