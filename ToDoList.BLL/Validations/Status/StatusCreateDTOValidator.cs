using FluentValidation;
using ToDoList.BLL.DTO.Status;

namespace ToDoList.BLL.Validations.Status;

public class StatusCreateDTOValidator : AbstractValidator<StatusCreateDTO>
{
    public StatusCreateDTOValidator()
    {
        RuleFor(s => s.Name).NotEmpty().MaximumLength(50);
    }
}