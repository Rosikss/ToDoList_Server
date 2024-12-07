using FluentValidation;
using System.Globalization;
using ToDoList.BLL.Util.Extensions;

namespace ToDoList.BLL.Util.CustomValidators;

public static class DateTimeValidators
{
    public static IRuleBuilderOptions<T, DateTime> MustBeCurrentWeek<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder
            .Must(dateTime => dateTime.GetCurrentWeek() == DateTime.Now.GetCurrentWeek())
            .WithMessage("Date must be in the current week");
    }

    
}