using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Moudles;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validations
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentServices _studentService;
        private readonly IDepartmentServices _departmentService;
        #endregion

        #region Constructors
        public AddStudentCommandValidator(IStudentServices studentService, IDepartmentServices departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            ApplyValidationsRules();
        }
        #endregion

        #region Actions
        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name it can not be empty")
                 .NotNull().WithMessage("Name it can not be null")
                 .MaximumLength(100).WithMessage(" FluentValidation.DependencyInjectionExtensions");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address it can not be empty")
                .NotNull().WithMessage("Address it can not be null")
                .MaximumLength(100).WithMessage(" FluentValidation.DependencyInjectionExtensions");

            RuleFor(x => x.DepartmentId)
                 .NotEmpty().WithMessage(" FluentValidation.DependencyInjectionExtensions")
                 .NotNull().WithMessage(" FluentValidation.DependencyInjectionExtensions");
        }

       

        #endregion
    }
}
