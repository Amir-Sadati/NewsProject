using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.New.Commands.CreateNewsCommands
{
    public class CreateNewsCommandValidator :AbstractValidator<CreateNewsCommand>
    {
        public CreateNewsCommandValidator()
        {
            RuleFor(x => x.Ttile).NotEmpty();
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
