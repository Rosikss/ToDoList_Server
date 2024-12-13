using FluentValidation;
using ToDoList.BLL.DTO.Status;

namespace ToDoList.BLL.Validations.Status;

public class StatusUpdateDTOValidator : AbstractValidator<StatusUpdateDTO>
{
    public StatusUpdateDTOValidator()
    {
        RuleFor(s => s.Id).NotEmpty();
        RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
        RuleFor(s => s.Color).NotEmpty().Matches("^#[0-9A-Fa-f]{0,6}$").MaximumLength(7);
    }
}