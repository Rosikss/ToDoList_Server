using System.Globalization;

namespace ToDoList.BLL.Util.Extensions;

public static class DateTimeExtensions
{
    public static int GetCurrentWeek(this DateTime dateTime)
    {
        Calendar cal = new CultureInfo("en-US").Calendar;
        int week = cal.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        return week;
    }
}