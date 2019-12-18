using Business.Interface;
using System;

namespace Business
{
    public class CashbackPopBusiness : ICashbackBusiness
    {
        public decimal ObterPercentualCashback(DayOfWeek diaDaSemana)
        {
            switch (diaDaSemana)
            {
                case DayOfWeek.Sunday:
                    return 25;
                case DayOfWeek.Monday:
                    return 7;
                case DayOfWeek.Tuesday:
                    return 6;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 10;
                case DayOfWeek.Friday:
                    return 15;
                case DayOfWeek.Saturday:
                    return 20;
                default:
                    throw new MissingMethodException();
            }
        }
    }
}
