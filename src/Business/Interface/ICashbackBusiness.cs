using System;

namespace Business.Interface
{
    public interface ICashbackBusiness
    {
        decimal ObterPercentualCashback(DayOfWeek diaDaSemana);
    }
}
