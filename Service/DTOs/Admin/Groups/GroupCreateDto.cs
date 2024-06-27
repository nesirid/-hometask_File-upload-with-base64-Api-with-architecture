using FluentValidation;


namespace Service.DTOs.Admin.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }


    }
    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
        }
    }
}
