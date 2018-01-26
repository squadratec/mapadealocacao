using System;

namespace SQH.Shared.Extensions
{
    public static class DateExtensions
    {
        /// <summary>
        /// Busca a última data do mês corrente a partir de um Datetime
        /// </summary>
        /// <param name="date">Data Atual</param>
        /// <returns>Última data do mês corrent</returns>
        public static DateTime GetLastDateFromCurrentMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        /// <summary>
        /// Busca a última data do mês corrente a partir de um inteiro
        /// </summary>
        /// <param name="date">Data Atual</param>
        /// <returns>Última data do mês corrent</returns>
        public static DateTime GetLastDateFromCurrentMonth(int month, int? year = null)
        {
            var date = DateTime.Now;
            return new DateTime(year ?? date.Year, month, DateTime.DaysInMonth(year ?? date.Year, month));
        }
    }
}
