using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.New.Commands.EditNewsCommands
{
    public class EditNewsCommandValidator :AbstractValidator<EditNewsCommand>
    {
        public EditNewsCommandValidator()
        {
            RuleFor(x => x.Ttile).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            
        }
    }
}
