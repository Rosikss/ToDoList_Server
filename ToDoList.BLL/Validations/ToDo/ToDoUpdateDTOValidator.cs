using FluentValidation;
using ToDoList.BLL.DTO.ToDo;
using ToDoList.BLL.Util.CustomValidators;

namespace ToDoList.BLL.Validations.ToDo;

public class ToDoUpdateDTOValidator : AbstractValidator<ToDoUpdateDTO>
{
    public ToDoUpdateDTOValidator()
    {
        RuleFor(td => td.Id).NotEmpty();
        RuleFor(td => td.Title).NotEmpty().MaximumLength(50);
        RuleFor(td => td.CreatedAt).MustBeCurrentWeek();
        RuleFor(td => td.DueDate).MustBeCurrentWeek();
        RuleFor(td => td.DueDate).GreaterThan(td => td.CreatedAt);
        RuleFor(td => td.Description).NotEmpty().MaximumLength(500);
        RuleFor(td => td.StatusId).NotEmpty();
    }
}