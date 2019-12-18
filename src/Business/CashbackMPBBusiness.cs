using Business.Interface;
using System;

namespace Business
{
    public class CashbackMPBBusiness : ICashbackBusiness
    {
        public decimal ObterPercentualCashback(DayOfWeek diaDaSemana)
        {
            switch (diaDaSemana)
            {
                case DayOfWeek.Sunday:
                    return 30;
                case DayOfWeek.Monday:
                    return 5;
                case DayOfWeek.Tuesday:
                    return 10;
                case DayOfWeek.Wednesday:
                    return 15;
                case DayOfWeek.Thursday:
                    return 20;
                case DayOfWeek.Friday:
                    return 25;
                case DayOfWeek.Saturday:
                    return 30;
                default:
                    throw new MissingMethodException();
            }
        }
    }
}
