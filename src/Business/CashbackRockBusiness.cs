using Business.Interface;
using System;

namespace Business
{
    public class CashbackRockBusiness : ICashbackBusiness
    {
        public decimal ObterPercentualCashback(DayOfWeek diaDaSemana)
        {
            switch (diaDaSemana)
            {
                case DayOfWeek.Sunday:
                    return 40;
                case DayOfWeek.Monday:
                    return 10;
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                    return 15;
                case DayOfWeek.Friday:
                    return 20;
                case DayOfWeek.Saturday:
                    return 40;
                default:
                    throw new MissingMethodException();
            }
        }
    }
}
