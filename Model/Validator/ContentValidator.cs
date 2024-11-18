using FluentValidation;
using System.Net;

namespace BackpackerOfLife.Blog.API.Model.Validator
{
    public class ContentValidator : AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(content => content.Id)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
                
            RuleFor(content => content.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Title cannot be empty");

            RuleFor(content => content.Description)
                .NotNull()
                .MaximumLength(1500)
                .WithMessage("Character maximum exceeded");

            RuleFor(content => content.IsActive)
                .NotNull()
                .WithMessage("Field cannot be null");
        }
    }
}
