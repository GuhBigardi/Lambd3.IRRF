
using FluentValidator;
using System;

namespace Lambda3.IRRF.Domain.Entities
{
    public class MonthlyTableIRRF  : Notifiable
    {
        public MonthlyTableIRRF(double calculationBasisInitial, double calculationBasisEnd, double aliquot, double portionToReduce)
        {
            Id = Guid.NewGuid();
            CalculationBasisInitial = calculationBasisInitial;
            CalculationBasisEnd = calculationBasisEnd;
            Aliquot = aliquot;
            PortionToDeducted = portionToReduce;

            new ValidationContract<MonthlyTableIRRF>(this)
                .IsGreaterThan(x => x.CalculationBasisEnd, this.CalculationBasisInitial, "A base de calculo final deve ser menor que a inicial")
                .IsGreaterThan(x => x.Aliquot, 0)
                .IsLowerThan(x => x.Aliquot, 100)
                .IsGreaterThan(x => x.PortionToDeducted, 0);
        }

        public Guid Id { get; private set; }
        public double CalculationBasisInitial { get; private set; }
        public double CalculationBasisEnd { get; private set; }
        public double Aliquot { get; private set; }
        public double PortionToDeducted { get; private set; }
    }
}
