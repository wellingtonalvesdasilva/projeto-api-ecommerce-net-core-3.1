using Business.Interface;
using System;

namespace Business
{
    public class CashbackClassicoBusiness : ICashbackBusiness
    {
        public decimal ObterPercentualCashback(DayOfWeek diaDaSemana)
        {
            switch (diaDaSemana)
            {
                case DayOfWeek.Sunday:
                    return 35;
                case DayOfWeek.Monday:
                    return 3;
                case DayOfWeek.Tuesday:
                    return 5;
                case DayOfWeek.Wednesday:
                    return 8;
                case DayOfWeek.Thursday:
                    return 13;
                case DayOfWeek.Friday:
                    return 18;
                case DayOfWeek.Saturday:
                    return 25;
                default:
                    throw new MissingMethodException();
            }
        }
    }
}
